// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Bot_Farmbot : Obj_Machinery_Bot {

		public int Max_Fertilizers = 10;
		public bool setting_water = true;
		public bool setting_refill = true;
		public bool setting_fertilize = true;
		public bool setting_weed = true;
		public bool setting_ignoreEmpty = false;
		public Obj target = null;
		public dynamic mode = null;
		public dynamic tank = null;
		public dynamic path = new ByTable();
		public int frustration = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.health = 50;
			this.maxhealth = 50;
			this.req_access = new ByTable(new object [] { 35 });
			this.icon_state = "farmbot0";
			this.layer = 5;
		}

		// Function from file: farmbot.dm
		public Obj_Machinery_Bot_Farmbot ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.icon_state = "farmbot" + this.on;
			Task13.Schedule( 4, (Task13.Closure)(() => {
				this.botcard = new Obj_Item_Weapon_Card_Id( this );
				this.botcard.access = this.req_access;

				if ( !Lang13.Bool( this.tank ) ) {
					this.tank = Lang13.FindIn( typeof(Obj_Structure_ReagentDispensers_Watertank), this.contents );
				}

				if ( !Lang13.Bool( this.tank ) ) {
					this.tank = new Obj_Structure_ReagentDispensers_Watertank( this );
				}
				return;
			}));
			return;
		}

		// Function from file: farmbot.dm
		public override dynamic process(  ) {
			
			if ( !this.on ) {
				return null;
			}

			if ( this.emagged != 0 && Rand13.PercentChance( 1 ) ) {
				Icon13.Flick( "farmbot_broke", this );
			}

			if ( this.mode == 5 ) {
				return null;
			}

			if ( !Lang13.Bool( this.mode ) || !( this.target != null ) || !false ) {
				this.mode = 0;
				this.target = null;

				if ( !Lang13.Bool( this.find_target() ) ) {
					this.mode = 5;
					Task13.Schedule( 100, (Task13.Closure)(() => {
						this.mode = 0;
						return;
					}));
					return null;
				}
			}

			if ( Lang13.Bool( this.mode ) && this.target != null ) {
				
				if ( Map13.GetDistance( this.target, this ) <= 1 || this.emagged != 0 && this.mode == 2 ) {
					this.frustration = 0;
					this.use_farmbot_item();
				} else {
					this.move_to_target();
				}
			}
			return null;
		}

		// Function from file: farmbot.dm
		public override void explode(  ) {
			dynamic Tsec = null;
			Obj_Item_Weapon_ReagentContainers_Glass_Fertilizer fert = null;
			Effect_Effect_System_SparkSpread s = null;

			this.on = false;
			this.visible_message( "<span class='danger'>" + this + " blows apart!</span>", 1 );
			Tsec = GlobalFuncs.get_turf( this );
			new Obj_Item_Weapon_Minihoe( Tsec );
			new Obj_Item_Weapon_ReagentContainers_Glass_Bucket( Tsec );
			new Obj_Item_Device_Assembly_ProxSensor( Tsec );
			new Obj_Item_Device_Analyzer_PlantAnalyzer( Tsec );

			if ( Lang13.Bool( this.tank ) ) {
				this.tank.loc = Tsec;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj_Item_Weapon_ReagentContainers_Glass_Fertilizer) )) {
				fert = _a;
				

				if ( Rand13.PercentChance( 50 ) ) {
					fert.loc = Tsec;
				}
			}

			if ( Rand13.PercentChance( 50 ) ) {
				new Obj_Item_RobotParts_LArm( Tsec );
			}
			s = new Effect_Effect_System_SparkSpread();
			s.set_up( 3, 1, this );
			s.start();
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: farmbot.dm
		public override void Emag( dynamic user = null ) {
			dynamic O = null;

			base.Emag( (object)(user) );

			if ( Lang13.Bool( user ) ) {
				GlobalFuncs.to_chat( user, "<span class='warning'>You short out " + this + "'s plant identifier circuits.</span>" );
			}
			Task13.Schedule( 0, (Task13.Closure)(() => {
				
				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchHearers( null, this ) )) {
					O = _a;
					
					O.show_message( "<span class='danger'>" + this + " buzzes oddly!</span>", 1 );
				}
				return;
			}));
			Icon13.Flick( "farmbot_broke", this );
			this.emagged = 1;
			this.on = true;
			this.icon_state = "farmbot" + this.on;
			this.target = null;
			this.mode = 5;
			Task13.Schedule( 150, (Task13.Closure)(() => {
				this.mode = 0;
				return;
			}));
			return;
		}

		// Function from file: farmbot.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Obj_Item_Weapon_Card_Id || a is Obj_Item_Device_Pda ) {
				
				if ( this.allowed( b ) ) {
					this.locked = !this.locked;
					GlobalFuncs.to_chat( b, "Controls are now " + ( this.locked ? "locked." : "unlocked." ) );
					this.updateUsrDialog();
				} else {
					GlobalFuncs.to_chat( b, "<span class='warning'>Access denied.</span>" );
				}
			} else if ( a is Obj_Item_Weapon_ReagentContainers_Glass_Fertilizer ) {
				
				if ( this.get_total_ferts() >= this.Max_Fertilizers ) {
					GlobalFuncs.to_chat( b, "The fertilizer storage is full!" );
					return null;
				}

				if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
					GlobalFuncs.to_chat( b, "You insert " + a + "." );
					Icon13.Flick( "farmbot_hatch", this );
					this.updateUsrDialog();
					return null;
				}
			} else {
				base.attackby( (object)(a), (object)(b), (object)(c) );
			}
			return null;
		}

		// Function from file: farmbot.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			Obj_Item_Weapon_ReagentContainers_Glass_Fertilizer fert = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return null;
			}
			Task13.User.machine = this;
			this.add_fingerprint( Task13.User );

			if ( Lang13.Bool( href_list["power"] ) && this.allowed( Task13.User ) ) {
				
				if ( this.on ) {
					this.turn_off();
				} else {
					this.turn_on();
				}
			} else if ( Lang13.Bool( href_list["water"] ) && !this.locked ) {
				this.setting_water = !this.setting_water;
			} else if ( Lang13.Bool( href_list["refill"] ) && !this.locked ) {
				this.setting_refill = !this.setting_refill;
			} else if ( Lang13.Bool( href_list["fertilize"] ) && !this.locked ) {
				this.setting_fertilize = !this.setting_fertilize;
			} else if ( Lang13.Bool( href_list["weed"] ) && !this.locked ) {
				this.setting_weed = !this.setting_weed;
			} else if ( Lang13.Bool( href_list["ignoreEmpty"] ) && !this.locked ) {
				this.setting_ignoreEmpty = !this.setting_ignoreEmpty;
			} else if ( Lang13.Bool( href_list["eject"] ) ) {
				Icon13.Flick( "farmbot_hatch", this );

				foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj_Item_Weapon_ReagentContainers_Glass_Fertilizer) )) {
					fert = _a;
					
					fert.loc = GlobalFuncs.get_turf( this );
				}
			}
			this.updateUsrDialog();
			return null;
		}

		// Function from file: farmbot.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic _default = null;

			dynamic dat = null;

			_default = base.attack_hand( (object)(a), (object)(b), (object)(c) );

			if ( Lang13.Bool( _default ) ) {
				return _default;
			}
			dat += "<TT><B>Automatic Hydroponic Assisting Unit v1.0</B></TT><BR><BR>";
			dat += new Txt( "Status: <A href='?src=" ).Ref( this ).str( ";power=1'>" ).item( ( this.on ? "On" : "Off" ) ).str( "</A><BR>" ).ToString();
			dat += "Water Tank: ";

			if ( Lang13.Bool( this.tank ) ) {
				dat += "[" + this.tank.reagents.total_volume + "/" + this.tank.reagents.maximum_volume + "]";
			} else {
				dat += "Error: Water Tank not Found";
			}
			dat += new Txt( "<br>Fertilizer Storage: <A href='?src=" ).Ref( this ).str( ";eject=1'>[" ).item( this.get_total_ferts() ).str( "/" ).item( this.Max_Fertilizers ).str( "]</a>" ).ToString();
			dat += "<br>Behaviour controls are " + ( this.locked ? "locked" : "unlocked" ) + "<hr>";

			if ( !this.locked ) {
				dat += "<TT>Watering Controls:<br>";
				dat += new Txt( " Water Plants : <A href='?src=" ).Ref( this ).str( ";water=1'>" ).item( ( this.setting_water ? "Yes" : "No" ) ).str( "</A><BR>" ).ToString();
				dat += new Txt( " Refill Watertank : <A href='?src=" ).Ref( this ).str( ";refill=1'>" ).item( ( this.setting_refill ? "Yes" : "No" ) ).str( "</A><BR>" ).ToString();
				dat += "<br>Fertilizer Controls:<br>";
				dat += new Txt( " Fertilize Plants : <A href='?src=" ).Ref( this ).str( ";fertilize=1'>" ).item( ( this.setting_fertilize ? "Yes" : "No" ) ).str( "</A><BR>" ).ToString();
				dat += "<br>Weeding Controls:<br>";
				dat += new Txt( " Weed Plants : <A href='?src=" ).Ref( this ).str( ";weed=1'>" ).item( ( this.setting_weed ? "Yes" : "No" ) ).str( "</A><BR>" ).ToString();
				dat += new Txt( "Ignore Empty Trays : <A href='?src=" ).Ref( this ).str( ";ignoreEmpty=1'>" ).item( ( this.setting_ignoreEmpty ? "Yes" : "No" ) ).str( "</A><BR>" ).ToString();
				dat += "</TT>";
			}
			Interface13.Browse( a, "<HEAD><TITLE>Farmbot v1.0 controls</TITLE></HEAD>" + dat, "window=autofarm" );
			GlobalFuncs.onclose( a, "autofarm" );
			return _default;
		}

		// Function from file: farmbot.dm
		public void refill(  ) {
			
			if ( !Lang13.Bool( this.tank ) || ( !Lang13.Bool( this.tank.reagents.total_volume ) ?1:0) > 600 || !( this.target is Obj_Structure_Sink ) ) {
				this.mode = 0;
				this.target = null;
				return;
			}
			this.mode = 5;
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/slosh.ogg", 25, 1 );
			this.visible_message( "<span class='notice'>" + this + " starts filling it's tank from " + this.target + ".</span>" );
			Task13.Schedule( 300, (Task13.Closure)(() => {
				this.visible_message( "<span class='notice'>" + this + " finishes filling it's tank.</span>" );
				this.mode = 0;
				((Reagents)this.tank.reagents).add_reagent( "water", this.tank.reagents.maximum_volume - this.tank.reagents.total_volume );
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/slosh.ogg", 25, 1 );
				return;
			}));
			return;
		}

		// Function from file: farmbot.dm
		public bool water(  ) {
			int splashAmount = 0;
			Obj tray = null;
			double b_amount = 0;

			
			if ( !Lang13.Bool( this.tank ) || ( this.tank.reagents.total_volume ??0) < 1 ) {
				this.mode = 0;
				this.target = null;
				return false;
			}
			this.icon_state = "farmbot_water";
			Task13.Schedule( 25, (Task13.Closure)(() => {
				this.icon_state = "farmbot" + this.on;
				return;
			}));

			if ( this.emagged != 0 ) {
				splashAmount = Num13.MinInt( 70, ((int)( this.tank.reagents.total_volume ??0 )) );
				this.visible_message( "<span class='warning'>" + this + " splashes " + this.target + " with a bucket of water!</span>" );
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/slosh.ogg", 25, 1 );

				if ( Rand13.PercentChance( 50 ) ) {
					((Reagents)this.tank.reagents).reaction( this.target, GlobalVars.TOUCH );
				} else {
					((Reagents)this.tank.reagents).reaction( this.target.loc, GlobalVars.TOUCH );
				}
				Task13.Schedule( 5, (Task13.Closure)(() => {
					((Reagents)this.tank.reagents).remove_any( splashAmount );
					return;
				}));
				this.mode = 5;
				Task13.Schedule( 60, (Task13.Closure)(() => {
					this.mode = 0;
					return;
				}));
			} else {
				tray = this.target;
				b_amount = ((Reagents)this.tank.reagents).get_reagent_amount( "water" ) ?1:0;

				if ( b_amount > 0 && Convert.ToDouble( ((dynamic)tray).waterlevel ) < 100 ) {
					
					if ( b_amount + Convert.ToDouble( ((dynamic)tray).waterlevel ) > 100 ) {
						b_amount = 100 - Convert.ToDouble( ((dynamic)tray).waterlevel );
					}
					((Reagents)this.tank.reagents).remove_reagent( "water", b_amount );
					((dynamic)tray).adjust_water( b_amount );
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/slosh.ogg", 25, 1 );
				}
				this.mode = 5;
				Task13.Schedule( 35, (Task13.Closure)(() => {
					this.mode = 0;
					return;
				}));
			}
			return false;
		}

		// Function from file: farmbot.dm
		public void weed(  ) {
			dynamic attackVerb = null;
			Obj human = null;
			int damage = 0;
			string dam_zone = null;
			dynamic affecting = null;
			dynamic armor = null;
			Obj tray = null;

			this.icon_state = "farmbot_hoe";
			Task13.Schedule( 25, (Task13.Closure)(() => {
				this.icon_state = "farmbot" + this.on;
				return;
			}));

			if ( this.emagged != 0 ) {
				this.mode = 5;
				Task13.Schedule( 60, (Task13.Closure)(() => {
					this.mode = 0;
					return;
				}));

				if ( Rand13.PercentChance( 30 ) ) {
					this.visible_message( "<span class='danger'>" + this + " swings wildly at " + this.target + " with a minihoe, missing completely!</span>" );
				} else {
					attackVerb = Rand13.Pick(new object [] { "slashed", "sliced", "cut", "clawed" });
					human = this.target;
					this.visible_message( "<span class='danger'>" + this + " " + attackVerb + " " + human + "!</span>" );
					damage = 15;
					dam_zone = Rand13.Pick(new object [] { "chest", "l_hand", "r_hand", "l_leg", "r_leg" });
					affecting = ((dynamic)human).get_organ( GlobalFuncs.ran_zone( dam_zone ) );
					armor = ((dynamic)human).run_armor_check( affecting, "melee" );
					((dynamic)human).apply_damage( damage, "brute", affecting, armor );
				}
			} else {
				this.mode = 5;
				Task13.Schedule( 35, (Task13.Closure)(() => {
					this.mode = 0;
					return;
				}));
				tray = this.target;
				((dynamic)tray).weedlevel = 0;
			}
			return;
		}

		// Function from file: farmbot.dm
		public bool fertilize( Obj_Item_Weapon_ReagentContainers_Glass_Fertilizer fert = null ) {
			Obj tray = null;

			
			if ( !( fert != null ) ) {
				this.target = null;
				this.mode = 0;
				return false;
			}

			if ( this.emagged != 0 ) {
				Task13.Schedule( 0, (Task13.Closure)(() => {
					fert.loc = this.loc;
					fert.throw_at( this.target, 16, 3 );
					return;
				}));
				this.visible_message( "<span class='danger'>" + this + " launches " + fert.name + " at " + this.target.name + "!</span>" );
				Icon13.Flick( "farmbot_broke", this );
				Task13.Schedule( 60, (Task13.Closure)(() => {
					this.mode = 0;
					this.target = null;
					return;
				}));
				return true;
			} else {
				tray = this.target;
				((dynamic)tray).nutrilevel = 10;
				((Reagents)fert.reagents).trans_to( tray, fert.reagents.total_volume );
				GlobalFuncs.qdel( fert );
				fert = null;
				this.icon_state = "farmbot_fertile";
				this.mode = 5;
				Task13.Schedule( 35, (Task13.Closure)(() => {
					this.mode = 0;
					this.target = null;
					return;
				}));
				Task13.Schedule( 25, (Task13.Closure)(() => {
					this.icon_state = "farmbot" + this.on;
					return;
				}));
				return true;
			}
		}

		// Function from file: farmbot.dm
		public void move_to_target(  ) {
			Tile dest = null;
			dynamic spot = null;

			
			if ( this.frustration > 8 ) {
				this.target = null;
				this.mode = 0;
				this.frustration = 0;
				this.path = new ByTable();
			}

			if ( !Lang13.Bool( this.path ) ) {
				this.path = new ByTable();
			}

			if ( this.target != null && this.path.len != 0 && Map13.GetDistance( this.target, this.path[this.path.len] ) > 2 ) {
				this.path = new ByTable();
			}

			if ( this.target != null && this.path.len == 0 && Map13.GetDistance( this, this.target ) > 1 ) {
				Task13.Schedule( 0, (Task13.Closure)(() => {
					dest = Map13.GetStepTowardsSimple( this.target, this );
					this.path = GlobalFuncs.AStar( this.loc, dest, typeof(Tile).GetMethod( "CardinalTurfsWithAccess" ), typeof(Tile).GetMethod( "Distance" ), 0, 30, null, null, this.botcard );

					if ( Lang13.Bool( this.path ) && this.path.len == 0 ) {
						
						foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRangeExcludeThis( this.target, 1 ) )) {
							spot = _a;
							

							if ( spot == dest ) {
								continue;
							}

							if ( spot.density ) {
								continue;
							}
							this.path = GlobalFuncs.AStar( this.loc, spot, typeof(Tile).GetMethod( "CardinalTurfsWithAccess" ), typeof(Tile).GetMethod( "Distance" ), 0, 30, null, null, this.botcard );
							this.path = GlobalFuncs.reverseRange( this.path );

							if ( this.path.len > 0 ) {
								break;
							}
						}

						if ( this.path.len == 0 ) {
							this.target = null;
							this.mode = 0;
						}
					}
					return;
				}));
				return;
			}

			if ( this.path.len > 0 && this.target != null ) {
				Map13.StepTowards( this, this.path[1], 0 );
				this.path -= this.path[1];
				Task13.Schedule( 3, (Task13.Closure)(() => {
					
					if ( this.path.len != 0 ) {
						Map13.StepTowards( this, this.path[1], 0 );
						this.path -= this.path[1];
					}
					return;
				}));
			}

			if ( this.path.len > 8 && this.target != null ) {
				this.frustration++;
			}
			return;
		}

		// Function from file: farmbot.dm
		public int GetNeededMode( Obj_Machinery_PortableAtmospherics_Hydroponics tray = null ) {
			
			if ( tray.dead ) {
				return 0;
			}

			if ( !this.setting_ignoreEmpty && !( tray.seed != null ) ) {
				return 0;
			}

			if ( this.setting_water && tray.waterlevel <= 10 && Lang13.Bool( this.tank ) && ( this.tank.reagents.total_volume ??0) >= 1 ) {
				return 1;
			}

			if ( this.setting_weed && tray.weedlevel >= 5 ) {
				return 3;
			}

			if ( this.setting_fertilize && tray.nutrilevel <= 2 && this.get_total_ferts() != 0 && ( !( tray.seed != null ) || !Lang13.Bool( tray.seed.hematophage ) ) ) {
				return 2;
			}
			return 0;
		}

		// Function from file: farmbot.dm
		public dynamic find_target(  ) {
			Mob_Living_Carbon_Human human = null;
			ByTable options = null;
			Obj_Structure_Sink source = null;
			Obj_Machinery_PortableAtmospherics_Hydroponics tray = null;
			int newMode = 0;

			
			if ( this.emagged != 0 ) {
				
				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInView( this, 7 ), typeof(Mob_Living_Carbon_Human) )) {
					human = _a;
					

					if ( human.stat == 2 ) {
						continue;
					}
					options = new ByTable(new object [] { 3 });

					if ( this.get_total_ferts() != 0 ) {
						options.Add( 2 );
					}

					if ( Lang13.Bool( this.tank ) && ( this.tank.reagents.total_volume ??0) >= 1 ) {
						options.Add( 1 );
					}
					this.mode = Rand13.PickFromTable( options );
					this.target = human;
					return this.mode;
				}
				return 0;
			} else {
				
				if ( this.setting_refill && Lang13.Bool( this.tank ) && ( this.tank.reagents.total_volume ??0) < 100 ) {
					
					foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInView( this, 7 ), typeof(Obj_Structure_Sink) )) {
						source = _b;
						
						this.target = source;
						this.mode = 4;
						return 1;
					}
				}

				foreach (dynamic _c in Lang13.Enumerate( Map13.FetchInView( this, 7 ), typeof(Obj_Machinery_PortableAtmospherics_Hydroponics) )) {
					tray = _c;
					
					newMode = this.GetNeededMode( tray );

					if ( newMode != 0 ) {
						this.mode = newMode;
						this.target = tray;
						return 1;
					}
				}
				return 0;
			}
		}

		// Function from file: farmbot.dm
		public bool use_farmbot_item(  ) {
			Obj_Item_Weapon_ReagentContainers_Glass_Fertilizer fert = null;
			Obj_Item_Weapon_ReagentContainers_Glass_Fertilizer nut = null;

			
			if ( !( this.target != null ) ) {
				this.mode = 0;
				return false;
			}

			if ( this.emagged != 0 && !( this.target is Mob ) ) {
				this.mode = 0;
				this.target = null;
				return false;
			}

			if ( !( this.emagged != 0 ) && !( this.target is Obj_Machinery_PortableAtmospherics_Hydroponics ) && !( this.target is Obj_Structure_Sink ) ) {
				this.mode = 0;
				this.target = null;
				return false;
			}

			if ( this.mode == 2 ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj_Item_Weapon_ReagentContainers_Glass_Fertilizer) )) {
					nut = _a;
					
					fert = nut;
					break;
				}

				if ( !( fert != null ) ) {
					this.target = null;
					this.mode = 0;
					return false;
				}
				this.fertilize( fert );
			}

			if ( this.mode == 3 ) {
				this.weed();
			}

			if ( this.mode == 1 ) {
				this.water();
			}

			if ( this.mode == 4 ) {
				this.refill();
			}
			return false;
		}

		// Function from file: farmbot.dm
		public int get_total_ferts(  ) {
			int total_fert = 0;
			Obj_Item_Weapon_ReagentContainers_Glass_Fertilizer fert = null;

			total_fert = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj_Item_Weapon_ReagentContainers_Glass_Fertilizer) )) {
				fert = _a;
				
				total_fert++;
			}
			return total_fert;
		}

		// Function from file: farmbot.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: farmbot.dm
		public override void turn_off(  ) {
			base.turn_off();
			this.path = new ByTable();
			this.icon_state = "farmbot" + this.on;
			this.updateUsrDialog();
			return;
		}

		// Function from file: farmbot.dm
		public override bool turn_on(  ) {
			bool _default = false;

			_default = base.turn_on();
			this.icon_state = "farmbot" + this.on;
			this.updateUsrDialog();
			return _default;
		}

		// Function from file: farmbot.dm
		public override dynamic Bump( Obj Obstacle = null, dynamic yes = null ) {
			Obj D = null;

			Task13.Schedule( 0, (Task13.Closure)(() => {
				
				if ( Obstacle is Obj_Machinery_Door && !( this.botcard == null ) ) {
					D = Obstacle;

					if ( !( D is Obj_Machinery_Door_Firedoor ) && D.check_access( this.botcard ) ) {
						((dynamic)D).open();
						this.frustration = 0;
					}
				}
				return;
				return;
			}));
			return null;
		}

	}

}