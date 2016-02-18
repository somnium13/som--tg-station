// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Teleprod : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Teleprod";
			this.result = typeof(Obj_Item_Weapon_Melee_Baton_Cattleprod_Teleprod);
			this.reqs = new ByTable()
				.Set( typeof(Obj_Item_Weapon_Restraints_Handcuffs_Cable), 1 )
				.Set( typeof(Obj_Item_Stack_Rods), 1 )
				.Set( typeof(Obj_Item_Weapon_Wirecutters), 1 )
				.Set( typeof(Obj_Item_Weapon_StockParts_Cell), 1 )
				.Set( typeof(Obj_Item_Weapon_Ore_BluespaceCrystal), 1 )
			;
			this.time = 40;
			this.parts = new ByTable().Set( typeof(Obj_Item_Weapon_StockParts_Cell), 1 );
			this.category = "Weaponry";
		}

	}

}