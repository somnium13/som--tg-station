// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Beefnoodle : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Beef noodle";
			this.reqs = new ByTable()
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bowl), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Boiledspaghetti), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Cutlet), 2 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Cabbage), 1 )
			;
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Beefnoodle);
			this.category = "Food";
		}

	}

}