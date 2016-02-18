// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Spidereggsham : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Spider eggs ham";
			this.reqs = new ByTable()
				.Set( typeof(Reagent_Consumable_Sodiumchloride), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Spidereggs), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Cutlet_Spider), 2 )
			;
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Spidereggsham);
			this.category = "Food";
		}

	}

}