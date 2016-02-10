// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_Supplycomp : Obj_Item_Weapon_Circuitboard {

		public bool contraband_enabled = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = "/obj/machinery/computer/supplycomp";
			this.origin_tech = "programming=3";
		}

		public Obj_Item_Weapon_Circuitboard_Supplycomp ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: buildandrepair.dm
		public override void solder_improve( dynamic user = null ) {
			GlobalFuncs.to_chat( user, "<span class='notice'>You " + ( this.contraband_enabled ? "" : "un" ) + "connect the mysterious fuse.</span>" );
			this.contraband_enabled = !this.contraband_enabled;
			return;
		}

	}

}