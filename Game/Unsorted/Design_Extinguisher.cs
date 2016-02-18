// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Extinguisher : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Fire extinguisher";
			this.id = "extinguisher";
			this.build_type = 4;
			this.materials = new ByTable().Set( "$metal", 90 );
			this.build_path = typeof(Obj_Item_Weapon_Extinguisher);
			this.category = new ByTable(new object [] { "initial", "Tools" });
		}

	}

}