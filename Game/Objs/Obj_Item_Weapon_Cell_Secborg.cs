// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Cell_Secborg : Obj_Item_Weapon_Cell {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "powerstorage=0";
			this.maxcharge = 600;
			this.starting_materials = new ByTable().Set( "$iron", 700 ).Set( "$glass", 40 );
		}

		public Obj_Item_Weapon_Cell_Secborg ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}