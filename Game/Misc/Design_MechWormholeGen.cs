// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_MechWormholeGen : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Module Design (Localized Wormhole Generator)";
			this.desc = "An exosuit module that allows generating of small quasi-stable wormholes.";
			this.id = "mech_wormhole_gen";
			this.build_type = 16;
			this.req_tech = new ByTable().Set( "bluespace", 3 ).Set( "magnets", 2 );
			this.build_path = typeof(Obj_Item_MechaParts_MechaEquipment_WormholeGenerator);
			this.category = "Exosuit_Tools";
			this.materials = new ByTable().Set( "$iron", 10000 );
		}

	}

}