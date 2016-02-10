// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Plasticflaps : Obj_Structure {

		public bool airtight = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.explosion_resistance = 5;
			this.icon = "icons/obj/stationobjs.dmi";
			this.icon_state = "plasticflaps";
			this.layer = 4;
		}

		public Obj_Structure_Plasticflaps ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: supplyshuttle.dm
		public override dynamic cultify(  ) {
			new Obj_Structure_Grille_Cult( GlobalFuncs.get_turf( this ) );
			base.cultify();
			return null;
		}

		// Function from file: supplyshuttle.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			
			switch ((double?)( severity )) {
				case 1:
					GlobalFuncs.qdel( this );
					break;
				case 2:
					
					if ( Rand13.PercentChance( 50 ) ) {
						GlobalFuncs.qdel( this );
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( 5 ) ) {
						GlobalFuncs.qdel( this );
					}
					break;
			}
			return false;
		}

		// Function from file: supplyshuttle.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 1.5;
			air_group = air_group ?? false;

			dynamic B = null;
			dynamic M = null;

			
			if ( mover is Ent_Dynamic && ((Ent_Static)mover).checkpass( 2 ) != 0 ) {
				return Rand13.PercentChance( 60 );
			}
			B = mover;

			if ( mover is Obj_Structure_Bed && B.locked_atoms.len != 0 ) {
				return false;
			} else if ( mover is Mob_Living ) {
				M = mover;

				if ( !( M.lying == true ) && !( M is Mob_Living_Carbon_Monkey ) && !( M is Mob_Living_Carbon_Slime ) && !( M is Mob_Living_SimpleAnimal_Mouse ) ) {
					return false;
				}
			}

			if ( !( mover is Ent_Dynamic ) ) {
				return !this.airtight;
			}
			return true;
		}

		// Function from file: supplyshuttle.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			base.examine( (object)(user), size );
			GlobalFuncs.to_chat( user, "It appears to be " + ( Lang13.Bool( this.anchored ) ? "anchored to" : "unachored from" ) + " the floor, " + ( this.airtight ? "and it seems to be airtight as well." : "but it does not seem to be airtight." ) );
			return null;
		}

		// Function from file: supplyshuttle.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic WT = null;

			
			if ( a is Obj_Item_Weapon_Crowbar && this.anchored == 1 ) {
				
				if ( !this.airtight ) {
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Ratchet.ogg", 50, 1 );
				} else {
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Deconstruct.ogg", 50, 1 );
				}
				((Ent_Static)b).visible_message( "" + b + " " + ( this.airtight ? "loosen the " + this + " from" : "tighten the " + this + " into" ) + " an airtight position.", "You " + ( this.airtight ? "loosen the " + this + " from" : "tighten the " + this + " into" ) + " an airtight position." );
				this.airtight = !this.airtight;
				this.name = new Txt().improper().item( ( this.airtight ? "Airtight p" : "P" ) ).str( "lastic flaps" ).ToString();
				this.desc = "" + ( this.airtight ? "Heavy duty, airtight, plastic flaps." : "I definitely can't get past those. No way." );
				return 1;
			}

			if ( a is Obj_Item_Weapon_Wrench && !this.airtight ) {
				
				if ( this.anchored == 0 ) {
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Crowbar.ogg", 50, 1 );
				} else {
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Deconstruct.ogg", 50, 1 );
				}
				((Ent_Static)b).visible_message( "" + b + " " + ( Lang13.Bool( this.anchored ) ? "loosens" : "tightens" ) + " the flap from its anchoring.", "You " + ( Lang13.Bool( this.anchored ) ? "loosen" : "tighten" ) + " the flap from its anchoring." );
				this.anchored = !Lang13.Bool( this.anchored );
				return 1;
			} else if ( a is Obj_Item_Weapon_Weldingtool && this.anchored == 0 ) {
				WT = a;

				if ( Lang13.Bool( WT.remove_fuel( 0, b ) ) ) {
					new Obj_Item_Stack_Sheet_Mineral_Plastic( this.loc, 10 );
					GlobalFuncs.qdel( this );
					return null;
				}
			}
			return base.attackby( (object)(a), (object)(b), (object)(c) );
		}

	}

}