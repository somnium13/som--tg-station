// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Emergency_Weedcontrol : SupplyPack_Emergency {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Weed Control Crate";
			this.cost = 15;
			this.access = 35;
			this.contains = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_Scythe), 
				typeof(Obj_Item_Clothing_Mask_Gas), 
				typeof(Obj_Item_Weapon_Grenade_ChemGrenade_Antiweed), 
				typeof(Obj_Item_Weapon_Grenade_ChemGrenade_Antiweed)
			 });
			this.crate_name = "weed control crate";
			this.crate_type = typeof(Obj_Structure_Closet_Crate_Secure_Hydroponics);
		}

	}

}