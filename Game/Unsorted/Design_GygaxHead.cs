// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_GygaxHead : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Head (\"Gygax\")";
			this.id = "gygax_head";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_Part_GygaxHead);
			this.materials = new ByTable().Set( "$metal", 10000 ).Set( "$glass", 5000 ).Set( "$diamond", 2000 );
			this.construction_time = 200;
			this.category = new ByTable(new object [] { "Gygax" });
		}

	}

}