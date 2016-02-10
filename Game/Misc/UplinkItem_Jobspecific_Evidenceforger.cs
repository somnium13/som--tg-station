// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_Jobspecific_Evidenceforger : UplinkItem_Jobspecific {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Evidence Forger";
			this.desc = "An evidence scanner that allows you forge evidence by setting the output before scanning the item.";
			this.item = typeof(Obj_Item_Device_DetectiveScanner_Forger);
			this.cost = 3;
			this.job = new ByTable(new object [] { "Detective" });
		}

	}

}