// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Sandwich : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Sandwich";
			this.reqs = new ByTable()
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Breadslice_Plain), 2 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Steak), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cheesewedge), 1 )
			;
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Sandwich);
			this.category = "Food";
		}

	}

}