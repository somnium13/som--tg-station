// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Bot_Secbot : Obj_Machinery_Bot {

		public dynamic target = null;
		public string oldtarget_name = null;
		public int threatlevel = 0;
		public Ent_Static target_lastloc = null;
		public int last_found = 0;
		public int frustration = 0;
		public bool check_records = true;
		public bool idcheck = false;
		public bool weaponscheck = false;
		public bool arrest_type = false;
		public bool declare_arrests = false;
		public int next_harm_time = 0;
		public int mode = 0;
		public bool auto_patrol = false;
		public int beacon_freq = 1445;
		public int control_freq = 1447;
		public dynamic patrol_target = null;
		public string new_destination = null;
		public string destination = null;
		public string next_destination = null;
		public dynamic path = new ByTable();
		public int blockcount = 0;
		public int awaiting_beacon = 0;
		public string nearest_beacon = null;
		public Ent_Static nearest_beacon_loc = null;
		public bool weapons_check = false;
		public ByTable safe_weapons = new ByTable(new object [] { 
											typeof(Obj_Item_Weapon_Gun_Energy_Laser_Bluetag), 
											typeof(Obj_Item_Weapon_Gun_Energy_Laser_Redtag), 
											typeof(Obj_Item_Weapon_Gun_Energy_Laser_Practice), 
											typeof(Obj_Item_Weapon_Gun_Hookshot)
										 });

		protected override void __FieldInit() {
			base.__FieldInit();

			this.health = 25;
			this.maxhealth = 25;
			this.fire_dam_coeff = 061;
			this.brute_dam_coeff = 0.5;
			this.req_one_access = new ByTable(new object [] { 1, 4 });
			this.light_color = "#FA8282";
			this.icon_state = "secbot0";
			this.layer = 5;
		}

		// Function from file: secbot.dm
		public Obj_Machinery_Bot_Secbot ( dynamic loc = null ) : base( (object)(loc) ) {
			Job_Detective J = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.icon_state = "secbot" + this.on;
			Task13.Schedule( 3, (Task13.Closure)(() => {
				this.botcard = new Obj_Item_Weapon_Card_Id( this );
				J = new Job_Detective();
				this.botcard.access = J.get_access();

				if ( GlobalVars.radio_controller != null ) {
					GlobalVars.radio_controller.add_object( this, this.control_freq, GlobalVars.RADIO_SECBOT );
					GlobalVars.radio_controller.add_object( this, this.beacon_freq, GlobalVars.RADIO_NAVBEACONS );
				}
				return;
			}));
			return;
		}

		// Function from file: secbot.dm
		public override void declare(  ) {
			dynamic location = null;

			location = GlobalFuncs.get_area( this );
			this.declare_message = new Txt( "<span class='info'>" ).icon( this ).str( " " ).item( this.name ).str( " is " ).item( ( this.arrest_type ? "detaining" : "arresting" ) ).str( " level " ).item( this.threatlevel ).str( " scumbag <b>" ).item( this.target ).str( "</b> in <b>" ).item( location ).str( "</b></span>" ).ToString();
			base.declare();
			return;
		}

		// Function from file: secbot.dm
		public override dynamic attack_alien( Mob user = null ) {
			base.attack_alien( user );

			if ( !( this.target is Mob_Living_Carbon_Alien ) ) {
				this.target = user;
				this.mode = 1;
			}
			return null;
		}

		// Function from file: secbot.dm
		public override void explode(  ) {
			dynamic Tsec = null;
			Obj_Item_Weapon_SecbotAssembly Sa = null;
			Effect_Effect_System_SparkSpread s = null;
			Game_Data O = null;

			Map13.WalkTowards( this, 0, 0, 0 );
			this.visible_message( "<span class='danger'>" + this + " blows apart!</span>", 1 );
			Tsec = GlobalFuncs.get_turf( this );
			Sa = new Obj_Item_Weapon_SecbotAssembly( Tsec );
			Sa.build_step = 1;
			Sa.overlays.Add( new Image( "icons/obj/aibots.dmi", "hs_hole" ) );
			Sa.created_name = this.name;
			new Obj_Item_Device_Assembly_ProxSensor( Tsec );
			new Obj_Item_Weapon_Melee_Baton_Loaded( Tsec );

			if ( Rand13.PercentChance( 50 ) ) {
				new Obj_Item_RobotParts_LArm( Tsec );
			}
			s = new Effect_Effect_System_SparkSpread();
			s.set_up( 3, 1, this );
			s.start();
			O = GlobalFuncs.getFromPool( typeof(Obj_Effect_Decal_Cleanable_Blood_Oil), this.loc );
			((dynamic)O).New( ((dynamic)O).loc );
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: secbot.dm
		public override dynamic Bump(Ent_Static Obstacle = null, dynamic yes = null) {
			Obj_Machinery_Door D = null;
			
			if ( Obstacle is Obj_Machinery_Door && !( this.botcard == null ) ) {
				D = (Obj_Machinery_Door)Obstacle;

				if ( !( D is Obj_Machinery_Door_Firedoor ) && D.check_access( this.botcard ) ) {
					((dynamic)D).open();
					this.frustration = 0;
				}
			} else if ( Obstacle is Mob_Living && !Lang13.Bool( this.anchored ) ) {
				this.loc = Obstacle.loc;
				this.frustration = 0;
			}
			return null;
		}

		// Function from file: secbot.dm
		public override bool receive_signal( Game_Data signal = null, bool? receive_method = null, dynamic receive_param = null ) {
			string recv = null;
			dynamic valid = null;
			int dist = 0;

			
			if ( !this.on ) {
				return false;
			}
			recv = ((dynamic)signal).data["command"];

			if ( recv == "bot_status" ) {
				this.send_status();
			}

			if ( ((dynamic)signal).data["active"] == this ) {
				
				switch ((string)( recv )) {
					case "stop":
						this.mode = 0;
						this.auto_patrol = false;
						return false;
						break;
					case "go":
						this.mode = 0;
						this.auto_patrol = true;
						return false;
						break;
					case "summon":
						this.patrol_target = ((dynamic)signal).data["target"];
						this.next_destination = this.destination;
						this.destination = null;
						this.awaiting_beacon = 0;
						this.mode = 6;
						this.calc_path();
						this.speak( "Responding." );
						return false;
						break;
				}
			}
			recv = ((dynamic)signal).data["beacon"];
			valid = ((dynamic)signal).data["patrol"];

			if ( !Lang13.Bool( recv ) || !Lang13.Bool( valid ) ) {
				return false;
			}

			if ( recv == this.new_destination ) {
				this.destination = this.new_destination;
				this.patrol_target = ((dynamic)signal).source.loc;
				this.next_destination = ((dynamic)signal).data["next_patrol"];
				this.awaiting_beacon = 0;
			} else if ( this.new_destination == "__nearest__" ) {
				dist = Map13.GetDistance( this, ((dynamic)signal).source.loc );

				if ( Lang13.Bool( this.nearest_beacon ) ) {
					
					if ( dist > 1 && dist < Map13.GetDistance( this, this.nearest_beacon_loc ) ) {
						this.nearest_beacon = recv;
						this.nearest_beacon_loc = ((dynamic)signal).source.loc;
						return false;
					} else {
						return false;
					}
				} else if ( dist > 1 ) {
					this.nearest_beacon = recv;
					this.nearest_beacon_loc = ((dynamic)signal).source.loc;
				}
			}
			return false;
		}

		// Function from file: secbot.dm
		public bool check_for_weapons( Base_Data slot_item = null ) {
			
			if ( slot_item is Obj_Item_Weapon_Gun || slot_item is Obj_Item_Weapon_Melee ) {
				
				if ( !this.safe_weapons.Contains( slot_item.type ) ) {
					return true;
				}
			}
			return false;
		}

		// Function from file: secbot.dm
		public void speak( string message = null ) {
			this.visible_message( "<span class='game say'><span class='name'>" + this + "</span> beeps, \"" + message + "\"", null, null, "<span class='game say'><span class='name'>" + this + "</span> beeps, \"" + Rand13.Pick(new object [] { "Wait! Let's be friends!", "Wait for me!", "You're so cool!", "Who's your favourite pony?", "I-It's not like I like you or anything...", "Wanna see a magic trick?", "Let's go have fun, assistant-kun~" }) + "\"" );
			return;
		}

		// Function from file: secbot.dm
		public int assess_perp( Mob_Living perp = null ) {
			int threatcount = 0;
			Data_Record E = null;
			string perpname = null;
			dynamic id = null;
			Data_Record R = null;

			threatcount = 0;

			if ( this.emagged == 2 ) {
				return 10;
			}

			if ( this.idcheck && !this.allowed( perp ) ) {
				
				if ( perp.l_hand is Obj_Item_Weapon_Gun || perp.l_hand is Obj_Item_Weapon_Melee ) {
					
					if ( !( perp.l_hand is Obj_Item_Weapon_Gun_Energy_Laser_Bluetag ) && !( perp.l_hand is Obj_Item_Weapon_Gun_Energy_Laser_Redtag ) && !( perp.l_hand is Obj_Item_Weapon_Gun_Energy_Laser_Practice ) ) {
						threatcount += 4;
					}
				}

				if ( perp.r_hand is Obj_Item_Weapon_Gun || perp.r_hand is Obj_Item_Weapon_Melee ) {
					
					if ( !( perp.r_hand is Obj_Item_Weapon_Gun_Energy_Laser_Bluetag ) && !( perp.r_hand is Obj_Item_Weapon_Gun_Energy_Laser_Redtag ) && !( perp.r_hand is Obj_Item_Weapon_Gun_Energy_Laser_Practice ) ) {
						threatcount += 4;
					}
				}

				if ( ((dynamic)perp).belt is Obj_Item_Weapon_Gun || ((dynamic)perp).belt is Obj_Item_Weapon_Melee ) {
					
					if ( !( ((dynamic)perp).belt is Obj_Item_Weapon_Gun_Energy_Laser_Bluetag ) && !( ((dynamic)perp).belt is Obj_Item_Weapon_Gun_Energy_Laser_Redtag ) && !( ((dynamic)perp).belt is Obj_Item_Weapon_Gun_Energy_Laser_Practice ) ) {
						threatcount += 2;
					}
				}

				if ( ((dynamic)perp).wear_suit is Obj_Item_Clothing_Suit_Wizrobe ) {
					threatcount += 2;
				}

				if ( perp.dna != null && Lang13.Bool( perp.dna.mutantrace ) && perp.dna.mutantrace != "none" ) {
					threatcount += 2;
				}

				if ( Lang13.Bool( ((dynamic)perp).wear_id ) && ((Obj_Item)((dynamic)perp).wear_id).GetID() is Obj_Item_Weapon_Card_Id_Syndicate ) {
					threatcount -= 2;
				}
			}

			if ( this.check_records ) {
				
				foreach (dynamic _b in Lang13.Enumerate( GlobalVars.data_core.general, typeof(Data_Record) )) {
					E = _b;
					
					perpname = perp.name;

					if ( Lang13.Bool( ((dynamic)perp).wear_id ) ) {
						id = ((Obj_Item)((dynamic)perp).wear_id).GetID();

						if ( Lang13.Bool( id ) ) {
							perpname = id.registered_name;
						}
					}

					if ( E.fields["name"] == perpname ) {
						
						foreach (dynamic _a in Lang13.Enumerate( GlobalVars.data_core.security, typeof(Data_Record) )) {
							R = _a;
							

							if ( R.fields["id"] == E.fields["id"] && R.fields["criminal"] == "*Arrest*" ) {
								threatcount = 4;
								break;
							}
						}
					}
				}
			}
			return threatcount;
		}

		// Function from file: secbot.dm
		public void look_for_perp(  ) {
			Mob_Living M = null;
			Mob_Living C = null;

			this.anchored = 0;

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInView( this, 7 ), typeof(Mob_Living) )) {
				M = _a;
				

				if ( M is Mob_Living_Carbon ) {
					C = M;

					if ( Lang13.Bool( C.stat ) || Lang13.Bool( ((dynamic)C).handcuffed ) ) {
						continue;
					}

					if ( C.name == this.oldtarget_name && Game13.time < this.last_found + 100 ) {
						continue;
					}

					if ( C is Mob_Living_Carbon_Human ) {
						this.threatlevel = this.assess_perp( C );
					} else if ( C is Mob_Living_Carbon_Monkey && GlobalVars.ticker.mode.infected_monkeys.Contains( C.viruses.Contains( typeof(Disease_JungleFever) ) || C.mind != null ) ) {
						this.threatlevel = 666;
					} else {
						continue;
					}
				} else {
					continue;
				}

				if ( !( this.threatlevel != 0 ) ) {
					continue;
				} else if ( this.threatlevel >= 4 ) {
					this.target = M;
					this.oldtarget_name = M.name;
					this.speak( "Level " + this.threatlevel + " infraction alert!" );
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), Rand13.Pick(new object [] { "sound/voice/bcriminal.ogg", "sound/voice/bjustice.ogg", "sound/voice/bfreeze.ogg" }), 50, 0 );
					this.visible_message( "<b>" + this + "</b> points at " + M.name + "!" );
					this.mode = 1;
					Task13.Schedule( 0, (Task13.Closure)(() => {
						this.process();
						return;
					}));
					break;
				} else {
					continue;
				}
			}
			return;
		}

		// Function from file: secbot.dm
		public void calc_path( Ent_Static avoid = null ) {
			this.path = GlobalFuncs.AStar( this.loc, this.patrol_target, typeof(Tile).GetMethod( "CardinalTurfsWithAccess" ), typeof(Tile).GetMethod( "Distance_cardinal" ), 0, 120, null, null, this.botcard, avoid );

			if ( !Lang13.Bool( this.path ) ) {
				this.path = new ByTable();
			}
			return;
		}

		// Function from file: secbot.dm
		public void send_status(  ) {
			ByTable kv = null;

			kv = new ByTable().Set( "type", "secbot" ).Set( "name", this.name ).Set( "loca", this.loc.loc ).Set( "mode", this.mode );
			this.post_signal_multiple( this.control_freq, kv );
			return;
		}

		// Function from file: secbot.dm
		public void post_signal_multiple( int freq = 0, ByTable keyval = null ) {
			dynamic frequency = null;
			Game_Data signal = null;

			frequency = GlobalVars.radio_controller.return_frequency( freq );

			if ( !Lang13.Bool( frequency ) ) {
				return;
			}
			signal = GlobalFuncs.getFromPool( typeof(Signal) );
			((dynamic)signal).source = this;
			((dynamic)signal).transmission_method = 1;
			((dynamic)signal).data = keyval;

			if ( Lang13.Bool( ((dynamic)signal).data["findbeacon"] ) ) {
				new ByTable().Set( 1, this ).Set( 2, signal ).Set( "filter", GlobalVars.RADIO_NAVBEACONS ).Apply( Lang13.BindFunc( frequency, "post_signal" ) );
			} else if ( ((dynamic)signal).data["type"] == "secbot" ) {
				new ByTable().Set( 1, this ).Set( 2, signal ).Set( "filter", GlobalVars.RADIO_SECBOT ).Apply( Lang13.BindFunc( frequency, "post_signal" ) );
			} else {
				frequency.post_signal( this, signal );
			}
			return;
		}

		// Function from file: secbot.dm
		public void post_signal( int freq = 0, string key = null, string value = null ) {
			this.post_signal_multiple( freq, new ByTable().Set( "" + key, value ) );
			return;
		}

		// Function from file: secbot.dm
		public void set_destination( string new_dest = null ) {
			this.new_destination = new_dest;
			this.post_signal( this.beacon_freq, "findbeacon", "patrol" );
			this.awaiting_beacon = 1;
			return;
		}

		// Function from file: secbot.dm
		public void at_patrol_target(  ) {
			this.find_patrol_target();
			return;
		}

		// Function from file: secbot.dm
		public void find_nearest_beacon(  ) {
			this.nearest_beacon = null;
			this.new_destination = "__nearest__";
			this.post_signal( this.beacon_freq, "findbeacon", "patrol" );
			this.awaiting_beacon = 1;
			Task13.Schedule( 10, (Task13.Closure)(() => {
				this.awaiting_beacon = 0;

				if ( Lang13.Bool( this.nearest_beacon ) ) {
					this.set_destination( this.nearest_beacon );
				} else {
					this.auto_patrol = false;
					this.mode = 0;
					this.speak( "Disengaging patrol mode." );
					this.send_status();
				}
				return;
			}));
			return;
		}

		// Function from file: secbot.dm
		public void find_patrol_target(  ) {
			this.send_status();

			if ( this.awaiting_beacon != 0 ) {
				this.awaiting_beacon++;

				if ( this.awaiting_beacon > 5 ) {
					this.find_nearest_beacon();
				}
				return;
			}

			if ( Lang13.Bool( this.next_destination ) ) {
				this.set_destination( this.next_destination );
			} else {
				this.find_nearest_beacon();
			}
			return;
		}

		// Function from file: secbot.dm
		public void patrol_step(  ) {
			Ent_Static next = null;
			dynamic moved = null;

			
			if ( this.loc == this.patrol_target ) {
				this.at_patrol_target();
				return;
			} else if ( this.path.len > 0 && Lang13.Bool( this.patrol_target ) ) {
				next = this.path[1];

				if ( next == this.loc ) {
					this.path -= next;
					return;
				}

				if ( next is Tile_Simulated ) {
					Map13.StepTowardsSimple( this, next );
					moved = null;

					if ( Lang13.Bool( moved ) ) {
						this.blockcount = 0;
						this.path -= this.loc;
						this.look_for_perp();
					} else {
						this.blockcount++;

						if ( this.blockcount > 5 ) {
							Task13.Schedule( 2, (Task13.Closure)(() => {
								this.calc_path( next );

								if ( this.path.len == 0 ) {
									this.find_patrol_target();
								} else {
									this.blockcount = 0;
								}
								return;
							}));
							return;
						}
						return;
					}
				} else {
					this.mode = 0;
					return;
				}
			} else {
				this.mode = 4;
			}
			return;
		}

		// Function from file: secbot.dm
		public override dynamic process(  ) {
			dynamic M = null;
			int maxstuns = 0;
			dynamic location = null;
			dynamic S = null;
			int olddist = 0;
			dynamic C = null;
			dynamic C2 = null;

			
			if ( !this.on ) {
				return null;
			}

			switch ((int)( this.mode )) {
				case 0:
					Map13.WalkTowards( this, 0, 0, 0 );
					this.look_for_perp();

					if ( !( this.mode != 0 ) && this.auto_patrol ) {
						this.mode = 4;
					}
					break;
				case 1:
					
					if ( this.frustration >= 8 ) {
						this.target = null;
						this.last_found = Game13.time;
						this.frustration = 0;
						this.mode = 0;
						Map13.WalkTowards( this, 0, 0, 0 );
					}

					if ( Lang13.Bool( this.target ) ) {
						
						if ( !( this.target.loc is Tile ) ) {
							return null;
						}

						if ( Map13.GetDistance( this, this.target ) <= 1 ) {
							
							if ( this.target is Mob_Living_Carbon ) {
								GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/weapons/Egloves.ogg", 50, 1, -1 );
								this.icon_state = "secbot-c";
								Task13.Schedule( 2, (Task13.Closure)(() => {
									this.icon_state = "secbot" + this.on;
									return;
								}));
								M = this.target;
								maxstuns = 4;

								if ( M is Mob_Living_Carbon_Human ) {
									
									if ( Convert.ToDouble( M.stuttering ) < 10 && !Lang13.Bool( M.mutations.Contains( 4 ) ) ) {
										M.stuttering = 10;
									}
									((Mob)M).Stun( 10 );
									((Mob)M).Weaken( 10 );
								} else {
									((Mob)M).Weaken( 10 );
									M.stuttering = 10;
									((Mob)M).Stun( 10 );
								}

								if ( this.declare_arrests ) {
									this.declare();
								}
								((Ent_Static)this.target).visible_message( "<span class='danger'>" + this.target + " has been stunned by " + this + "!</span>", "<span class='userdanger'>You have been stunned by " + this + "!</span>" );
								maxstuns--;

								if ( maxstuns <= 0 ) {
									this.target = null;
								}

								if ( this.declare_arrests ) {
									location = GlobalFuncs.get_area( this );
									GlobalFuncs.broadcast_security_hud_message( "" + this.name + " is " + ( this.arrest_type ? "detaining" : "arresting" ) + " level " + this.threatlevel + " suspect <b>" + this.target + "</b> in <b>" + location + "</b>", this );
								}
								this.mode = 2;
								this.anchored = 1;
								this.target_lastloc = M.loc;
								return null;
							} else if ( this.target is Mob_Living_SimpleAnimal ) {
								
								if ( Game13.time > this.next_harm_time ) {
									this.next_harm_time = Game13.time + 15;
									GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/weapons/Egloves.ogg", 50, 1, -1 );
									this.visible_message( "<span class='danger'>" + this + " beats " + this.target + " with the stun baton!</span>" );
									this.icon_state = "secbot-c";
									Task13.Schedule( 2, (Task13.Closure)(() => {
										this.icon_state = "secbot" + this.on;
										return;
									}));
									S = this.target;

									if ( Lang13.Bool( S ) && S is Mob_Living_SimpleAnimal ) {
										((Mob)S).AdjustStunned( 10 );
										((Mob_Living)S).adjustBruteLoss( 15 );

										if ( Lang13.Bool( S.stat ) ) {
											this.frustration = 8;
											GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), Rand13.Pick(new object [] { "sound/voice/bgod.ogg", "sound/voice/biamthelaw.ogg", "sound/voice/bsecureday.ogg", "sound/voice/bradio.ogg", "sound/voice/bcreep.ogg" }), 50, 0 );
										}
									}
								}
							}
						} else {
							olddist = Map13.GetDistance( this, this.target );
							Map13.WalkTowards( this, this.target, 1, 4 );

							if ( Map13.GetDistance( this, this.target ) >= olddist ) {
								this.frustration++;
							} else {
								this.frustration = 0;
							}
						}
					} else {
						this.frustration = 8;
					}
					break;
				case 2:
					
					if ( Map13.GetDistance( this, this.target ) > 1 || this.target.loc != this.target_lastloc && this.target.weakened < 2 ) {
						this.anchored = 0;
						this.mode = 1;
						return null;
					}

					if ( this.target is Mob_Living_Carbon && !( this.target is Mob_Living_Carbon_Alien ) ) {
						C = this.target;

						if ( !Lang13.Bool( C.handcuffed ) && !this.arrest_type ) {
							GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/weapons/handcuffs.ogg", 30, 1, -2 );
							this.mode = 3;
							this.visible_message( "<span class='danger'>" + this + " is trying to put handcuffs on " + this.target + "!</span>", "<span class='danger'>" + this + " is trying to cut " + this.target + "'s hands off!</span>" );
							Task13.Schedule( 60, (Task13.Closure)(() => {
								
								if ( this.Adjacent( this.target ) ) {
									
									if ( this.target is Mob_Living_Carbon && !( this.target is Mob_Living_Carbon_Alien ) ) {
										C = this.target;

										if ( !Lang13.Bool( C.handcuffed ) ) {
											C.handcuffed = new Obj_Item_Weapon_Handcuffs( this.target );
											((Mob)C).update_inv_handcuffed();
										}
									}
									this.mode = 0;
									this.target = null;
									this.anchored = 0;
									this.last_found = Game13.time;
									this.frustration = 0;
									GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), Rand13.Pick(new object [] { "sound/voice/bgod.ogg", "sound/voice/biamthelaw.ogg", "sound/voice/bsecureday.ogg", "sound/voice/bradio.ogg", "sound/voice/binsult.ogg", "sound/voice/bcreep.ogg" }), 50, 0 );
								}
								return;
							}));
						}
					} else {
						this.mode = 0;
						this.target = null;
						this.anchored = 0;
						this.last_found = Game13.time;
						this.frustration = 0;
					}
					break;
				case 3:
					
					if ( !Lang13.Bool( this.target ) || !( this.target is Mob_Living_Carbon ) ) {
						this.anchored = 0;
						this.mode = 0;
						return null;
					} else {
						C2 = this.target;

						if ( !Lang13.Bool( C2.handcuffed ) ) {
							this.anchored = 0;
							this.mode = 0;
							return null;
						}
					}
					break;
				case 4:
					
					if ( this.path != null ) {
						
						if ( this.path.len > 0 && Lang13.Bool( this.patrol_target ) ) {
							this.mode = 5;
							return null;
						} else if ( Lang13.Bool( this.patrol_target ) ) {
							Task13.Schedule( 0, (Task13.Closure)(() => {
								this.calc_path();

								if ( this.path.len == 0 ) {
									this.patrol_target = 0;
									return;
								}
								this.mode = 5;
								return;
							}));
						} else {
							this.find_patrol_target();
							this.speak( "Engaging patrol mode." );
						}
					}
					break;
				case 5:
					this.patrol_step();
					Task13.Schedule( 5, (Task13.Closure)(() => {
						
						if ( this.mode == 5 ) {
							this.patrol_step();
						}
						return;
					}));
					break;
				case 6:
					this.patrol_step();
					Task13.Schedule( 4, (Task13.Closure)(() => {
						
						if ( this.mode == 6 ) {
							this.patrol_step();
							Task13.Sleep( 4 );
							this.patrol_step();
						}
						return;
					}));
					break;
			}
			return null;
		}

		// Function from file: secbot.dm
		public override void Emag( dynamic user = null ) {
			dynamic O = null;

			base.Emag( (object)(user) );

			if ( this.open && !this.locked ) {
				
				if ( Lang13.Bool( user ) ) {
					GlobalFuncs.to_chat( user, "<span class='warning'>You short out " + this + "'s target assessment circuits.</span>" );
				}
				Task13.Schedule( 0, (Task13.Closure)(() => {
					
					foreach (dynamic _a in Lang13.Enumerate( Map13.FetchHearers( null, this ) )) {
						O = _a;
						
						O.show_message( "<span class='danger'>" + this + " buzzes oddly!</span>", 1 );
					}
					return;
				}));
				this.target = null;

				if ( Lang13.Bool( user ) ) {
					this.oldtarget_name = user.name;
				}
				this.last_found = Game13.time;
				this.anchored = 0;
				this.emagged = 2;
				this.on = true;
				this.icon_state = "secbot" + this.on;
				this.mode = 0;
			}
			return;
		}

		// Function from file: secbot.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Obj_Item_Weapon_Card_Id || a is Obj_Item_Device_Pda ) {
				
				if ( this.allowed( b ) && !this.open && !( this.emagged != 0 ) ) {
					this.locked = !this.locked;
					GlobalFuncs.to_chat( b, "Controls are now " + ( this.locked ? "locked." : "unlocked." ) );
				} else {
					
					if ( this.emagged != 0 ) {
						GlobalFuncs.to_chat( b, "<span class='warning'>ERROR</span>" );
					}

					if ( this.open ) {
						GlobalFuncs.to_chat( b, "<span class='warning'>Please close the access panel before locking it.</span>" );
					} else {
						GlobalFuncs.to_chat( b, "<span class='warning'>Access denied.</span>" );
					}
				}
			} else {
				base.attackby( (object)(a), (object)(b), (object)(c) );
			}

			if ( a is Obj_Item_Weapon_Weldingtool && b.a_intent != "harm" ) {
				return null;
			}

			if ( !( a is Obj_Item_Weapon_Screwdriver ) && Lang13.Bool( a.force ) && !Lang13.Bool( this.target ) ) {
				this.threatlevel = ((Mob)b).assess_threat( this );
				this.threatlevel += 6;

				if ( this.threatlevel > 0 ) {
					this.target = b;
					this.mode = 1;
				}
			}
			return null;
		}

		// Function from file: secbot.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return 1;
			}
			Task13.User.set_machine( this );
			this.add_fingerprint( Task13.User );

			if ( Lang13.Bool( href_list["power"] ) && this.allowed( Task13.User ) ) {
				
				if ( this.on ) {
					this.turn_off();
				} else {
					this.turn_on();
				}
				return null;
			}

			dynamic _a = href_list["operation"]; // Was a switch-case, sorry for the mess.
			if ( _a=="idcheck" ) {
				this.idcheck = !this.idcheck;
				this.updateUsrDialog();
			} else if ( _a=="weaponscheck" ) {
				this.weaponscheck = !this.weaponscheck;
				this.updateUsrDialog();
			} else if ( _a=="ignorerec" ) {
				this.check_records = !this.check_records;
				this.updateUsrDialog();
			} else if ( _a=="switchmode" ) {
				this.arrest_type = !this.arrest_type;
				this.updateUsrDialog();
			} else if ( _a=="patrol" ) {
				this.auto_patrol = !this.auto_patrol;
				this.mode = 0;
				this.updateUsrDialog();
			} else if ( _a=="declarearrests" ) {
				this.declare_arrests = !this.declare_arrests;
				this.updateUsrDialog();
			}
			return null;
		}

		// Function from file: secbot.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			dynamic dat = null;

			dat += "\n<TT><B>Automatic Security Unit v1.3</B></TT><BR><BR>\nStatus: " + new Txt( "<A href='?src=" ).Ref( this ).str( ";power=1'>" ).item( ( this.on ? "On" : "Off" ) ).str( "</A>" ).ToString() + "<BR>\nBehaviour controls are " + ( this.locked ? "locked" : "unlocked" ) + "<BR>\nMaintenance panel panel is " + ( this.open ? "opened" : "closed" );

			if ( !this.locked || user is Mob_Living_Silicon ) {
				dat += "<BR>\nArrest for No ID: " + new Txt( "<A href='?src=" ).Ref( this ).str( ";operation=idcheck'>" ).item( ( this.idcheck ? "Yes" : "No" ) ).str( "</A>" ).ToString() + " <BR>\nArrest for Unauthorized Weapons: " + new Txt( "<A href='?src=" ).Ref( this ).str( ";operation=weaponscheck'>" ).item( ( this.weaponscheck ? "Yes" : "No" ) ).str( "</A>" ).ToString() + "<BR>\nArrest for Warrant: " + new Txt( "<A href='?src=" ).Ref( this ).str( ";operation=ignorerec'>" ).item( ( this.check_records ? "Yes" : "No" ) ).str( "</A>" ).ToString() + "<BR>\n<BR>\nOperating Mode: " + new Txt( "<A href='?src=" ).Ref( this ).str( ";operation=switchmode'>" ).item( ( this.arrest_type ? "Detain" : "Arrest" ) ).str( "</A>" ).ToString() + "<BR>\nReport Arrests: " + new Txt( "<A href='?src=" ).Ref( this ).str( ";operation=declarearrests'>" ).item( ( this.declare_arrests ? "Yes" : "No" ) ).str( "</A>" ).ToString() + "<BR>\nAuto Patrol: " + new Txt( "<A href='?src=" ).Ref( this ).str( ";operation=patrol'>" ).item( ( this.auto_patrol ? "On" : "Off" ) ).str( "</A>" ).ToString();
			}
			Interface13.Browse( user, "<HEAD><TITLE>Securitron v1.3 controls</TITLE></HEAD>" + dat, "window=autosec" );
			GlobalFuncs.onclose( user, "autosec" );
			return null;
		}

		// Function from file: secbot.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic _default = null;

			_default = base.attack_hand( (object)(a), (object)(b), (object)(c) );

			if ( Lang13.Bool( _default ) ) {
				return _default;
			}
			Task13.User.set_machine( this );
			this.interact( a );
			return _default;
		}

		// Function from file: secbot.dm
		public override void turn_off(  ) {
			base.turn_off();
			this.target = null;
			this.oldtarget_name = null;
			this.anchored = 0;
			this.mode = 0;
			Map13.WalkTowards( this, 0, 0, 0 );
			this.icon_state = "secbot" + this.on;
			this.updateUsrDialog();
			return;
		}

		// Function from file: secbot.dm
		public override bool turn_on(  ) {
			base.turn_on();
			this.icon_state = "secbot" + this.on;
			this.updateUsrDialog();
			return false;
		}

		// Function from file: secbot.dm
		public override dynamic power_change(  ) {
			base.power_change();

			if ( this.on ) {
				this.set_light( 2 );
			} else {
				this.set_light( 0 );
			}
			return null;
		}

	}

}