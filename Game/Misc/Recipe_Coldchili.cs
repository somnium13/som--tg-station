// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Recipe_Coldchili : Recipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.items = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Icepepper), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tomato)
			 });
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Coldchili);
		}

	}

}