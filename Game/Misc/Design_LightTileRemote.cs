// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_LightTileRemote : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Light Tile Remote";
			this.desc = "A device used to remotely configure light tiles.";
			this.id = "lt_remote";
			this.req_tech = new ByTable().Set( "programming", 2 ).Set( "magnets", 3 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$iron", 1500 ).Set( "$glass", 200 );
			this.build_path = typeof(Obj_Item_Device_Assembly_LightTileControl);
			this.category = "Engineering";
		}

	}

}