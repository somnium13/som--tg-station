// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Sassysagepizza : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Sassysage pizza";
			this.reqs = new ByTable()
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pizzabread), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Faggot), 3 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cheesewedge), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tomato), 1 )
			;
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pizza_Sassysage);
			this.category = "Food";
		}

	}

}