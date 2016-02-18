// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Wrap : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Wrap";
			this.reqs = new ByTable()
				.Set( typeof(Reagent_Consumable_Soysauce), 10 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Friedegg), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Cabbage), 1 )
			;
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Eggwrap);
			this.category = "Food";
		}

	}

}