// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Displaycase : Obj_Structure {

		public double health = 30;
		public dynamic occupant = null;
		public bool destroyed = false;
		public bool locked = false;
		public string ue = null;
		public Image occupant_overlay = null;
		public dynamic circuit = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.unacidable = true;
			this.icon = "icons/obj/stationobjs.dmi";
			this.icon_state = "glassbox20";
		}

		public Obj_Structure_Displaycase ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: displaycase.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( this.destroyed ) {
				
				if ( Lang13.Bool( this.occupant ) ) {
					this.dump();
					GlobalFuncs.to_chat( a, "<span class='danger'>You smash your fist into the delicate electronics at the bottom of the case, and deactivate the hoverfield permanently.</span>" );
					this.add_fingerprint( a );
					this.update_icon();
				}
			} else if ( a.a_intent == "hurt" ) {
				((Mob)a).delayNextAttack( 8 );
				((Ent_Static)a).visible_message( new Txt( "<span class='danger'>" ).item( a.name ).str( " kicks " ).the( this ).item().str( "!</span>" ).ToString(), new Txt( "<span class='danger'>You kick " ).the( this ).item().str( "!</span>" ).ToString(), "You hear glass crack." );
				this.health -= 2;
				this.healthcheck();
			} else if ( !this.locked ) {
				
				if ( a is Mob_Living_Carbon_Human ) {
					
					if ( !Lang13.Bool( this.ue ) ) {
						GlobalFuncs.to_chat( a, "<span class='notice'>You press your thumb against the fingerprint scanner, registering your identity with the case.</span>" );
						this.ue = this.getPrint( a );
						return null;
					}

					if ( this.ue != this.getPrint( a ) ) {
						GlobalFuncs.to_chat( a, "<span class='rose'>Access denied.</span>" );
						return null;
					}
					GlobalFuncs.to_chat( a, "<span class='notice'>You press your thumb against the fingerprint scanner, and deactivate the hoverfield built into the case.</span>" );

					if ( Lang13.Bool( this.occupant ) ) {
						this.dump();
						this.update_icon();
					} else {
						GlobalFuncs.to_chat( this, new Txt().icon( this ).str( " <span class='rose'>" ).The( this ).item().str( " is empty!</span>" ).ToString() );
					}
				}
			} else {
				((Mob)a).delayNextAttack( 10 );
				((Ent_Static)a).visible_message( new Txt().item( a.name ).str( " gently runs their hands over " ).the( this ).item().str( " in appreciation of its contents." ).ToString(), new Txt( "You gently run your hands over " ).the( this ).item().str( " in appreciation of its contents." ).ToString(), "You hear someone streaking glass with their greasy hands." );
			}
			return null;
		}

		// Function from file: displaycase.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: displaycase.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic I = null;
			dynamic T = null;
			Obj_Item_Weapon_Circuitboard_Airlock C = null;
			Obj_Structure_DisplaycaseFrame F = null;

			
			if ( a is Obj_Item_Weapon_Card_Id ) {
				I = a;

				if ( !this.check_access( I ) ) {
					GlobalFuncs.to_chat( b, "<span class='rose'>Access denied.</span>" );
					return null;
				}
				this.locked = !this.locked;

				if ( !this.locked ) {
					GlobalFuncs.to_chat( b, new Txt().icon( this ).str( " <span class='notice'>" ).The( this ).item().str( " clicks as locks release, and it slowly opens for you.</span>" ).ToString() );
				} else {
					GlobalFuncs.to_chat( b, new Txt().icon( this ).str( " <span class='notice'>You close " ).the( this ).item().str( " and swipe your card, locking it.</span>" ).ToString() );
				}
				this.update_icon();
			} else if ( a is Obj_Item_Weapon_Crowbar && ( !this.locked || this.destroyed ) ) {
				((Ent_Static)b).visible_message( new Txt().item( b.name ).str( " pries " ).the( this ).item().str( " apart." ).ToString(), new Txt( "You pry " ).the( this ).item().str( " apart." ).ToString(), "You hear something pop." );
				T = GlobalFuncs.get_turf( this );
				GlobalFuncs.playsound( T, "sound/items/Crowbar.ogg", 50, 1 );
				this.dump();
				C = this.circuit;

				if ( !( C != null ) ) {
					C = new Obj_Item_Weapon_Circuitboard_Airlock( this );
					C.installed = true;
				}
				C.one_access = !( Lang13.Bool( this.req_access ) && this.req_access.len > 0 );

				if ( !C.one_access ) {
					C.conf_access = this.req_access;
				} else {
					C.conf_access = this.req_one_access;
				}

				if ( !this.destroyed ) {
					F = new Obj_Structure_DisplaycaseFrame( T );
					F.state = 1;
					F.circuit = C;
					F.circuit.loc = F;
					F.update_icon();
				} else {
					C.loc = T;
					C.installed = false;
					this.circuit = null;
					new Obj_Machinery_ConstructableFrame_MachineFrame( T );
				}
				GlobalFuncs.qdel( this );
			} else if ( b.a_intent == "hurt" ) {
				((Mob)b).delayNextAttack( 8 );
				this.health -= Convert.ToDouble( a.force );
				this.healthcheck();
				base.attackby( (object)(a), (object)(b), (object)(c) );
			} else if ( this.locked ) {
				GlobalFuncs.to_chat( b, "<span class='rose'>It's locked, you can't put anything into it.</span>" );
			} else if ( !Lang13.Bool( this.occupant ) ) {
				
				if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
					GlobalFuncs.to_chat( b, new Txt( "<span class='notice'>You insert " ).the( a ).item().str( " into " ).the( this ).item().str( ", and it floats as the hoverfield activates.</span>" ).ToString() );
					this.occupant = a;
					this.update_icon();
				}
			}
			return null;
		}

		// Function from file: displaycase.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			Icon occupant_icon = null;

			
			if ( this.destroyed ) {
				this.icon_state = "glassbox2b";
			} else {
				this.icon_state = "glassbox2" + this.locked;
			}
			this.overlays = 0;

			if ( Lang13.Bool( this.occupant ) ) {
				occupant_icon = GlobalFuncs.getFlatIcon( this.occupant );
				occupant_icon.Scale( 19, 19 );
				this.occupant_overlay = new Image( occupant_icon );
				this.occupant_overlay.pixel_x = 8;
				this.occupant_overlay.pixel_y = 8;

				if ( this.locked ) {
					this.occupant_overlay.alpha = 128;
				}
				this.overlays.Add( this.occupant_overlay );
			}
			return null;
		}

		// Function from file: displaycase.dm
		public override bool blob_act( dynamic severity = null ) {
			
			if ( Rand13.PercentChance( 75 ) ) {
				GlobalFuncs.getFromPool( typeof(Obj_Item_Weapon_Shard), this.loc );

				if ( Lang13.Bool( this.occupant ) ) {
					this.dump();
				}
				GlobalFuncs.qdel( this );
			}
			return false;
		}

		// Function from file: displaycase.dm
		public override int? bullet_act( dynamic Proj = null, dynamic def_zone = null ) {
			this.health -= Convert.ToDouble( Proj.damage );
			base.bullet_act( (object)(Proj), (object)(def_zone) );
			this.healthcheck();
			return null;
		}

		// Function from file: displaycase.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			
			switch ((double?)( severity )) {
				case 1:
					GlobalFuncs.getFromPool( typeof(Obj_Item_Weapon_Shard), this.loc );

					if ( Lang13.Bool( this.occupant ) ) {
						this.dump();
					}
					GlobalFuncs.qdel( this );
					break;
				case 2:
					
					if ( Rand13.PercentChance( 50 ) ) {
						this.health -= 15;
						this.healthcheck();
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( 50 ) ) {
						this.health -= 5;
						this.healthcheck();
					}
					break;
			}
			return false;
		}

		// Function from file: displaycase.dm
		public string getPrint( dynamic user = null ) {
			return Num13.Md5( user.dna.uni_identity );
		}

		// Function from file: displaycase.dm
		public void healthcheck(  ) {
			
			if ( this.health <= 0 ) {
				
				if ( !this.destroyed ) {
					this.density = false;
					this.destroyed = true;
					GlobalFuncs.getFromPool( typeof(Obj_Item_Weapon_Shard), this.loc );
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "shatter", 70, 1 );
					this.update_icon();
				}
			} else {
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/Glasshit.ogg", 75, 1 );
			}
			return;
		}

		// Function from file: displaycase.dm
		public void dump(  ) {
			
			if ( Lang13.Bool( this.occupant ) ) {
				this.occupant.loc = GlobalFuncs.get_turf( this );
				this.occupant = null;
			}
			this.occupant_overlay = null;
			return;
		}

		// Function from file: displaycase.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			string msg = null;

			base.examine( (object)(user), size );
			msg = "<span class='info'>Peering through the glass, you see that it contains:</span>";

			if ( Lang13.Bool( this.occupant ) ) {
				msg += new Txt().icon( this.occupant ).str( " <span class='notice'>" ).A( this.occupant ).item().str( "</span>" ).ToString();
			} else {
				msg += "Nothing.";
			}
			GlobalFuncs.to_chat( user, msg );
			return null;
		}

		// Function from file: displaycase.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			base.Destroy( (object)(brokenup) );

			if ( Lang13.Bool( this.circuit ) ) {
				GlobalFuncs.qdel( this.circuit );
				this.circuit = null;
			}
			this.dump();
			return null;
		}

	}

}