// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_DeviceTools_Teleporter : UplinkItem_DeviceTools {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Teleporter Circuit Board";
			this.desc = "A printed circuit board that completes the teleporter onboard the mothership. Advise you test fire the teleporter before entering it, as malfunctions can occur.";
			this.item = typeof(Obj_Item_Weapon_Circuitboard_Teleporter);
			this.cost = 20;
			this.gamemodes = new ByTable(new object [] { "nuclear emergency" });
		}

	}

}