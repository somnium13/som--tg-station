// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Tray_Robotray : Obj_Item_Weapon_Tray {

		public Obj_Item_Weapon_Tray_Robotray ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: robot_items.dm
		public override bool afterattack( dynamic A = null, dynamic user = null, bool? flag = null, dynamic _params = null, bool? struggle = null ) {
			Ent_Static pickup = null;
			bool addedSomething = false;
			Obj_Item_Weapon I = null;
			int add = 0;
			bool foundtable = false;
			Obj_Structure_Table T = null;
			dynamic dropspot = null;
			bool droppedSomething = false;
			Obj_Item I2 = null;
			int? i = null;

			
			if ( !Lang13.Bool( A ) ) {
				return false;
			}

			if ( !( flag == true ) ) {
				return false;
			}

			if ( A is Obj_Item ) {
				
				if ( !( A.loc is Tile ) ) {
					return false;
				}
				pickup = A.loc;
				addedSomething = false;

				foreach (dynamic _a in Lang13.Enumerate( pickup, typeof(Obj_Item_Weapon_ReagentContainers_Food) )) {
					I = _a;
					

					if ( I != this && !Lang13.Bool( I.anchored ) && !( I is Obj_Item_Clothing_Under ) && !( I is Obj_Item_Clothing_Suit ) && !( I is Obj_Item_Projectile ) ) {
						add = 0;

						if ( I.w_class == 1 ) {
							add = 1;
						} else if ( I.w_class == 2 ) {
							add = 3;
						} else {
							add = 5;
						}

						if ( this.calc_carry() + add >= this.max_carry ) {
							break;
						}
						I.loc = this;
						this.carrying.Add( I );
						this.overlays.Add( new Image( I.icon, null, I.icon_state, I.layer + 30 ) );
						addedSomething = true;
					}
				}

				if ( addedSomething ) {
					((Ent_Static)user).visible_message( "<span class='notice'>" + user + " load some items onto their service tray.</span>" );
				}
				return false;
			}

			if ( A is Tile || A is Obj_Structure_Table ) {
				foundtable = A is Obj_Structure_Table;

				if ( !foundtable ) {
					
					foreach (dynamic _b in Lang13.Enumerate( A, typeof(Obj_Structure_Table) )) {
						T = _b;
						
						foundtable = true;
						break;
					}
				}
				dropspot = null;

				if ( !foundtable ) {
					dropspot = user.loc;
				} else if ( A is Tile ) {
					dropspot = A;
				} else {
					dropspot = A.loc;
				}
				this.overlays = null;
				droppedSomething = false;

				foreach (dynamic _c in Lang13.Enumerate( this.carrying, typeof(Obj_Item) )) {
					I2 = _c;
					
					I2.loc = dropspot;
					this.carrying.Remove( I2 );
					droppedSomething = true;

					if ( !foundtable && dropspot is Tile ) {
						Task13.Schedule( 0, (Task13.Closure)(() => {
							i = null;
							i = 1;

							while (( i ??0) <= Rand13.Int( 1, 2 )) {
								
								if ( I2 != null ) {
									Map13.Step( I2, Convert.ToInt32( Rand13.Pick(new object [] { GlobalVars.NORTH, GlobalVars.SOUTH, GlobalVars.EAST, GlobalVars.WEST }) ) );
									Task13.Sleep( Rand13.Int( 2, 4 ) );
								}
								i++;
							}
							return;
						}));
					}
				}

				if ( droppedSomething ) {
					
					if ( foundtable ) {
						((Ent_Static)user).visible_message( "<span class='notice'>" + user + " unloads their service tray.</span>" );
					} else {
						((Ent_Static)user).visible_message( "<span class='notice'>" + user + " drops all the items on their tray.</span>" );
					}
				}
			}
			return base.afterattack( (object)(A), (object)(user), flag, (object)(_params), struggle );
		}

	}

}