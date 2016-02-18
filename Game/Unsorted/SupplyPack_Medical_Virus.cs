// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Medical_Virus : SupplyPack_Medical {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Virus Crate";
			this.cost = 25;
			this.access = 40;
			this.contains = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bottle_FluVirion), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Cold), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bottle_EpiglottisVirion), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bottle_LiverEnhanceVirion), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bottle_FakeGbs), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Magnitis), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bottle_PierrotThroat), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Brainrot), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bottle_HullucigenVirion), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Anxiety), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Beesease), 
				typeof(Obj_Item_Weapon_Storage_Box_Syringes), 
				typeof(Obj_Item_Weapon_Storage_Box_Beakers), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Mutagen)
			 });
			this.crate_name = "virus crate";
			this.crate_type = typeof(Obj_Structure_Closet_Crate_Secure_Plasma);
			this.dangerous = true;
		}

	}

}