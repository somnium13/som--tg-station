// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Recharger_Defibcharger_Wallcharger : Obj_Machinery_Recharger_Defibcharger {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.idle_power_usage = 10;
			this.active_power_usage = 150;
			this.machine_flags = 6;
			this.icon_state = "wrecharger0";
		}

		// Function from file: defibcharger.dm
		public Obj_Machinery_Recharger_Defibcharger_Wallcharger ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.component_parts = new ByTable(new object [] { 
				new Obj_Item_Weapon_Circuitboard_DefibRecharger(), 
				new Obj_Item_Weapon_StockParts_MatterBin(), 
				new Obj_Item_Weapon_StockParts_MatterBin(), 
				new Obj_Item_Weapon_StockParts_Manipulator(), 
				new Obj_Item_Weapon_StockParts_Manipulator(), 
				new Obj_Item_Weapon_StockParts_MicroLaser(), 
				new Obj_Item_Weapon_StockParts_ConsoleScreen()
			 });
			this.RefreshParts();
			return;
		}

		// Function from file: defibcharger.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic D = null;
			dynamic a2 = null;

			
			if ( Lang13.Bool( base.attackby( (object)(a), (object)(b), (object)(c) ) ) ) {
				return null;
			}

			if ( b is Mob_Living_Silicon ) {
				return null;
			}

			if ( a is Obj_Item_Weapon_Melee_Defibrillator ) {
				D = a;

				if ( Lang13.Bool( D.ready ) ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>" + D + " won't fit. Try putting the paddles back on!</span>" );
					return null;
				}

				if ( Lang13.Bool( this.charging ) ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>Remove " + D + " first!</span>" );
					return null;
				}
				a2 = GlobalFuncs.get_area( this );

				if ( !( a2 is Zone ) ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>" + this + " blinks red as you try to insert " + D + "!</span>" );
					return null;
				}

				if ( !a2.power_equip ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>" + this + " blinks red as you try to insert " + D + "!</span>" );
					return null;
				}

				if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
					this.charging = a;
					this.use_power = 2;
					this.update_icon();
				} else {
					b.WriteMsg( new Txt( "<span class='warning'>You can't let go of " ).the( a ).item().str( "!</span>" ).ToString() );
				}
			}
			return null;
		}

		// Function from file: defibcharger.dm
		public override int crowbarDestroy( dynamic user = null ) {
			
			if ( base.crowbarDestroy( (object)(user) ) == 1 ) {
				
				if ( Lang13.Bool( this.charging ) ) {
					this.charging.loc = this.loc;
				}
				return 1;
			}
			return -1;
		}

		// Function from file: defibcharger.dm
		public override int togglePanelOpen( dynamic toggleitem = null, dynamic user = null, dynamic CC = null ) {
			
			if ( Lang13.Bool( this.charging ) ) {
				GlobalFuncs.to_chat( user, "<span class='warning'>Not while " + this + " is charging!</span>" );
				return 0;
			}
			return base.togglePanelOpen( (object)(toggleitem), (object)(user), (object)(CC) );
		}

		// Function from file: defibcharger.dm
		public override dynamic process(  ) {
			dynamic B = null;

			
			if ( ( this.stat & 3 ) != 0 || !Lang13.Bool( this.anchored ) ) {
				return null;
			}

			if ( Lang13.Bool( this.charging ) ) {
				
				if ( this.charging is Obj_Item_Weapon_Melee_Defibrillator ) {
					B = this.charging;

					if ( Convert.ToDouble( B.charges ) < Convert.ToDouble( Lang13.Initial( B, "charges" ) ) ) {
						B.charges++;
						this.icon_state = "wrecharger1";
						this.f_use_power( 150 );
					} else {
						this.icon_state = "wrecharger2";
					}
				}
			}
			return null;
		}

		// Function from file: defibcharger.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			if ( Lang13.Bool( this.charging ) ) {
				this.icon_state = "wrecharger1";
			} else {
				this.icon_state = "wrecharger0";
			}
			return null;
		}

		// Function from file: defibcharger.dm
		public override dynamic emp_act( int severity = 0 ) {
			dynamic B = null;

			
			if ( ( this.stat & 3 ) != 0 || !Lang13.Bool( this.anchored ) ) {
				base.emp_act( severity );
				return null;
			}

			if ( this.charging is Obj_Item_Weapon_Melee_Defibrillator ) {
				B = this.charging;
				B.charges = 0;
			}
			base.emp_act( severity );
			return null;
		}

		// Function from file: defibcharger.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: defibcharger.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			this.add_fingerprint( a );

			if ( Lang13.Bool( this.charging ) ) {
				this.charging.update_icon();
				this.charging.loc = this.loc;
				this.charging = null;
				this.use_power = 1;
				this.update_icon();
			}
			return null;
		}

	}

}