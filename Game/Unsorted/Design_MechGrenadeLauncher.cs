// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_MechGrenadeLauncher : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Weapon (SGL-6 Grenade Launcher)";
			this.desc = "Allows for the construction of SGL-6 Grenade Launcher.";
			this.id = "mech_grenade_launcher";
			this.build_type = 16;
			this.req_tech = new ByTable().Set( "combat", 3 );
			this.build_path = typeof(Obj_Item_MechaParts_MechaEquipment_Weapon_Ballistic_Launcher_Flashbang);
			this.materials = new ByTable().Set( "$metal", 22000 ).Set( "$gold", 6000 ).Set( "$silver", 8000 );
			this.construction_time = 100;
			this.category = new ByTable(new object [] { "Exosuit Equipment" });
		}

	}

}