// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_Card : Obj_Machinery_Computer {

		public dynamic scan = null;
		public dynamic modify = null;
		public double? mode = 0;
		public bool? printing = null;
		public ByTable card_skins = new ByTable(new object [] { "data", "id", "gold", "silver", "centcom_old", "centcom", "security", "medical", "HoS", "research", "engineering", "CMO", "RD", "CE", "clown", "mime", "syndie" });
		public ByTable cent_card_skins = new ByTable(new object [] { "data", "id", "centcom_old", "centcom", "syndie", "deathsquad", "creed", "ERT_leader", "ERT_security", "ERT_engineering", "ERT_medical" });

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_access = new ByTable(new object [] { 15 });
			this.circuit = "/obj/item/weapon/circuitboard/card";
			this.light_color = "#6496FA";
			this.icon_state = "id";
		}

		public Obj_Machinery_Computer_Card ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: card.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic I = null;
			dynamic I2 = null;
			double? access_type = null;
			double? access_allowed = null;
			string t1 = null;
			dynamic temp_t = null;
			ByTable access = null;
			dynamic jobdatum = null;
			dynamic jobtype = null;
			dynamic J = null;
			dynamic t2 = null;
			string temp_name = null;
			dynamic t22 = null;
			double? account_num = null;
			Obj_Item_Weapon_Paper P = null;
			dynamic A = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return 1;
			}

			if ( Lang13.Bool( href_list["close"] ) ) {
				
				if ( Task13.User.machine == this ) {
					Task13.User.unset_machine();
				}
				return 1;
			}

			dynamic _c = href_list["choice"]; // Was a switch-case, sorry for the mess.
			if ( _c=="modify" ) {
				
				if ( Lang13.Bool( this.modify ) ) {
					GlobalVars.data_core.manifest_modify( this.modify.registered_name, this.modify.assignment );
					this.modify.name = "" + this.modify.registered_name + "'s ID Card (" + this.modify.assignment + ")";

					if ( Task13.User is Mob_Living_Carbon_Human ) {
						this.modify.loc = Task13.User.loc;

						if ( !Lang13.Bool( Task13.User.get_active_hand() ) ) {
							Task13.User.put_in_hands( this.modify );
						}
						this.modify = null;
					} else {
						this.modify.loc = this.loc;
						this.modify = null;
					}
				} else {
					I = Task13.User.get_active_hand();

					if ( I is Obj_Item_Weapon_Card_Id ) {
						
						if ( Task13.User.drop_item( I, this ) ) {
							this.modify = I;
						}
					}
				}
			} else if ( _c=="scan" ) {
				
				if ( Lang13.Bool( this.scan ) ) {
					
					if ( Task13.User is Mob_Living_Carbon_Human ) {
						this.scan.loc = Task13.User.loc;

						if ( !Lang13.Bool( Task13.User.get_active_hand() ) ) {
							Task13.User.put_in_hands( this.scan );
						}
						this.scan = null;
					} else {
						this.scan.loc = this.loc;
						this.scan = null;
					}
				} else {
					I2 = Task13.User.get_active_hand();

					if ( I2 is Obj_Item_Weapon_Card_Id ) {
						
						if ( Task13.User.drop_item( I2, this ) ) {
							this.scan = I2;
						}
					}
				}
			} else if ( _c=="access" ) {
				
				if ( Lang13.Bool( href_list["allowed"] ) ) {
					
					if ( this.is_authenticated() ) {
						access_type = String13.ParseNumber( href_list["access_target"] );
						access_allowed = String13.ParseNumber( href_list["allowed"] );
						Interface13.Stat( null, ( this.is_centcom() ? GlobalFuncs.get_all_centcom_access() : GlobalFuncs.get_all_accesses() ).Contains( access_type ) );

						if ( this.is_centcom() ) {
							this.modify.access -= access_type;

							if ( !Lang13.Bool( access_allowed ) ) {
								this.modify.access += access_type;
							}
						}
					}
				}
			} else if ( _c=="skin" ) {
				this.modify.icon_state = href_list["skin_target"];
			} else if ( _c=="assign" ) {
				
				if ( this.is_authenticated() && Lang13.Bool( this.modify ) ) {
					t1 = href_list["assign_target"];

					if ( t1 == "Custom" ) {
						temp_t = Interface13.Input( "Enter a custom job assignment.", "Assignment", null, null, null, InputType.Str | InputType.Null );

						if ( Lang13.Bool( temp_t ) ) {
							temp_t = String13.SubStr( GlobalFuncs.sanitize( temp_t ), 1, 45 );

							if ( Lang13.Bool( temp_t ) && Lang13.Bool( this.modify ) ) {
								this.modify.assignment = temp_t;
							}
						}
					} else {
						access = new ByTable();

						if ( this.is_centcom() ) {
							access = GlobalFuncs.get_centcom_access( t1 );
						} else {
							jobdatum = null;

							foreach (dynamic _a in Lang13.Enumerate( Lang13.GetTypes( typeof(Job) ) )) {
								jobtype = _a;
								
								J = Lang13.Call( jobtype );

								if ( String13.CKey( J.title ) == String13.CKey( t1 ) ) {
									jobdatum = J;
									break;
								}
							}

							if ( !Lang13.Bool( jobdatum ) ) {
								GlobalFuncs.to_chat( Task13.User, "<span class='warning'>No log exists for this job: " + t1 + "</span>" );
								return null;
							}
							access = ((Job)jobdatum).get_access();
						}
						this.modify.access = access;
						this.modify.assignment = t1;
						this.modify.rank = t1;
					}
				}
			} else if ( _c=="reg" ) {
				
				if ( this.is_authenticated() ) {
					t2 = this.modify;

					if ( this.modify == t2 && ( GlobalFuncs.in_range( this, Task13.User ) || Task13.User is Mob_Living_Silicon ) && this.loc is Tile ) {
						temp_name = GlobalFuncs.reject_bad_name( href_list["reg"] );

						if ( Lang13.Bool( temp_name ) ) {
							this.modify.registered_name = temp_name;
						} else {
							this.visible_message( "<span class='notice'>" + this + " buzzes rudely.</span>" );
						}
						((Obj_Item_Weapon_Card_Id)this.modify).update_virtual_wallet();
					}
				}
				GlobalVars.nanomanager.update_uis( this );
			} else if ( _c=="account" ) {
				
				if ( this.is_authenticated() ) {
					t22 = this.modify;

					if ( this.modify == t22 && ( GlobalFuncs.in_range( this, Task13.User ) || Task13.User is Mob_Living_Silicon ) && this.loc is Tile ) {
						account_num = String13.ParseNumber( href_list["account"] );
						this.modify.associated_account_number = account_num;
					}
				}
				GlobalVars.nanomanager.update_uis( this );
			} else if ( _c=="mode" ) {
				this.mode = String13.ParseNumber( href_list["mode_target"] );
			} else if ( _c=="print" ) {
				
				if ( !( this.printing == true ) ) {
					this.printing = true;
					Task13.Schedule( 50, (Task13.Closure)(() => {
						this.printing = null;
						GlobalVars.nanomanager.update_uis( this );
						P = new Obj_Item_Weapon_Paper( this.loc );

						if ( Lang13.Bool( this.mode ) ) {
							P.name = "crew manifest (" + GlobalFuncs.worldtime2text() + ")";
							P.info = "<h4>Crew Manifest</h4>\n							<br>\n							" + ( GlobalVars.data_core != null ? GlobalVars.data_core.get_manifest( false ) : "" ) + "\n						";
						} else if ( Lang13.Bool( this.modify ) ) {
							P.name = "access report";
							P.info = "<h4>Access Report</h4>\n							<u>Prepared By:</u> " + ( Lang13.Bool( this.scan.registered_name ) ? this.scan.registered_name : "Unknown" ) + "<br>\n							<u>For:</u> " + ( Lang13.Bool( this.modify.registered_name ) ? this.modify.registered_name : "Unregistered" ) + "<br>\n							<hr>\n							<u>Assignment:</u> " + this.modify.assignment + "<br>\n							<u>Account Number:</u> #" + this.modify.associated_account_number + "<br>\n							<u>Blood Type:</u> " + this.modify.blood_type + "<br><br>\n							<u>Access:</u><br>\n						";

							foreach (dynamic _b in Lang13.Enumerate( this.modify.access )) {
								A = _b;
								
								P.info += "  " + GlobalFuncs.get_access_desc( A );
							}
						}
						return;
					}));
				}
			}

			if ( Lang13.Bool( this.modify ) ) {
				this.modify.name = "" + this.modify.registered_name + "'s ID Card (" + this.modify.assignment + ")";
			}
			return 1;
		}

		// Function from file: card.dm
		public override void ui_interact( dynamic user = null, string ui_key = null, Nanoui ui = null, bool? force_open = null ) {
			ui_key = ui_key ?? "main";

			ByTable data = null;
			ByTable all_centcom_access = null;
			dynamic access = null;
			ByTable regions = null;
			double? i = null;
			ByTable accesses = null;
			dynamic access2 = null;

			((Mob)user).set_machine( this );
			data = new ByTable( 0 );
			data["src"] = new Txt().Ref( this ).ToString();
			data["station_name"] = GlobalFuncs.station_name();
			data["mode"] = this.mode;
			data["printing"] = this.printing;
			data["manifest"] = ( GlobalVars.data_core != null ? String13.HtmlDecode( GlobalVars.data_core.get_manifest( false ) ) : null );
			data["target_name"] = ( Lang13.Bool( this.modify ) ? this.modify.name : "-----" );
			data["target_owner"] = ( Lang13.Bool( this.modify ) && Lang13.Bool( this.modify.registered_name ) ? this.modify.registered_name : "-----" );
			data["target_rank"] = this.get_target_rank();
			data["scan_name"] = ( Lang13.Bool( this.scan ) ? this.scan.name : "-----" );
			data["authenticated"] = this.is_authenticated();
			data["has_modify"] = !( !Lang13.Bool( this.modify ) );
			data["account_number"] = ( Lang13.Bool( this.modify ) ? this.modify.associated_account_number : null );
			data["centcom_access"] = this.is_centcom();
			data["all_centcom_access"] = null;
			data["regions"] = null;
			data["engineering_jobs"] = this.format_jobs( GlobalVars.engineering_positions );
			data["medical_jobs"] = this.format_jobs( GlobalVars.medical_positions );
			data["science_jobs"] = this.format_jobs( GlobalVars.science_positions );
			data["security_jobs"] = this.format_jobs( GlobalVars.security_positions );
			data["civilian_jobs"] = this.format_jobs( GlobalVars.civilian_positions );
			data["centcom_jobs"] = this.format_jobs( GlobalFuncs.get_all_centcom_jobs() );
			data["card_skins"] = this.format_card_skins( this.card_skins );
			data["cent_card_skins"] = this.format_card_skins( this.cent_card_skins );

			if ( Lang13.Bool( this.modify ) ) {
				data["current_skin"] = this.modify.icon_state;
			}

			if ( Lang13.Bool( this.modify ) && this.is_centcom() ) {
				all_centcom_access = new ByTable();

				foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_all_centcom_access() )) {
					access = _a;
					

					if ( Lang13.Bool( GlobalFuncs.get_centcom_access_desc( access ) ) ) {
						Interface13.Stat( "allowed", this.modify.access.Contains( access ) );
						all_centcom_access.Add( new ByTable(new object [] { 
							new ByTable().Set( null, "desc" ).Set( GlobalFuncs.replacetext( GlobalFuncs.get_centcom_access_desc( access ), " ", "&nbsp" ), "ref" ).Set( access, ( false ? true : false ) )
						 }) );
					}
				}
				data["all_centcom_access"] = all_centcom_access;
			} else if ( Lang13.Bool( this.modify ) ) {
				regions = new ByTable();
				i = null;
				i = 1;

				while (( i ??0) <= 7) {
					accesses = new ByTable();

					foreach (dynamic _b in Lang13.Enumerate( GlobalFuncs.get_region_accesses( i ) )) {
						access2 = _b;
						

						if ( Lang13.Bool( GlobalFuncs.get_access_desc( access2 ) ) ) {
							Interface13.Stat( "allowed", this.modify.access.Contains( access2 ) );
							accesses.Add( new ByTable(new object [] { new ByTable().Set( null, "desc" ).Set( GlobalFuncs.replacetext( GlobalFuncs.get_access_desc( access2 ), " ", "&nbsp" ), "ref" ).Set( access2, ( false ? true : false ) ) }) );
						}
					}
					regions.Add( new ByTable(new object [] { new ByTable().Set( "name", GlobalFuncs.get_region_accesses_name( i ) ).Set( "accesses", accesses ) }) );
					i++;
				}
				data["regions"] = regions;
			}
			ui = GlobalVars.nanomanager.try_update_ui( user, this, ui_key, ui, data );

			if ( !( ui != null ) ) {
				ui = new Nanoui( user, this, ui_key, "identification_computer.tmpl", this.name, 800, 700 );
				ui.set_initial_data( data );
				ui.open();
			}
			return;
		}

		// Function from file: card.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( Lang13.Bool( base.attack_hand( (object)(a), (object)(b), (object)(c) ) ) ) {
				return null;
			}

			if ( ( this.stat & 3 ) != 0 ) {
				return null;
			}
			this.ui_interact( a );
			return null;
		}

		// Function from file: card.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: card.dm
		public override dynamic attack_ai( dynamic user = null ) {
			return this.attack_hand( user );
		}

		// Function from file: card.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( !( a is Obj_Item_Weapon_Card_Id ) ) {
				return base.attackby( (object)(a), (object)(b), (object)(c) );
			}

			if ( !this.is_centcom() && !Lang13.Bool( this.scan ) && false ) {
				
				if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
					this.scan = a;
				}
			} else if ( this.is_centcom() && !Lang13.Bool( this.scan ) && ( false || false ) ) {
				
				if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
					this.scan = a;
				}
			} else if ( !Lang13.Bool( this.modify ) ) {
				
				if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
					this.modify = a;
				}
			}
			GlobalVars.nanomanager.update_uis( this );
			this.attack_hand( b );
			return null;
		}

		// Function from file: card.dm
		public ByTable format_card_skins( ByTable card_skins = null ) {
			ByTable formatted = null;
			dynamic skin = null;

			formatted = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( card_skins )) {
				skin = _a;
				
				formatted.Add( new ByTable(new object [] { new ByTable().Set( "display_name", GlobalFuncs.replacetext( skin, " ", "&nbsp;" ) ).Set( "skin", skin ) }) );
			}
			return formatted;
		}

		// Function from file: card.dm
		public ByTable format_jobs( ByTable jobs = null ) {
			ByTable formatted = null;
			dynamic job = null;

			formatted = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( jobs )) {
				job = _a;
				
				formatted.Add( new ByTable(new object [] { new ByTable().Set( "display_name", GlobalFuncs.replacetext( job, " ", "&nbsp;" ) ).Set( "target_rank", this.get_target_rank() ).Set( "job", job ) }) );
			}
			return formatted;
		}

		// Function from file: card.dm
		public dynamic get_target_rank(  ) {
			return ( Lang13.Bool( this.modify ) && Lang13.Bool( this.modify.assignment ) ? this.modify.assignment : ((dynamic)( "Unassigned" )) );
		}

		// Function from file: card.dm
		public bool is_authenticated(  ) {
			return ( Lang13.Bool( this.scan ) ? this.check_access( this.scan ) : false );
		}

		// Function from file: card.dm
		public bool is_centcom(  ) {
			return this is Obj_Machinery_Computer_Card_Centcom;
		}

		// Function from file: card.dm
		[Verb]
		[VerbInfo( name: "Eject ID Card", group: "Object", access: VerbAccess.InViewExcludeThis, range: 1 )]
		public void eject_id(  ) {
			
			if ( !( Task13.User != null ) || Task13.User.isUnconscious() || Task13.User.lying == true ) {
				return;
			}

			if ( !Lang13.Bool( Task13.User.dexterity_check() ) ) {
				GlobalFuncs.to_chat( Task13.User, "<span class='warning'>You don't have the dexterity to do this!</span>" );
				return;
			}

			if ( Lang13.Bool( this.scan ) ) {
				GlobalFuncs.to_chat( Task13.User, new Txt( "You remove " ).the( this.scan ).item().str( " from " ).the( this ).item().str( "." ).ToString() );
				this.scan.loc = GlobalFuncs.get_turf( this );

				if ( !Lang13.Bool( Task13.User.get_active_hand() ) ) {
					Task13.User.put_in_hands( this.scan );
				}
				this.scan = null;
			} else if ( Lang13.Bool( this.modify ) ) {
				GlobalFuncs.to_chat( Task13.User, new Txt( "You remove " ).the( this.modify ).item().str( " from " ).the( this ).item().str( "." ).ToString() );
				this.modify.loc = GlobalFuncs.get_turf( this );

				if ( !Lang13.Bool( Task13.User.get_active_hand() ) ) {
					Task13.User.put_in_hands( this.modify );
				}
				this.modify = null;
			} else {
				GlobalFuncs.to_chat( Task13.User, "There is nothing to remove from the console." );
			}
			return;
		}

	}

}