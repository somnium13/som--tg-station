// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_BorgChest : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Cyborg Torso";
			this.id = "borg_chest";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_RobotParts_Chest);
			this.materials = new ByTable().Set( "$metal", 40000 );
			this.construction_time = 350;
			this.category = new ByTable(new object [] { "Cyborg" });
		}

	}

}