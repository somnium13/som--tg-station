// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_Ammo_Machinegun : UplinkItem_Ammo {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.cost = 6;
			this.surplus = 0;
			this.include_modes = new ByTable(new object [] { typeof(GameMode_Nuclear) });
		}

	}

}