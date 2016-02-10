// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Recipe_Applecake : Recipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.reagents = new ByTable().Set( "milk", 5 ).Set( "flour", 15 );
			this.items = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Egg), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Egg), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Egg), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Apple), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Apple)
			 });
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Sliceable_Applecake);
		}

	}

}