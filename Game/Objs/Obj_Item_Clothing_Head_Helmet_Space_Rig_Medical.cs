// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Space_Rig_Medical : Obj_Item_Clothing_Head_Helmet_Space_Rig {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "medical_helm";
			this._color = "medical";
			this.species_restricted = new ByTable(new object [] { "exclude", "Vox" });
			this.pressure_resistance = 4053;
			this.icon_state = "rig0-medical";
		}

		public Obj_Item_Clothing_Head_Helmet_Space_Rig_Medical ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}