// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoCasing_Shotgun_Blank : Obj_Item_AmmoCasing_Shotgun {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.starting_materials = new ByTable().Set( "$iron", 250 );
			this.icon_state = "blshell";
		}

		public Obj_Item_AmmoCasing_Shotgun_Blank ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}