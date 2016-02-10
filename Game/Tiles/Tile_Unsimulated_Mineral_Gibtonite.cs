// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Unsimulated_Mineral_Gibtonite : Tile_Unsimulated_Mineral {

		public int det_time = 8;
		public int stage = 0;
		public string activated_ckey = null;
		public string activated_name = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.mineral = new Mineral_Gibtonite();
			this.scan_state = "rock_Gibtonite";
			this.icon_state = "rock_Gibtonite";
		}

		// Function from file: mine_turfs.dm
		public Tile_Unsimulated_Mineral_Gibtonite ( dynamic loc = null ) : base( (object)(loc) ) {
			this.icon_state = "rock_Diamond";
			this.det_time = Rand13.Int( 8, 10 );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: mine_turfs.dm
		public override void GetDrilled( bool? artifact_fail = null ) {
			dynamic bombturf = null;
			Obj_Item_Weapon_Gibtonite G = null;
			dynamic G2 = null;

			
			if ( this.stage == 0 && this.mineral.result_amount >= 1 ) {
				GlobalFuncs.playsound( this, "sound/effects/hit_on_shattered_glass.ogg", 50, 1 );
				this.explosive_reaction();
				return;
			}

			if ( this.stage == 1 && this.mineral.result_amount >= 1 ) {
				bombturf = GlobalFuncs.get_turf( this );
				this.mineral.result_amount = 0;
				GlobalFuncs.explosion( bombturf, 1, 2, 5, null, 0 );
			}

			if ( this.stage == 2 ) {
				G = new Obj_Item_Weapon_Gibtonite( this );

				if ( this.det_time <= 0 ) {
					G.quality = 3;
					G.icon_state = "Gibtonite ore 3";
				}

				if ( this.det_time >= 1 && this.det_time <= 2 ) {
					G.quality = 2;
					G.icon_state = "Gibtonite ore 2";
				}
			}
			G2 = this.ChangeTurf( typeof(Tile_Unsimulated_Floor_Asteroid_GibtoniteRemains) );
			((Tile_Unsimulated_Floor_Asteroid)G2).fullUpdateMineralOverlays();
			return;
		}

		// Function from file: mine_turfs.dm
		public void defuse(  ) {
			
			if ( this.stage == 1 ) {
				this.icon_state = "rock_Gibtonite";
				this.desc = "An inactive gibtonite reserve. The ore can be extracted.";
				this.stage = 2;

				if ( this.det_time < 0 ) {
					this.det_time = 0;
				}
				this.visible_message( "<span class='notice'>The chain reaction was stopped! The gibtonite had " + this.det_time + " reactions left till the explosion!</span>" );
			}
			return;
		}

		// Function from file: mine_turfs.dm
		public void countdown(  ) {
			dynamic bombturf = null;

			Task13.Schedule( 0, (Task13.Closure)(() => {
				
				while (this.stage == 1 && this.det_time > 0 && this.mineral.result_amount >= 1) {
					this.det_time--;
					Task13.Sleep( 5 );
				}

				if ( this.stage == 1 && this.det_time <= 0 && this.mineral.result_amount >= 1 ) {
					bombturf = GlobalFuncs.get_turf( this );
					this.mineral.result_amount = 0;
					GlobalFuncs.explosion( bombturf, 1, 3, 5, null, 0 );
				}

				if ( this.stage == 0 || this.stage == 2 ) {
					return;
				}
				return;
			}));
			return;
		}

		// Function from file: mine_turfs.dm
		public void explosive_reaction(  ) {
			dynamic bombturf = null;
			dynamic A = null;
			string log_str = null;

			
			if ( this.stage == 0 ) {
				this.icon_state = "rock_Gibtonite_active";
				this.name = "Gibtonite deposit";
				this.desc = "An active gibtonite reserve. Run!";
				this.stage = 1;
				this.visible_message( "<span class='warning'>There was gibtonite inside! It's going to explode!</span>" );
				bombturf = GlobalFuncs.get_turf( this );
				A = GlobalFuncs.get_area( bombturf );
				log_str = new Txt().item( this.activated_ckey ).str( "<A HREF='?_src_=holder;adminmoreinfo=" ).Ref( Task13.User ).str( "'>?</A> " ).item( this.activated_name ).str( " has triggered a gibtonite deposit reaction <A HREF='?_src_=holder;adminplayerobservecoodjump=1;X=" ).item( bombturf.x ).str( ";Y=" ).item( bombturf.y ).str( ";Z=" ).item( bombturf.z ).str( "'>" ).item( A.name ).str( " (JMP)</a>." ).ToString();
				GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + log_str ) );
				this.countdown();
			}
			return;
		}

		// Function from file: mine_turfs.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( ( a is Obj_Item_Device_MiningScanner || a is Obj_Item_Device_DepthScanner ) && this.stage == 1 ) {
				((Ent_Static)b).visible_message( "<span class='notice'>You use " + a + " to locate where to cut off the chain reaction and attempt to stop it...</span>" );
				this.defuse();
			}

			if ( a is Obj_Item_Weapon_Pickaxe ) {
				this.activated_ckey = "" + b.ckey;
				this.activated_name = "" + b.name;
			}
			base.attackby( (object)(a), (object)(b), (object)(c) );
			return null;
		}

		// Function from file: mine_turfs.dm
		public override bool Bumped( Ent_Static AM = null, dynamic yes = null ) {
			bool bump_reject = false;
			Ent_Static H = null;
			Ent_Static R = null;
			Ent_Static M = null;

			bump_reject = false;

			if ( AM is Mob_Living_Carbon_Human ) {
				H = AM;

				if ( ( ((Mob)H).get_active_hand() is Obj_Item_Weapon_Pickaxe || ((Mob)H).get_inactive_hand() is Obj_Item_Weapon_Pickaxe ) && this.stage == 1 ) {
					GlobalFuncs.to_chat( H, "<span class='warning'>You don't think that's a good idea...</span>" );
					bump_reject = true;
				}
			} else if ( AM is Mob_Living_Silicon_Robot ) {
				R = AM;

				if ( ((dynamic)R).module_active is Obj_Item_Weapon_Pickaxe ) {
					GlobalFuncs.to_chat( R, "<span class='warning'>You don't think that's a good idea...</span>" );
					bump_reject = true;
				} else if ( ((dynamic)R).module_active is Obj_Item_Device_MiningScanner ) {
					this.attackby( ((dynamic)R).module_active, R );
				}
			} else if ( AM is Obj_Mecha ) {
				M = AM;

				if ( ((dynamic)M).selected is Obj_Item_MechaParts_MechaEquipment_Tool_Drill ) {
					((Obj_Mecha)M).occupant_message( "<span class='warning'>Safety features prevent this action.</span>" );
					bump_reject = true;
				}
			}

			if ( !bump_reject ) {
				return base.Bumped( AM, (object)(yes) );
			}
			return false;
		}

	}

}