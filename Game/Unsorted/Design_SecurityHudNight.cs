// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_SecurityHudNight : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Night Vision Security HUD";
			this.desc = "A heads-up display which provides id data and vision in complete darkness.";
			this.id = "security_hud_night";
			this.req_tech = new ByTable().Set( "magnets", 5 ).Set( "combat", 4 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$metal", 200 ).Set( "$glass", 200 ).Set( "$uranium", 1000 ).Set( "$gold", 350 );
			this.build_path = typeof(Obj_Item_Clothing_Glasses_Hud_Security_Night);
			this.category = new ByTable(new object [] { "Equipment" });
		}

	}

}