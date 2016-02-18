// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Carrotcake : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Carrot cake";
			this.reqs = new ByTable().Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Store_Cake_Plain), 1 ).Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Carrot), 2 );
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Store_Cake_Carrot);
			this.category = "Food";
		}

	}

}