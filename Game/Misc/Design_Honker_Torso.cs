// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Honker_Torso : Design_Honker {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Structure (H.O.N.K. torso)";
			this.desc = "Used to build a H.O.N.K. torso.";
			this.id = "honker_torso";
			this.req_tech = new ByTable().Set( "combat", 1 );
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_Part_HonkerTorso);
			this.category = "HONK";
			this.materials = new ByTable().Set( "$iron", 35000 ).Set( "$glass", 10000 ).Set( "$clown", 10000 );
		}

	}

}