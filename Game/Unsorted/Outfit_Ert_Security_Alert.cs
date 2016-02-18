// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Outfit_Ert_Security_Alert : Outfit_Ert_Security {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "ERT Security - High Alert";
			this.backpack_contents = new ByTable()
				.Set( typeof(Obj_Item_Weapon_Storage_Box_Engineer), 1 )
				.Set( typeof(Obj_Item_Weapon_Storage_Box_Handcuffs), 1 )
				.Set( typeof(Obj_Item_Clothing_Mask_Gas_Sechailer_Swat), 1 )
				.Set( typeof(Obj_Item_Weapon_Melee_Baton_Loaded), 1 )
				.Set( typeof(Obj_Item_Weapon_Gun_Energy_Pulse_Carbine_Loyalpin), 1 )
			;
		}

	}

}