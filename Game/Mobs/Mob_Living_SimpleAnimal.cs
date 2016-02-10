// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal : Mob_Living {

		public string icon_living = "";
		public string icon_dead = "";
		public string icon_gib = null;
		public ByTable speak = new ByTable();
		public dynamic speak_chance = 0;
		public ByTable emote_hear = new ByTable();
		public ByTable emote_see = new ByTable();
		public dynamic turns_per_move = 1;
		public int turns_since_move = 0;
		public bool stop_automated_movement = false;
		public bool wander = true;
		public bool stop_automated_movement_when_pulled = true;
		public dynamic response_help = "pokes";
		public dynamic response_disarm = "shoves";
		public dynamic response_harm = "hits";
		public int harm_intent_damage = 3;
		public dynamic minbodytemp = 250;
		public dynamic maxbodytemp = 350;
		public int heat_damage_per_tick = 3;
		public int cold_damage_per_tick = 2;
		public int fire_alert = 0;
		public bool oxygen_alert = false;
		public bool toxins_alert = false;
		public bool show_stat_health = true;
		public dynamic min_oxy = 5;
		public bool max_oxy = false;
		public bool min_tox = false;
		public bool max_tox = true;
		public bool min_co2 = false;
		public int max_co2 = 5;
		public bool min_n2 = false;
		public bool max_n2 = false;
		public int unsuitable_atoms_damage = 2;
		public dynamic melee_damage_lower = 0;
		public dynamic melee_damage_upper = 0;
		public string melee_damage_type = "brute";
		public string attacktext = "attacks";
		public string attack_sound = null;
		public string friendly = "nuzzles";
		public int environment_smash = 0;
		public dynamic speed = 0;
		public Type childtype = null;
		public int? child_amount = 1;
		public bool scan_ready = true;
		public bool can_breed = false;
		public bool supernatural = false;
		public int? purge = 0;
		public int life_tick = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.health = 20;
			this.maxHealth = 20;
			this.treadmill_speed = 0.5;
			this.meat_type = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Animal);
			this.mob_bump_flag = 32;
			this.mob_swap_flags = 50;
			this.mob_push_flags = 50;
			this.universal_speak = true;
			this.universal_understand = true;
			this.icon = "icons/mob/animal.dmi";
		}

		// Function from file: simple_animal.dm
		public Mob_Living_SimpleAnimal ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.verbs.Remove( typeof(Mob).GetMethod( "observe" ) );

			if ( !Lang13.Bool( this.real_name ) ) {
				this.real_name = this.name;
			}
			GlobalVars.animal_count[this.type]++;
			return;
		}

		// Function from file: simple_animal.dm
		public override bool say_understands( Ent_Dynamic other = null, Language speaking = null ) {
			
			if ( other != null ) {
				other = other.GetSource();
			}

			if ( other is Mob_Living_Silicon ) {
				return true;
			}
			return base.say_understands( other, speaking );
		}

		// Function from file: simple_animal.dm
		public override void revive( bool? animation = null ) {
			this.health = this.maxHealth;
			this.butchering_drops = null;
			this.meat_taken = 0;
			base.revive( animation );
			return;
		}

		// Function from file: simple_animal.dm
		public override void ExtinguishMob(  ) {
			return;
		}

		// Function from file: simple_animal.dm
		public override bool IgniteMob(  ) {
			return false;
		}

		// Function from file: simple_animal.dm
		public override void update_fire( bool? update_icons = null ) {
			return;
		}

		// Function from file: simple_animal.dm
		public override void update_targeted( bool? update_icons = null ) {
			
			if ( !( this.targeted_by != null ) && this.target_locked != null ) {
				Lang13.Delete( this.target_locked );
				this.target_locked = null;
			}
			this.overlays = null;

			if ( this.targeted_by != null && this.target_locked != null ) {
				this.overlays.Add( this.target_locked );
			}
			return;
		}

		// Function from file: simple_animal.dm
		public override bool adjustBruteLoss( dynamic amount = null, string damage_type = null ) {
			this.health = ( Convert.ToDouble( this.health - amount ) <= 0 ? ((dynamic)( 0 )) : ( Convert.ToDouble( this.health - amount ) >= Convert.ToDouble( this.maxHealth ) ? this.maxHealth : this.health - amount ) );

			if ( Convert.ToDouble( this.health ) < 1 && this.stat != 2 ) {
				this.Die();
			}
			return false;
		}

		// Function from file: simple_animal.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			
			if ( Lang13.Bool( this.flags & 128 ) ) {
				return false;
			}
			base.ex_act( severity, (object)(child) );

			switch ((double?)( severity )) {
				case 1:
					this.adjustBruteLoss( 500 );
					this.gib();
					return false;
					break;
				case 2:
					this.adjustBruteLoss( 60 );
					break;
				case 3:
					this.adjustBruteLoss( 30 );
					break;
			}
			return false;
		}

		// Function from file: simple_animal.dm
		public override dynamic death( bool? gibbed = null ) {
			
			if ( this.stat == 2 ) {
				return null;
			}

			if ( !( gibbed == true ) ) {
				this.visible_message( new Txt( "<span class='danger'>" ).the( this ).item().str( " stops moving...</span>" ).ToString() );
			}
			this.Die();
			return null;
		}

		// Function from file: simple_animal.dm
		public override dynamic Stat(  ) {
			base.Stat();

			if ( Interface13.IsStatPanelActive( "Status" ) && this.show_stat_health ) {
				Interface13.Stat( null, "Health: " + Num13.Floor( Convert.ToDouble( this.health / this.maxHealth * 100 ) ) + "%" );
			}
			return null;
		}

		// Function from file: simple_animal.dm
		public override dynamic movement_delay(  ) {
			dynamic tally = null;
			Ent_Static T = null;

			tally = 0;
			tally = this.speed;

			if ( Lang13.Bool( this.purge ) ) {
				
				if ( Convert.ToDouble( tally ) <= 0 ) {
					tally = 1;
				}
				tally *= this.purge;
			}

			if ( this.loc is Tile_Simulated_Floor ) {
				T = this.loc;

				if ( ((dynamic)T).material == "phazon" ) {
					return -1;
				}
			}
			return tally + GlobalVars.config.animal_delay;
		}

		// Function from file: simple_animal.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic MED = null;
			dynamic damage = null;
			dynamic M = null;
			dynamic M2 = null;

			
			if ( a is Obj_Item_Stack_Medical ) {
				((Mob)b).delayNextAttack( 4 );

				if ( this.stat != 2 ) {
					MED = a;

					if ( Convert.ToDouble( this.health ) < Convert.ToDouble( this.maxHealth ) ) {
						
						if ( Lang13.Bool( MED.use( 1 ) ) ) {
							this.adjustBruteLoss( -MED.heal_brute );
							this.visible_message( new Txt( "<span class='notice'>" ).item( b ).str( " applies " ).the( MED ).item().str( " to " ).the( this ).item().str( ".</span>" ).ToString() );
						}
					}
				} else {
					GlobalFuncs.to_chat( b, "<span class='notice'>This " + this + " is dead, medical items won't bring it back to life.</span>" );
				}
			} else if ( ( Lang13.Bool( this.meat_type ) || this.butchering_drops != null ) && this.stat == 2 ) {
				
				if ( Lang13.Bool( ((Obj)a).is_sharp() ) ) {
					
					if ( b.a_intent != "help" ) {
						GlobalFuncs.to_chat( b, "<span class='info'>You must be on <b>help</b> intent to do this!</span>" );
					} else {
						this.butcher();
						return 1;
					}
				}
			} else {
				((Mob)b).delayNextAttack( 8 );

				if ( Lang13.Bool( a.force ) ) {
					damage = a.force;

					if ( a.damtype == "halloss" ) {
						damage = 0;
					}

					if ( this.supernatural && a is Obj_Item_Weapon_Nullrod ) {
						damage *= 2;
						this.purge = 3;
					}
					this.adjustBruteLoss( damage );

					foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, this ) )) {
						M = _a;
						

						if ( Lang13.Bool( M.client ) && !Lang13.Bool( M.blinded ) ) {
							M.show_message( "<span class='danger'>" + this + " has been attacked with the " + a + " by " + b + ". </span>" );
						}
					}
				} else {
					GlobalFuncs.to_chat( Task13.User, "<span class='warning'>This weapon is ineffective, it does no damage.</span>" );

					foreach (dynamic _b in Lang13.Enumerate( Map13.FetchViewers( null, this ) )) {
						M2 = _b;
						

						if ( Lang13.Bool( M2.client ) && !Lang13.Bool( M2.blinded ) ) {
							M2.show_message( "<span class='warning'>" + b + " gently taps " + this + " with the " + a + ". </span>" );
						}
					}
				}
			}
			return null;
		}

		// Function from file: simple_animal.dm
		public override void attack_slime( Mob_Living_Carbon_Slime user = null ) {
			int damage = 0;

			
			if ( !( GlobalVars.ticker != null ) ) {
				GlobalFuncs.to_chat( user, "You cannot attack people before the game has started." );
				return;
			}

			if ( Lang13.Bool( user.Victim ) ) {
				return;
			}
			this.visible_message( "<span class='danger'>" + user.name + " glomps " + this + "!</span>" );
			damage = Rand13.Int( 1, 3 );

			if ( user is Mob_Living_Carbon_Slime_Adult ) {
				damage = Rand13.Int( 20, 40 );
			} else {
				damage = Rand13.Int( 5, 35 );
			}
			this.adjustBruteLoss( damage );
			return;
		}

		// Function from file: simple_animal.dm
		public override void attack_larva( Mob_Living_Carbon_Alien_Larva user = null ) {
			int damage = 0;

			
			dynamic _a = user.a_intent; // Was a switch-case, sorry for the mess.
			if ( _a=="help" ) {
				this.visible_message( "<span class='notice'>" + user + " rubs it's head against " + this + "</span>" );
			} else {
				damage = Rand13.Int( 5, 10 );
				this.visible_message( "<span class='danger'>" + user + " bites " + this + "!</span>" );

				if ( this.stat != 2 ) {
					this.adjustBruteLoss( damage );
					user.amount_grown = Num13.MinInt( user.amount_grown + damage, user.max_grown );
				}
			}
			return;
		}

		// Function from file: simple_animal.dm
		public override dynamic attack_alien( Mob user = null ) {
			dynamic O = null;
			Game_Data G = null;
			dynamic O2 = null;
			int damage = 0;

			
			dynamic _c = user.a_intent; // Was a switch-case, sorry for the mess.
			if ( _c=="help" ) {
				
				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, this ) )) {
					O = _a;
					

					if ( Lang13.Bool( O.client ) && !Lang13.Bool( O.blinded ) ) {
						O.show_message( "<span class='notice'>" + user + " caresses " + this + " with its scythe like arm.</span>", 1 );
					}
				}
			} else if ( _c=="grab" ) {
				
				if ( user == this || Lang13.Bool( this.anchored ) ) {
					return null;
				}

				if ( !( ( this.status_flags & 8 ) != 0 ) ) {
					return null;
				}
				G = GlobalFuncs.getFromPool( typeof(Obj_Item_Weapon_Grab), user, this );
				user.put_in_active_hand( G );
				this.grabbed_by.Add( G );
				((Obj_Item_Weapon_Grab)G).synch();
				((dynamic)G).affecting = this;
				this.LAssailant = user;
				GlobalFuncs.playsound( this.loc, "sound/weapons/thudswoosh.ogg", 50, 1, -1 );

				foreach (dynamic _b in Lang13.Enumerate( Map13.FetchViewers( null, this ) )) {
					O2 = _b;
					

					if ( Lang13.Bool( O2.client ) && !Lang13.Bool( O2.blinded ) ) {
						O2.show_message( "<span class='warning'>" + user + " has grabbed " + this + " passively!</span>", 1 );
					}
				}
			} else if ( _c=="hurt" || _c=="disarm" ) {
				damage = Rand13.Int( 15, 30 );
				this.visible_message( "<span class='danger'>" + user + " has slashed at " + this + "!</span>" );
				this.adjustBruteLoss( damage );
			}
			return null;
		}

		// Function from file: simple_animal.dm
		public override dynamic MouseDrop( Mob over_object = null, dynamic src_location = null, Ent_Static over_location = null, dynamic src_control = null, dynamic over_control = null, string _params = null ) {
			dynamic strength_of_M = null;

			
			if ( over_object != Task13.User || !( over_object is Mob_Living_Carbon_Human ) || !this.Adjacent( over_object ) || over_object.incapacitated() ) {
				return null;
			}
			strength_of_M = over_object.size - 1;

			if ( over_object.a_intent != "help" && Convert.ToDouble( this.size ) <= Convert.ToDouble( strength_of_M ) && this.loc is Tile && this.holder_type != null ) {
				this.scoop_up( over_object );
			} else {
				base.MouseDrop( over_object, (object)(src_location), over_location, (object)(src_control), (object)(over_control), _params );
			}
			return null;
		}

		// Function from file: simple_animal.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic O = null;
			Game_Data G = null;

			base.attack_hand( (object)(a), (object)(b), (object)(c) );

			dynamic _b = a.a_intent; // Was a switch-case, sorry for the mess.
			if ( _b=="help" ) {
				
				if ( Convert.ToDouble( this.health ) > 0 ) {
					
					foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, this ) )) {
						O = _a;
						

						if ( Lang13.Bool( O.client ) && !Lang13.Bool( O.blinded ) ) {
							O.show_message( "<span class='notice'>" + a + " " + this.response_help + " " + this + ".</span>" );
						}
					}
				}
			} else if ( _b=="grab" ) {
				
				if ( a == this || Lang13.Bool( this.anchored ) ) {
					return null;
				}

				if ( !( ( this.status_flags & 8 ) != 0 ) ) {
					return null;
				}
				G = GlobalFuncs.getFromPool( typeof(Obj_Item_Weapon_Grab), a, this );
				((Mob)a).put_in_active_hand( G );
				this.grabbed_by.Add( G );
				((Obj_Item_Weapon_Grab)G).synch();
				((dynamic)G).affecting = this;
				this.LAssailant = a;
				this.visible_message( "<span class='warning'>" + a + " has grabbed " + this + " passively!</span>" );
			} else if ( _b=="hurt" || _b=="disarm" ) {
				this.adjustBruteLoss( this.harm_intent_damage );
				this.visible_message( "<span class='warning'>" + a + " " + this.response_harm + " " + this + "!</span>" );
			}
			return null;
		}

		// Function from file: simple_animal.dm
		public override int? bullet_act( dynamic Proj = null, dynamic def_zone = null ) {
			Mob_Living_SimpleAnimal M = null;

			
			if ( !Lang13.Bool( Proj ) ) {
				return null;
			}

			if ( this is Mob_Living_SimpleAnimal_Mouse && ( Proj.stun ??0) + ( Proj.weaken ??0) + ( Proj.paralyze == true ?1:0) + ( Proj.agony ??0) > 5 ) {
				M = this;
				GlobalFuncs.to_chat( M, "<span class='warning'>What would probably not kill a human completely overwhelms your tiny body.</span>" );
				((dynamic)M).splat();
				return 0;
			}
			this.adjustBruteLoss( Proj.damage );
			((Obj_Item_Projectile)Proj).on_hit( this, 0 );
			return 0;
		}

		// Function from file: simple_animal.dm
		public override dynamic attack_animal( Mob_Living user = null ) {
			dynamic O = null;
			int damage = 0;

			
			if ( Lang13.Bool( ((dynamic)user).melee_damage_upper ) == false ) {
				user.emote( "" + ((dynamic)user).friendly + " " + this );
			} else {
				user.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='red'>" + ((dynamic)user).attacktext + " " + this.name + " (" + this.ckey + ")</font>" );
				this.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='orange'>Has been " + ((dynamic)user).attacktext + " by " + user.name + " (" + user.ckey + ")</font>" );

				if ( Lang13.Bool( ((dynamic)user).attack_sound ) ) {
					GlobalFuncs.playsound( this.loc, ((dynamic)user).attack_sound, 50, 1, 1 );
				}

				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, this ) )) {
					O = _a;
					
					O.show_message( new Txt( "<span class='warning'><B>" ).The( user ).item().str( "</B> " ).item( ((dynamic)user).attacktext ).str( " " ).item( this ).str( "!</span>" ).ToString(), 1 );
				}
				GlobalFuncs.add_logs( user, this, "attacked", false );
				damage = Rand13.Int( Convert.ToInt32( ((dynamic)user).melee_damage_lower ), Convert.ToInt32( ((dynamic)user).melee_damage_upper ) );
				this.adjustBruteLoss( damage, ((dynamic)user).melee_damage_type );
				this.updatehealth();
			}
			return null;
		}

		// Function from file: simple_animal.dm
		public override void emote( dynamic act = null, int? type = null, dynamic message = null, bool? auto = null ) {
			
			if ( this.timestopped ) {
				return;
			}

			if ( Lang13.Bool( this.stat ) ) {
				return;
			}

			if ( act == "scream" ) {
				message = "makes a loud and pained whimper";
				act = "me";
			}
			base.emote( (object)(act), type, (object)(message), auto );
			return;
		}

		// Function from file: simple_animal.dm
		public override string say_quote( dynamic text = null ) {
			dynamic emote = null;

			
			if ( this.speak_emote != null && this.speak_emote.len != 0 ) {
				emote = Rand13.PickFromTable( this.speak_emote );

				if ( Lang13.Bool( emote ) ) {
					return "" + emote + ", " + text;
				}
			}
			return "says, " + text;
		}

		// Function from file: simple_animal.dm
		public override bool blob_act( dynamic severity = null ) {
			this.adjustBruteLoss( 20 );
			return false;
		}

		// Function from file: simple_animal.dm
		public override dynamic gib( bool? animation = null, bool? meat = null ) {
			animation = animation ?? false;
			meat = meat ?? true;

			int? i = null;

			
			if ( Lang13.Bool( this.icon_gib ) ) {
				Icon13.Flick( this.icon_gib, this );
			}

			if ( meat == true && Lang13.Bool( this.meat_type ) ) {
				i = null;
				i = 0;

				while (( i ??0) < Convert.ToDouble( this.size - this.meat_taken )) {
					this.drop_meat( GlobalFuncs.get_turf( this ) );
					i++;
				}
			}
			base.gib( animation, meat );
			return null;
		}

		// Function from file: simple_animal.dm
		public override bool Life(  ) {
			Tile destination = null;
			int length = 0;
			int randomValue = 0;
			int length2 = 0;
			int pick = 0;
			bool atmos_suitable = false;
			Ent_Static A = null;
			Ent_Static T = null;
			GasMixture Environment = null;

			
			if ( this.timestopped ) {
				return false;
			}
			base.Life();

			if ( this.stat == 2 ) {
				
				if ( Convert.ToDouble( this.health ) > 0 ) {
					this.icon_state = this.icon_living;
					this.resurrect();
					this.stat = 0;
					this.density = true;
					this.update_canmove();
				}
				return false;
			}

			if ( Convert.ToDouble( this.health ) < 1 && this.stat != 2 ) {
				this.Die();
				return false;
			}
			this.life_tick++;
			this.health = Num13.MinInt( Convert.ToInt32( this.health ), Convert.ToInt32( this.maxHealth ) );

			if ( this.stunned != 0 ) {
				this.AdjustStunned( -1 );
			}

			if ( this.weakened != 0 ) {
				this.AdjustWeakened( -1 );
			}

			if ( this.paralysis != 0 ) {
				this.AdjustParalysis( -1 );
			}

			if ( Lang13.Bool( this.purge ) ) {
				this.purge -= 1;
			}

			if ( ( !( this.client != null ) || this.deny_client_move ) && !this.stop_automated_movement && this.wander && !Lang13.Bool( this.anchored ) && this.ckey == null && !Lang13.Bool( this.flags & 128 ) ) {
				
				if ( this.loc is Tile && this.canmove ) {
					this.turns_since_move++;

					if ( this.turns_since_move >= Convert.ToDouble( this.turns_per_move ) ) {
						
						if ( !( this.stop_automated_movement_when_pulled && this.pulledby != null ) ) {
							destination = Map13.GetStep( this, Convert.ToInt32( Rand13.PickFromTable( GlobalVars.cardinal ) ) );
							this.wander_move( destination );
							this.turns_since_move = 0;
						}
					}
				}
			}

			if ( !( this.client != null ) && Lang13.Bool( this.speak_chance ) && this.ckey == null ) {
				
				if ( Rand13.Int( 0, 200 ) < Convert.ToDouble( this.speak_chance ) ) {
					
					if ( this.speak != null && this.speak.len != 0 ) {
						
						if ( this.emote_hear != null && this.emote_hear.len != 0 || this.emote_see != null && this.emote_see.len != 0 ) {
							length = this.speak.len;

							if ( this.emote_hear != null && this.emote_hear.len != 0 ) {
								length += this.emote_hear.len;
							}

							if ( this.emote_see != null && this.emote_see.len != 0 ) {
								length += this.emote_see.len;
							}
							randomValue = Rand13.Int( 1, length );

							if ( randomValue <= this.speak.len ) {
								this.say( Rand13.PickFromTable( this.speak ) );
							} else {
								randomValue -= this.speak.len;

								if ( this.emote_see != null && randomValue <= this.emote_see.len ) {
									this.emote( Rand13.PickFromTable( this.emote_see ), 1 );
								} else {
									this.emote( Rand13.PickFromTable( this.emote_hear ), 2 );
								}
							}
						} else {
							this.say( Rand13.PickFromTable( this.speak ) );
						}
					} else {
						
						if ( !( this.emote_hear != null && this.emote_hear.len != 0 ) && this.emote_see != null && this.emote_see.len != 0 ) {
							this.emote( Rand13.PickFromTable( this.emote_see ), 1 );
						}

						if ( this.emote_hear != null && this.emote_hear.len != 0 && !( this.emote_see != null && this.emote_see.len != 0 ) ) {
							this.emote( Rand13.PickFromTable( this.emote_hear ), 2 );
						}

						if ( this.emote_hear != null && this.emote_hear.len != 0 && this.emote_see != null && this.emote_see.len != 0 ) {
							length2 = this.emote_hear.len + this.emote_see.len;
							pick = Rand13.Int( 1, length2 );

							if ( pick <= this.emote_see.len ) {
								this.emote( Rand13.PickFromTable( this.emote_see ), 1 );
							} else {
								this.emote( Rand13.PickFromTable( this.emote_hear ), 2 );
							}
						}
					}
				}
			}

			if ( Lang13.Bool( this.flags & 128 ) ) {
				return true;
			}
			atmos_suitable = true;
			A = this.loc;

			if ( A is Tile ) {
				T = A;
				Environment = T.return_air();

				if ( Environment != null ) {
					
					if ( Math.Abs( ( Environment.temperature ??0) - Convert.ToDouble( this.bodytemperature ) ) > 40 ) {
						this.bodytemperature += ( ( Environment.temperature ??0) - Convert.ToDouble( this.bodytemperature ) ) / 5;
					}

					if ( Lang13.Bool( this.min_oxy ) ) {
						
						if ( Convert.ToDouble( Environment.oxygen ) < Convert.ToDouble( this.min_oxy ) ) {
							atmos_suitable = false;
							this.oxygen_alert = true;
						} else {
							this.oxygen_alert = false;
						}
					}

					if ( this.max_oxy ) {
						
						if ( Convert.ToDouble( Environment.oxygen ) > ( this.max_oxy ?1:0) ) {
							atmos_suitable = false;
						}
					}

					if ( this.min_tox ) {
						
						if ( Convert.ToDouble( Environment.toxins ) < ( this.min_tox ?1:0) ) {
							atmos_suitable = false;
						}
					}

					if ( this.max_tox ) {
						
						if ( Convert.ToDouble( Environment.toxins ) > ( this.max_tox ?1:0) ) {
							atmos_suitable = false;
							this.toxins_alert = true;
						} else {
							this.toxins_alert = false;
						}
					}

					if ( this.min_n2 ) {
						
						if ( Convert.ToDouble( Environment.nitrogen ) < ( this.min_n2 ?1:0) ) {
							atmos_suitable = false;
						}
					}

					if ( this.max_n2 ) {
						
						if ( Convert.ToDouble( Environment.nitrogen ) > ( this.max_n2 ?1:0) ) {
							atmos_suitable = false;
						}
					}

					if ( this.min_co2 ) {
						
						if ( Convert.ToDouble( Environment.carbon_dioxide ) < ( this.min_co2 ?1:0) ) {
							atmos_suitable = false;
						}
					}

					if ( this.max_co2 != 0 ) {
						
						if ( Convert.ToDouble( Environment.carbon_dioxide ) > this.max_co2 ) {
							atmos_suitable = false;
						}
					}
				}
			}

			if ( Convert.ToDouble( this.bodytemperature ) < Convert.ToDouble( this.minbodytemp ) ) {
				this.fire_alert = 2;
				this.adjustBruteLoss( this.cold_damage_per_tick );
			} else if ( Convert.ToDouble( this.bodytemperature ) > Convert.ToDouble( this.maxbodytemp ) ) {
				this.fire_alert = 1;
				this.adjustBruteLoss( this.heat_damage_per_tick );
			} else {
				this.fire_alert = 0;
			}

			if ( !atmos_suitable ) {
				this.adjustBruteLoss( this.unsuitable_atoms_damage );
			}

			if ( this.can_breed ) {
				this.make_babies();
			}
			return true;
		}

		// Function from file: simple_animal.dm
		public virtual dynamic reagent_act( string id = null, int? method = null, double volume = 0 ) {
			
			if ( this.isDead() ) {
				return null;
			}

			switch ((string)( id )) {
				case "sacid":
					
					if ( !this.supernatural ) {
						this.adjustBruteLoss( volume * 0.5 );
					}
					break;
				case "pacid":
					
					if ( !this.supernatural ) {
						this.adjustBruteLoss( volume * 0.5 );
					}
					break;
			}
			return null;
		}

		// Function from file: simple_animal.dm
		public virtual void give_birth(  ) {
			int? i = null;
			dynamic child = null;

			i = null;
			i = 1;

			while (( i ??0) <= ( this.child_amount ??0)) {
				
				if ( Convert.ToDouble( GlobalVars.animal_count[this.childtype] ) > GlobalVars.ANIMAL_CHILD_CAP ) {
					break;
				}
				child = Lang13.Call( this.childtype, this.loc );

				if ( child is Mob_Living_SimpleAnimal ) {
					child.faction = this.faction;
				}
				i++;
			}
			return;
		}

		// Function from file: simple_animal.dm
		public void make_babies(  ) {
			bool alone = false;
			dynamic partner = null;
			int children = 0;
			dynamic M = null;

			
			if ( this.gender != GlobalVars.FEMALE || Lang13.Bool( this.stat ) || !this.scan_ready || !( this.childtype != null ) || !( this.species_type != null ) ) {
				return;
			}
			this.scan_ready = false;
			Task13.Schedule( 400, (Task13.Closure)(() => {
				this.scan_ready = true;
				return;
			}));
			alone = true;
			children = 0;

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInViewExcludeThis( this, 7 ) )) {
				M = _a;
				

				if ( Lang13.Bool( M.stat ) != false ) {
					continue;
				} else if ( Lang13.Bool( ((dynamic)this.childtype).IsInstanceOfType( M ) ) ) {
					children++;
				} else if ( Lang13.Bool( ((dynamic)this.species_type).IsInstanceOfType( M ) ) ) {
					
					if ( Lang13.Bool( M.client ) ) {
						continue;
					} else if ( !Lang13.Bool( ((dynamic)this.childtype).IsInstanceOfType( M ) ) && M.gender == GlobalVars.MALE ) {
						partner = M;
					}
				} else if ( M is Mob_Living ) {
					
					if ( !( M is Mob_Dead_Observer ) || Convert.ToInt32( M.stat ) != 2 ) {
						alone = false;
						continue;
					}
				}
			}

			if ( alone && Lang13.Bool( partner ) && children < 3 ) {
				this.give_birth();
			}
			return;
		}

		// Function from file: simple_animal.dm
		public virtual bool CanAttack( dynamic target = null ) {
			dynamic L = null;
			dynamic M = null;
			dynamic B = null;

			
			if ( this.see_invisible < Convert.ToDouble( target.invisibility ) ) {
				return false;
			}

			if ( target is Mob_Living ) {
				L = target;

				if ( !Lang13.Bool( L.stat ) && Convert.ToDouble( L.health ) >= 0 ) {
					return false;
				}
			}

			if ( target is Obj_Mecha ) {
				M = target;

				if ( Lang13.Bool( M.occupant ) ) {
					return false;
				}
			}

			if ( target is Obj_Machinery_Bot ) {
				B = target;

				if ( Convert.ToDouble( B.health ) > 0 ) {
					return false;
				}
			}
			return true;
		}

		// Function from file: simple_animal.dm
		public bool SA_attackable( dynamic target = null ) {
			return this.CanAttack( target );
		}

		// Function from file: simple_animal.dm
		public virtual void Die( bool? gore = null ) {
			dynamic L = null;
			dynamic butchering_type = null;

			this.health = 0;
			GlobalVars.living_mob_list.Remove( this );
			GlobalVars.dead_mob_list.Add( this );
			this.icon_state = this.icon_dead;
			this.stat = 2;
			this.density = false;
			GlobalVars.animal_count[this.type]--;

			if ( !( this.butchering_drops != null ) && Lang13.Bool( GlobalVars.animal_butchering_products[this.species_type] ) ) {
				L = GlobalVars.animal_butchering_products[this.species_type];
				this.butchering_drops = new ByTable();

				foreach (dynamic _a in Lang13.Enumerate( L )) {
					butchering_type = _a;
					
					this.butchering_drops.Add( Lang13.Call( butchering_type ) );
				}
			}
			this.verbs.Add( typeof(Mob_Living).GetMethod( "butcher" ) );
			return;
		}

		// Function from file: simple_animal.dm
		public virtual void wander_move( Tile dest = null ) {
			this.Move( dest );
			return;
		}

		// Function from file: simple_animal.dm
		public override dynamic airflow_hit( dynamic A = null ) {
			return null;
		}

		// Function from file: simple_animal.dm
		public override bool airflow_stun(  ) {
			return false;
		}

		// Function from file: simple_animal.dm
		public override void updatehealth(  ) {
			return;
		}

		// Function from file: simple_animal.dm
		public override dynamic Login(  ) {
			
			if ( this != null && this.client != null ) {
				this.client.reset_screen();
			}
			base.Login();
			return null;
		}

		// Function from file: simple_animal.dm
		public override bool rejuvenate( bool? animation = null ) {
			animation = animation ?? false;

			dynamic T = null;

			T = GlobalFuncs.get_turf( this );

			if ( animation == true ) {
				((Tile)T).turf_animation( "icons/effects/64x64.dmi", "rejuvinate", -16, 0, 5, "sound/effects/rejuvinate.ogg" );
			}
			this.health = this.maxHealth;
			return true;
		}

		// Function from file: simple_animal.dm
		public override bool apply_beam_damage( Obj_Effect_Beam B = null ) {
			dynamic lastcheck = null;
			double damage = 0;

			lastcheck = this.last_beamchecks[new Txt().Ref( B ).ToString()];
			damage = ( Game13.time - Convert.ToDouble( lastcheck ) ) / 10 * ( B.get_damage() / 2 );
			this.health -= damage;
			this.last_beamchecks[new Txt().Ref( B ).ToString()] = Game13.time;
			return false;
		}

		// Function from file: handle_hypothermia.dm
		public override int undergoing_hypothermia(  ) {
			return 0;
		}

		// Function from file: mind.dm
		public override void mind_initialize(  ) {
			base.mind_initialize();
			this.mind.assigned_role = "Animal";
			return;
		}

		// Function from file: suicide.dm
		[Verb]
		[VerbInfo( hidden: true )]
		public virtual void suicide(  ) {
			string confirm = null;

			
			if ( this.stat == 2 ) {
				GlobalFuncs.to_chat( this, "<span class='warning'>You're already dead!</span>" );
				return;
			}

			if ( this.suiciding == true ) {
				GlobalFuncs.to_chat( this, "<span class='warning'>You're already committing suicide! Be patient!</span>" );
				return;
			}
			confirm = Interface13.Alert( "Are you sure you want to commit suicide?", "Confirm Suicide", "Yes", "No" );

			if ( confirm == "Yes" ) {
				this.suiciding = true;
				this.visible_message( new Txt( "<span class='danger'>" ).item( this ).str( " suddenly starts thrashing around! It looks like " ).he_she_it_they().str( "'s trying to commit suicide.</span>" ).ToString() );
				this.Die();
			}
			return;
		}

	}

}