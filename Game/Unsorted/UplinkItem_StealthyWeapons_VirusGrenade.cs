// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_StealthyWeapons_VirusGrenade : UplinkItem_StealthyWeapons {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Fungal Tuberculosis Grenade";
			this.desc = "A primed bio-grenade packed into a compact box. Comes with five Bio Virus Antidote Kit (BVAK) autoinjectors for rapid application on up to two targets each, a syringe, and a bottle containing the BVAK solution.";
			this.item = typeof(Obj_Item_Weapon_Storage_Box_SyndieKit_Tuberculosisgrenade);
			this.cost = 12;
			this.surplus = 35;
			this.include_modes = new ByTable(new object [] { typeof(GameMode_Nuclear) });
		}

	}

}