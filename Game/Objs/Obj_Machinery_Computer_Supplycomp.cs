// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_Supplycomp : Obj_Machinery_Computer {

		public string temp = null;
		public int reqtime = 0;
		public bool hacked = false;
		public bool can_order_contraband = false;
		public string last_viewed_group = "categories";
		public MoneyAccount current_acct = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_access = new ByTable(new object [] { 31 });
			this.circuit = "/obj/item/weapon/circuitboard/supplycomp";
			this.light_color = "#966432";
			this.icon_state = "supply";
		}

		public Obj_Machinery_Computer_Supplycomp ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: supplyshuttle.dm
		public void post_signal( string command = null ) {
			dynamic frequency = null;
			Game_Data status_signal = null;

			frequency = GlobalVars.radio_controller.return_frequency( 1435 );

			if ( !Lang13.Bool( frequency ) ) {
				return;
			}
			status_signal = GlobalFuncs.getFromPool( typeof(Signal) );
			((dynamic)status_signal).source = this;
			((dynamic)status_signal).transmission_method = 1;
			((dynamic)status_signal).data["command"] = command;
			frequency.post_signal( this, status_signal );
			return;
		}

		// Function from file: supplyshuttle.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic supply_group_name = null;
			dynamic supply_name = null;
			dynamic N = null;
			dynamic V = null;
			SupplyPacks P = null;
			int timeout = 0;
			string reason = null;
			dynamic idname = null;
			dynamic idrank = null;
			MoneyAccount account = null;
			dynamic I = null;
			Obj_Item_Weapon_Paper reqform = null;
			SupplyOrder O = null;
			double? ordernum = null;
			SupplyOrder O2 = null;
			SupplyPacks P2 = null;
			MoneyAccount A = null;
			MoneyAccount cargo_acct = null;
			int? i = null;
			SupplyOrder SO = null;
			double? cargo_share = null;
			double? centcom_share = null;
			dynamic S = null;
			dynamic SO2 = null;
			dynamic S2 = null;
			dynamic SO3 = null;
			double? ordernum2 = null;
			int? i2 = null;
			dynamic SO4 = null;

			
			if ( !( GlobalVars.supply_shuttle != null ) ) {
				Game13.log.WriteMsg( "## ERROR: Eek. The supply_shuttle controller datum is missing somehow." );
				return null;
			}

			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return 1;
			}

			if ( Lang13.Bool( href_list["send"] ) ) {
				
				if ( !GlobalVars.supply_shuttle.can_move() ) {
					this.temp = new Txt( "For safety reasons the automated supply shuttle cannot transport live organisms, classified nuclear weaponry or homing beacons.<BR><BR><A href='?src=" ).Ref( this ).str( ";mainmenu=1'>OK</A>" ).ToString();
				} else if ( GlobalVars.supply_shuttle.at_station ) {
					GlobalVars.supply_shuttle.moving = -1;
					GlobalVars.supply_shuttle.sell();
					GlobalVars.supply_shuttle.send();
					this.temp = new Txt( "The supply shuttle has departed.<BR><BR><A href='?src=" ).Ref( this ).str( ";mainmenu=1'>OK</A>" ).ToString();
				} else {
					GlobalVars.supply_shuttle.moving = 1;
					GlobalVars.supply_shuttle.buy();
					GlobalVars.supply_shuttle.eta_timeofday = ( Game13.timeofday + GlobalVars.supply_shuttle.movetime ) % 864000;
					this.temp = new Txt( "The supply shuttle has been called and will arrive in " ).item( Num13.Round( GlobalVars.supply_shuttle.movetime / 600, 1 ) ).str( " minutes.<BR><BR><A href='?src=" ).Ref( this ).str( ";mainmenu=1'>OK</A>" ).ToString();
					this.post_signal( "supply" );
				}
			} else if ( Lang13.Bool( href_list["order"] ) ) {
				
				if ( GlobalVars.supply_shuttle.moving != 0 ) {
					return null;
				}

				if ( href_list["order"] == "categories" ) {
					this.last_viewed_group = "categories";
					this.temp = new Txt( "<b>Available credits: " ).item( ( this.current_acct != null ? this.current_acct.fmtBalance() : "PANIC" ) ).str( "</b><BR>\n				<A href='?src=" ).Ref( this ).str( ";mainmenu=1'>Main Menu</A><HR><BR><BR>\n				<b>Select a category</b><BR><BR>" ).ToString();

					foreach (dynamic _a in Lang13.Enumerate( GlobalVars.all_supply_groups )) {
						supply_group_name = _a;
						
						this.temp += new Txt( "<A href='?src=" ).Ref( this ).str( ";order=" ).item( supply_group_name ).str( "'>" ).item( supply_group_name ).str( "</A><BR>" ).ToString();
					}
				} else {
					this.last_viewed_group = href_list["order"];
					this.temp = new Txt( "<b>Available credits: " ).item( ( this.current_acct != null ? this.current_acct.fmtBalance() : "PANIC" ) ).str( "</b><BR>\n				<A href='?src=" ).Ref( this ).str( ";order=categories'>Back to all categories</A><HR><BR><BR>\n				<b>Request from: " ).item( this.last_viewed_group ).str( "</b><BR><BR>" ).ToString();

					foreach (dynamic _b in Lang13.Enumerate( GlobalVars.supply_shuttle.supply_packs )) {
						supply_name = _b;
						
						N = GlobalVars.supply_shuttle.supply_packs[supply_name];

						if ( Lang13.Bool( N.hidden ) && !this.hacked || Lang13.Bool( N.contraband ) && !this.can_order_contraband || N.group != this.last_viewed_group ) {
							continue;
						}
						this.temp += new Txt( "<A href='?src=" ).Ref( this ).str( ";doorder=" ).item( supply_name ).str( "'>" ).item( supply_name ).str( "</A> Cost: " ).item( N.cost ).str( "<BR>" ).ToString();
					}
				}
			} else if ( Lang13.Bool( href_list["doorder"] ) ) {
				
				if ( Game13.time < this.reqtime ) {
					
					foreach (dynamic _c in Lang13.Enumerate( Map13.FetchHearers( null, this ) )) {
						V = _c;
						
						V.show_message( "<b>" + this + "</b>'s monitor flashes, \"" + ( Game13.time - this.reqtime ) + " seconds remaining until another requisition form may be printed.\"" );
					}
					return null;
				}
				P = GlobalVars.supply_shuttle.supply_packs[href_list["doorder"]];

				if ( !( P is SupplyPacks ) ) {
					return null;
				}
				timeout = Game13.time + 600;
				reason = String13.SubStr( GlobalFuncs.sanitize( Interface13.Input( Task13.User, "Reason:", "Why do you require this item?", "", null, InputType.Str | InputType.Null ) ), 1, 1024 );

				if ( Game13.time > timeout ) {
					return null;
				}

				if ( !Lang13.Bool( reason ) ) {
					return null;
				}
				idname = "*None Provided*";
				idrank = "*None Provided*";
				account = null;

				if ( Task13.User is Mob_Living_Carbon_Human ) {
					I = Task13.User.get_id_card();

					if ( Lang13.Bool( I ) ) {
						idname = I.registered_name;
						idrank = ((Obj_Item_Weapon_Card_Id)I).GetJobName();
						account = this.get_card_account( I );
					} else {
						GlobalFuncs.to_chat( Task13.User, new Txt().icon( this ).str( "<span class='warning'>Please wear an ID with an associated bank account.</span>" ).ToString() );
						return null;
					}
					GlobalFuncs.to_chat( Task13.User, new Txt().icon( this ).str( "<span class='notice'>Your request has been saved. The transaction will be performed to your bank account when it has been accepted by cargo staff.</span>" ).ToString() );

					if ( account != null && ( account.money ??0) < ( P.cost ??0) ) {
						GlobalFuncs.to_chat( Task13.User, new Txt().icon( this ).str( "<span class='warning'>Your bank account doesn't have enough funds to order this pack. Your request will be on hold until you provide your bank account with the necessary funds.</span>" ).ToString() );
					}
				} else if ( Task13.User is Mob_Living_Silicon ) {
					idname = Task13.User.real_name;
					account = GlobalVars.station_account;
				}
				GlobalVars.supply_shuttle.ordernum++;
				reqform = new Obj_Item_Weapon_Paper( this.loc );
				reqform.name = "" + P.name + " Requisition Form - " + idname + ", " + idrank;
				reqform.info += "<h3>" + GlobalVars.station_name + " Supply Requisition Form</h3><hr>\n			INDEX: #" + GlobalVars.supply_shuttle.ordernum + "<br>\n			REQUESTED BY: " + idname + "<br>\n			RANK: " + idrank + "<br>\n			REASON: " + reason + "<br>\n			SUPPLY CRATE TYPE: " + P.name + "<br>\n			ACCESS RESTRICTION: " + GlobalFuncs.replacetext( GlobalFuncs.get_access_desc( P.access ) ) + "<br>\n			CONTENTS:<br>";
				reqform.info += P.manifest;
				reqform.info += "<hr>\n			STAMP BELOW TO APPROVE THIS REQUISITION:<br>";
				reqform.update_icon();
				this.reqtime = ( Game13.time + 5 ) % 100000;
				O = new SupplyOrder();
				O.ordernum = GlobalVars.supply_shuttle.ordernum;
				O.v_object = P;
				O.orderedby = idname;
				O.account = account;
				GlobalVars.supply_shuttle.requestlist.Add( O );
				this.temp = new Txt( "Order request placed.<BR>\n			<BR><A href='?src=" ).Ref( this ).str( ";order=" ).item( this.last_viewed_group ).str( "'>Back</A> | <A href='?src=" ).Ref( this ).str( ";mainmenu=1'>Main Menu</A> | <A href='?src=" ).Ref( this ).str( ";confirmorder=" ).item( O.ordernum ).str( "'>Authorize Order</A>" ).ToString();
			} else if ( Lang13.Bool( href_list["confirmorder"] ) ) {
				ordernum = String13.ParseNumber( href_list["confirmorder"] );
				O2 = null;
				P2 = null;
				A = null;
				cargo_acct = GlobalVars.department_accounts["Cargo"];
				this.temp = new Txt( "Invalid Request. <br /><A href='?src=" ).Ref( this ).str( ";mainmenu=1'>Main Menu</A>" ).ToString();
				i = null;
				i = 1;

				while (( i ??0) <= GlobalVars.supply_shuttle.requestlist.len) {
					SO = GlobalVars.supply_shuttle.requestlist[i];

					if ( SO.ordernum == ordernum ) {
						O2 = SO;
						P2 = O2.v_object;
						A = SO.account;

						if ( A != null && ( A.money ??0) >= ( P2.cost ??0) ) {
							GlobalVars.supply_shuttle.requestlist.Cut( i, ( i ??0) + 1 );
							cargo_share = Num13.Floor( ( P2.cost ??0) / 100 * 20 );
							centcom_share = ( P2.cost ??0) - ( cargo_share ??0);
							A.charge( centcom_share, null, "Supply Order #" + SO.ordernum + " (" + P2.name + ")", this.name, null, "CentComm" );
							A.charge( cargo_share, cargo_acct, "Order Tax", this.name );
							GlobalVars.supply_shuttle.shoppinglist.Add( O2 );
							this.temp = new Txt( "Thanks for your order.<BR>\n						<BR><A href='?src=" ).Ref( this ).str( ";viewrequests=1'>Back</A> <A href='?src=" ).Ref( this ).str( ";mainmenu=1'>Main Menu</A>" ).ToString();
						} else {
							this.temp = new Txt( "Not enough credit.<BR>\n						<BR><A href='?src=" ).Ref( this ).str( ";viewrequests=1'>Back</A> <A href='?src=" ).Ref( this ).str( ";mainmenu=1'>Main Menu</A>" ).ToString();
						}
						break;
					}
					i++;
				}
			} else if ( Lang13.Bool( href_list["vieworders"] ) ) {
				this.temp = "Current approved orders: <BR><BR>";

				foreach (dynamic _d in Lang13.Enumerate( GlobalVars.supply_shuttle.shoppinglist )) {
					S = _d;
					
					SO2 = S;
					this.temp += "#" + SO2.ordernum + " - " + SO2.v_object.name + " approved by " + SO2.orderedby + ( Lang13.Bool( SO2.comment ) ? " (" + SO2.comment + ")" : "" ) + "<BR>";
				}
				this.temp += new Txt( "<BR><A href='?src=" ).Ref( this ).str( ";mainmenu=1'>OK</A>" ).ToString();
			} else if ( Lang13.Bool( href_list["viewrequests"] ) ) {
				this.temp = "Current requests: <BR><BR>";

				foreach (dynamic _e in Lang13.Enumerate( GlobalVars.supply_shuttle.requestlist )) {
					S2 = _e;
					
					SO3 = S2;
					this.temp += "#" + SO3.ordernum + " - " + SO3.v_object.name + " requested by " + SO3.orderedby + "  " + ( GlobalVars.supply_shuttle.moving != 0 ? "" : ( GlobalVars.supply_shuttle.at_station ? "" : new Txt( "<A href='?src=" ).Ref( this ).str( ";confirmorder=" ).item( SO3.ordernum ).str( "'>Approve</A> <A href='?src=" ).Ref( this ).str( ";rreq=" ).item( SO3.ordernum ).str( "'>Remove</A>" ).ToString() ) ) + "<BR>";
				}
				this.temp += new Txt( "<BR><A href='?src=" ).Ref( this ).str( ";clearreq=1'>Clear list</A>\n			<BR><A href='?src=" ).Ref( this ).str( ";mainmenu=1'>OK</A>" ).ToString();
			} else if ( Lang13.Bool( href_list["rreq"] ) ) {
				ordernum2 = String13.ParseNumber( href_list["rreq"] );
				this.temp = "Invalid Request.<BR>";
				i2 = null;
				i2 = 1;

				while (( i2 ??0) <= GlobalVars.supply_shuttle.requestlist.len) {
					SO4 = GlobalVars.supply_shuttle.requestlist[i2];

					if ( Lang13.DoubleNullable( SO4.ordernum ) == ordernum2 ) {
						GlobalVars.supply_shuttle.requestlist.Cut( i2, ( i2 ??0) + 1 );
						this.temp = "Request removed.<BR>";
						break;
					}
					i2++;
				}
				this.temp += new Txt( "<BR><A href='?src=" ).Ref( this ).str( ";viewrequests=1'>Back</A> <A href='?src=" ).Ref( this ).str( ";mainmenu=1'>Main Menu</A>" ).ToString();
			} else if ( Lang13.Bool( href_list["clearreq"] ) ) {
				GlobalVars.supply_shuttle.requestlist.len = 0;
				this.temp = new Txt( "List cleared.<BR>\n			<BR><A href='?src=" ).Ref( this ).str( ";mainmenu=1'>OK</A>" ).ToString();
			} else if ( Lang13.Bool( href_list["mainmenu"] ) ) {
				this.temp = null;
			}
			this.add_fingerprint( Task13.User );
			this.updateUsrDialog();
			return null;
		}

		// Function from file: supplyshuttle.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Obj_Structure_Computerframe A = null;
			Obj_Item_Weapon_Circuitboard_Supplycomp M = null;
			Obj C = null;
			Obj_Structure_Computerframe A2 = null;
			Obj_Item_Weapon_Circuitboard_Supplycomp M2 = null;
			Obj C2 = null;

			
			if ( a is Obj_Item_Weapon_Card_Emag && !this.hacked ) {
				GlobalFuncs.to_chat( b, "<span class='notice'>Special supplies unlocked.</span>" );
				this.hacked = true;
				return null;
			}

			if ( a is Obj_Item_Weapon_Screwdriver ) {
				GlobalFuncs.playsound( this.loc, "sound/items/Screwdriver.ogg", 50, 1 );

				if ( GlobalFuncs.do_after( b, this, 20 ) ) {
					
					if ( ( this.stat & 1 ) != 0 ) {
						GlobalFuncs.to_chat( b, "<span class='notice'>The broken glass falls out.</span>" );
						A = new Obj_Structure_Computerframe( this.loc );
						GlobalFuncs.getFromPool( typeof(Obj_Item_Weapon_Shard), this.loc );
						M = new Obj_Item_Weapon_Circuitboard_Supplycomp( A );

						foreach (dynamic _a in Lang13.Enumerate( this, typeof(Obj) )) {
							C = _a;
							
							C.loc = this.loc;
						}
						A.circuit = M;
						A.state = 3;
						A.icon_state = "3";
						A.anchored = 1;
						GlobalFuncs.qdel( this );
					} else {
						GlobalFuncs.to_chat( b, "<span class='notice'>You disconnect the monitor.</span>" );
						A2 = new Obj_Structure_Computerframe( this.loc );
						M2 = new Obj_Item_Weapon_Circuitboard_Supplycomp( A2 );

						if ( this.can_order_contraband ) {
							M2.contraband_enabled = true;
						}

						foreach (dynamic _b in Lang13.Enumerate( this, typeof(Obj) )) {
							C2 = _b;
							
							C2.loc = this.loc;
						}
						A2.circuit = M2;
						A2.state = 4;
						A2.icon_state = "4";
						A2.anchored = 1;
						GlobalFuncs.qdel( this );
					}
				}
			} else {
				return base.attackby( (object)(a), (object)(b), (object)(c) );
			}
			return null;
		}

		// Function from file: supplyshuttle.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			string dat = null;

			
			if ( !this.allowed( a ) ) {
				GlobalFuncs.to_chat( a, "<span class='warning'>Access Denied.</span>" );
				return null;
			}

			if ( Lang13.Bool( base.attack_hand( (object)(a), (object)(b), (object)(c) ) ) ) {
				return null;
			}
			this.current_acct = ((Mob)a).get_worn_id_account();
			((Mob)a).set_machine( this );
			this.post_signal( "supply" );

			if ( Lang13.Bool( this.temp ) ) {
				dat = this.temp;
			} else {
				dat += new Txt( "<BR><B>Supply shuttle</B><HR>\n		\nLocation: " ).item( ( GlobalVars.supply_shuttle.moving != 0 ? "Moving to station (" + GlobalVars.supply_shuttle.eta + " Mins.)" : ( GlobalVars.supply_shuttle.at_station ? "Station" : "Away" ) ) ).str( "<BR>\n		<HR>\nAvailable Credits: " ).item( ( this.current_acct != null ? this.current_acct.fmtBalance() : "N/A" ) ).str( "<BR>\n<BR>\n		" ).item( ( GlobalVars.supply_shuttle.moving != 0 ? "\n*Must be away to order items*<BR>\n<BR>" : ( GlobalVars.supply_shuttle.at_station ? "\n*Must be away to order items*<BR>\n<BR>" : new Txt( "\n<A href='?src=" ).Ref( this ).str( ";order=categories'>Order items</A><BR>\n<BR>" ).ToString() ) ) ).str( "\n		" ).item( ( GlobalVars.supply_shuttle.moving != 0 ? "\n*Shuttle already called*<BR>\n<BR>" : ( GlobalVars.supply_shuttle.at_station ? new Txt( "\n<A href='?src=" ).Ref( this ).str( ";send=1'>Send away</A><BR>\n<BR>" ).ToString() : new Txt( "\n<A href='?src=" ).Ref( this ).str( ";send=1'>Send to station</A><BR>\n<BR>" ).ToString() ) ) ).str( "\n		\n<A href='?src=" ).Ref( this ).str( ";viewrequests=1'>View requests</A><BR>\n<BR>\n		\n<A href='?src=" ).Ref( this ).str( ";vieworders=1'>View orders</A><BR>\n<BR>\n		\n<A href='?src=" ).Ref( a ).str( ";mach_close=computer'>Close</A>" ).ToString();
			}
			Interface13.Browse( a, dat, "window=computer;size=575x450" );
			GlobalFuncs.onclose( a, "computer" );
			return null;
		}

		// Function from file: supplyshuttle.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: supplyshuttle.dm
		public override dynamic attack_ai( dynamic user = null ) {
			this.add_hiddenprint( user );
			return this.attack_hand( user );
		}

	}

}