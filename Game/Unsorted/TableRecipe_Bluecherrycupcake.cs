// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Bluecherrycupcake : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Blue cherry cupcake";
			this.reqs = new ByTable().Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pastrybase), 1 ).Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Bluecherries), 1 );
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Bluecherrycupcake);
			this.category = "Food";
		}

	}

}