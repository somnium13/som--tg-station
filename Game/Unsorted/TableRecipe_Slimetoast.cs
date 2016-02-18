// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Slimetoast : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Slime toast";
			this.reqs = new ByTable().Set( typeof(Reagent_Toxin_Slimejelly), 5 ).Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Breadslice_Plain), 1 );
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Jelliedtoast_Slime);
			this.category = "Food";
		}

	}

}