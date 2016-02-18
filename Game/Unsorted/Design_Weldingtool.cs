// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Weldingtool : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Welding tool";
			this.id = "welding_tool";
			this.build_type = 4;
			this.materials = new ByTable().Set( "$metal", 70 ).Set( "$glass", 20 );
			this.build_path = typeof(Obj_Item_Weapon_Weldingtool);
			this.category = new ByTable(new object [] { "initial", "Tools" });
		}

	}

}