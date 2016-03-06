// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Sign_Poster : Obj_Structure_Sign {

		public dynamic serial_number = null;
		public bool ruined = false;
		public bool? official = false;
		public double placespeed = 37;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/contraband.dmi";
		}

		// Function from file: contraband.dm
        // TODO Does this actually take loc? base was being called with serial. -Pdan
		public Obj_Structure_Sign_Poster (dynamic loc = null, dynamic serial = null, bool rolled_official = false ) : base( (object)(loc) ) {
			this.serial_number = serial;
			this.official = rolled_official;

			//if ( this.serial_number == this.loc ) {   //This was a tautology to begin with. -Pdan
				
				if ( !( this.official == true ) ) {
					this.serial_number = Rand13.Int( 1, 36 );
				}

				if ( this.official == true ) {
					this.serial_number = Rand13.Int( 1, 35 );
				}
			//}

			if ( !( this.official == true ) ) {
				this.icon_state = "poster" + this.serial_number;
				this.name += GlobalVars.contrabandposters[this.serial_number]["name"];
				this.desc += GlobalVars.contrabandposters[this.serial_number]["desc"];
			} else if ( this.official == true ) {
				this.icon_state = "poster" + this.serial_number + "_legit";
				this.name += GlobalVars.legitposters[this.serial_number]["name"];
				this.desc += GlobalVars.legitposters[this.serial_number]["desc"];
			}
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: contraband.dm
		public void roll_and_drop( Ent_Static location = null, bool? official = null ) {
			Obj_Item_Weapon_Poster_Contraband P = null;
			Obj_Item_Weapon_Poster_Legit P2 = null;

			
			if ( !( official == true ) ) {
				P = new Obj_Item_Weapon_Poster_Contraband( this, this.serial_number );
				P.resulting_poster = this;
				P.loc = location;
				P.pixel_x = 0;
				P.pixel_y = 0;
				this.loc = P;
			} else {
				P2 = new Obj_Item_Weapon_Poster_Legit( this, this.serial_number );
				P2.resulting_poster = this;
				P2.loc = location;
				P2.pixel_x = 0;
				P2.pixel_y = 0;
				this.loc = P2;
			}
			return;
		}

		// Function from file: contraband.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			Ent_Static temp_loc = null;

			
			if ( this.ruined ) {
				return null;
			}
			temp_loc = a.loc;

			if ( a.loc != temp_loc || this.ruined ) {
				return null;
			}
			this.visible_message( "" + a + " rips " + this + " in a single, decisive motion!" );
			GlobalFuncs.playsound( this.loc, "sound/items/poster_ripped.ogg", 100, 1 );
			this.ruined = true;
			this.icon_state = "poster_ripped";
			this.name = "ripped poster";
			this.desc = "You can't make out anything from the poster's original print. It's ruined.";
			this.add_fingerprint( a );
			return null;
		}

		// Function from file: contraband.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( A is Obj_Item_Weapon_Wirecutters ) {
				GlobalFuncs.playsound( this.loc, "sound/items/Wirecutter.ogg", 100, 1 );

				if ( this.ruined ) {
					user.WriteMsg( "<span class='notice'>You remove the remnants of the poster.</span>" );
					GlobalFuncs.qdel( this );
				} else {
					user.WriteMsg( "<span class='notice'>You carefully remove the poster from the wall.</span>" );
					this.roll_and_drop( user.loc, this.official );
				}
				return null;
			}
			return null;
		}

	}

}