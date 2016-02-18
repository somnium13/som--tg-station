// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Creamcheesebread : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Cream cheese bread";
			this.reqs = new ByTable()
				.Set( typeof(Reagent_Consumable_Milk), 5 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Store_Bread_Plain), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cheesewedge), 2 )
			;
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Store_Bread_Creamcheese);
			this.category = "Food";
		}

	}

}