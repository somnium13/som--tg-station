// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Recipe_Meatballspaghetti : Recipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.reagents = new ByTable().Set( "water", 5 );
			this.items = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Spaghetti), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Faggot), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Faggot)
			 });
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meatballspaghetti);
		}

	}

}