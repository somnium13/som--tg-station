// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_CyberimpXray : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "X-Ray implant";
			this.desc = "These cybernetic eyes will give you X-ray vision. Blinking is futile.";
			this.id = "ci-xray";
			this.req_tech = new ByTable().Set( "materials", 7 ).Set( "programming", 5 ).Set( "biotech", 6 ).Set( "magnets", 5 );
			this.build_type = 18;
			this.construction_time = 60;
			this.materials = new ByTable().Set( "$metal", 200 ).Set( "$glass", 200 ).Set( "$silver", 600 ).Set( "$gold", 600 ).Set( "$plasma", 1000 ).Set( "$uranium", 1000 ).Set( "$diamond", 2000 );
			this.build_path = typeof(Obj_Item_Organ_Internal_Cyberimp_Eyes_Xray);
			this.category = new ByTable(new object [] { "Misc", "Medical Designs" });
		}

	}

}