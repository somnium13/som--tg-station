// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_BorgVtecBoard : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "cyborg VTEC module";
			this.desc = "Used to upgrade a borg's speed.";
			this.id = "borg_vtec_board";
			this.req_tech = new ByTable().Set( "engineering", 1 );
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_Borg_Upgrade_Vtec);
			this.category = "Robotic_Upgrade_Modules";
			this.materials = new ByTable().Set( "$iron", 80000 ).Set( "$glass", 6000 ).Set( "$gold", 5000 );
		}

	}

}