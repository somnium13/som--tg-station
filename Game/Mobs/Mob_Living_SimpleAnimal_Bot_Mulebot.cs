// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Bot_Mulebot : Mob_Living_SimpleAnimal_Bot {

		public dynamic load = null;
		public dynamic passenger = null;
		public dynamic target = null;
		public double? loaddir = 0;
		public dynamic home_destination = "";
		public bool reached_target = true;
		public bool auto_return = true;
		public bool auto_pickup = true;
		public bool report_delivery = true;
		public dynamic cell = null;
		public int bloodiness = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.health = 50;
			this.maxHealth = 50;
			this.damage_coeff = new ByTable().Set( "brute", 0.5 ).Set( "fire", 061 ).Set( "tox", 0 ).Set( "clone", 0 ).Set( "stamina", 0 ).Set( "oxy", 0 );
			this.a_intent = "harm";
			this.buckle_lying = 0;
			this.mob_size = 3;
			this.radio_key = typeof(Obj_Item_Device_Encryptionkey_HeadsetCargo);
			this.radio_channel = "Supply";
			this.bot_type = 2;
			this.model = "MULE";
			this.bot_core_type = typeof(Obj_Machinery_BotCore_Mulebot);
			this.icon_state = "mulebot0";
		}

		// Function from file: mulebot.dm
		public Mob_Living_SimpleAnimal_Bot_Mulebot ( dynamic loc = null ) : base( (object)(loc) ) {
			Job_CargoTech J = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.wires = new Wires_Mulebot( this );
			J = new Job_CargoTech();
			this.access_card.access = J.get_access();
			this.prev_access = this.access_card.access;
			this.cell = new Obj_Item_Weapon_StockParts_Cell( this );
			this.cell.charge = 2000;
			this.cell.maxcharge = 2000;
			Task13.Schedule( 10, (Task13.Closure)(() => {
				GlobalVars.mulebot_count += 1;

				if ( !Lang13.Bool( this.suffix ) ) {
					this.set_suffix( "#" + GlobalVars.mulebot_count );
				}
				return;
			}));
			return;
		}

		// Function from file: mulebot.dm
		public override void UnarmedAttack( Ent_Static A = null, bool? proximity_flag = null ) {
			
			if ( A is Tile && this.loc is Tile && this.loc.Adjacent( A ) && Lang13.Bool( this.load ) ) {
				this.unload( Map13.GetDistance( this.loc, A ) );
			} else {
				base.UnarmedAttack( A, proximity_flag );
			}
			return;
		}

		// Function from file: mulebot.dm
		public override dynamic remove_air( double amount = 0 ) {
			
			if ( this.loc != null ) {
				return this.loc.remove_air( amount );
			} else {
				return null;
			}
		}

		// Function from file: mulebot.dm
		public override void explode(  ) {
			dynamic Tsec = null;
			EffectSystem_SparkSpread s = null;

			this.visible_message( "<span class='boldannounce'>" + this + " blows apart!</span>" );
			Tsec = GlobalFuncs.get_turf( this );
			new Obj_Item_Device_Assembly_ProxSensor( Tsec );
			new Obj_Item_Stack_Rods( Tsec );
			new Obj_Item_Stack_Rods( Tsec );
			new Obj_Item_Stack_CableCoil_Cut( Tsec );

			if ( Lang13.Bool( this.cell ) ) {
				this.cell.loc = Tsec;
				this.cell.update_icon();
				this.cell = null;
			}
			s = new EffectSystem_SparkSpread();
			s.set_up( 3, 1, this );
			s.start();
			new Obj_Effect_Decal_Cleanable_Oil( this.loc );
			base.explode();
			return;
		}

		// Function from file: mulebot.dm
		public override double emp_act( int severity = 0 ) {
			
			if ( Lang13.Bool( this.cell ) ) {
				((Ent_Static)this.cell).emp_act( severity );
			}

			if ( Lang13.Bool( this.load ) ) {
				((Ent_Static)this.load).emp_act( severity );
			}
			base.emp_act( severity );
			return 0;
		}

		// Function from file: mulebot.dm
		public override bool relaymove( Mob user = null, int? direction = null ) {
			
			if ( user.incapacitated() ) {
				return false;
			}

			if ( this.load == user ) {
				this.unload( 0 );
			}
			return false;
		}

		// Function from file: mulebot.dm
		public override dynamic Bump( Ent_Static Obstacle = null, dynamic yes = null ) {
			Ent_Static M = null;

			
			if ( ((Wires)this.wires).is_cut( "avoidance" ) ) {
				M = Obstacle;

				if ( M is Mob ) {
					
					if ( M is Mob_Living_Silicon_Robot ) {
						this.visible_message( "<span class='danger'>" + this + " bumps into " + M + "!</span>" );
					} else {
						GlobalFuncs.add_logs( this, M, "knocked down" );
						this.visible_message( "<span class='danger'>" + this + " knocks over " + M + "!</span>" );
						((Mob)M).stop_pulling();
						((dynamic)M).Stun( 8 );
						((dynamic)M).Weaken( 5 );
					}
				}
			}
			return base.Bump( Obstacle, (object)(yes) );
		}

		// Function from file: mulebot.dm
		public override void calc_path( Ent_Static avoid = null ) {
			this.path = GlobalFuncs.get_path_to( this, this.target, typeof(Tile).GetMethod( "Distance_cardinal" ), false, 250, null, null, this.access_card, avoid );
			return;
		}

		// Function from file: mulebot.dm
		public override bool handle_automated_action(  ) {
			int speed = 0;
			int num_steps = 0;
			int? i = null;

			
			if ( !this.has_power() ) {
				this.on = 0;
				return false;
			}

			if ( Lang13.Bool( this.on ) ) {
				speed = ( ( ((Wires)this.wires).is_cut( "motor1" ) ? false : true ) ?1:0) + ( ((Wires)this.wires).is_cut( "motor2" ) ? 0 : 2 );
				num_steps = 0;

				switch ((int)( speed )) {
					case 0:
						
						break;
					case 1:
						num_steps = 10;
						break;
					case 2:
						num_steps = 5;
						break;
					case 3:
						num_steps = 3;
						break;
				}

				if ( num_steps != 0 ) {
					this.process_bot();
					num_steps--;

					if ( this.v_mode != 0 ) {
						Task13.Schedule( 0, (Task13.Closure)(() => {
							i = null;
							i = num_steps;

							while (( i ??0) > 0) {
								Task13.Sleep( 2 );
								this.process_bot();
								i--;
							}
							return;
						}));
					}
				}
			}
			return false;
		}

		// Function from file: mulebot.dm
		public override void call_bot( Mob_Living_Silicon_Ai caller = null, dynamic waypoint = null, int? message = null ) {
			dynamic dest_area = null;

			base.call_bot( caller, (object)(waypoint), message );

			if ( Lang13.Bool( this.path ) && this.path.len != 0 ) {
				this.target = this.ai_waypoint;
				dest_area = GlobalFuncs.get_area( this.target );
				this.destination = GlobalFuncs.format_text( dest_area.name );
				this.pathset = true;
				this.start();
			}
			return;
		}

		// Function from file: mulebot.dm
		public override void post_buckle_mob( dynamic M = null ) {
			
			if ( M == this.buckled_mob ) {
				M.pixel_y = Lang13.Initial( M, "pixel_y" ) + 9;

				if ( Convert.ToDouble( M.layer ) < this.layer ) {
					M.layer = this.layer + 0.1;
				}
			} else {
				this.load = null;
				M.layer = Lang13.Initial( M, "layer" );
				M.pixel_y = Lang13.Initial( M, "pixel_y" );
			}
			return;
		}

		// Function from file: mulebot.dm
		public override bool MouseDrop_T( Ent_Static dropping = null, Mob user = null ) {
			
			if ( user.incapacitated() || Lang13.Bool( user.lying ) ) {
				return false;
			}

			if ( !( dropping is Ent_Dynamic ) ) {
				return false;
			}
			this.f_load( dropping );
			return false;
		}

		// Function from file: mulebot.dm
		public override string get_controls( dynamic M = null ) {
			bool ai = false;
			dynamic dat = null;

			ai = M is Mob_Living_Silicon;
			dat += "<h3>Multiple Utility Load Effector Mk. V</h3>";
			dat += "<b>ID:</b> " + this.suffix + "<BR>";
			dat += "<b>Power:</b> " + ( Lang13.Bool( this.on ) ? "On" : "Off" ) + "<BR>";
			dat += "<h3>Status</h3>";
			dat += "<div class='statusDisplay'>";

			switch ((int)( this.v_mode )) {
				case 0:
					dat += "<span class='good'>Ready</span>";
					break;
				case 12:
					dat += "<span class='good'>" + this.mode_name[12] + "</span>";
					break;
				case 13:
					dat += "<span class='good'>" + this.mode_name[13] + "</span>";
					break;
				case 14:
					dat += "<span class='average'>" + this.mode_name[14] + "</span>";
					break;
				case 15:
				case 16:
					dat += "<span class='average'>" + this.mode_name[15] + "</span>";
					break;
				case 17:
					dat += "<span class='bad'>" + this.mode_name[17] + "</span>";
					break;
			}
			dat += "</div>";
			dat += "<b>Current Load:</b> " + ( Lang13.Bool( this.load ) ? this.load.name : "<i>none</i>" ) + "<BR>";
			dat += "<b>Destination:</b> " + ( !Lang13.Bool( this.destination ) ? ((dynamic)( "<i>none</i>" )) : this.destination ) + "<BR>";
			dat += "<b>Power level:</b> " + ( Lang13.Bool( this.cell ) ? ((Obj_Item_Weapon_StockParts_Cell)this.cell).percent() : 0 ) + "%";

			if ( this.locked && !ai && !Lang13.Bool( GlobalFuncs.IsAdminGhost( M ) ) ) {
				dat += new Txt( "&nbsp;<br /><div class='notice'>Controls are locked</div><A href='byond://?src=" ).Ref( this ).str( ";op=unlock'>Unlock Controls</A>" ).ToString();
			} else {
				dat += new Txt( "&nbsp;<br /><div class='notice'>Controls are unlocked</div><A href='byond://?src=" ).Ref( this ).str( ";op=lock'>Lock Controls</A><BR><BR>" ).ToString();
				dat += new Txt( "<A href='byond://?src=" ).Ref( this ).str( ";op=power'>Toggle Power</A><BR>" ).ToString();
				dat += new Txt( "<A href='byond://?src=" ).Ref( this ).str( ";op=stop'>Stop</A><BR>" ).ToString();
				dat += new Txt( "<A href='byond://?src=" ).Ref( this ).str( ";op=go'>Proceed</A><BR>" ).ToString();
				dat += new Txt( "<A href='byond://?src=" ).Ref( this ).str( ";op=home'>Return to Home</A><BR>" ).ToString();
				dat += new Txt( "<A href='byond://?src=" ).Ref( this ).str( ";op=destination'>Set Destination</A><BR>" ).ToString();
				dat += new Txt( "<A href='byond://?src=" ).Ref( this ).str( ";op=setid'>Set Bot ID</A><BR>" ).ToString();
				dat += new Txt( "<A href='byond://?src=" ).Ref( this ).str( ";op=sethome'>Set Home</A><BR>" ).ToString();
				dat += new Txt( "<A href='byond://?src=" ).Ref( this ).str( ";op=autoret'>Toggle Auto Return Home</A> (" ).item( ( this.auto_return ? "On" : "Off" ) ).str( ")<BR>" ).ToString();
				dat += new Txt( "<A href='byond://?src=" ).Ref( this ).str( ";op=autopick'>Toggle Auto Pickup Crate</A> (" ).item( ( this.auto_pickup ? "On" : "Off" ) ).str( ")<BR>" ).ToString();
				dat += new Txt( "<A href='byond://?src=" ).Ref( this ).str( ";op=report'>Toggle Delivery Reporting</A> (" ).item( ( this.report_delivery ? "On" : "Off" ) ).str( ")<BR>" ).ToString();

				if ( Lang13.Bool( this.load ) ) {
					dat += new Txt( "<A href='byond://?src=" ).Ref( this ).str( ";op=unload'>Unload Now</A><BR>" ).ToString();
				}
				dat += "<div class='notice'>The maintenance hatch is closed.</div>";
			}
			return dat;
		}

		// Function from file: mulebot.dm
		public override bool bot_control( string command = null, Mob user = null, dynamic user_turf = null, dynamic user_access = null ) {
			user_turf = user_turf ?? 0;

			dynamic new_dest = null;
			string new_id = null;
			dynamic new_home = null;

			
			if ( Lang13.Bool( user_turf ) && ((Wires)this.wires).is_cut( "recieve" ) ) {
				return false;
			}

			switch ((string)( command )) {
				case "stop":
					
					if ( this.v_mode >= 12 ) {
						this.bot_reset();
					}
					break;
				case "go":
					
					if ( this.v_mode == 0 ) {
						this.start();
					}
					break;
				case "home":
					
					if ( this.v_mode == 0 || this.v_mode == 12 ) {
						this.start_home();
					}
					break;
				case "destination":
					new_dest = Interface13.Input( user, "Enter Destination:", this.name, this.destination, GlobalVars.deliverybeacontags, InputType.Null | InputType.Any );

					if ( Lang13.Bool( new_dest ) ) {
						this.set_destination( new_dest );
					}
					break;
				case "setid":
					new_id = GlobalFuncs.stripped_input( user, "Enter ID:", this.name, this.suffix, 26 );

					if ( Lang13.Bool( new_id ) ) {
						this.set_suffix( new_id );
					}
					break;
				case "sethome":
					new_home = Interface13.Input( user, "Enter Home:", this.name, this.home_destination, GlobalVars.deliverybeacontags, InputType.Null | InputType.Any );

					if ( Lang13.Bool( new_home ) ) {
						this.home_destination = new_home;
					}
					break;
				case "unload":
					
					if ( Lang13.Bool( this.load ) && this.v_mode != 1 ) {
						
						if ( this.loc == this.target ) {
							this.unload( this.loaddir );
						} else {
							this.unload( 0 );
						}
					}
					break;
				case "autoret":
					this.auto_return = !this.auto_return;
					break;
				case "autopick":
					this.auto_pickup = !this.auto_pickup;
					break;
				case "report":
					this.report_delivery = !this.report_delivery;
					break;
				case "ejectpai":
					this.ejectpairemote( user );
					break;
			}
			return false;
		}

		// Function from file: mulebot.dm
		public override int? ui_act( string action = null, ByTable _params = null, Tgui ui = null, UiState state = null ) {
			int? _default = null;

			
			if ( Lang13.Bool( base.ui_act( action, _params, ui, state ) ) || this.locked && !Task13.User.has_unlimited_silicon_privilege ) {
				return _default;
			}

			switch ((string)( action )) {
				case "lock":
					
					if ( Task13.User.has_unlimited_silicon_privilege ) {
						this.locked = !this.locked;
						_default = GlobalVars.TRUE;
					}
					break;
				case "power":
					
					if ( Lang13.Bool( this.on ) ) {
						this.turn_off();
					} else if ( Lang13.Bool( this.cell ) && !this.open ) {
						
						if ( !this.turn_on() ) {
							Task13.User.WriteMsg( "<span class='warning'>You can't switch on " + this + "!</span>" );
							return _default;
						}
					}
					_default = GlobalVars.TRUE;
					break;
				default:
					this.bot_control( action, Task13.User );
					_default = GlobalVars.TRUE;
					break;
			}
			return _default;
		}

		// Function from file: mulebot.dm
		public override ByTable ui_data( dynamic user = null ) {
			ByTable data = null;

			data = new ByTable();
			data["on"] = this.on;
			data["locked"] = this.locked;
			data["siliconUser"] = user.has_unlimited_silicon_privilege;
			data["mode"] = ( this.v_mode != 0 ? this.mode_name[this.v_mode] : "Ready" );
			data["modeStatus"] = "";

			switch ((int)( this.v_mode )) {
				case 0:
				case 12:
				case 13:
					data["modeStatus"] = "good";
					break;
				case 14:
				case 15:
				case 16:
					data["modeStatus"] = "average";
					break;
				case 17:
					data["modeStatus"] = "bad";
					break;
			}
			data["load"] = ( Lang13.Bool( this.load ) ? this.load.name : null );
			data["destination"] = ( Lang13.Bool( this.destination ) ? this.destination : null );
			data["cell"] = ( Lang13.Bool( this.cell ) ? GlobalVars.TRUE : GlobalVars.FALSE );
			data["cellPercent"] = ( Lang13.Bool( this.cell ) ? ((Obj_Item_Weapon_StockParts_Cell)this.cell).percent() : 0 );
			data["autoReturn"] = this.auto_return;
			data["autoPickup"] = this.auto_pickup;
			data["reportDelivery"] = this.report_delivery;
			data["haspai"] = ( Lang13.Bool( this.paicard ) ? GlobalVars.TRUE : GlobalVars.FALSE );
			return data;
		}

		// Function from file: mulebot.dm
		public override int ui_interact( dynamic user = null, string ui_key = null, Tgui ui = null, bool? force_open = null, Tgui master_ui = null, UiState state = null ) {
			ui_key = ui_key ?? "main";
			force_open = force_open ?? false;
			state = state ?? GlobalVars.default_state;

			ui = GlobalVars.SStgui.try_update_ui( user, this, ui_key, ui, force_open );

			if ( !( ui != null ) ) {
				ui = new Tgui( user, this, ui_key, "mulebot", this.name, 600, 375, master_ui, state );
				ui.open();
			}
			return 0;
		}

		// Function from file: mulebot.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			
			if ( this.open && !( user is Mob_Living_Silicon_Ai ) ) {
				this.wires.interact( user );
			} else {
				
				if ( ((Wires)this.wires).is_cut( "recieve" ) && user is Mob_Living_Silicon_Ai ) {
					return null;
				}
				this.ui_interact( user );
			}
			return null;
		}

		// Function from file: mulebot.dm
		public override dynamic bullet_act( dynamic P = null, dynamic def_zone = null ) {
			
			if ( Lang13.Bool( base.bullet_act( (object)(P), (object)(def_zone) ) ) ) {
				
				if ( Rand13.PercentChance( 50 ) && !( this.load == null ) ) {
					this.unload( 0 );
				}

				if ( Rand13.PercentChance( 25 ) ) {
					this.visible_message( "<span class='danger'>Something shorts out inside " + this + "!</span>" );
					((Wires)this.wires).cut_random();
				}
			}
			return null;
		}

		// Function from file: mulebot.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			int? i = null;

			this.unload( 0 );

			switch ((int?)( severity )) {
				case 1:
					GlobalFuncs.qdel( this );
					break;
				case 2:
					i = null;
					i = 1;

					while (( i ??0) < 3) {
						((Wires)this.wires).cut_random();
						i++;
					}
					break;
				case 3:
					((Wires)this.wires).cut_random();
					break;
			}
			return false;
		}

		// Function from file: mulebot.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			
			if ( this.open ) {
				this.icon_state = "mulebot-hatch";
			} else {
				this.icon_state = "mulebot" + ((Wires)this.wires).is_cut( "avoidance" );
			}
			this.overlays.Cut();

			if ( Lang13.Bool( this.load ) && !( this.load is Mob ) ) {
				this.load.pixel_y = Lang13.Initial( this.load, "pixel_y" ) + 9;

				if ( Convert.ToDouble( this.load.layer ) < this.layer ) {
					this.load.layer = this.layer + 0.1;
				}
				this.overlays.Add( this.load );
			}
			return false;
		}

		// Function from file: mulebot.dm
		public override bool emag_act( dynamic user = null ) {
			
			if ( this.emagged < 1 ) {
				this.emagged = 1;
			}

			if ( !this.open ) {
				this.locked = !this.locked;
				user.WriteMsg( "<span class='notice'>You " + ( this.locked ? "lock" : "unlock" ) + " the " + this + "'s controls!</span>" );
			}
			Icon13.Flick( "mulebot-emagged", this );
			GlobalFuncs.playsound( this.loc, "sound/effects/sparks1.ogg", 100, 0 );
			return false;
		}

		// Function from file: mulebot.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic C = null;

			
			if ( A is Obj_Item_Weapon_Screwdriver ) {
				base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

				if ( this.open ) {
					this.on = GlobalVars.FALSE;
				}
			} else if ( A is Obj_Item_Weapon_StockParts_Cell && this.open && !Lang13.Bool( this.cell ) ) {
				
				if ( !Lang13.Bool( user.drop_item() ) ) {
					return null;
				}
				C = A;
				C.loc = this;
				this.cell = C;
				this.visible_message( "" + user + " inserts a cell into " + this + ".", "<span class='notice'>You insert the new cell into " + this + ".</span>" );
			} else if ( A is Obj_Item_Weapon_Crowbar && this.open && Lang13.Bool( this.cell ) ) {
				((Ent_Static)this.cell).add_fingerprint( Task13.User );
				this.cell.loc = this.loc;
				this.cell = null;
				this.visible_message( "" + user + " crowbars out the power cell from " + this + ".", "<span class='notice'>You pry the powercell out of " + this + ".</span>" );
			} else if ( Lang13.Bool( GlobalFuncs.is_wire_tool( A ) ) && this.open ) {
				return this.attack_hand( user );
			} else if ( Lang13.Bool( this.load ) && this.load is Mob ) {
				
				if ( Rand13.PercentChance( Convert.ToInt32( A.force * 2 + 1 ) ) ) {
					this.unload( 0 );
					((Ent_Static)user).visible_message( new Txt( "<span class='danger'>" ).item( user ).str( " knocks " ).item( this.load ).str( " off " ).item( this ).str( " with " ).the( A ).item().str( "!</span>" ).ToString(), new Txt( "<span class='danger'>You knock " ).item( this.load ).str( " off " ).item( this ).str( " with " ).the( A ).item().str( "!</span>" ).ToString() );
				} else {
					user.WriteMsg( new Txt( "<span class='warning'>You hit " ).item( this ).str( " with " ).the( A ).item().str( " but to no effect!</span>" ).ToString() );
					base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
				}
			} else {
				base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			}
			this.update_icon();
			return null;
		}

		// Function from file: mulebot.dm
		public override void bot_reset(  ) {
			base.bot_reset();
			this.reached_target = false;
			return;
		}

		// Function from file: mulebot.dm
		public void get_nav(  ) {
			Obj_Machinery_Navbeacon NB = null;
			dynamic direction = null;

			
			if ( !Lang13.Bool( this.on ) || ((Wires)this.wires).is_cut( "beacon" ) ) {
				return;
			}

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.deliverybeacons, typeof(Obj_Machinery_Navbeacon) )) {
				NB = _a;
				

				if ( NB.location == this.new_destination ) {
					this.destination = this.new_destination;
					this.target = NB.loc;
					direction = NB.dir;

					if ( Lang13.Bool( direction ) ) {
						this.loaddir = String13.ParseNumber( direction );
					} else {
						this.loaddir = 0;
					}
					this.update_icon();

					if ( Lang13.Bool( this.destination ) ) {
						this.calc_path();
					}
				}
			}
			return;
		}

		// Function from file: mulebot.dm
		public void RunOver( Mob_Living H = null ) {
			int damage = 0;
			Obj_Effect_Decal_Cleanable_Blood B = null;

			GlobalFuncs.add_logs( this, H, "run over", null, "(DAMTYPE: " + String13.ToUpper( "brute" ) + ")" );
			H.visible_message( "<span class='danger'>" + this + " drives over " + H + "!</span>", "<span class='userdanger'>" + this + " drives over you!<span>" );
			GlobalFuncs.playsound( this.loc, "sound/effects/splat.ogg", 50, 1 );
			damage = Rand13.Int( 5, 15 );
			H.apply_damage( damage * 2, "brute", "head", this.run_armor_check( "head", "melee" ) );
			H.apply_damage( damage * 2, "brute", "chest", this.run_armor_check( "chest", "melee" ) );
			H.apply_damage( damage * 0.5, "brute", "l_leg", this.run_armor_check( "l_leg", "melee" ) );
			H.apply_damage( damage * 0.5, "brute", "r_leg", this.run_armor_check( "r_leg", "melee" ) );
			H.apply_damage( damage * 0.5, "brute", "l_arm", this.run_armor_check( "l_arm", "melee" ) );
			H.apply_damage( damage * 0.5, "brute", "r_arm", this.run_armor_check( "r_arm", "melee" ) );
			B = new Obj_Effect_Decal_Cleanable_Blood( this.loc );
			B.add_blood_list( H );
			this.add_blood_list( H );
			this.bloodiness += 4;
			return;
		}

		// Function from file: mulebot.dm
		public void at_target(  ) {
			dynamic AM = null;
			Ent_Dynamic A = null;

			
			if ( !this.reached_target ) {
				this.radio_channel = "Supply";
				this.audible_message( "" + this + " makes a chiming sound!", "<span class='italics'>You hear a chime.</span>" );
				GlobalFuncs.playsound( this.loc, "sound/machines/chime.ogg", 50, 0 );
				this.reached_target = true;

				if ( this.pathset ) {
					this.loaddir = this.dir;

					if ( this.calling_ai != null ) {
						this.calling_ai.WriteMsg( new Txt( "<span class='notice'>" ).icon( this ).str( " " ).item( this ).str( " wirelessly plays a chiming sound!</span>" ).ToString() );
						GlobalFuncs.playsound( this.calling_ai, "sound/machines/chime.ogg", 40, 0 );
						this.calling_ai = null;
						this.radio_channel = "AI Private";
					}
				}

				if ( Lang13.Bool( this.load ) ) {
					
					if ( this.report_delivery ) {
						this.f_speak( "Destination <b>" + this.destination + "</b> reached. Unloading " + this.load + ".", this.radio_channel );
					}
					this.unload( this.loaddir );
				} else if ( this.auto_pickup ) {
					
					if ( ((Wires)this.wires).is_cut( "loadcheck" ) ) {
						
						foreach (dynamic _a in Lang13.Enumerate( Map13.GetStep( this.loc, ((int)( this.loaddir ??0 )) ), typeof(Ent_Dynamic) )) {
							A = _a;
							

							if ( !Lang13.Bool( A.anchored ) ) {
								AM = A;
								break;
							}
						}
					} else {
						AM = Lang13.FindIn( typeof(Obj_Structure_Closet_Crate), Map13.GetStep( this.loc, ((int)( this.loaddir ??0 )) ) );
					}

					if ( Lang13.Bool( AM ) && ((Ent_Static)AM).Adjacent( this ) ) {
						this.f_load( AM );

						if ( this.report_delivery ) {
							this.f_speak( "Now loading " + this.load + " at <b>" + GlobalFuncs.get_area( this ) + "</b>.", this.radio_channel );
						}
					}
				}

				if ( this.auto_return && Lang13.Bool( this.home_destination ) && this.destination != this.home_destination ) {
					this.start_home();
					this.v_mode = 14;
				} else {
					this.bot_reset();
				}
			}
			return;
		}

		// Function from file: mulebot.dm
		public void start_home(  ) {
			
			if ( !Lang13.Bool( this.on ) ) {
				return;
			}
			Task13.Schedule( 0, (Task13.Closure)(() => {
				this.set_destination( this.home_destination );
				this.v_mode = 14;
				return;
			}));
			this.update_icon();
			return;
		}

		// Function from file: mulebot.dm
		public void start(  ) {
			
			if ( !Lang13.Bool( this.on ) ) {
				return;
			}

			if ( this.destination == this.home_destination ) {
				this.v_mode = 13;
			} else {
				this.v_mode = 12;
			}
			this.update_icon();
			this.get_nav();
			return;
		}

		// Function from file: mulebot.dm
		public void set_destination( dynamic new_dest = null ) {
			this.new_destination = new_dest;
			this.get_nav();
			return;
		}

		// Function from file: mulebot.dm
		public void process_bot(  ) {
			Ent_Static next = null;
			Obj_Effect_Decal_Cleanable_Blood_Tracks B = null;
			int newdir = 0;
			Ent_Static oldloc = null;
			int moved = 0;

			
			if ( !Lang13.Bool( this.on ) || this.client != null ) {
				return;
			}
			this.update_icon();

			switch ((int)( this.v_mode )) {
				case 0:
					return;
					break;
				case 12:
				case 13:
				case 14:
					
					if ( this.loc == this.target ) {
						this.at_target();
						return;
					} else if ( this.path.len > 0 && Lang13.Bool( this.target ) ) {
						next = this.path[1];
						this.reached_target = false;

						if ( next == this.loc ) {
							this.path -= next;
							return;
						}

						if ( next is Tile_Simulated ) {
							
							if ( this.bloodiness != 0 ) {
								B = new Obj_Effect_Decal_Cleanable_Blood_Tracks( this.loc );
								B.blood_DNA.Or( this.blood_DNA.Copy() );
								newdir = Map13.GetDistance( next, this.loc );

								if ( newdir == this.dir ) {
									B.dir = newdir;
								} else {
									newdir = newdir | this.dir;

									if ( newdir == 3 ) {
										newdir = 1;
									} else if ( newdir == 12 ) {
										newdir = 4;
									}
									B.dir = newdir;
								}
								this.bloodiness--;
							}
							oldloc = this.loc;
							Map13.StepTowardsSimple( this, next );
							moved = this.bloodiness;

							if ( Lang13.Bool( this.cell ) ) {
								((Obj_Item_Weapon_StockParts_Cell)this.cell).use( 1 );
							}

							if ( moved != 0 && oldloc != this.loc ) {
								this.blockcount = 0;
								this.path -= this.loc;

								if ( this.destination == this.home_destination ) {
									this.v_mode = 13;
								} else {
									this.v_mode = 12;
								}
							} else {
								this.blockcount++;
								this.v_mode = 14;

								if ( this.blockcount == 3 ) {
									this.buzz( 1 );
								}

								if ( this.blockcount > 10 ) {
									this.buzz( 0 );
									this.v_mode = 16;
									this.blockcount = 0;
									Task13.Schedule( 20, (Task13.Closure)(() => {
										this.calc_path( next );

										if ( this.path.len > 0 ) {
											this.buzz( 2 );
										}
										this.v_mode = 14;
										return;
									}));
									return;
								}
								return;
							}
						} else {
							this.buzz( 1 );
							this.v_mode = 15;
							return;
						}
					} else {
						this.v_mode = 15;
						return;
					}
					break;
				case 15:
					this.v_mode = 16;
					Task13.Schedule( 0, (Task13.Closure)(() => {
						this.calc_path();

						if ( this.path.len > 0 ) {
							this.blockcount = 0;
							this.v_mode = 14;
							this.buzz( 2 );
						} else {
							this.buzz( 0 );
							this.v_mode = 17;
						}
						return;
					}));
					break;
			}
			return;
		}

		// Function from file: mulebot.dm
		public void unload( double? dirn = null ) {
			Ent_Static T = null;
			Tile newT = null;

			
			if ( !Lang13.Bool( this.load ) ) {
				return;
			}
			this.v_mode = 0;
			this.overlays.Cut();
			this.unbuckle_mob();

			if ( Lang13.Bool( this.load ) ) {
				this.load.loc = this.loc;
				this.load.pixel_y = Lang13.Initial( this.load, "pixel_y" );
				this.load.layer = Lang13.Initial( this.load, "layer" );

				if ( Lang13.Bool( dirn ) ) {
					T = this.loc;
					newT = Map13.GetStep( T, ((int)( dirn ??0 )) );

					if ( ((Ent_Static)this.load).CanPass( this.load, newT ) ) {
						Map13.Step( this.load, ((int)( dirn ??0 )) );
					}
				}
				this.load = null;
			}
			return;
		}

		// Function from file: mulebot.dm
		public int? load_mob( dynamic M = null ) {
			this.can_buckle = GlobalVars.TRUE;

			if ( this.buckle_mob( M ) ) {
				this.passenger = M;
				this.load = M;
				this.can_buckle = GlobalVars.FALSE;
				return GlobalVars.TRUE;
			}
			return GlobalVars.FALSE;
		}

		// Function from file: mulebot.dm
		[VerbInfo( name: "load" )]
		[VerbArg( 1, InputType.Mob | InputType.Obj )]
		public void f_load( dynamic AM = null ) {
			dynamic CRATE = null;
			dynamic O = null;

			
			if ( Lang13.Bool( this.load ) || Lang13.Bool( AM.anchored ) ) {
				return;
			}

			if ( !( AM.loc is Tile ) ) {
				return;
			}

			if ( AM is Obj_Structure_Closet_Crate ) {
				CRATE = AM;
			} else if ( !((Wires)this.wires).is_cut( "loadcheck" ) ) {
				this.buzz( 0 );
				return;
			}

			if ( Lang13.Bool( CRATE ) ) {
				CRATE.close();
			}

			if ( AM is Obj ) {
				O = AM;

				if ( Lang13.Bool( O.buckled_mob ) || Lang13.Bool( Lang13.FindIn( typeof(Mob), AM ) ) ) {
					this.buzz( 0 );
					return;
				}
			}

			if ( AM is Mob_Living ) {
				
				if ( !Lang13.Bool( this.load_mob( AM ) ) ) {
					return;
				}
			} else {
				AM.loc = this;
			}
			this.load = AM;
			this.v_mode = 0;
			this.update_icon();
			return;
		}

		// Function from file: mulebot.dm
		public void buzz( int type = 0 ) {
			
			switch ((int)( type )) {
				case 0:
					this.audible_message( "" + this + " makes a sighing buzz.", "<span class='italics'>You hear an electronic buzzing sound.</span>" );
					GlobalFuncs.playsound( this.loc, "sound/machines/buzz-sigh.ogg", 50, 0 );
					break;
				case 1:
					this.audible_message( "" + this + " makes an annoyed buzzing sound.", "<span class='italics'>You hear an electronic buzzing sound.</span>" );
					GlobalFuncs.playsound( this.loc, "sound/machines/buzz-two.ogg", 50, 0 );
					break;
				case 2:
					this.audible_message( "" + this + " makes a delighted ping!", "<span class='italics'>You hear a ping.</span>" );
					GlobalFuncs.playsound( this.loc, "sound/machines/ping.ogg", 50, 0 );
					break;
			}
			return;
		}

		// Function from file: mulebot.dm
		public bool has_power(  ) {
			return !this.open && Lang13.Bool( this.cell ) && Convert.ToDouble( this.cell.charge ) > 0 && !((Wires)this.wires).is_cut( "power1" ) && !((Wires)this.wires).is_cut( "power2" );
		}

		// Function from file: mulebot.dm
		public void set_suffix( string suffix = null ) {
			this.suffix = suffix;

			if ( Lang13.Bool( this.paicard ) ) {
				this.bot_name = new Txt().improper().str( "MULEbot (" ).item( suffix ).str( ")" ).ToString();
			} else {
				this.name = new Txt().improper().str( "MULEbot (" ).item( suffix ).str( ")" ).ToString();
			}
			return;
		}

		// Function from file: mulebot.dm
		public override dynamic Destroy(  ) {
			this.unload( 0 );
			GlobalFuncs.qdel( this.wires );
			this.wires = null;
			return base.Destroy();
		}

		// Function from file: mulebot.dm
		[Verb]
		[VerbInfo( name: "Resist", group: "IC" )]
		public override void resist(  ) {
			Lang13.SuperCall();

			if ( Lang13.Bool( this.load ) ) {
				this.unload();
			}
			return;
		}

	}

}