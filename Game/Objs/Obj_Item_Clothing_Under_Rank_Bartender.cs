// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Under_Rank_Bartender : Obj_Item_Clothing_Under_Rank {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "ba_suit";
			this._color = "ba_suit";
			this.flags = 8448;
			this.species_fit = new ByTable(new object [] { "Vox" });
			this.icon_state = "ba_suit";
		}

		public Obj_Item_Clothing_Under_Rank_Bartender ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}