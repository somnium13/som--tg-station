// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_Ammo_Bioterror : UplinkItem_Ammo {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Box of Bioterror Syringes";
			this.desc = "A box full of preloaded syringes, containing various chemicals that seize up the victim's motor and broca systems, making it impossible for them to move or speak for some time.";
			this.item = typeof(Obj_Item_Weapon_Storage_Box_SyndieKit_Bioterror);
			this.cost = 6;
			this.include_modes = new ByTable(new object [] { typeof(GameMode_Nuclear) });
		}

	}

}