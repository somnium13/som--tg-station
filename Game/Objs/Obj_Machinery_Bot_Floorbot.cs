// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Bot_Floorbot : Obj_Machinery_Bot {

		public int mode = 0;
		public bool auto_patrol = false;
		public double amount = 10;
		public bool repairing = false;
		public bool improvefloors = false;
		public bool eattiles = false;
		public bool maketiles = false;
		public Ent_Static target = null;
		public Ent_Static oldtarget = null;
		public Ent_Static oldloc = null;
		public dynamic path = new ByTable();
		public int? targetdirection = null;
		public int beacon_freq = 1445;
		public dynamic patrol_target = null;
		public string new_destination = null;
		public string destination = null;
		public string next_destination = null;
		public ByTable patpath = new ByTable();
		public int blockcount = 0;
		public int awaiting_beacon = 0;
		public string nearest_beacon = null;
		public Ent_Static nearest_beacon_loc = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.health = 25;
			this.maxhealth = 25;
			this.req_access = new ByTable(new object [] { 32 });
			this.icon_state = "floorbot0";
			this.layer = 5;
		}

		// Function from file: floorbot.dm
		public Obj_Machinery_Bot_Floorbot ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.updateicon();
			return;
		}

		// Function from file: floorbot.dm
		public override void explode(  ) {
			dynamic Tsec = null;
			Obj_Item_Weapon_Storage_Toolbox_Mechanical N = null;
			Obj_Item_Stack_Tile_Plasteel T = null;
			Obj_Item_Stack_Tile_Plasteel T2 = null;
			Effect_Effect_System_SparkSpread s = null;

			this.on = false;
			this.visible_message( "<span class='danger'>" + this + " blows apart!</span>", 1 );
			Tsec = GlobalFuncs.get_turf( this );
			N = new Obj_Item_Weapon_Storage_Toolbox_Mechanical( Tsec );
			N.contents = new ByTable();
			new Obj_Item_Device_Assembly_ProxSensor( Tsec );

			if ( Rand13.PercentChance( 50 ) ) {
				new Obj_Item_RobotParts_LArm( Tsec );
			}

			if ( this.target != null ) {
				GlobalVars.floorbot_targets.Remove( this.target );
			}

			while (this.amount != 0) {
				
				if ( this.amount >= 16 ) {
					T = new Obj_Item_Stack_Tile_Plasteel( Tsec );
					T.amount = 16;
					this.amount -= 16;
				} else {
					T2 = new Obj_Item_Stack_Tile_Plasteel( Tsec );
					T2.amount = this.amount;
					this.amount = 0;
				}
			}
			s = new Effect_Effect_System_SparkSpread();
			s.set_up( 3, 1, this );
			s.start();
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: floorbot.dm
		public override bool receive_signal( Game_Data signal = null, bool? receive_method = null, dynamic receive_param = null ) {
			string recv = null;
			dynamic valid = null;
			int dist = 0;

			
			if ( !this.on ) {
				return false;
			}
			recv = ((dynamic)signal).data["command"];
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

		// Function from file: floorbot.dm
		public override dynamic Bump(Ent_Static Obstacle = null, dynamic yes = null) {
			Obj_Machinery_Door D = null;

			
			if ( Obstacle is Obj_Machinery_Door && !( this.botcard == null ) ) {
				D = (Obj_Machinery_Door)Obstacle;

				if ( !( D is Obj_Machinery_Door_Firedoor ) && D.check_access( this.botcard ) ) {
					((dynamic)D).open();
				}
			}
			return null;
		}

		// Function from file: floorbot.dm
		public override dynamic process(  ) {
			string message = null;

			
			if ( !this.on ) {
				return null;
			}

			if ( this.repairing ) {
				return null;
			}

			if ( Rand13.PercentChance( 1 ) ) {
				message = Rand13.Pick(new object [] { "Metal to the metal.", "I am the only engineering staff on this station.", "Law 1. Place tiles.", "Tiles, tiles, tiles..." });
				this.speak( message );
			}

			switch ((int)( this.mode )) {
				case 0:
					Map13.WalkTowards( this, 0, 0, 0 );

					if ( this.checkforwork() ) {
						return null;
					}

					if ( !( this.mode != 0 ) && this.auto_patrol ) {
						this.mode = 2;
					}
					break;
				case 1:
					this.fix_shit();
					return null;
					break;
				case 2:
					
					if ( this.patpath.len > 0 && Lang13.Bool( this.patrol_target ) ) {
						this.mode = 3;
						return null;
					} else if ( Lang13.Bool( this.patrol_target ) ) {
						Task13.Schedule( 0, (Task13.Closure)(() => {
							this.calc_path();

							if ( this.patpath.len == 0 ) {
								this.patrol_target = 0;
								return;
							}
							this.mode = 3;
							return;
						}));
					} else {
						this.find_patrol_target();
						this.speak( "That's done, what's next?" );
					}
					break;
				case 3:
					this.patrol_step();
					Task13.Schedule( 5, (Task13.Closure)(() => {
						
						if ( this.mode == 3 ) {
							this.patrol_step();
						}
						return;
					}));
					break;
			}
			return null;
		}

		// Function from file: floorbot.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return null;
			}
			Task13.User.set_machine( this );
			this.add_fingerprint( Task13.User );

			dynamic _a = href_list["operation"]; // Was a switch-case, sorry for the mess.
			if ( _a=="start" ) {
				
				if ( this.on ) {
					this.turn_off();
				} else {
					this.turn_on();
				}
			} else if ( _a=="improve" ) {
				this.improvefloors = !this.improvefloors;
				this.updateUsrDialog();
			} else if ( _a=="tiles" ) {
				this.eattiles = !this.eattiles;
				this.updateUsrDialog();
			} else if ( _a=="make" ) {
				this.maketiles = !this.maketiles;
				this.updateUsrDialog();
			}
			return null;
		}

		// Function from file: floorbot.dm
		public override void Emag( dynamic user = null ) {
			base.Emag( (object)(user) );

			if ( this.open && !this.locked ) {
				
				if ( Lang13.Bool( user ) ) {
					GlobalFuncs.to_chat( user, "<span class='notice'>The " + this + " buzzes and beeps.</span>" );
				}
			}
			return;
		}

		// Function from file: floorbot.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic T = null;
			int loaded = 0;

			
			if ( a is Obj_Item_Stack_Tile_Plasteel ) {
				T = a;

				if ( this.amount >= 50 ) {
					return null;
				}
				loaded = Num13.MinInt( ((int)( 50 - this.amount )), Convert.ToInt32( T.amount ) );
				T.use( loaded );
				this.amount += loaded;
				GlobalFuncs.to_chat( b, "<span class='notice'>You load " + loaded + " tiles into the floorbot. He now contains " + this.amount + " tiles.</span>" );
				this.updateicon();
			} else if ( a is Obj_Item_Weapon_Card_Id || a is Obj_Item_Device_Pda ) {
				
				if ( this.allowed( Task13.User ) && !this.open && !( this.emagged != 0 ) ) {
					this.locked = !this.locked;
					GlobalFuncs.to_chat( b, "<span class='notice'>You " + ( this.locked ? "lock" : "unlock" ) + " the " + this + " behaviour controls.</span>" );
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
				this.updateUsrDialog();
			} else {
				base.attackby( (object)(a), (object)(b), (object)(c) );
			}
			return null;
		}

		// Function from file: floorbot.dm
		public void set_destination( string new_dest = null ) {
			this.new_destination = new_dest;
			this.post_signal( this.beacon_freq, "findbeacon", "patrol" );
			this.awaiting_beacon = 1;
			return;
		}

		// Function from file: floorbot.dm
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
			} else {
				frequency.post_signal( this, signal );
			}
			return;
		}

		// Function from file: floorbot.dm
		public void post_signal( int freq = 0, string key = null, string value = null ) {
			this.post_signal_multiple( freq, new ByTable().Set( "" + key, value ) );
			return;
		}

		// Function from file: floorbot.dm
		public void at_patrol_target(  ) {
			this.find_patrol_target();
			return;
		}

		// Function from file: floorbot.dm
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
				}
				return;
			}));
			return;
		}

		// Function from file: floorbot.dm
		public void find_patrol_target(  ) {
			
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

		// Function from file: floorbot.dm
		public void patrol_step(  ) {
			Ent_Static next = null;
			dynamic moved = null;

			
			if ( this.loc == this.patrol_target ) {
				this.at_patrol_target();
				return;
			} else if ( this.patpath.len > 0 && Lang13.Bool( this.patrol_target ) ) {
				next = this.patpath[1];

				if ( next == this.loc ) {
					this.patpath.Remove( next );
					return;
				}

				if ( next is Tile_Simulated ) {
					Map13.StepTowardsSimple( this, next );
					moved = null;

					if ( Lang13.Bool( moved ) ) {
						this.blockcount = 0;
						this.patpath.Remove( this.loc );
						this.checkforwork();
					} else {
						this.blockcount++;

						if ( this.blockcount > 5 ) {
							Task13.Schedule( 2, (Task13.Closure)(() => {
								this.calc_path( next );

								if ( this.patpath.len == 0 ) {
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
				this.mode = 2;
			}
			return;
		}

		// Function from file: floorbot.dm
		public void calc_path( Ent_Static avoid = null ) {
			this.path = GlobalFuncs.AStar( this.loc, this.patrol_target, typeof(Tile).GetMethod( "CardinalTurfsWithAccess" ), typeof(Tile).GetMethod( "Distance" ), 0, 120, null, null, this.botcard, avoid );
			this.path = GlobalFuncs.reverseRange( this.path );
			return;
		}

		// Function from file: floorbot.dm
		public void updateicon(  ) {
			
			if ( this.amount > 0 ) {
				this.icon_state = "floorbot" + this.on;
			} else {
				this.icon_state = "floorbot" + this.on + "e";
			}
			return;
		}

		// Function from file: floorbot.dm
		public void maketile( Ent_Static M = null ) {
			Obj_Item_Stack_Tile_Plasteel T = null;

			
			if ( !( M is Obj_Item_Stack_Sheet_Metal ) ) {
				return;
			}

			if ( Convert.ToDouble( ((dynamic)M).amount ) < 1 ) {
				return;
			}
			this.visible_message( "<span class='warning'>" + this + " begins to create tiles.</span>" );
			this.repairing = true;
			Task13.Schedule( 20, (Task13.Closure)(() => {
				
				if ( !( M != null ) || !Lang13.Bool( GlobalFuncs.get_turf( M ) ) ) {
					this.target = null;
					this.repairing = false;
					return;
				}
				T = new Obj_Item_Stack_Tile_Plasteel( GlobalFuncs.get_turf( M ) );
				T.amount = 4;

				if ( Lang13.Bool( ((dynamic)M).amount ) == true ) {
					GlobalFuncs.returnToPool( M );
				} else {
					((dynamic)M).amount--;
				}
				GlobalVars.floorbot_targets.Remove( this.target );
				this.target = null;
				this.repairing = false;
				return;
			}));
			return;
		}

		// Function from file: floorbot.dm
		public void eattile( Ent_Static T = null ) {
			double i = 0;

			
			if ( !( T is Obj_Item_Stack_Tile_Plasteel ) ) {
				return;
			}
			this.visible_message( "<span class='warning'>" + this + " begins to collect tiles.</span>" );
			this.repairing = true;
			Task13.Schedule( 20, (Task13.Closure)(() => {
				
				if ( T == null ) {
					this.target = null;
					this.repairing = false;
					return;
				}

				if ( this.amount + Convert.ToDouble( ((dynamic)T).amount ) > 50 ) {
					i = 50 - this.amount;
					this.amount += i;
					((dynamic)T).amount -= i;
				} else {
					this.amount += Convert.ToDouble( ((dynamic)T).amount );
					GlobalFuncs.returnToPool( T );
				}
				this.updateicon();
				GlobalVars.floorbot_targets.Remove( this.target );
				this.target = null;
				this.repairing = false;
				return;
			}));
			return;
		}

		// Function from file: floorbot.dm
		public void repair( Ent_Static target = null ) {
			Obj_Item_Stack_Tile_Plasteel T = null;
			Ent_Static F = null;

			
			if ( target is Tile_Space ) {
				
				if ( target.loc.type == typeof(Zone) ) {
					return;
				}
			} else if ( !( target is Tile_Simulated_Floor ) ) {
				return;
			}

			if ( this.amount <= 0 ) {
				return;
			}
			this.anchored = 1;
			this.icon_state = "floorbot-c";

			if ( target is Tile_Space ) {
				this.visible_message( "<span class='warning'>" + this + " begins to repair the hole</span>" );
				T = new Obj_Item_Stack_Tile_Plasteel();
				this.repairing = true;
				Task13.Schedule( 50, (Task13.Closure)(() => {
					T.build( this.loc );
					this.repairing = false;
					this.amount -= 1;
					this.updateicon();
					this.anchored = 0;
					GlobalVars.floorbot_targets.Remove( this.target );
					this.target = null;
					return;
				}));
			} else {
				F = this.loc;

				if ( !Lang13.Bool( ((dynamic)F).broken ) && !Lang13.Bool( ((dynamic)F).burnt ) ) {
					this.visible_message( "<span class='warning'>" + this + " begins to improve the floor.</span>" );
					this.repairing = true;
					Task13.Schedule( 50, (Task13.Closure)(() => {
						((dynamic)F).make_plasteel_floor();
						this.repairing = false;
						this.amount -= 1;
						this.updateicon();
						this.anchored = 0;
						GlobalVars.floorbot_targets.Remove( this.target );
						this.target = null;
						return;
					}));
				} else if ( Lang13.Bool( ((dynamic)F).is_plating() ) ) {
					this.visible_message( "<span class='warning'>" + this + " begins to fix dents in the floor.</span>" );
					this.repairing = true;
					Task13.Schedule( 20, (Task13.Closure)(() => {
						this.repairing = false;
						F.icon_state = "plating";
						((dynamic)F).burnt = 0;
						((dynamic)F).broken = 0;
						GlobalVars.floorbot_targets.Remove( this.target );
						this.target = null;
						return;
					}));
				}
			}
			return;
		}

		// Function from file: floorbot.dm
		public bool checkforwork(  ) {
			ByTable floorbottargets = null;
			ByTable shitICanSee = null;
			Tile T = null;
			Tile_Space D = null;
			Tile F = null;
			Tile_Simulated_Floor D2 = null;

			
			if ( this.have_target() ) {
				return false;
			}
			floorbottargets = new ByTable();
			shitICanSee = Map13.FetchInView( this, 7 );

			if ( this.amount < 50 && !this.have_target() ) {
				
				if ( this.eattiles ) {
					
					if ( Lang13.Bool( this.hunt_for_tiles( shitICanSee, floorbottargets ) ) ) {
						return true;
					}
				}

				if ( this.maketiles && !this.have_target() ) {
					
					if ( Lang13.Bool( this.hunt_for_metal( shitICanSee, floorbottargets ) ) ) {
						return true;
					}
				} else {
					return false;
				}
			}

			if ( Rand13.PercentChance( 5 ) ) {
				this.visible_message( "" + this + " makes an excited booping beeping sound!" );
			}

			if ( !this.have_target() && this.emagged < 2 ) {
				
				if ( this.targetdirection != null ) {
					T = Map13.GetStep( this, this.targetdirection ??0 );

					if ( T is Tile_Space && !GlobalVars.floorbot_targets.Contains( T ) ) {
						this.oldtarget = T;
						this.target = T;
						GlobalVars.floorbot_targets.Add( T );
						this.mode = 1;
						return true;
					}
				}

				if ( !this.have_target() ) {
					
					foreach (dynamic _a in Lang13.Enumerate( shitICanSee, typeof(Tile_Space) )) {
						D = _a;
						

						if ( !floorbottargets.Contains( D ) && D != this.oldtarget && !( D.loc.type == typeof(Zone) ) && !GlobalVars.floorbot_targets.Contains( D ) ) {
							this.oldtarget = D;
							this.target = D;
							GlobalVars.floorbot_targets.Add( D );
							this.mode = 1;
							return true;
						}
					}
				}

				if ( ( !( this.target != null ) || this.target == null ) && this.improvefloors ) {
					
					foreach (dynamic _b in Lang13.Enumerate( shitICanSee, typeof(Tile_Simulated_Floor) )) {
						F = _b;
						

						if ( !floorbottargets.Contains( F ) && F != this.oldtarget && F.is_plating() && !( F is Tile_Simulated_Wall ) && !GlobalVars.floorbot_targets.Contains( F ) ) {
							
							if ( !Lang13.Bool( ((dynamic)F).broken ) && !Lang13.Bool( ((dynamic)F).burnt ) ) {
								this.oldtarget = F;
								this.target = F;
								GlobalVars.floorbot_targets.Add( F );
								this.mode = 1;
								return true;
							}
						}

						if ( !floorbottargets.Contains( F ) && !GlobalVars.floorbot_targets.Contains( F ) && F != this.oldtarget && F.is_plasteel_floor() && ( Lang13.Bool( ((dynamic)F).broken ) || Lang13.Bool( ((dynamic)F).burnt ) ) ) {
							this.oldtarget = F;
							this.target = F;
							GlobalVars.floorbot_targets.Add( F );
							this.mode = 1;
							return true;
						}
					}
				}
			}

			if ( !this.have_target() && this.emagged == 2 ) {
				
				foreach (dynamic _c in Lang13.Enumerate( shitICanSee, typeof(Tile_Simulated_Floor) )) {
					D2 = _c;
					

					if ( !floorbottargets.Contains( D2 ) && D2 != this.oldtarget && D2.is_plasteel_floor() && !GlobalVars.floorbot_targets.Contains( D2 ) ) {
						this.oldtarget = D2;
						this.target = D2;
						GlobalVars.floorbot_targets.Add( D2 );
						this.mode = 1;
						return true;
					}
				}
			}
			return false;
		}

		// Function from file: floorbot.dm
		public bool fix_shit(  ) {
			Ent_Static F = null;
			Ent_Static F2 = null;

			
			if ( !this.have_target() ) {
				
				if ( this.loc != this.oldloc ) {
					this.oldtarget = null;
				}
				return false;
			}

			if ( !Lang13.Bool( this.path ) ) {
				this.path = new ByTable();
			}

			if ( this.target != null && this.target != null && this.path.len == 0 ) {
				Task13.Schedule( 0, (Task13.Closure)(() => {
					
					if ( !( this.target is Tile ) ) {
						this.path = GlobalFuncs.AStar( this.loc, this.target.loc, typeof(Tile).GetMethod( "AdjacentTurfsSpace" ), typeof(Tile).GetMethod( "Distance" ), 0, 30, null, null, this.botcard );
					} else {
						this.path = GlobalFuncs.AStar( this.loc, this.target, typeof(Tile).GetMethod( "AdjacentTurfsSpace" ), typeof(Tile).GetMethod( "Distance" ), 0, 30, null, null, this.botcard );
					}

					if ( !Lang13.Bool( this.path ) ) {
						this.path = new ByTable();
					}

					if ( this.path.len == 0 ) {
						this.oldtarget = this.target;
						GlobalVars.floorbot_targets.Remove( this.target );
						this.target = null;
					}
					return;
				}));
				return true;
			}

			if ( this.path.len > 0 && this.target != null && this.target != null ) {
				Map13.StepTowards( this, this.path[1], 0 );
				this.path -= this.path[1];
			} else if ( this.path.len == 1 ) {
				Map13.StepTowards( this, this.target, 0 );
				this.path = new ByTable();
			}

			if ( this.loc == this.target || this.loc == this.target.loc ) {
				
				if ( this.target is Obj_Item_Stack_Tile_Plasteel ) {
					this.eattile( this.target );
					this.mode = 0;
				} else if ( this.target is Obj_Item_Stack_Sheet_Metal ) {
					this.maketile( this.target );
					this.mode = 0;
				} else if ( ( Lang13.Bool( ((dynamic)this.target).is_plating() ) || this.target is Tile_Space ) && this.emagged < 2 ) {
					this.repair( this.target );
					this.mode = 0;
				} else if ( Lang13.Bool( ((dynamic)this.target).is_plasteel_floor() ) && ( Lang13.Bool( ((dynamic)this.target).broken ) || Lang13.Bool( ((dynamic)this.target).burnt ) ) && this.emagged < 2 ) {
					F = this.target;
					this.anchored = 1;
					this.repairing = true;
					((dynamic)F).break_tile_to_plating();
					Task13.Schedule( 50, (Task13.Closure)(() => {
						this.anchored = 0;
						this.repairing = false;
						this.target = null;
						GlobalVars.floorbot_targets.Remove( this.target );
						return;
					}));
					this.mode = 0;
				} else if ( Lang13.Bool( ((dynamic)this.target).is_plating() ) && this.emagged == 2 ) {
					F2 = this.target;
					this.anchored = 1;
					this.repairing = true;

					if ( Rand13.PercentChance( 90 ) ) {
						((dynamic)F2).break_tile_to_plating();
					} else {
						((dynamic)F2).ReplaceWithLattice();
					}
					this.visible_message( "<span class='warning'>" + this + " makes an excited booping sound.</span>" );
					Task13.Schedule( 50, (Task13.Closure)(() => {
						this.amount++;
						this.anchored = 0;
						this.repairing = false;
						this.target = null;
						GlobalVars.floorbot_targets.Remove( this.target );
						return;
					}));
					this.mode = 0;
				}
				this.path = new ByTable();
				this.mode = 0;
				return true;
			}
			this.oldloc = this.loc;
			return true;
		}

		// Function from file: floorbot.dm
		public bool have_target(  ) {
			return this.target != null;
		}

		// Function from file: floorbot.dm
		public dynamic hunt_for_metal( ByTable shit_in_view = null, ByTable floorbottargets = null ) {
			Obj_Item_Stack_Sheet_Metal M = null;

			
			foreach (dynamic _a in Lang13.Enumerate( shit_in_view, typeof(Obj_Item_Stack_Sheet_Metal) )) {
				M = _a;
				

				if ( !GlobalVars.floorbot_targets.Contains( M ) && this.is_obj_valid_target( M ) && M.amount == 1 ) {
					this.oldtarget = M;
					this.target = M;
					GlobalVars.floorbot_targets.Add( M );
					this.mode = 1;
					return null;
				}
			}
			return null;
		}

		// Function from file: floorbot.dm
		public dynamic hunt_for_tiles( ByTable shit_in_view = null, ByTable floorbottargets = null ) {
			Obj_Item_Stack_Tile_Plasteel T = null;

			
			foreach (dynamic _a in Lang13.Enumerate( shit_in_view, typeof(Obj_Item_Stack_Tile_Plasteel) )) {
				T = _a;
				

				if ( !GlobalVars.floorbot_targets.Contains( T ) && this.is_obj_valid_target( T, floorbottargets ) ) {
					this.oldtarget = T;
					this.target = T;
					GlobalVars.floorbot_targets.Add( T );
					this.mode = 1;
					return null;
				}
			}
			return null;
		}

		// Function from file: floorbot.dm
		public bool is_obj_valid_target( Obj_Item_Stack T = null, ByTable floorbottargets = null ) {
			
			if ( floorbottargets.Contains( T ) ) {
				return false;
			}

			if ( T == this.oldtarget ) {
				return false;
			}

			if ( T.loc is Tile_Simulated_Wall ) {
				return false;
			}

			if ( !T.loc.Enter( this ) ) {
				return false;
			}
			return true;
		}

		// Function from file: floorbot.dm
		public void speak( string message = null ) {
			dynamic O = null;

			
			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchHearers( null, this ) )) {
				O = _a;
				
				O.show_message( "<span class='game say'><span class='name'>" + this + "</span> beeps, \"" + message + "\"", 2 );
			}
			return;
		}

		// Function from file: floorbot.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			dynamic dat = null;

			dat += "<TT><B>Automatic Station Floor Repairer v1.0</B></TT><BR><BR>";
			dat += new Txt( "Status: <A href='?src=" ).Ref( this ).str( ";operation=start'>" ).item( ( this.on ? "On" : "Off" ) ).str( "</A><BR>" ).ToString();
			dat += "Maintenance panel panel is " + ( this.open ? "opened" : "closed" ) + "<BR>";
			dat += "Tiles left: " + this.amount + "<BR>";
			dat += "Behvaiour controls are " + ( this.locked ? "locked" : "unlocked" ) + "<BR>";

			if ( !this.locked || user is Mob_Living_Silicon ) {
				dat += new Txt( "Improves floors: <A href='?src=" ).Ref( this ).str( ";operation=improve'>" ).item( ( this.improvefloors ? "Yes" : "No" ) ).str( "</A><BR>" ).ToString();
				dat += new Txt( "Finds tiles: <A href='?src=" ).Ref( this ).str( ";operation=tiles'>" ).item( ( this.eattiles ? "Yes" : "No" ) ).str( "</A><BR>" ).ToString();
				dat += new Txt( "Make single pieces of metal into tiles when empty: <A href='?src=" ).Ref( this ).str( ";operation=make'>" ).item( ( this.maketiles ? "Yes" : "No" ) ).str( "</A><BR>" ).ToString();
			}
			Interface13.Browse( user, "<HEAD><TITLE>Repairbot v1.0 controls</TITLE></HEAD>" + dat, "window=autorepair" );
			GlobalFuncs.onclose( user, "autorepair" );
			return null;
		}

		// Function from file: floorbot.dm
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

		// Function from file: floorbot.dm
		public override void turn_off(  ) {
			base.turn_off();

			if ( !( this.target == null ) ) {
				GlobalVars.floorbot_targets.Remove( this.target );
			}
			this.target = null;
			this.oldtarget = null;
			this.oldloc = null;
			this.updateicon();
			this.path = new ByTable();
			this.patpath = new ByTable();
			this.updateUsrDialog();
			this.mode = 0;
			return;
		}

		// Function from file: floorbot.dm
		public override bool turn_on(  ) {
			bool _default = false;

			_default = base.turn_on();
			this.updateicon();
			this.updateUsrDialog();
			return _default;
		}

	}

}