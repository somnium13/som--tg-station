// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TheftObjective_Number_Salvage_Plasteel : TheftObjective_Number_Salvage {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "plasteel";
			this.typepath = typeof(Obj_Item_Stack_Sheet_Plasteel);
			this.min = 100;
			this.max = 100;
		}

	}

}