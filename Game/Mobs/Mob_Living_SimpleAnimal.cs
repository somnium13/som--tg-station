// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal : Mob_Living {

		public string icon_living = "";
		public string icon_dead = "";
		public string icon_gib = null;
		public ByTable speak = new ByTable();
		public ByTable speak_emote = new ByTable();
		public double speak_chance = 0;
		public ByTable emote_hear = new ByTable();
		public ByTable emote_see = new ByTable();
		public int turns_per_move = 1;
		public int turns_since_move = 0;
		public bool stop_automated_movement = false;
		public bool wander = true;
		public bool stop_automated_movement_when_pulled = true;
		public string response_help = "pokes";
		public string response_disarm = "shoves";
		public string response_harm = "hits";
		public double harm_intent_damage = 3;
		public double force_threshold = 0;
		public double minbodytemp = 250;
		public double maxbodytemp = 350;
		public bool healable = true;
		public ByTable atmos_requirements = new ByTable().Set( "min_oxy", 5 ).Set( "max_oxy", 0 ).Set( "min_tox", 0 ).Set( "max_tox", 1 ).Set( "min_co2", 0 ).Set( "max_co2", 5 ).Set( "min_n2", 0 ).Set( "max_n2", 0 );
		public int unsuitable_atmos_damage = 2;
		public dynamic melee_damage_lower = 0;
		public dynamic melee_damage_upper = 0;
		public int armour_penetration = 0;
		public string melee_damage_type = "brute";
		public ByTable damage_coeff = new ByTable().Set( "brute", 1 ).Set( "fire", 1 ).Set( "tox", 1 ).Set( "clone", 1 ).Set( "stamina", 0 ).Set( "oxy", 1 );
		public dynamic attacktext = "attacks";
		public string attack_sound = null;
		public string friendly = "nuzzles";
		public int environment_smash = 0;
		public dynamic speed = 1;
		public Type childtype = null;
		public bool scan_ready = true;
		public Type species = null;
		public Obj_Item_Weapon_Card_Id access_card = null;
		public bool flying = false;
		public int buffed = 0;
		public int gold_core_spawnable = 0;
		public Mob_Living_SimpleAnimal_Hostile_Spawner nest = null;
		public int sentience_type = 1;
		public ByTable loot = new ByTable();
		public bool del_on_death = false;
		public string deathmessage = "";
		public int? allow_movement_on_non_turfs = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.health = 20;
			this.maxHealth = 20;
			this.status_flags = 8;
			this.icon = "icons/mob/animal.dmi";
		}

		// Function from file: simple_animal.dm
		public Mob_Living_SimpleAnimal ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.verbs.Remove( typeof(Mob).GetMethod( "observe" ) );

			if ( !Lang13.Bool( this.real_name ) ) {
				this.real_name = this.name;
			}
			return;
		}

		// Function from file: simple_animal.dm
		public override void update_sight(  ) {
			dynamic A = null;

			
			if ( !( this.client != null ) ) {
				return;
			}

			if ( this.stat == 2 ) {
				this.sight = 28;
				this.see_in_dark = 8;
				this.see_invisible = 60;
				return;
			}
			this.see_invisible = Convert.ToInt32( Lang13.Initial( this, "see_invisible" ) );
			this.see_in_dark = Convert.ToInt32( Lang13.Initial( this, "see_in_dark" ) );
			this.sight = Convert.ToInt32( Lang13.Initial( this, "sight" ) );

			if ( this.client.eye != this ) {
				A = this.client.eye;

				if ( ((Ent_Static)A).update_remote_sight( this ) ) {
					return;
				}
			}
			return;
		}

		// Function from file: simple_animal.dm
		public override dynamic Destroy(  ) {
			
			if ( this.nest != null ) {
				this.nest.spawned_mobs.Remove( this );
			}
			this.nest = null;
			return base.Destroy();
		}

		// Function from file: simple_animal.dm
		public override void update_transform(  ) {
			Matrix ntransform = null;
			int changed = 0;

			ntransform = Num13.Matrix( this.transform );
			changed = 0;

			if ( this.resize != 1 ) {
				changed++;
				ntransform.Scale( this.resize );
				this.resize = 1;
			}

			if ( changed != 0 ) {
				Icon13.Animate( new ByTable().Set( 1, this ).Set( "transform", ntransform ).Set( "time", 2 ).Set( "easing", 192 ) );
			}
			return;
		}

		// Function from file: simple_animal.dm
		public override bool update_canmove(  ) {
			
			if ( this.paralysis != 0 || this.stunned != 0 || this.weakened != 0 || this.stat != 0 || this.resting != 0 ) {
				this.drop_r_hand();
				this.drop_l_hand();
				this.canmove = false;
			} else if ( this.buckled != null ) {
				this.canmove = false;
			} else {
				this.canmove = true;
			}
			this.update_transform();
			return this.canmove;
		}

		// Function from file: simple_animal.dm
		public override bool stripPanelEquip( dynamic what = null, Mob who = null, double? where = null, bool? child_override = null ) {
			
			if ( !( child_override == true ) ) {
				this.WriteMsg( "<span class='warning'>You don't have the dexterity to do this!</span>" );
				return false;
			} else {
				base.stripPanelEquip( (object)(what), who, where, child_override );
			}
			return false;
		}

		// Function from file: simple_animal.dm
		public override void stripPanelUnequip( dynamic what = null, Mob who = null, double? where = null, bool? child_override = null ) {
			
			if ( !( child_override == true ) ) {
				this.WriteMsg( "<span class='warning'>You don't have the dexterity to do this!</span>" );
				return;
			} else {
				base.stripPanelUnequip( (object)(what), who, where, child_override );
			}
			return;
		}

		// Function from file: simple_animal.dm
		public override void revive(  ) {
			this.health = this.maxHealth;
			this.icon = Lang13.Initial( this, "icon" );
			this.icon_state = this.icon_living;
			this.density = Lang13.Bool( Lang13.Initial( this, "density" ) );
			this.update_canmove();
			base.revive();
			return;
		}

		// Function from file: simple_animal.dm
		public override void ExtinguishMob(  ) {
			return;
		}

		// Function from file: simple_animal.dm
		public override void IgniteMob(  ) {
			return;
		}

		// Function from file: simple_animal.dm
		public override void update_fire( string fire_icon = null ) {
			return;
		}

		// Function from file: simple_animal.dm
		public override bool handle_fire(  ) {
			return false;
		}

		// Function from file: simple_animal.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			base.ex_act( severity, (object)(target) );

			switch ((int?)( severity )) {
				case 1:
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
			this.updatehealth();
			return false;
		}

		// Function from file: simple_animal.dm
		public override bool death( bool? gibbed = null, bool? toast = null ) {
			dynamic i = null;

			
			if ( this.nest != null ) {
				this.nest.spawned_mobs.Remove( this );
				this.nest = null;
			}

			if ( this.loot.len != 0 ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.loot )) {
					i = _a;
					
					Lang13.Call( i, this.loc );
				}
			}

			if ( Lang13.Bool( this.deathmessage ) && !( gibbed == true ) ) {
				this.visible_message( "<span class='danger'>" + this.deathmessage + "</span>" );
			} else if ( !this.del_on_death ) {
				this.visible_message( new Txt( "<span class='danger'>" ).the( this ).item().str( " stops moving...</span>" ).ToString() );
			}

			if ( this.del_on_death ) {
				this.ghostize();
				GlobalFuncs.qdel( this );
			} else {
				this.health = 0;
				this.icon_state = this.icon_dead;
				this.stat = 2;
				this.density = false;
			}
			base.death( gibbed, toast );
			return false;
		}

		// Function from file: simple_animal.dm
		public override dynamic Stat(  ) {
			base.Stat();

			if ( Interface13.IsStatPanelActive( "Status" ) ) {
				Interface13.Stat( null, "Health: " + Num13.Floor( Convert.ToDouble( this.health / this.maxHealth * 100 ) ) + "%" );
				return 1;
			}
			return null;
		}

		// Function from file: simple_animal.dm
		public override dynamic movement_delay(  ) {
			dynamic _default = null;

			_default = base.movement_delay();
			_default = this.speed;
			_default += GlobalVars.config.animal_delay;
			return _default;
		}

		// Function from file: simple_animal.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( Lang13.Bool( A.flags & 4 ) ) {
				return null;
			}
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

		// Function from file: simple_animal.dm
		public override bool attack_slime( Mob_Living_SimpleAnimal_Slime user = null ) {
			double damage = 0;

			
			if ( base.attack_slime( user ) ) {
				damage = Rand13.Int( 15, 25 );

				if ( user.is_adult ) {
					damage = Rand13.Int( 20, 35 );
				}
				this.attack_threshold_check( damage );
				return true;
			}
			return false;
		}

		// Function from file: simple_animal.dm
		public override bool attack_larva( Mob_Living_Carbon_Alien_Larva user = null ) {
			double damage = 0;

			
			if ( base.attack_larva( user ) ) {
				damage = Rand13.Int( 5, 10 );

				if ( this.stat != 2 ) {
					user.amount_grown = Num13.MinInt( ((int)( user.amount_grown + damage )), user.max_grown );
					this.attack_threshold_check( damage );
				}
				return true;
			}
			return false;
		}

		// Function from file: simple_animal.dm
		public override bool attack_alien( dynamic user = null ) {
			double damage = 0;

			
			if ( base.attack_alien( (object)(user) ) ) {
				
				if ( user.a_intent == "disarm" ) {
					GlobalFuncs.playsound( this.loc, "sound/weapons/pierce.ogg", 25, 1, -1 );
					this.visible_message( "<span class='danger'>" + user + " " + this.response_disarm + " " + this.name + "!</span>", "<span class='userdanger'>" + user + " " + this.response_disarm + " " + this.name + "!</span>" );
					GlobalFuncs.add_logs( user, this, "disarmed" );
				} else {
					damage = Rand13.Int( 15, 30 );
					this.visible_message( "<span class='danger'>" + user + " has slashed at " + this + "!</span>", "<span class='userdanger'>" + user + " has slashed at " + this + "!</span>" );
					GlobalFuncs.playsound( this.loc, "sound/weapons/slice.ogg", 25, 1, -1 );
					this.attack_threshold_check( damage );
					GlobalFuncs.add_logs( user, this, "attacked" );
				}
				return true;
			}
			return false;
		}

		// Function from file: simple_animal.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			double damage = 0;

			
			if ( Lang13.Bool( base.attack_paw( (object)(a), (object)(b), (object)(c) ) ) ) {
				
				if ( this.stat != 2 ) {
					damage = Rand13.Int( 1, 3 );
					this.attack_threshold_check( damage );
					return 1;
				}
			}

			if ( a.a_intent == "help" ) {
				
				if ( Convert.ToDouble( this.health ) > 0 ) {
					this.visible_message( "<span class='notice'>" + a.name + " " + this.response_help + " " + this + ".</span>" );
					GlobalFuncs.playsound( this.loc, "sound/weapons/thudswoosh.ogg", 50, 1, -1 );
				}
			}
			return null;
		}

		// Function from file: simple_animal.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			base.attack_hand( (object)(a), b, c );

			dynamic _a = a.a_intent; // Was a switch-case, sorry for the mess.
			if ( _a=="help" ) {
				
				if ( Convert.ToDouble( this.health ) > 0 ) {
					this.visible_message( "<span class='notice'>" + a + " " + this.response_help + " " + this + ".</span>" );
					GlobalFuncs.playsound( this.loc, "sound/weapons/thudswoosh.ogg", 50, 1, -1 );
				}
			} else if ( _a=="grab" ) {
				this.grabbedby( a );
			} else if ( _a=="harm" || _a=="disarm" ) {
				((Ent_Dynamic)a).do_attack_animation( this );
				this.visible_message( "<span class='danger'>" + a + " " + this.response_harm + " " + this + "!</span>" );
				GlobalFuncs.playsound( this.loc, "punch", 25, 1, -1 );
				this.attack_threshold_check( this.harm_intent_damage );
				GlobalFuncs.add_logs( a, this, "attacked" );
				this.updatehealth();
				return 1;
			}
			return null;
		}

		// Function from file: simple_animal.dm
		public override bool adjustStaminaLoss( dynamic amount = null ) {
			return false;
		}

		// Function from file: simple_animal.dm
		public override dynamic adjustCloneLoss( dynamic amount = null, bool? updating_health = null ) {
			dynamic _default = null;

			
			if ( Lang13.Bool( this.damage_coeff["clone"] ) ) {
				_default = this.adjustHealth( amount * this.damage_coeff["clone"] );
			}
			return _default;
		}

		// Function from file: simple_animal.dm
		public override dynamic adjustToxLoss( dynamic amount = null, bool? updating_health = null ) {
			dynamic _default = null;

			
			if ( Lang13.Bool( this.damage_coeff["tox"] ) ) {
				_default = this.adjustHealth( amount * this.damage_coeff["tox"] );
			}
			return _default;
		}

		// Function from file: simple_animal.dm
		public override dynamic adjustOxyLoss( dynamic amount = null, bool? updating_health = null ) {
			dynamic _default = null;

			
			if ( Lang13.Bool( this.damage_coeff["oxy"] ) ) {
				_default = this.adjustHealth( amount * this.damage_coeff["oxy"] );
			}
			return _default;
		}

		// Function from file: simple_animal.dm
		public override dynamic adjustFireLoss( dynamic amount = null, bool? updating_health = null ) {
			dynamic _default = null;

			
			if ( Lang13.Bool( this.damage_coeff["fire"] ) ) {
				_default = this.adjustHealth( amount * this.damage_coeff["fire"] );
			}
			return _default;
		}

		// Function from file: simple_animal.dm
		public override dynamic adjustBruteLoss( dynamic amount = null, bool? updating_health = null ) {
			dynamic _default = null;

			
			if ( Lang13.Bool( this.damage_coeff["brute"] ) ) {
				_default = this.adjustHealth( amount * this.damage_coeff["brute"] );
			}
			return _default;
		}

		// Function from file: simple_animal.dm
		public override dynamic bullet_act( dynamic P = null, dynamic def_zone = null ) {
			
			if ( !Lang13.Bool( P ) ) {
				return null;
			}
			this.apply_damage( P.damage, P.damage_type );
			((Obj_Item_Projectile)P).on_hit( this );
			return 0;
		}

		// Function from file: simple_animal.dm
		public override bool attack_animal( Mob_Living user = null ) {
			double damage = 0;

			
			if ( base.attack_animal( user ) ) {
				damage = Rand13.Int( Convert.ToInt32( ((dynamic)user).melee_damage_lower ), Convert.ToInt32( ((dynamic)user).melee_damage_upper ) );
				this.attack_threshold_check( damage, ((dynamic)user).melee_damage_type );
				return true;
			}
			return false;
		}

		// Function from file: simple_animal.dm
		public override void emote( string act = null, int? m_type = null, dynamic message = null ) {
			m_type = m_type ?? 1;

			
			if ( this.stat != 0 ) {
				return;
			}

			if ( act == "scream" ) {
				message = "makes a loud and pained whimper";
				act = "me";
			}
			base.emote( act, m_type, (object)(message) );
			return;
		}

		// Function from file: simple_animal.dm
		public override string say_quote( dynamic input = null, dynamic spans = null ) {
			string ending = null;
			dynamic emote = null;

			ending = String13.SubStr( input, Lang13.Length( input ), 0 );

			if ( this.speak_emote != null && this.speak_emote.len != 0 && ending != "?" && ending != "!" ) {
				emote = Rand13.PickFromTable( this.speak_emote );

				if ( Lang13.Bool( emote ) ) {
					return "" + emote + ", \"" + input + "\"";
				}
			}
			return base.say_quote( (object)(input), (object)(spans) );
		}

		// Function from file: simple_animal.dm
		public override bool blob_act( dynamic severity = null ) {
			this.adjustBruteLoss( 20 );
			return false;
		}

		// Function from file: simple_animal.dm
		public override dynamic gib( dynamic animation = null ) {
			animation = animation ?? 0;

			dynamic path = null;
			int? i = null;

			
			if ( Lang13.Bool( this.icon_gib ) ) {
				Icon13.Flick( this.icon_gib, this );
			}

			if ( this.butcher_results != null ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.butcher_results )) {
					path = _a;
					
					i = null;
					i = 1;

					while (( i ??0) <= Convert.ToDouble( this.butcher_results[path] )) {
						Lang13.Call( path, this.loc );
						i++;
					}
				}
			}
			base.gib( (object)(animation) );
			return null;
		}

		// Function from file: simple_animal.dm
		public override void handle_environment( GasMixture environment = null ) {
			bool atmos_suitable = false;
			Ent_Static A = null;
			Ent_Static T = null;
			dynamic areatemp = null;
			dynamic diff = null;
			Ent_Static ST = null;
			ByTable ST_gases = null;
			dynamic tox = null;
			dynamic oxy = null;
			dynamic n2 = null;
			dynamic co2 = null;

			atmos_suitable = true;
			A = this.loc;

			if ( A is Tile ) {
				T = A;
				areatemp = this.get_temperature( environment );

				if ( Math.Abs( Convert.ToDouble( areatemp - this.bodytemperature ) ) > 40 ) {
					diff = areatemp - this.bodytemperature;
					diff = diff / 5;
					this.bodytemperature += diff;
				}

				if ( T is Tile_Simulated ) {
					ST = T;

					if ( Lang13.Bool( ((dynamic)ST).air ) ) {
						ST_gases = ((dynamic)ST).air.gases;
						GlobalVars.hardcoded_gases.Apply( Lang13.BindFunc( ((dynamic)ST).air, "assert_gases" ) );
						tox = ST_gases["plasma"][1];
						oxy = ST_gases["o2"][1];
						n2 = ST_gases["n2"][1];
						co2 = ST_gases["co2"][1];
						((dynamic)ST).air.garbage_collect();

						if ( Lang13.Bool( this.atmos_requirements["min_oxy"] ) && Convert.ToDouble( oxy ) < Convert.ToDouble( this.atmos_requirements["min_oxy"] ) ) {
							atmos_suitable = false;
						} else if ( Lang13.Bool( this.atmos_requirements["max_oxy"] ) && Convert.ToDouble( oxy ) > Convert.ToDouble( this.atmos_requirements["max_oxy"] ) ) {
							atmos_suitable = false;
						} else if ( Lang13.Bool( this.atmos_requirements["min_tox"] ) && Convert.ToDouble( tox ) < Convert.ToDouble( this.atmos_requirements["min_tox"] ) ) {
							atmos_suitable = false;
						} else if ( Lang13.Bool( this.atmos_requirements["max_tox"] ) && Convert.ToDouble( tox ) > Convert.ToDouble( this.atmos_requirements["max_tox"] ) ) {
							atmos_suitable = false;
						} else if ( Lang13.Bool( this.atmos_requirements["min_n2"] ) && Convert.ToDouble( n2 ) < Convert.ToDouble( this.atmos_requirements["min_n2"] ) ) {
							atmos_suitable = false;
						} else if ( Lang13.Bool( this.atmos_requirements["max_n2"] ) && Convert.ToDouble( n2 ) > Convert.ToDouble( this.atmos_requirements["max_n2"] ) ) {
							atmos_suitable = false;
						} else if ( Lang13.Bool( this.atmos_requirements["min_co2"] ) && Convert.ToDouble( co2 ) < Convert.ToDouble( this.atmos_requirements["min_co2"] ) ) {
							atmos_suitable = false;
						} else if ( Lang13.Bool( this.atmos_requirements["max_co2"] ) && Convert.ToDouble( co2 ) > Convert.ToDouble( this.atmos_requirements["max_co2"] ) ) {
							atmos_suitable = false;
						}

						if ( !atmos_suitable ) {
							this.adjustBruteLoss( this.unsuitable_atmos_damage );
						}
					}
				} else if ( Lang13.Bool( this.atmos_requirements["min_oxy"] ) || Lang13.Bool( this.atmos_requirements["min_tox"] ) || Lang13.Bool( this.atmos_requirements["min_n2"] ) || Lang13.Bool( this.atmos_requirements["min_co2"] ) ) {
					this.adjustBruteLoss( this.unsuitable_atmos_damage );
				}
			}
			this.handle_temperature_damage();
			return;
		}

		// Function from file: simple_animal.dm
		public virtual void sentience_act(  ) {
			return;
		}

		// Function from file: simple_animal.dm
		public void make_babies(  ) {
			bool alone = false;
			dynamic partner = null;
			int children = 0;
			dynamic M = null;

			
			if ( this.gender != GlobalVars.FEMALE || this.stat != 0 || !this.scan_ready || !( this.childtype != null ) || !( this.species != null ) ) {
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
				} else if ( Lang13.Bool( ((dynamic)this.species).IsInstanceOfType( M ) ) ) {
					
					if ( Lang13.Bool( M.ckey ) ) {
						continue;
					} else if ( !Lang13.Bool( ((dynamic)this.childtype).IsInstanceOfType( M ) ) && M.gender == GlobalVars.MALE ) {
						partner = M;
					}
				} else if ( M is Mob ) {
					alone = false;
					continue;
				}
			}

			if ( alone && Lang13.Bool( partner ) && children < 3 ) {
				Lang13.Call( this.childtype, this.loc );
			}
			return;
		}

		// Function from file: simple_animal.dm
		public virtual bool CanAttack( dynamic the_target = null ) {
			dynamic L = null;
			dynamic M = null;

			
			if ( this.see_invisible < Convert.ToDouble( the_target.invisibility ) ) {
				return false;
			}

			if ( the_target is Mob_Living ) {
				L = the_target;

				if ( Lang13.Bool( L.stat ) != false ) {
					return false;
				}
			}

			if ( the_target is Obj_Mecha ) {
				M = the_target;

				if ( Lang13.Bool( M.occupant ) ) {
					return false;
				}
			}
			return true;
		}

		// Function from file: simple_animal.dm
		public void attack_threshold_check( double damage = 0, string damagetype = null ) {
			damagetype = damagetype ?? "brute";

			
			if ( damage <= this.force_threshold || !Lang13.Bool( this.damage_coeff[damagetype] ) ) {
				this.visible_message( "<span class='warning'>" + this + " looks unharmed.</span>" );
			} else {
				this.adjustBruteLoss( damage );
				this.updatehealth();
			}
			return;
		}

		// Function from file: simple_animal.dm
		public virtual dynamic adjustHealth( dynamic amount = null ) {
			
			if ( ( this.status_flags & 4096 ) != 0 ) {
				return 0;
			}
			this.bruteloss = Num13.MaxInt( 0, Num13.MinInt( ((int)( this.bruteloss + Convert.ToDouble( amount ) )), Convert.ToInt32( this.maxHealth ) ) );
			this.updatehealth();
			return amount;
		}

		// Function from file: simple_animal.dm
		public virtual void handle_temperature_damage(  ) {
			
			if ( Convert.ToDouble( this.bodytemperature ) < this.minbodytemp ) {
				this.adjustBruteLoss( 2 );
			} else if ( Convert.ToDouble( this.bodytemperature ) > this.maxbodytemp ) {
				this.adjustBruteLoss( 3 );
			}
			return;
		}

		// Function from file: simple_animal.dm
		public virtual void handle_automated_speech( bool? _override = null ) {
			int length = 0;
			int randomValue = 0;
			int length2 = 0;
			int pick = 0;

			
			if ( this.speak_chance != 0 ) {
				
				if ( Rand13.PercentChance( ((int)( this.speak_chance )) ) || _override == true ) {
					
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
									this.emote( "me", 1, Rand13.PickFromTable( this.emote_see ) );
								} else {
									this.emote( "me", 2, Rand13.PickFromTable( this.emote_hear ) );
								}
							}
						} else {
							this.say( Rand13.PickFromTable( this.speak ) );
						}
					} else {
						
						if ( !( this.emote_hear != null && this.emote_hear.len != 0 ) && this.emote_see != null && this.emote_see.len != 0 ) {
							this.emote( "me", 1, Rand13.PickFromTable( this.emote_see ) );
						}

						if ( this.emote_hear != null && this.emote_hear.len != 0 && !( this.emote_see != null && this.emote_see.len != 0 ) ) {
							this.emote( "me", 2, Rand13.PickFromTable( this.emote_hear ) );
						}

						if ( this.emote_hear != null && this.emote_hear.len != 0 && this.emote_see != null && this.emote_see.len != 0 ) {
							length2 = this.emote_hear.len + this.emote_see.len;
							pick = Rand13.Int( 1, length2 );

							if ( pick <= this.emote_see.len ) {
								this.emote( "me", 1, Rand13.PickFromTable( this.emote_see ) );
							} else {
								this.emote( "me", 2, Rand13.PickFromTable( this.emote_hear ) );
							}
						}
					}
				}
			}
			return;
		}

		// Function from file: simple_animal.dm
		public virtual bool handle_automated_movement(  ) {
			dynamic anydir = null;

			
			if ( !this.stop_automated_movement && this.wander ) {
				
				if ( ( this.loc is Tile || Lang13.Bool( this.allow_movement_on_non_turfs ) ) && !( this.resting != 0 ) && !( this.buckled != null ) && this.canmove ) {
					this.turns_since_move++;

					if ( this.turns_since_move >= this.turns_per_move ) {
						
						if ( !( this.stop_automated_movement_when_pulled && this.pulledby != null ) ) {
							anydir = Rand13.PickFromTable( GlobalVars.cardinal );

							if ( this.Process_Spacemove( anydir ) != 0 ) {
								this.Move( Map13.GetStep( this, Convert.ToInt32( anydir ) ), Lang13.IntNullable( anydir ) );
								this.turns_since_move = 0;
							}
						}
					}
					return true;
				}
			}
			return false;
		}

		// Function from file: simple_animal.dm
		public virtual bool handle_automated_action(  ) {
			return false;
		}

		// Function from file: simple_animal.dm
		public override void handle_status_effects(  ) {
			base.handle_status_effects();

			if ( this.stuttering != 0 ) {
				this.stuttering = 0;
			}
			return;
		}

		// Function from file: simple_animal.dm
		public override void adjustEarDamage( double damage = 0, int deaf = 0 ) {
			return;
		}

		// Function from file: simple_animal.dm
		public override void setEarDamage( int damage = 0, double? deaf = null ) {
			return;
		}

		// Function from file: simple_animal.dm
		public override bool become_blind(  ) {
			return false;
		}

		// Function from file: simple_animal.dm
		public override void set_blurriness( int amount = 0 ) {
			return;
		}

		// Function from file: simple_animal.dm
		public override void set_blindness( int amount = 0 ) {
			return;
		}

		// Function from file: simple_animal.dm
		public override void adjust_blurriness( dynamic amount = null ) {
			return;
		}

		// Function from file: simple_animal.dm
		public override void adjust_blindness( int amount = 0 ) {
			return;
		}

		// Function from file: simple_animal.dm
		public override void blur_eyes( dynamic amount = null ) {
			return;
		}

		// Function from file: simple_animal.dm
		public override void blind_eyes( double amount = 0 ) {
			return;
		}

		// Function from file: simple_animal.dm
		public override void update_stat(  ) {
			
			if ( ( this.status_flags & 4096 ) != 0 ) {
				return;
			}

			if ( this.stat != 2 ) {
				
				if ( Convert.ToDouble( this.health ) < 1 ) {
					this.death();
				}
			}
			return;
		}

		// Function from file: simple_animal.dm
		public override bool Life(  ) {
			
			if ( base.Life() ) {
				
				if ( !Lang13.Bool( this.ckey ) ) {
					this.handle_automated_movement();
					this.handle_automated_action();
					this.handle_automated_speech();
				}
				return true;
			}
			return false;
		}

		// Function from file: simple_animal.dm
		public override void updatehealth(  ) {
			base.updatehealth();
			this.health = Num13.MaxInt( 0, Num13.MinInt( Convert.ToInt32( this.health ), Convert.ToInt32( this.maxHealth ) ) );
			return;
		}

		// Function from file: simple_animal.dm
		public override dynamic Login(  ) {
			
			if ( this != null && this.client != null ) {
				this.client.screen = new ByTable();
				this.client.screen.Add( GlobalVars._void );
			}
			base.Login();
			return null;
		}

		// Function from file: mind.dm
		public override void mind_initialize(  ) {
			base.mind_initialize();
			this.mind.assigned_role = "Animal";
			this.mind.special_role = "Animal";
			return;
		}

		// Function from file: item_attack.dm
		public override bool attacked_by( Obj_Item I = null, dynamic user = null, bool? def_zone = null ) {
			
			if ( !Lang13.Bool( I.force ) ) {
				((Ent_Static)user).visible_message( "<span class='warning'>" + user + " gently taps " + this + " with " + I + ".</span>", "<span class='warning'>This weapon is ineffective, it does no damage!</span>" );
			} else if ( Convert.ToDouble( I.force ) >= this.force_threshold && I.damtype != "stamina" ) {
				base.attacked_by( I, (object)(user), def_zone );
			} else {
				this.visible_message( "<span class='warning'>" + I + " bounces harmlessly off of " + this + ".</span>", "<span class='warning'>" + I + " bounces harmlessly off of " + this + "!</span>" );
			}
			return false;
		}

		// Function from file: suicide.dm
		[Verb]
		[VerbInfo( hidden: true )]
		public void suicide(  ) {
			string confirm = null;

			
			if ( !this.canSuicide() ) {
				return;
			}
			confirm = Interface13.Alert( "Are you sure you want to commit suicide?", "Confirm Suicide", "Yes", "No" );

			if ( !this.canSuicide() ) {
				return;
			}

			if ( confirm == "Yes" ) {
				this.suiciding = 1;
				this.visible_message( new Txt( "<span class='danger'>" ).item( this ).str( " begins to fall down. It looks like " ).he_she_it_they().str( "'s lost the will to live.</span>" ).ToString(), new Txt( "<span class='userdanger'>" ).item( this ).str( " begins to fall down. It looks like " ).he_she_it_they().str( "'s lost the will to live.</span>" ).ToString() );
				this.death( false );
			}
			return;
		}

	}

}