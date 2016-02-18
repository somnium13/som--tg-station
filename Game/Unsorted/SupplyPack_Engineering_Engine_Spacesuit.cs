// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Engineering_Engine_Spacesuit : SupplyPack_Engineering_Engine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Space Suit Crate";
			this.cost = 30;
			this.access = 18;
			this.contains = new ByTable(new object [] { 
				typeof(Obj_Item_Clothing_Suit_Space), 
				typeof(Obj_Item_Clothing_Suit_Space), 
				typeof(Obj_Item_Clothing_Head_Helmet_Space), 
				typeof(Obj_Item_Clothing_Head_Helmet_Space), 
				typeof(Obj_Item_Clothing_Mask_Breath), 
				typeof(Obj_Item_Clothing_Mask_Breath)
			 });
			this.crate_name = "space suit crate";
			this.crate_type = typeof(Obj_Structure_Closet_Crate_Secure);
		}

	}

}