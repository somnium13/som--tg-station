// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Baguette : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Baguette";
			this.time = 40;
			this.reqs = new ByTable().Set( typeof(Reagent_Consumable_Sodiumchloride), 1 ).Set( typeof(Reagent_Consumable_Blackpepper), 1 ).Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pastrybase), 2 );
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Baguette);
			this.category = "Food";
		}

	}

}