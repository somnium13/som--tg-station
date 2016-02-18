// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_DeviceTools_SingularityBeacon : UplinkItem_DeviceTools {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Singularity Beacon";
			this.desc = "When screwed to wiring attached to an electric grid and activated, this large device pulls any active gravitational singularities towards it. This will not work when the singularity is still in containment. A singularity beacon can cause catastrophic damage to a space station, leading to an emergency evacuation. Because of its size, it cannot be carried. Ordering this sends you a small beacon that will teleport the larger beacon to your location upon activation.";
			this.item = typeof(Obj_Item_Device_Sbeacondrop);
			this.cost = 14;
			this.exclude_modes = new ByTable(new object [] { typeof(GameMode_Gang) });
		}

	}

}