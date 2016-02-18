// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_DeviceTools_AssaultPod : UplinkItem_DeviceTools {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Assault Pod Targetting Device";
			this.desc = "Use to select the landing zone of your assault pod.";
			this.item = typeof(Obj_Item_Device_AssaultPod);
			this.cost = 30;
			this.surplus = 0;
			this.include_modes = new ByTable(new object [] { typeof(GameMode_Nuclear) });
		}

	}

}