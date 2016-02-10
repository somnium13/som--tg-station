// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Mechapowerfloor : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Circuit Design (Recharge Station)";
			this.desc = "Allows for the construction of circuit boards used to build a mech bay recharge station.";
			this.id = "mechapowerfloor";
			this.req_tech = new ByTable().Set( "materials", 2 ).Set( "powerstorage", 3 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 2000 ).Set( "sacid", 20 );
			this.category = "Machine Boards";
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_MechBayRechargeStation);
		}

	}

}