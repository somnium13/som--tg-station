// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_MechLaserHeavy : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Weapon Design (CH-LC \"Solaris\" Laser Cannon)";
			this.desc = "Allows for the construction of CH-LC Laser Cannon.";
			this.id = "mech_laser_heavy";
			this.build_type = 16;
			this.req_tech = new ByTable().Set( "combat", 4 ).Set( "magnets", 4 );
			this.build_path = typeof(Obj_Item_MechaParts_MechaEquipment_Weapon_Energy_Laser_Heavy);
			this.category = "Exosuit_Weapons";
			this.locked = true;
			this.materials = new ByTable().Set( "$iron", 10000 );
		}

	}

}