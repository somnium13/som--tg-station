// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPacks_Evacuation : SupplyPacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Emergency equipment";
			this.contains = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_Storage_Toolbox_Emergency), 
				typeof(Obj_Item_Weapon_Storage_Toolbox_Emergency), 
				typeof(Obj_Item_Clothing_Suit_Storage_Hazardvest), 
				typeof(Obj_Item_Clothing_Suit_Storage_Hazardvest), 
				typeof(Obj_Item_Weapon_Tank_EmergencyOxygen), 
				typeof(Obj_Item_Weapon_Tank_EmergencyOxygen), 
				typeof(Obj_Item_Weapon_Tank_EmergencyOxygen), 
				typeof(Obj_Item_Weapon_Tank_EmergencyOxygen), 
				typeof(Obj_Item_Weapon_Tank_EmergencyOxygen), 
				typeof(Obj_Item_Clothing_Mask_Gas), 
				typeof(Obj_Item_Clothing_Mask_Gas), 
				typeof(Obj_Item_Clothing_Mask_Gas), 
				typeof(Obj_Item_Clothing_Mask_Gas), 
				typeof(Obj_Item_Clothing_Mask_Gas), 
				typeof(Obj_Machinery_Bot_Floorbot), 
				typeof(Obj_Machinery_Bot_Floorbot), 
				typeof(Obj_Machinery_Bot_Medbot), 
				typeof(Obj_Machinery_Bot_Medbot)
			 });
			this.cost = 40;
			this.containertype = typeof(Obj_Structure_Closet_Crate_Internals);
			this.containername = "Emergency Crate";
		}

	}

}