// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Materials_Plasteel50 : SupplyPack_Materials {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "50 Plasteel Sheets";
			this.cost = 50;
			this.contains = new ByTable(new object [] { typeof(Obj_Item_Stack_Sheet_Plasteel_Fifty) });
			this.crate_name = "plasteel sheets crate";
		}

	}

}