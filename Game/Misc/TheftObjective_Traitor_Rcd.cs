// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TheftObjective_Traitor_Rcd : TheftObjective_Traitor {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "an RCD";
			this.typepath = typeof(Obj_Item_Device_Rcd_Matter_Engineering);
			this.protected_jobs = new ByTable(new object [] { "Chief Engineer" });
		}

	}

}