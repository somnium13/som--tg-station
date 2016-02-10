// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_Jobspecific_Radgun : UplinkItem_Jobspecific {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Radgun";
			this.desc = "An experimental energy gun that fires radioactive projectiles that burn, irradiate, and scramble DNA, giving the victim a different appearance and name, and potentially harmful or beneficial mutations. Recharges automatically.";
			this.item = typeof(Obj_Item_Weapon_Gun_Energy_Radgun);
			this.cost = 6;
			this.job = new ByTable(new object [] { "Geneticist", "Chief Medical Officer" });
		}

	}

}