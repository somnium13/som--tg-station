// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPacks_Grass : SupplyPacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "30 Grass Tiles";
			this.contains = new ByTable(new object [] { typeof(Obj_Item_Stack_Tile_Grass) });
			this.amount = 30;
			this.cost = 15;
			this.containertype = typeof(Obj_Structure_Closet_Crate);
			this.containername = "Grass Crate";
		}

	}

}