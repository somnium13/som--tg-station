// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Light_Bulb_He : Obj_Item_Weapon_Light_Bulb {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.base_state = "hebulb";
			this.cost = 1;
			this.starting_materials = new ByTable().Set( "$glass", 150 ).Set( "$iron", 30 );
		}

		public Obj_Item_Weapon_Light_Bulb_He ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}