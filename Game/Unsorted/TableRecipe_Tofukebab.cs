// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Tofukebab : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Tofu kebab";
			this.reqs = new ByTable().Set( typeof(Obj_Item_Stack_Rods), 1 ).Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Tofu), 2 );
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Kebab_Tofu);
			this.category = "Food";
		}

	}

}