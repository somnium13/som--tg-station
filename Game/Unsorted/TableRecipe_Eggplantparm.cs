// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Eggplantparm : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Eggplant parmigiana";
			this.reqs = new ByTable().Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cheesewedge), 2 ).Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Eggplant), 1 );
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Eggplantparm);
			this.category = "Food";
		}

	}

}