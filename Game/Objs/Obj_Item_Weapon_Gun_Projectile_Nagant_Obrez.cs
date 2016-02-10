// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Projectile_Nagant_Obrez : Obj_Item_Weapon_Gun_Projectile_Nagant {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.fire_sound = "sound/weapons/obrez.ogg";
			this.inhand_states = new ByTable().Set( "left_hand", "icons/mob/in-hand/left/guninhands_left.dmi" ).Set( "right_hand", "icons/mob/in-hand/right/guninhands_right.dmi" );
			this.icon_state = "obrez";
		}

		public Obj_Item_Weapon_Gun_Projectile_Nagant_Obrez ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: nagant.dm
		public void flame_turf( ByTable turflist = null ) {
			Ent_Static T = null;
			dynamic previousturf = null;
			dynamic M = null;

			T = turflist[2];

			if ( Lang13.Length( turflist ) > 1 ) {
				previousturf = GlobalFuncs.get_turf( this );
			}

			if ( Lang13.Bool( previousturf ) && GlobalFuncs.LinkBlocked( previousturf, T ) ) {
				return;
			}

			if ( !T.density && !( T is Tile_Space ) ) {
				new Obj_Fire( T );
				GlobalFuncs.getFromPool( typeof(Obj_Effect_Decal_Cleanable_LiquidFuel), T, 0.1, Map13.GetDistance( T.loc, T ) );
				((dynamic)T).hotspot_expose( 500, 500 );
				previousturf = null;
			}

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( this.loc, 1 ) )) {
				M = _a;
				

				if ( Lang13.Bool( M.client ) && M.machine == this ) {
					this.attack_self( M );
				}
			}
			return;
		}

		// Function from file: nagant.dm
		public override bool afterattack( dynamic A = null, dynamic user = null, bool? flag = null, dynamic _params = null, bool? struggle = null ) {
			struggle = struggle ?? false;

			Effect_Effect_System_SparkSpread sparks = null;
			dynamic target_turf = null;
			ByTable turflist = null;

			
			if ( flag == true ) {
				return false;
			}

			if ( this.current_shell != null && Lang13.Bool( this.current_shell.BB ) ) {
				sparks = new Effect_Effect_System_SparkSpread();
				sparks.set_up( 3, 0, GlobalFuncs.get_turf( user ) );
				sparks.start();
				target_turf = GlobalFuncs.get_turf( A );

				if ( Lang13.Bool( target_turf ) ) {
					turflist = GlobalFuncs.getline( user, A );
					this.flame_turf( turflist );
				}

				if ( Rand13.PercentChance( 15 ) ) {
					
					if ( Lang13.Bool( user.drop_item( this ) ) ) {
						GlobalFuncs.to_chat( user, new Txt( "<span class='danger'>" ).The( this ).item().str( " flies out of your hands.</span>" ).ToString() );
						((Mob_Living)user).take_organ_damage( 0, 10 );
					} else {
						GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>" ).The( this ).item().str( " almost flies out of your hands!</span>" ).ToString() );
					}
				}
			}
			this.Fire( A, user, _params, null, struggle );
			return true;
		}

	}

}