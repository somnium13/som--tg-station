// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Decal_Slag : Obj_Effect_Decal {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.light_color = "#FA9632";
			this.starting_materials = new ByTable();
			this.icon = "icons/effects/effects.dmi";
			this.icon_state = "slagcold";
		}

		public Obj_Effect_Decal_Slag ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: slag.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Obj_Item_Weapon_Ore_Slag slag = null;

			
			if ( this.molten ) {
				b.show_message( new Txt( "<span class=\"warning\">You need to wait for " ).the( this ).item().str( " to cool.</span>" ).ToString() );
				return null;
			}

			if ( Convert.ToDouble( a.force ) >= 5 && Convert.ToDouble( a.w_class ) >= 3 ) {
				((Ent_Static)b).visible_message( new Txt( "<span class=\"danger\">" ).The( this ).item().str( " is broken apart with the " ).item( a.name ).str( " by " ).item( b.name ).str( "!</span>" ).ToString(), new Txt( "<span class=\"danger\">You break apart " ).the( this ).item().str( " with your " ).item( a.name ).str( "!" ).ToString(), "You hear the sound of rock crumbling." );
				slag = new Obj_Item_Weapon_Ore_Slag( this.loc );
				slag.materials = this.materials;
				((dynamic)slag.materials).holder = slag;
				GlobalFuncs.qdel( this );
			} else {
				((Ent_Static)b).visible_message( new Txt( "<span class=\"attack\">" ).item( b.name ).str( " hits " ).the( this ).item().str( " with his " ).item( a.name ).str( ".</span>" ).ToString(), new Txt( "<span class=\"attack\">You fail to damage " ).the( this ).item().str( " with your " ).item( a.name ).str( "!</span>" ).ToString(), "You hear someone hitting something." );
			}
			return null;
		}

		// Function from file: slag.dm
		public override dynamic Crossed( Ent_Dynamic O = null, dynamic X = null ) {
			Ent_Dynamic H = null;
			Ent_Dynamic L = null;

			base.Crossed( O, (object)(X) );

			if ( !this.molten ) {
				return null;
			}

			if ( !( O != null ) ) {
				return null;
			}

			if ( O is Mob_Dead_Observer ) {
				return null;
			}

			if ( O is Mob_Living_Carbon_Human ) {
				H = O;
				((Mob_Living)H).apply_damage( 3, "fire", "l_leg", 0, 0, "Slag" );
				((Mob_Living)H).apply_damage( 3, "fire", "r_leg", 0, 0, "Slag" );
			} else if ( O is Mob_Living ) {
				L = O;
				((Mob_Living)L).apply_damage( 125, "fire" );
			}
			return null;
		}

		// Function from file: slag.dm
		public override void melt(  ) {
			this.icon_state = "slaghot";
			this.set_light( 2 );
			return;
		}

		// Function from file: slag.dm
		public override void solidify(  ) {
			this.icon_state = "slagcold";
			this.set_light( 0 );
			return;
		}

		// Function from file: slag.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			ByTable bits = null;
			dynamic mat_id = null;
			dynamic mat = null;

			base.examine( (object)(user), size );

			if ( this.molten ) {
				GlobalFuncs.to_chat( user, "<span class=\"warning\">Jesus, it's hot!</span>" );
			}
			bits = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( ((dynamic)this.materials).storage )) {
				mat_id = _a;
				
				mat = ((dynamic)this.materials).getMaterial( mat_id );

				if ( Convert.ToDouble( ((dynamic)this.materials).storage[mat_id] ) > 0 ) {
					bits.Add( mat.processed_name );
				}
			}

			if ( bits.len > 0 ) {
				GlobalFuncs.to_chat( user, "<span class=\"info\">It appears to contain bits of " + GlobalFuncs.english_list( bits ) + ".</span>" );
			} else {
				GlobalFuncs.to_chat( user, "<span class=\"warning\">It appears to be completely worthless.</span>" );
			}
			return null;
		}

		// Function from file: slag.dm
		public override dynamic process(  ) {
			Ent_Static T = null;
			GasMixture env = null;

			
			if ( !this.molten ) {
				GlobalVars.processing_objects.Remove( this );
				return null;
			}
			T = this.loc;
			env = T.return_air();

			if ( ( this.melt_temperature ??0) > ( env.temperature ??0) && this.molten && Rand13.PercentChance( 5 ) ) {
				this.molten = false;
				this.solidify();
				return 1;
			}
			return null;
		}

		// Function from file: slag.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			this.set_light( 0 );
			GlobalVars.processing_objects.Remove( this );
			base.Destroy( (object)(brokenup) );
			return null;
		}

		// Function from file: slag.dm
		public void slaggify( Ent_Dynamic O = null ) {
			
			if ( O.recycle( this.materials ) != 0 ) {
				
				if ( this.melt_temperature == 0 ) {
					this.melt_temperature = O.melt_temperature;
				} else {
					this.melt_temperature = Num13.MinInt( ((int)( this.melt_temperature ??0 )), ((int)( O.melt_temperature ??0 )) );
				}
				GlobalFuncs.qdel( O );

				if ( !this.molten ) {
					this.molten = true;
					this.icon_state = "slaghot";
					GlobalVars.processing_objects.Add( this );
					this.set_light( 2 );
				}
			}
			return;
		}

	}

}