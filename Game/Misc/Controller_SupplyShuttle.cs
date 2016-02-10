// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Controller_SupplyShuttle : Controller {

		public int credits_per_slip = 2;
		public int credits_per_crate = 5;
		public int ordernum = 0;
		public ByTable centcomm_orders = new ByTable();
		public ByTable shoppinglist = new ByTable();
		public ByTable requestlist = new ByTable();
		public ByTable supply_packs = new ByTable();
		public bool at_station = false;
		public int movetime = 1200;
		public int moving = 0;
		public int eta_timeofday = 0;
		public double eta = 0;
		public Materials materials_list = new Materials();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.processing = true;
			this.processing_interval = 300;
		}

		// Function from file: supplyshuttle.dm
		public Controller_SupplyShuttle (  ) {
			this.ordernum = Rand13.Int( 1, 9000 );
			return;
		}

		// Function from file: supplyshuttle.dm
		public bool? forbidden_atoms_check( dynamic A = null ) {
			bool? _default = null;

			ByTable contents = null;

			contents = GlobalFuncs.get_contents_in_object( A );

			if ( Lang13.Bool( Lang13.FindIn( typeof(Mob_Living), contents ) ) ) {
				_default = GlobalVars.TRUE;
			} else if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Item_Weapon_Disk_Nuclear), contents ) ) ) {
				_default = GlobalVars.TRUE;
			} else if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Machinery_Nuclearbomb), contents ) ) ) {
				_default = GlobalVars.TRUE;
			} else if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Item_Beacon), contents ) ) ) {
				_default = GlobalVars.TRUE;
			} else if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Effect_Portal), contents ) ) ) {
				_default = GlobalVars.TRUE;
			} else {
				_default = GlobalVars.FALSE;
			}
			return _default;
		}

		// Function from file: supplyshuttle.dm
		public void buy(  ) {
			dynamic shuttle = null;
			ByTable clear_turfs = null;
			dynamic T = null;
			int? contcount = null;
			Ent_Static A = null;
			dynamic S = null;
			int? i = null;
			dynamic pickedloc = null;
			dynamic SO = null;
			SupplyPacks SP = null;
			dynamic A2 = null;
			Obj_Item_Weapon_Paper_Manifest slip = null;
			ByTable contains = null;
			SupplyPacks SPR = null;
			int? j = null;
			dynamic typepath = null;
			dynamic B2 = null;

			
			if ( !( this.shoppinglist.len != 0 ) ) {
				return;
			}
			shuttle = GlobalVars.cargo_shuttle.linked_area;

			if ( !Lang13.Bool( shuttle ) ) {
				return;
			}
			clear_turfs = new ByTable();

			foreach (dynamic _b in Lang13.Enumerate( shuttle )) {
				T = _b;
				

				if ( T.density ) {
					continue;
				}
				contcount = null;

				foreach (dynamic _a in Lang13.Enumerate( T.contents, typeof(Ent_Static) )) {
					A = _a;
					

					if ( A is Dynamic_LightingOverlay ) {
						continue;
					}
					contcount++;
				}

				if ( Lang13.Bool( contcount ) ) {
					continue;
				}
				clear_turfs.Add( T );
			}

			foreach (dynamic _d in Lang13.Enumerate( this.shoppinglist )) {
				S = _d;
				

				if ( !( clear_turfs.len != 0 ) ) {
					break;
				}
				i = Rand13.Int( 1, clear_turfs.len );
				pickedloc = clear_turfs[i];
				clear_turfs.Cut( i, ( i ??0) + 1 );
				SO = S;
				SP = SO.v_object;
				A2 = Lang13.Call( SP.containertype, pickedloc );
				A2.name = "" + SP.containername + " " + ( Lang13.Bool( SO.comment ) ? "(" + SO.comment + ")" : "" );
				slip = new Obj_Item_Weapon_Paper_Manifest( A2 );
				slip.name = "Shipping Manifest for " + SO.orderedby + "'s Order";
				slip.info = "<h3>" + GlobalFuncs.command_name() + " Shipping Manifest for " + SO.orderedby + "'s Order</h3><hr><br>\n			Order #" + SO.ordernum + "<br>\n			Destination: " + GlobalVars.station_name + "<br>\n			" + GlobalVars.supply_shuttle.shoppinglist.len + " PACKAGES IN THIS SHIPMENT<br>\n			CONTENTS:<br><ul>";

				if ( Lang13.Bool( SP.access ) ) {
					A2.req_access = new ByTable();
					A2.req_access += String13.ParseNumber( SP.access );
				}
				contains = null;

				if ( SP is SupplyPacks_Randomised ) {
					SPR = SP;
					contains = new ByTable();

					if ( SPR.contains.len != 0 ) {
						j = null;
						j = 1;

						while (( j ??0) <= Convert.ToDouble( ((dynamic)SPR).num_contained )) {
							contains.Add( Rand13.PickFromTable( SPR.contains ) );
							j++;
						}
					}
				} else {
					contains = SP.contains;
				}

				foreach (dynamic _c in Lang13.Enumerate( contains )) {
					typepath = _c;
					

					if ( !Lang13.Bool( typepath ) ) {
						continue;
					}
					B2 = Lang13.Call( typepath, A2 );

					if ( SP.amount != 0 && Lang13.Bool( B2.amount ) ) {
						B2.amount = SP.amount;
					}
					slip.info += "<li>" + B2.name + "</li>";
				}
				slip.info += "</ul><br>\n			CHECK CONTENTS AND STAMP BELOW THE LINE TO CONFIRM RECEIPT OF GOODS<hr>";

				if ( SP.contraband ) {
					slip.loc = null;
				}
			}
			GlobalVars.supply_shuttle.shoppinglist.len = 0;
			return;
		}

		// Function from file: supplyshuttle.dm
		public void sell(  ) {
			dynamic shuttle = null;
			MoneyAccount cargo_acct = null;
			Ent_Dynamic MA = null;
			Ent_Dynamic P = null;
			dynamic mat = null;
			bool find_slip = false;
			Ent_Static A = null;
			Ent_Static P2 = null;
			dynamic mat2 = null;
			Ent_Static slip = null;
			CentcommOrder O = null;

			shuttle = GlobalVars.cargo_shuttle.linked_area;

			if ( !Lang13.Bool( shuttle ) ) {
				return;
			}
			cargo_acct = GlobalVars.department_accounts["Cargo"];

			foreach (dynamic _c in Lang13.Enumerate( shuttle, typeof(Ent_Dynamic) )) {
				MA = _c;
				

				if ( Lang13.Bool( MA.anchored ) ) {
					continue;
				}

				if ( MA is Obj_Item_Stack_Sheet_Mineral_Plasma ) {
					P = MA;

					if ( Lang13.Bool( ((dynamic)P).redeemed ) ) {
						continue;
					}
					mat = this.materials_list.getMaterial( ((dynamic)P).sheettype );
					cargo_acct.money += Convert.ToDouble( mat.value * ((dynamic)P).amount * 2 );
				} else if ( MA is Obj_Structure_Closet_Crate ) {
					cargo_acct.money += this.credits_per_crate;
					find_slip = true;

					foreach (dynamic _a in Lang13.Enumerate( MA, typeof(Ent_Static) )) {
						A = _a;
						

						if ( A is Obj_Item_Stack_Sheet_Mineral_Plasma ) {
							P2 = A;

							if ( Lang13.Bool( ((dynamic)P2).redeemed ) ) {
								continue;
							}
							mat2 = this.materials_list.getMaterial( ((dynamic)P2).sheettype );
							cargo_acct.money += Convert.ToDouble( mat2.value * ((dynamic)P2).amount * 2 );
							continue;
						}

						if ( find_slip && A is Obj_Item_Weapon_Paper_Manifest ) {
							slip = A;

							if ( Lang13.Bool( ((dynamic)slip).stamped ) && ((dynamic)slip).stamped.len != 0 ) {
								cargo_acct.money += this.credits_per_slip;
								find_slip = false;
							}
							continue;
						}
						this.SellObjToOrders( A, false );

						if ( A != null ) {
							GlobalFuncs.qdel( A );
						}
					}
				} else {
					this.SellObjToOrders( MA, true );
				}

				foreach (dynamic _b in Lang13.Enumerate( this.centcomm_orders, typeof(CentcommOrder) )) {
					O = _b;
					

					if ( O.CheckFulfilled() ) {
						O.Pay();
						this.centcomm_orders.Remove( O );
					}
				}
				GlobalFuncs.qdel( MA );
			}
			return;
		}

		// Function from file: supplyshuttle.dm
		public void SellObjToOrders( Ent_Static A = null, bool in_crate = false ) {
			ByTable deferred_order_checks = null;
			int order_idx = 0;
			CentcommOrder O = null;
			dynamic oid = null;
			CentcommOrder O2 = null;

			deferred_order_checks = new ByTable();
			order_idx = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.centcomm_orders, typeof(CentcommOrder) )) {
				O = _a;
				
				order_idx++;

				if ( O is CentcommOrder_PerUnit ) {
					deferred_order_checks.Add( order_idx );
				}

				if ( O.CheckShuttleObject( A, in_crate ) ) {
					return;
				}
			}

			foreach (dynamic _b in Lang13.Enumerate( deferred_order_checks )) {
				oid = _b;
				
				O2 = this.centcomm_orders[oid];

				if ( O2.CheckShuttleObject( A, in_crate ) ) {
					return;
				}
			}
			return;
		}

		// Function from file: supplyshuttle.dm
		public bool can_move(  ) {
			
			if ( this.moving != 0 ) {
				return false;
			}

			if ( this.forbidden_atoms_check( GlobalVars.cargo_shuttle.linked_area ) == true ) {
				return false;
			}
			return true;
		}

		// Function from file: supplyshuttle.dm
		public void send(  ) {
			dynamic destination = null;

			
			if ( !this.at_station ) {
				destination = GlobalVars.cargo_shuttle.dock_station;
				this.at_station = true;

				if ( !Lang13.Bool( destination ) ) {
					GlobalFuncs.message_admins( "WARNING: Cargo shuttle unable to find the station!" );
					Game13.log.WriteMsg( "## WARNING: " + "Cargo shuttle can't find centcomm" );
				}
			} else {
				destination = GlobalVars.cargo_shuttle.dock_centcom;
				this.at_station = false;

				if ( !Lang13.Bool( destination ) ) {
					GlobalFuncs.message_admins( "WARNING: Cargo shuttle unable to find centcomm!" );
					Game13.log.WriteMsg( "## WARNING: " + "Cargo shuttle can't find centcomm" );
				}
			}
			GlobalVars.cargo_shuttle.move_to_dock( destination );
			this.moving = 0;
			return;
		}

		// Function from file: supplyshuttle.dm
		public void process(  ) {
			dynamic typepath = null;
			dynamic P = null;
			int ticksleft = 0;

			
			foreach (dynamic _a in Lang13.Enumerate( Lang13.GetTypes( typeof(SupplyPacks) ) - typeof(SupplyPacks) )) {
				typepath = _a;
				
				P = Lang13.Call( typepath );
				this.supply_packs[P.name] = P;
			}
			Task13.Schedule( 0, (Task13.Closure)(() => {
				
				while (true) {
					
					if ( this.processing ) {
						this.iteration++;

						if ( this.moving == 1 ) {
							ticksleft = this.eta_timeofday - Game13.timeofday;

							if ( ticksleft > 0 ) {
								this.eta = Num13.Round( ticksleft / 600, 1 );
							} else {
								this.eta = 0;
								this.send();
							}
						}
					}
					Task13.Sleep( this.processing_interval );
				}
				return;
			}));
			return;
		}

	}

}