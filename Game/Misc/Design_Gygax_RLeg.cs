// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Gygax_RLeg : Design_Gygax {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Structure (Gygax right leg)";
			this.desc = "Used to build a Gygax right leg.";
			this.id = "gygax_rleg";
			this.req_tech = new ByTable().Set( "combat", 1 );
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_Part_GygaxRightLeg);
			this.category = "Gygax";
			this.materials = new ByTable().Set( "$iron", 35000 );
		}

	}

}