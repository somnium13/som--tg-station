// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Organic_Vending_Cola : SupplyPack_Organic_Vending {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Softdrinks Supply Crate";
			this.cost = 15;
			this.contains = new ByTable(new object [] { typeof(Obj_Item_Weapon_VendingRefill_Cola), typeof(Obj_Item_Weapon_VendingRefill_Cola), typeof(Obj_Item_Weapon_VendingRefill_Cola) });
			this.crate_name = "softdrinks supply crate";
		}

	}

}