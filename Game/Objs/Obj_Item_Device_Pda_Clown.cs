// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Pda_Clown : Obj_Item_Device_Pda {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.default_cartridge = typeof(Obj_Item_Weapon_Cartridge_Clown);
			this.ttone = "honk";
			this.icon_state = "pda-clown";
		}

		public Obj_Item_Device_Pda_Clown ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: PDA.dm
		public override dynamic Crossed( Ent_Dynamic O = null, dynamic X = null ) {
			Ent_Dynamic M = null;
			dynamic honkcartridge = null;

			
			if ( O is Mob_Living_Carbon ) {
				M = O;

				if ( Lang13.Bool( ((dynamic)M).Slip( 8, 5 ) ) ) {
					GlobalFuncs.to_chat( M, "<span class='notice'>You slipped on the PDA!</span>" );

					if ( M is Mob_Living_Carbon_Human && ((dynamic)M).real_name != this.owner && this.cartridge is Obj_Item_Weapon_Cartridge_Clown ) {
						honkcartridge = this.cartridge;

						if ( honkcartridge.honk_charges < 5 ) {
							honkcartridge.honk_charges++;
						}
					}
				}
			}
			return null;
		}

	}

}