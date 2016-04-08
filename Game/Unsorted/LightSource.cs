// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class LightSource : Game_Data {

		public Ent_Static owner = null;
		public int radius = 0;
		public dynamic luminosity = 0;
		public int? cap = 0;
		public bool changed = false;
		public ByTable effect = new ByTable();
		public int __x = 0;
		public int __y = 0;

		// Function from file: lighting_system.dm
		public LightSource ( Ent_Static A = null ) {
			
			if ( !( A is Ent_Static ) ) {
				Task13.Crash( "The first argument to the light object's constructor must be the atom that is the light source. Expected atom, received '" + A + "' instead." );
			}
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.owner = A;
			this.UpdateLuminosity( A.luminosity );
			return;
		}

		// Function from file: lighting_system.dm
		public bool add_effect(  ) {
			int range = 0;
			dynamic To = null;
			Ent_Dynamic AM = null;
			dynamic center_strength = null;
			dynamic T = null;
			double distance = 0;
			double delta_lumcount = 0;

			
			if ( !( this.owner != null ) || !( this.owner.loc != null ) ) {
				return false;
			}
			range = this.owner.get_light_range( this.radius );

			if ( range <= 0 || Convert.ToDouble( this.luminosity ) <= 0 ) {
				this.owner.luminosity = 0;
				return false;
			}
			this.effect = new ByTable();
			To = GlobalFuncs.get_turf( this.owner );

			foreach (dynamic _a in Lang13.Enumerate( To, typeof(Ent_Dynamic) )) {
				AM = _a;
				

				if ( AM == this.owner ) {
					continue;
				}

				if ( AM.opacity ) {
					range = 0;
					break;
				}
			}
			this.owner.luminosity = range;

			if ( !( range != 0 ) ) {
				return false;
			}
			center_strength = 0;

			if ( ( this.cap ??0) <= 0 ) {
				center_strength = this.luminosity * 1.6666666269302368;
			} else {
				center_strength = this.cap;
			}

			foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInView( To, range + 1 ), typeof(Tile) )) {
				T = _b;
				
				distance = GlobalFuncs.cheap_hypotenuse( Convert.ToInt32( T.x ), Convert.ToInt32( T.y ), this.__x, this.__y );
				delta_lumcount = Num13.MaxInt( 0, Num13.MinInt( Convert.ToInt32( center_strength * ( range - distance ) / range ), 10 ) );

				if ( delta_lumcount > 0 ) {
					this.effect[T] = delta_lumcount;
					((Tile)T).update_lumcount( delta_lumcount );

					if ( !( T.affecting_lights != null ) ) {
						T.affecting_lights = new ByTable();
					}
					T.affecting_lights.Or( this );
				}
			}
			return true;
		}

		// Function from file: lighting_system.dm
		public void remove_effect(  ) {
			dynamic T = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.effect )) {
				T = _a;
				
				((Tile)T).update_lumcount( Convert.ToDouble( -this.effect[T] ) );

				if ( T.affecting_lights != null && T.affecting_lights.len != 0 ) {
					T.affecting_lights.Remove( this );
				}
			}
			this.effect.Cut();
			return;
		}

		// Function from file: lighting_system.dm
		[VerbInfo( name: "changed" )]
		public void f_changed(  ) {
			
			if ( this.owner != null ) {
				this.__x = this.owner.x;
				this.__y = this.owner.y;
			}

			if ( !this.changed ) {
				this.changed = true;
				GlobalVars.SSlighting.changed_lights.Or( this );
			}
			return;
		}

		// Function from file: lighting_system.dm
		public bool check(  ) {
			
			if ( !( this.owner != null ) ) {
				this.remove_effect();
				return false;
			}

			if ( this.changed ) {
				this.changed = false;
				this.remove_effect();
				return this.add_effect();
			}
			return true;
		}

		// Function from file: lighting_system.dm
		public void UpdateLuminosity( dynamic new_luminosity = null, int? new_cap = null ) {
			
			if ( Convert.ToDouble( new_luminosity ) < 0 ) {
				new_luminosity = 0;
			}

			if ( this.luminosity == new_luminosity && ( new_cap == null || this.cap == new_cap ) ) {
				return;
			}
			this.radius = Num13.MaxInt( 4, Convert.ToInt32( new_luminosity ) );
			this.luminosity = new_luminosity;

			if ( new_cap != null ) {
				this.cap = new_cap;
			}
			this.f_changed();
			return;
		}

		// Function from file: lighting_system.dm
		public override dynamic Destroy(  ) {
			
			if ( this.owner != null && this.owner.light == this ) {
				this.remove_effect();
				this.owner.light = null;
				this.owner.luminosity = 0;
				this.owner = null;
			}

			if ( this.changed ) {
				GlobalVars.SSlighting.changed_lights.Remove( this );
			}
			return base.Destroy();
		}

	}

}