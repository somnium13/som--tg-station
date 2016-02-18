// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Clownstears : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Clowns tears";
			this.reqs = new ByTable()
				.Set( typeof(Reagent_Water), 10 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bowl), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Banana), 1 )
				.Set( typeof(Obj_Item_Weapon_Ore_Bananium), 1 )
			;
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soup_Clownstears);
			this.category = "Food";
		}

	}

}