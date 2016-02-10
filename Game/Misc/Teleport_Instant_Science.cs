// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Teleport_Instant_Science : Teleport_Instant {

		public Teleport_Instant_Science ( dynamic ateleatom = null, dynamic adestination = null, bool? aprecision = null, bool? afteleport = null, dynamic aeffectin = null, dynamic aeffectout = null, dynamic asoundin = null, dynamic asoundout = null ) : base( (object)(ateleatom), (object)(adestination), aprecision, afteleport, (object)(aeffectin), (object)(aeffectout), (object)(asoundin), (object)(asoundout) ) {
			
		}

		// Function from file: teleport.dm
		public override bool teleportChecks(  ) {
			Ent_Dynamic MM = null;
			Ent_Dynamic MM2 = null;
			Ent_Dynamic H = null;
			Ent_Dynamic MM3 = null;

			
			if ( this.teleatom is Obj_Item_Weapon_Disk_Nuclear ) {
				this.teleatom.visible_message( "<span class='danger'>The " + this.teleatom + " bounces off of the portal!</span>" );
				return false;
			}

			if ( Lang13.Bool( this.teleatom.locked_to ) ) {
				return false;
			}

			if ( !GlobalFuncs.isemptylist( this.teleatom.search_contents_for( typeof(Obj_Item_Weapon_Disk_Nuclear) ) ) ) {
				
				if ( this.teleatom is Mob_Living ) {
					MM = this.teleatom;
					MM.visible_message( "<span class='danger'>The " + MM + " bounces off of the portal!</span>", "<span class='warning'>Something you are carrying seems to be unable to pass through the portal. Better drop it if you want to go through.</span>" );
				} else {
					this.teleatom.visible_message( "<span class='danger'>The " + this.teleatom + " bounces off of the portal!</span>" );
				}
				return false;
			}

			if ( this.destination.z == 2 ) {
				
				if ( this.teleatom is Obj_Mecha && GlobalVars.universe.name != "Supermatter Cascade" ) {
					MM2 = this.teleatom;
					GlobalFuncs.to_chat( ((dynamic)MM2).occupant, "<span class='danger'>The mech would not survive the jump to a location so far away!</span>" );
					return false;
				}

				if ( !GlobalFuncs.isemptylist( this.teleatom.search_contents_for( typeof(Obj_Item_Weapon_Storage_Backpack_Holding) ) ) ) {
					this.teleatom.visible_message( "<span class='danger'>The Bag of Holding bounces off of the portal!</span>" );
					return false;
				}
			}

			if ( this.teleatom is Obj_Item_Clothing_Head_Tinfoil ) {
				return false;
			}

			if ( this.teleatom is Mob_Living_Carbon_Human ) {
				H = this.teleatom;

				if ( Lang13.Bool( ((dynamic)H).head ) && ((dynamic)H).head is Obj_Item_Clothing_Head_Tinfoil ) {
					GlobalFuncs.to_chat( H, "<span class'info'>Your headgear has 'foiled' a teleport!</span>" );
					return false;
				}
			}

			if ( this.destination.z > 7 ) {
				return false;
			}

			if ( this.teleatom is Mob_Living ) {
				MM3 = this.teleatom;

				if ( Lang13.Bool( ((dynamic)MM3).locked_to_z ) != false && this.destination.z != Convert.ToInt32( ((dynamic)MM3).locked_to_z ) ) {
					MM3.visible_message( "<span class='danger'>" + MM3 + " bounces off the portal!</span>", "<span class='warning'>You're unable to go to that destination!</span>" );
					return false;
				}
			}
			return true;
		}

		// Function from file: teleport.dm
		public override bool setPrecision( dynamic aprecision = null ) {
			ByTable bagholding = null;
			Ent_Dynamic MM = null;

			base.setPrecision( (object)(aprecision) );

			if ( this.teleatom is Obj_Item_Weapon_Storage_Backpack_Holding ) {
				this.precision = Rand13.Int( 1, 100 );
			}
			bagholding = this.teleatom.search_contents_for( typeof(Obj_Item_Weapon_Storage_Backpack_Holding) );

			if ( bagholding.len != 0 ) {
				this.precision = Num13.MaxInt( Rand13.Int( 1, 100 ) * bagholding.len, 100 );

				if ( this.teleatom is Mob_Living ) {
					MM = this.teleatom;
					GlobalFuncs.to_chat( MM, "<span class='warning'>The Bluespace interface on your Bag of Holding interferes with the teleport!</span>" );
				}
			}
			return true;
		}

		// Function from file: teleport.dm
		public override bool setEffects( dynamic aeffectin = null, dynamic aeffectout = null ) {
			Effect_Effect_System_SparkSpread aeffect = null;

			
			if ( !Lang13.Bool( aeffectin ) || !Lang13.Bool( aeffectout ) ) {
				aeffect = new Effect_Effect_System_SparkSpread();
				aeffect.set_up( 5, 1, this.teleatom );
				this.effectin = this.effectin || aeffect != null;
				this.effectout = this.effectout || aeffect != null;
				return true;
			} else {
				return base.setEffects( (object)(aeffectin), (object)(aeffectout) );
			}
		}

	}

}