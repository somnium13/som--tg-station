// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Outfit_Wizard_Academy : Outfit_Wizard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Academy Wizard";
			this.suit = typeof(Obj_Item_Clothing_Suit_Wizrobe_Red);
			this.head = typeof(Obj_Item_Clothing_Head_Wizard_Red);
			this.backpack_contents = new ByTable().Set( typeof(Obj_Item_Weapon_Storage_Box_Survival), 1 );
		}

	}

}