// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Mysterysoup : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Mystery soup";
			this.reqs = new ByTable()
				.Set( typeof(Reagent_Water), 10 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bowl), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Badrecipe), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Tofu), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Boiledegg), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cheesewedge), 1 )
			;
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soup_Mystery);
			this.category = "Food";
		}

	}

}