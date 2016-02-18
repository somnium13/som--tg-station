// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_BeanbagSlug : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Beanbag slug";
			this.id = "beanbag_slug";
			this.build_type = 4;
			this.materials = new ByTable().Set( "$metal", 250 );
			this.build_path = typeof(Obj_Item_AmmoCasing_Shotgun_Beanbag);
			this.category = new ByTable(new object [] { "initial", "Security" });
		}

	}

}