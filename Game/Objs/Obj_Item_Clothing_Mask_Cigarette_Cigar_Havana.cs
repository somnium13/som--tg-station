// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Mask_Cigarette_Cigar_Havana : Obj_Item_Clothing_Mask_Cigarette_Cigar {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.overlay_on = "cigar2lit";
			this.smoketime = 7200;
			this.chem_volume = 30;
			this.icon_state = "cigar2";
		}

		public Obj_Item_Clothing_Mask_Cigarette_Cigar_Havana ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}