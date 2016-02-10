// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Under_Rank_Warden : Obj_Item_Clothing_Under_Rank {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "r_suit";
			this._color = "warden";
			this.armor = new ByTable().Set( "melee", 10 ).Set( "bullet", 0 ).Set( "laser", 0 ).Set( "energy", 0 ).Set( "bomb", 0 ).Set( "bio", 0 ).Set( "rad", 0 );
			this.flags = 8448;
			this.siemens_coefficient = 081;
			this.species_fit = new ByTable(new object [] { "Vox" });
			this.icon_state = "warden";
		}

		public Obj_Item_Clothing_Under_Rank_Warden ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}