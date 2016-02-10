// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Recipe_Cookiebowl : Recipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.reagents = new ByTable().Set( "flour", 5 ).Set( "sugar", 2 );
			this.items = new ByTable(new object [] { typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Egg), typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Chocolatebar) });
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cookiebowl);
		}

	}

}