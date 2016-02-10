// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Grenade_Iedcasing : Obj_Item_Weapon_Grenade {

		public int assembled = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.active = true;
			this.icon_state = "improvised_grenade";
		}

		public Obj_Item_Weapon_Grenade_Iedcasing ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: ghettobomb.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			base.examine( (object)(user), size );

			if ( this.assembled == 3 ) {
				GlobalFuncs.to_chat( user, "<span class='info'>You can't tell when it will explode!</span>" );
			}
			return null;
		}

		// Function from file: ghettobomb.dm
		public override void prime( dynamic L = null ) {
			Ent_Static boomtrap = null;
			Ent_Static H = null;
			dynamic leg = null;

			this.update_mob();
			GlobalFuncs.explosion( GlobalFuncs.get_turf( this.loc ), -1, 0, 2 );

			if ( this.loc is Obj_Item_Weapon_Legcuffs_Beartrap ) {
				boomtrap = this.loc;

				if ( boomtrap.loc is Mob_Living_Carbon_Human ) {
					H = this.loc.loc;

					if ( ((dynamic)H).legcuffed == boomtrap ) {
						leg = ((dynamic)H).get_organ( "" + Rand13.Pick(new object [] { "l", "r" }) + "_leg" );

						if ( Lang13.Bool( leg ) && !Lang13.Bool( leg.status & 64 ) ) {
							((Organ_External)leg).droplimb( 1, false );
						}
						GlobalFuncs.qdel( ((dynamic)H).legcuffed );
						((dynamic)H).legcuffed = null;
					}
				}
			}
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: ghettobomb.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			dynamic bombturf = null;
			dynamic A = null;
			string log_str = null;
			dynamic C = null;

			
			if ( !this.active ) {
				
				if ( this.clown_check( user ) ) {
					GlobalFuncs.to_chat( user, "<span class='warning'>You light the " + this.name + "!</span>" );
					this.active = true;
					this.overlays.Remove( new Image( "icons/obj/grenade.dmi", null, "improvised_grenade_filled" ) );
					this.icon_state = Lang13.Initial( this, "icon_state" ) + "_active";
					this.assembled = 3;
					this.add_fingerprint( user );
					bombturf = GlobalFuncs.get_turf( this );
					A = GlobalFuncs.get_area( bombturf );
					log_str = new Txt().item( GlobalFuncs.key_name( Task13.User ) ).str( "<A HREF='?_src_=holder;adminmoreinfo=" ).Ref( Task13.User ).str( "'>?</A> has primed a " ).item( this.name ).str( " for detonation at <A HREF='?_src_=holder;adminplayerobservecoodjump=1;X=" ).item( bombturf.x ).str( ";Y=" ).item( bombturf.y ).str( ";Z=" ).item( bombturf.z ).str( "'>" ).item( A.name ).str( " (JMP)</a>." ).ToString();
					GlobalFuncs.message_admins( log_str );
					GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + log_str ) );

					if ( user is Mob_Living_Carbon ) {
						C = user;
						((Mob_Living_Carbon)C).throw_mode_on();
					}
					Task13.Schedule( this.det_time, (Task13.Closure)(() => {
						this.prime();
						return;
					}));
				}
			}
			return null;
		}

		// Function from file: ghettobomb.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic C = null;

			
			if ( a is Obj_Item_Stack_CableCoil ) {
				
				if ( this.assembled == 1 ) {
					C = a;
					((Obj_Item_Stack)C).use( 1 );
					this.assembled = 2;
					GlobalFuncs.to_chat( b, "<span  class='notice'>You wire the igniter to detonate the fuel.</span>" );
					this.desc = "A weak, improvised explosive.";
					this.overlays.Add( new Image( "icons/obj/grenade.dmi", null, "improvised_grenade_wired" ) );
					this.name = "improvised explosive";
					this.active = false;
					this.det_time = Rand13.Int( 30, 80 );
				}
			}
			return null;
		}

		// Function from file: ghettobomb.dm
		public override bool afterattack( dynamic A = null, dynamic user = null, bool? flag = null, dynamic _params = null, bool? struggle = null ) {
			dynamic F = null;

			
			if ( this.assembled == 0 ) {
				
				if ( A is Obj_Structure_ReagentDispensers_Fueltank && ((Ent_Static)A).Adjacent( user ) ) {
					
					if ( ( A.reagents.total_volume ??0) < 50 ) {
						GlobalFuncs.to_chat( user, "<span  class='notice'>There's not enough fuel left to work with.</span>" );
						return false;
					}
					F = A;
					((Reagents)F.reagents).remove_reagent( "fuel", 50, true );
					this.assembled = 1;
					GlobalFuncs.to_chat( user, "<span  class='notice'>You've filled the makeshift explosive with welding fuel.</span>" );
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/refill.ogg", 50, 1, -6 );
					this.desc = "An improvised explosive assembly. Filled to the brim with 'Explosive flavor'";
					this.overlays.Add( new Image( "icons/obj/grenade.dmi", null, "improvised_grenade_filled" ) );
					return false;
				}
			}
			return false;
		}

	}

}