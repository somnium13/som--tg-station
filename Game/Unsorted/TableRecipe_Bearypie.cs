// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Bearypie : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Beary Pie";
			this.reqs = new ByTable()
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pie_Plain), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Berries), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Steak_Bear), 1 )
			;
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pie_Bearypie);
			this.category = "Food";
		}

	}

}