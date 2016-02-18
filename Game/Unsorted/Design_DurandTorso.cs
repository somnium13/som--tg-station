// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_DurandTorso : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Torso (\"Durand\")";
			this.id = "durand_torso";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_Part_DurandTorso);
			this.materials = new ByTable().Set( "$metal", 25000 ).Set( "$glass", 10000 ).Set( "$silver", 10000 );
			this.construction_time = 300;
			this.category = new ByTable(new object [] { "Durand" });
		}

	}

}