// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_BiomassController : Obj_Effect {

		public ByTable vines = new ByTable();
		public ByTable growth_queue = new ByTable();
		public bool? reached_collapse_size = false;
		public bool? reached_slowdown_size = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.invisibility = 60;
		}

		// Function from file: biomass.dm
		public Obj_Effect_BiomassController ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( !( loc is Tile_Simulated_Floor ) ) {
				GlobalFuncs.qdel( this );
			}
			this.spawn_biomass_piece( loc );
			GlobalVars.processing_objects.Add( this );
			return;
		}

		// Function from file: biomass.dm
		public override dynamic process(  ) {
			int maxgrowth = 0;
			int length = 0;
			int i = 0;
			int growth = 0;
			ByTable queue_end = null;
			Obj_Effect_Biomass Biomass = null;

			
			if ( this.vines == null || this.vines.len == 0 ) {
				GlobalFuncs.qdel( this );
				return null;
			}

			if ( this.growth_queue == null ) {
				GlobalFuncs.qdel( this );
				return null;
			}

			if ( this.vines.len >= 250 && !( this.reached_collapse_size == true ) ) {
				this.reached_collapse_size = GlobalVars.TRUE;
			}

			if ( this.vines.len >= 30 && !( this.reached_slowdown_size == true ) ) {
				this.reached_slowdown_size = GlobalVars.TRUE;
			}
			maxgrowth = 0;

			if ( this.reached_collapse_size == true ) {
				maxgrowth = 0;
			} else if ( this.reached_slowdown_size == true ) {
				
				if ( Rand13.PercentChance( 25 ) ) {
					maxgrowth = 1;
				} else {
					maxgrowth = 0;
				}
			} else {
				maxgrowth = 4;
			}
			length = Num13.MinInt( 30, ((int)( this.vines.len / 5 )) );
			i = 0;
			growth = 0;
			queue_end = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( this.growth_queue, typeof(Obj_Effect_Biomass) )) {
				Biomass = _a;
				
				i++;
				this.growth_queue.Remove( Biomass );
				queue_end.Add( Biomass );

				if ( Biomass.energy < 2 ) {
					
					if ( Rand13.PercentChance( 20 ) ) {
						Biomass.grow();
					}
				}

				if ( Biomass.spread() ) {
					growth++;

					if ( growth >= maxgrowth ) {
						break;
					}
				}

				if ( i >= length ) {
					break;
				}
			}
			this.growth_queue = this.growth_queue + queue_end;
			return null;
		}

		// Function from file: biomass.dm
		public void spawn_biomass_piece( dynamic location = null ) {
			Obj_Effect_Biomass Biomass = null;

			Biomass = new Obj_Effect_Biomass( location );
			Biomass.master = this;
			this.vines.Add( Biomass );
			this.growth_queue.Add( Biomass );
			return;
		}

		// Function from file: biomass.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			Obj_Effect_Biomass Biomass = null;

			
			if ( this.vines != null && this.vines.len > 0 ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.vines, typeof(Obj_Effect_Biomass) )) {
					Biomass = _a;
					
					Biomass.unreferenceMaster();
				}
			}
			GlobalVars.processing_objects.Remove( this );
			base.Destroy( (object)(brokenup) );
			return null;
		}

	}

}