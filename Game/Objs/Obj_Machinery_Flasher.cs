// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Flasher : Obj_Machinery {

		public string id_tag = null;
		public int range = 2;
		public bool disable = false;
		public int last_flash = 0;
		public int strength = 10;
		public string base_state = "mflash";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.ghost_read = false;
			this.min_harm_label = 15;
			this.harm_label_examine = new ByTable(new object [] { "<span class='info'>A label is on the bulb, but doesn't cover it.</span>", "<span class='warning'>A label covers the bulb!</span>" });
			this.flags = 257;
			this.icon_state = "mflash1";
		}

		// Function from file: flasher.dm
		public Obj_Machinery_Flasher ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalVars.flashers.Add( this );
			return;
		}

		// Function from file: flasher.dm
		public override dynamic emp_act( int severity = 0 ) {
			
			if ( ( this.stat & 3 ) != 0 ) {
				base.emp_act( severity );
				return null;
			}

			if ( Rand13.PercentChance( ((int)( 75 / severity )) ) ) {
				this.flash();
			}
			base.emp_act( severity );
			return null;
		}

		// Function from file: flasher.dm
		public void flash(  ) {
			dynamic O = null;
			dynamic H = null;
			dynamic H2 = null;
			Organ_Internal E = null;

			
			if ( !Lang13.Bool( this.powered() ) ) {
				return;
			}

			if ( this.disable || this.last_flash != 0 && Game13.time < this.last_flash + 150 ) {
				return;
			}
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/weapons/flash.ogg", 100, 1 );
			this.last_flash = Game13.time;
			this.f_use_power( 1000 );

			if ( this.harm_labeled >= this.min_harm_label ) {
				return;
			}
			Icon13.Flick( "" + this.base_state + "_flash", this );

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, this ) )) {
				O = _a;
				

				if ( O is Mob_Dead_Observer ) {
					continue;
				}

				if ( Map13.GetDistance( this, O ) > this.range ) {
					continue;
				}

				if ( O is Mob_Living_Carbon_Human ) {
					H = O;

					if ( ( !Lang13.Bool( H.eyecheck() ) ?1:0) <= 0 ) {
						continue;
					}
				}

				if ( O is Mob_Living_Carbon_Alien ) {
					continue;
				}
				((Mob)O).Weaken( this.strength );

				if ( O is Mob_Living_Carbon_Human ) {
					H2 = O;
					E = H2.internal_organs_by_name["eyes"];

					if ( E != null && E.damage > E.min_bruised_damage && Rand13.PercentChance( ((int)( E.damage + 50 )) ) ) {
						Icon13.Flick( "e_flash", O.flash );
						E.damage += Rand13.Int( 1, 5 );
					}
				} else if ( !Lang13.Bool( O.blinded ) ) {
					Icon13.Flick( "flash", O.flash );
				}
			}
			return;
		}

		// Function from file: flasher.dm
		public override dynamic attack_ai( dynamic user = null ) {
			
			if ( Lang13.Bool( this.anchored ) ) {
				this.flash(); return null;
			} else {
				return null;
			}
		}

		// Function from file: flasher.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Obj_Item_Weapon_Wirecutters ) {
				this.add_fingerprint( b );
				this.disable = !this.disable;

				if ( this.disable ) {
					((Ent_Static)b).visible_message( "<span class='warning'>" + b + " has disconnected the " + this + "'s flashbulb!</span>", "<span class='warning'>You disconnect the " + this + "'s flashbulb!</span>" );
				}

				if ( !this.disable ) {
					((Ent_Static)b).visible_message( "<span class='warning'>" + b + " has connected the " + this + "'s flashbulb!</span>", "<span class='warning'>You connect the " + this + "'s flashbulb!</span>" );
				}
			}
			return null;
		}

		// Function from file: flasher.dm
		public override dynamic power_change(  ) {
			
			if ( Lang13.Bool( this.powered() ) ) {
				this.stat &= 65533;
				this.icon_state = "" + this.base_state + "1";
			} else {
				this.stat |= 65533;
				this.icon_state = "" + this.base_state + "1-p";
			}
			return null;
		}

		// Function from file: flasher.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			base.Destroy( (object)(brokenup) );
			GlobalVars.flashers.Remove( this );
			return null;
		}

		// Function from file: trash_machinery.dm
		public override dynamic cultify(  ) {
			GlobalFuncs.qdel( this );
			return null;
		}

	}

}