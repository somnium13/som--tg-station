// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Chawanmushi : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Chawanmushi";
			this.reqs = new ByTable()
				.Set( typeof(Reagent_Water), 5 )
				.Set( typeof(Reagent_Consumable_Soysauce), 5 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Boiledegg), 2 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Mushroom_Chanterelle), 1 )
			;
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Chawanmushi);
			this.category = "Food";
		}

	}

}