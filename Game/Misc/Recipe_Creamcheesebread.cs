// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Recipe_Creamcheesebread : Recipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.reagents = new ByTable().Set( "flour", 15 );
			this.items = new ByTable(new object [] { typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cheesewedge), typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cheesewedge) });
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Sliceable_Creamcheesebread);
		}

	}

}