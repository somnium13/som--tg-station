// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPacks_Miningmachines : SupplyPacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Dwarven Mining Equipment stack of packs";
			this.contains = new ByTable(new object [] { typeof(Obj_Structure_Vendomatpack_Mining), typeof(Obj_Structure_Vendomatpack_Mining) });
			this.cost = 10;
			this.containertype = typeof(Obj_Structure_Stackopacks);
			this.containername = "Mining stack of packs";
			this.group = "Vending Machine packs";
		}

	}

}