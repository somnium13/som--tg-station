// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Fudgedice : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Fudge dice";
			this.reqs = new ByTable().Set( typeof(Obj_Item_Weapon_Dice), 1 ).Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Chocolatebar), 1 );
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Fudgedice);
			this.category = "Food";
		}

	}

}