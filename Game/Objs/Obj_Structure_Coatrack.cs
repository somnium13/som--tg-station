// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Coatrack : Obj_Structure {

		public dynamic suit = null;
		public dynamic hat = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.pressure_resistance = 506.625;
			this.autoignition_temperature = 573.1500244140625;
			this.fire_fuel = 3;
			this.icon = "icons/obj/coatrack.dmi";
			this.icon_state = "coatrack0";
		}

		public Obj_Structure_Coatrack ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: coatrack.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			if ( Lang13.Bool( this.hat ) ) {
				
				if ( Lang13.Bool( this.suit ) ) {
					this.icon_state = "coatrack3";
				} else {
					this.icon_state = "coatrack1";
				}
			} else if ( Lang13.Bool( this.suit ) ) {
				this.icon_state = "coatrack2";
			} else {
				this.icon_state = "coatrack0";
			}
			return null;
		}

		// Function from file: coatrack.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			
			if ( this.loc != null ) {
				
				if ( Lang13.Bool( this.suit ) ) {
					this.suit.loc = this.loc;
				}

				if ( Lang13.Bool( this.hat ) ) {
					this.hat.loc = this.loc;
				}
			}
			base.Destroy( (object)(brokenup) );
			return null;
		}

		// Function from file: coatrack.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			
			switch ((double?)( severity )) {
				case 1:
					GlobalFuncs.qdel( this );
					return false;
					break;
				case 2:
					
					if ( Rand13.PercentChance( 50 ) ) {
						GlobalFuncs.qdel( this );
						return false;
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( 5 ) ) {
						GlobalFuncs.qdel( this );
						return false;
					}
					break;
			}
			return false;
		}

		// Function from file: coatrack.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Obj_Item_Clothing_Suit_Storage_DetSuit && !Lang13.Bool( this.suit ) ) {
				
				if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
					GlobalFuncs.to_chat( b, "<span class='notice'>You place your " + a + " on the " + this + "</span>" );
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "rustle", 50, 1, -5 );
					this.suit = a;
					this.update_icon();
				}
			} else if ( a is Obj_Item_Clothing_Head_DetHat && !Lang13.Bool( this.hat ) ) {
				
				if ( Lang13.Bool( b.drop_item( a, this ) ) ) {
					GlobalFuncs.to_chat( b, "<span class='notice'>You place your " + a + " on the " + this + "</span>" );
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "rustle", 50, 1, -5 );
					this.hat = a;
					this.update_icon();
				}
			} else {
				return base.attackby( (object)(a), (object)(b), (object)(c) );
			}
			return null;
		}

		// Function from file: coatrack.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( Lang13.Bool( this.suit ) ) {
				GlobalFuncs.to_chat( a, "<span class='notice'>You pick up the " + this.suit + " from the " + this + "</span>" );
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "rustle", 50, 1, -5 );
				this.suit.loc = GlobalFuncs.get_turf( this );

				if ( !Lang13.Bool( ((Mob)a).get_active_hand() ) ) {
					((Mob)a).put_in_hands( this.suit );
				}
				this.suit = null;
				this.update_icon();
				return null;
			}

			if ( Lang13.Bool( this.hat ) ) {
				GlobalFuncs.to_chat( a, "<span class='notice'>You pick up the " + this.hat + " from the " + this + "</span>" );
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "rustle", 50, 1, -5 );
				this.hat.loc = GlobalFuncs.get_turf( this );

				if ( !Lang13.Bool( ((Mob)a).get_active_hand() ) ) {
					((Mob)a).put_in_hands( this.hat );
				}
				this.hat = null;
				this.update_icon();
				return null;
			}
			return null;
		}

	}

}