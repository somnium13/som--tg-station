// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_StealthyWeapons_PizzaBomb : UplinkItem_StealthyWeapons {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Pizza Bomb";
			this.desc = "A pizza box with a bomb cunningly attached to the lid. The timer needs to be set by opening the box; afterwards, opening the box again will trigger the detonation after the timer has elapsed. Comes with free pizza, for you or your target!";
			this.item = typeof(Obj_Item_Pizzabox_Bomb);
			this.cost = 6;
			this.surplus = 8;
		}

	}

}