// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ObjectiveItem_Steal_Hypo : ObjectiveItem_Steal {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "the hypospray";
			this.targetitem = typeof(Obj_Item_Weapon_ReagentContainers_Hypospray_CMO);
			this.difficulty = 5;
			this.excludefromjob = new ByTable(new object [] { "Chief Medical Officer" });
		}

	}

}