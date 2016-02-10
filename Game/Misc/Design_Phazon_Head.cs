// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Phazon_Head : Design_Phazon {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Structure (Phazon head)";
			this.desc = "Used to build a Phazon head.";
			this.id = "phazon_head";
			this.req_tech = new ByTable().Set( "bluespace", 1 );
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_Part_PhazonHead);
			this.category = "Phazon";
			this.materials = new ByTable().Set( "$iron", 15000 ).Set( "$glass", 5000 ).Set( "$plasma", 10000 ).Set( "$phazon", 2500 );
		}

	}

}