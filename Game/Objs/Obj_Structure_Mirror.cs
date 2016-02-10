// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Mirror : Obj_Structure {

		public bool shattered = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/watercloset.dmi";
			this.icon_state = "mirror";
		}

		public Obj_Structure_Mirror ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: mirror.dm
		public override void attack_slime( Mob_Living_Carbon_Slime user = null ) {
			
			if ( !( user is Mob_Living_Carbon_Slime_Adult ) ) {
				return;
			}

			if ( this.shattered ) {
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/hit_on_shattered_glass.ogg", 70, 1 );
				return;
			}
			user.visible_message( "<span class='danger'>" + user + " smashes " + this + "!</span>" );
			this.shatter();
			return;
		}

		// Function from file: mirror.dm
		public override dynamic attack_animal( Mob_Living user = null ) {
			Mob_Living M = null;

			
			if ( !( user is Mob_Living_SimpleAnimal ) ) {
				return null;
			}
			M = user;

			if ( Convert.ToDouble( ((dynamic)M).melee_damage_upper ) <= 0 ) {
				return null;
			}

			if ( this.shattered ) {
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/hit_on_shattered_glass.ogg", 70, 1 );
				return null;
			}
			user.visible_message( "<span class='danger'>" + user + " smashes " + this + "!</span>" );
			this.shatter();
			return null;
		}

		// Function from file: mirror.dm
		public override dynamic attack_alien( Mob user = null ) {
			
			if ( user is Mob_Living_Carbon_Alien_Larva ) {
				return null;
			}

			if ( this.shattered ) {
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/hit_on_shattered_glass.ogg", 70, 1 );
				return null;
			}
			user.visible_message( "<span class='danger'>" + user + " smashes " + this + "!</span>" );
			this.shatter();
			return null;
		}

		// Function from file: mirror.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic stack = null;

			
			if ( this.shattered && a is Obj_Item_Stack_Sheet_Glass_Glass ) {
				stack = a;

				if ( Convert.ToDouble( stack.amount - 2 ) < 0 ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>You need more glass to do that.</span>" );
				} else {
					stack.use( 2 );
					this.shattered = false;
					this.icon_state = "mirror";
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Deconstruct.ogg", 80, 1 );
				}
			} else if ( this.shattered ) {
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/hit_on_shattered_glass.ogg", 70, 1 );
				return null;
			} else if ( Rand13.PercentChance( Convert.ToInt32( a.force * 2 ) ) ) {
				this.visible_message( "<span class='warning'>" + b + " smashes " + this + " with " + a + "!</span>" );
				this.shatter();
			} else {
				this.visible_message( "<span class='warning'>" + b + " hits " + this + " with " + a + "!</span>" );
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/Glasshit.ogg", 70, 1 );
			}
			return null;
		}

		// Function from file: mirror.dm
		public override int? bullet_act( dynamic Proj = null, dynamic def_zone = null ) {
			
			if ( Rand13.PercentChance( Convert.ToInt32( Proj.damage * 2 ) ) ) {
				
				if ( !this.shattered ) {
					this.shatter();
				} else {
					GlobalFuncs.playsound( this, "sound/effects/hit_on_shattered_glass.ogg", 70, 1 );
				}
			}
			base.bullet_act( (object)(Proj), (object)(def_zone) );
			return null;
		}

		// Function from file: mirror.dm
		public void shatter(  ) {
			
			if ( this.shattered ) {
				return;
			}
			this.shattered = true;
			this.icon_state = "mirror_broke";
			GlobalFuncs.playsound( this, "shatter", 70, 1 );
			this.desc = "Oh no, seven years of bad luck!";
			return;
		}

		// Function from file: mirror.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic H = null;
			Ent_Static userloc = null;
			ByTable species_facial_hair = null;
			dynamic i = null;
			SpriteAccessory tmp_facial = null;
			dynamic new_style = null;
			ByTable species_hair = null;
			dynamic i2 = null;
			SpriteAccessory tmp_hair = null;
			dynamic new_style2 = null;

			
			if ( this.shattered ) {
				return null;
			}

			if ( a is Mob_Living_Carbon_Human ) {
				H = a;
				Interface13.Stat( null, GlobalVars.ticker.mode.vampires.Contains( H.mind ) );

				if ( false || H.mind.vampire != null ) {
					Interface13.Stat( null, H.mind.vampire.powers.Contains( 13 ) );

					if ( !false ) {
						GlobalFuncs.to_chat( H, "<span class='notice'>You don't see anything.</span>" );
						return null;
					}
				}

				if ( ((Mob)a).hallucinating() ) {
					
					dynamic _a = Rand13.Int( 1, 100 ); // Was a switch-case, sorry for the mess.
					if ( 1<=_a&&_a<=20 ) {
						GlobalFuncs.to_chat( H, "<span class='sinister'>You look like " + Rand13.Pick(new object [] { "a monster", "a goliath", "a catbeast", "a ghost", "a chicken", "the mailman", "a demon" }) + "! Your heart skips a beat.</span>" );
						((Mob)H).Weaken( 4 );
						return null;
					} else if ( 21<=_a&&_a<=40 ) {
						GlobalFuncs.to_chat( H, "<span class='sinister'>There's " + Rand13.Pick(new object [] { "somebody", "a monster", "a little girl", "a zombie", "a ghost", "a catbeast", "a demon" }) + " standing behind you!</span>" );
						((Mob)H).emote( "scream", null, null, true );
						H.dir = Num13.Rotate( H.dir, 180 );
						return null;
					} else if ( 41<=_a&&_a<=50 ) {
						GlobalFuncs.to_chat( H, "<span class='notice'>You don't see anything.</span>" );
						return null;
					}
				}
				userloc = H.loc;

				if ( H.gender == GlobalVars.MALE ) {
					species_facial_hair = new ByTable();

					if ( Lang13.Bool( H.species ) ) {
						
						foreach (dynamic _b in Lang13.Enumerate( GlobalVars.facial_hair_styles_list )) {
							i = _b;
							
							tmp_facial = GlobalVars.facial_hair_styles_list[i];
							Interface13.Stat( null, tmp_facial.species_allowed.Contains( H.species.name ) );

							if ( false ) {
								species_facial_hair.Add( i );
							}
						}
					} else {
						species_facial_hair = GlobalVars.facial_hair_styles_list;
					}
					new_style = Interface13.Input( a, "Select a facial hair style", "Grooming", null, species_facial_hair, InputType.Null | InputType.Any );

					if ( userloc != H.loc ) {
						return null;
					}

					if ( Lang13.Bool( new_style ) ) {
						H.f_style = new_style;
					}
				}
				species_hair = new ByTable();

				if ( Lang13.Bool( H.species ) ) {
					
					foreach (dynamic _c in Lang13.Enumerate( GlobalVars.hair_styles_list )) {
						i2 = _c;
						
						tmp_hair = GlobalVars.hair_styles_list[i2];
						Interface13.Stat( null, tmp_hair.species_allowed.Contains( H.species.name ) );

						if ( false ) {
							species_hair.Add( i2 );
						}
					}
				} else {
					species_hair = GlobalVars.hair_styles_list;
				}
				new_style2 = Interface13.Input( a, "Select a hair style", "Grooming", null, species_hair, InputType.Null | InputType.Any );

				if ( userloc != H.loc ) {
					return null;
				}

				if ( Lang13.Bool( new_style2 ) ) {
					H.h_style = new_style2;
				}
				((Mob_Living_Carbon_Human)H).update_hair();
			}
			return null;
		}

	}

}