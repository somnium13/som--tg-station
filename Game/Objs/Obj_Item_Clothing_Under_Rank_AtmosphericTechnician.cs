// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Under_Rank_AtmosphericTechnician : Obj_Item_Clothing_Under_Rank {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "atmos_suit";
			this._color = "atmos";
			this.flags = 8448;
			this.species_fit = new ByTable(new object [] { "Vox" });
			this.icon_state = "atmos";
		}

		public Obj_Item_Clothing_Under_Rank_AtmosphericTechnician ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}