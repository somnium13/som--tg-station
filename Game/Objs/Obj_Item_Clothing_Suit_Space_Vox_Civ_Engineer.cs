// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Space_Vox_Civ_Engineer : Obj_Item_Clothing_Suit_Space_Vox_Civ {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "vox-pressure-engineer";
			this.armor = new ByTable().Set( "melee", 5 ).Set( "bullet", 5 ).Set( "laser", 5 ).Set( "energy", 5 ).Set( "bomb", 0 ).Set( "bio", 100 ).Set( "rad", 50 );
			this.pressure_resistance = 20265;
			this.icon_state = "vox-civ-engineer";
		}

		public Obj_Item_Clothing_Suit_Space_Vox_Civ_Engineer ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}