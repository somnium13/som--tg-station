// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Security_Armory_Wt550ammo : SupplyPack_Security_Armory {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "WT-550 Auto Rifle Ammo Crate";
			this.cost = 30;
			this.contains = new ByTable(new object [] { 
				typeof(Obj_Item_AmmoBox_Magazine_Wt550m9), 
				typeof(Obj_Item_AmmoBox_Magazine_Wt550m9), 
				typeof(Obj_Item_AmmoBox_Magazine_Wt550m9), 
				typeof(Obj_Item_AmmoBox_Magazine_Wt550m9)
			 });
			this.crate_name = "auto rifle ammo crate";
		}

	}

}