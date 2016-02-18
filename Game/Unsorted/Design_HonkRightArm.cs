// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_HonkRightArm : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Right Arm (\"H.O.N.K\")";
			this.id = "honk_right_arm";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_Part_HonkerRightArm);
			this.materials = new ByTable().Set( "$metal", 15000 ).Set( "$bananium", 5000 );
			this.construction_time = 200;
			this.category = new ByTable(new object [] { "H.O.N.K" });
		}

	}

}