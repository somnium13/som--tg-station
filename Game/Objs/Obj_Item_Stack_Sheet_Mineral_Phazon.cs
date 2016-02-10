// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Stack_Sheet_Mineral_Phazon : Obj_Item_Stack_Sheet_Mineral {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.singular_name = "phazon sheet";
			this.item_state = "sheet-phazon";
			this.sheettype = "phazon";
			this.perunit = 1500;
			this.melt_temperature = 453.41;
			this.throwforce = 15;
			this.origin_tech = "materials=9";
			this.recyck_mat = "$phazon";
			this.icon_state = "sheet-phazon";
		}

		// Function from file: mineral.dm
		public Obj_Item_Stack_Sheet_Mineral_Phazon ( dynamic loc = null, int? amount = null ) : base( (object)(loc), amount ) {
			this.recipes = GlobalVars.phazon_recipes;
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}