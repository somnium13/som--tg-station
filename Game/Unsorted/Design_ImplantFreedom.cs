// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_ImplantFreedom : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Freedom Implant Case";
			this.desc = "A glass case containing an implant.";
			this.id = "implant_freedom";
			this.req_tech = new ByTable().Set( "materials", 2 ).Set( "biotech", 3 ).Set( "magnets", 3 ).Set( "syndicate", 5 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$metal", 50 ).Set( "$glass", 500 ).Set( "$gold", 250 );
			this.build_path = typeof(Obj_Item_Weapon_Implantcase_Freedom);
			this.category = new ByTable(new object [] { "Medical Designs" });
		}

	}

}