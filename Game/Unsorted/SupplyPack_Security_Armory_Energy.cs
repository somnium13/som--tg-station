// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Security_Armory_Energy : SupplyPack_Security_Armory {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Energy Guns Crate";
			this.cost = 25;
			this.contains = new ByTable(new object [] { typeof(Obj_Item_Weapon_Gun_Energy_Gun), typeof(Obj_Item_Weapon_Gun_Energy_Gun) });
			this.crate_name = "energy gun crate";
			this.crate_type = typeof(Obj_Structure_Closet_Crate_Secure_Plasma);
		}

	}

}