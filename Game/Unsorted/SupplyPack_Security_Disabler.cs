// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Security_Disabler : SupplyPack_Security {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Disabler Crate";
			this.cost = 10;
			this.contains = new ByTable(new object [] { typeof(Obj_Item_Weapon_Gun_Energy_Disabler), typeof(Obj_Item_Weapon_Gun_Energy_Disabler), typeof(Obj_Item_Weapon_Gun_Energy_Disabler) });
			this.crate_name = "disabler crate";
		}

	}

}