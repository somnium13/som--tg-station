// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_Ammo_Pistol : UplinkItem_Ammo {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "10mm Handgun Magazine";
			this.desc = "An additional 8-round 10mm magazine; compatible with the Stechkin Pistol. These subsonic rounds are dirt cheap but are half as effective as .357 rounds.";
			this.item = typeof(Obj_Item_AmmoBox_Magazine_M10mm);
			this.cost = 1;
		}

	}

}