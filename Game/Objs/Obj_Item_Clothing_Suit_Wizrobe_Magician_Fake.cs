// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Wizrobe_Magician_Fake : Obj_Item_Clothing_Suit_Wizrobe_Magician {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.armor = new ByTable().Set( "melee", 0 ).Set( "bullet", 0 ).Set( "laser", 0 ).Set( "energy", 0 ).Set( "bomb", 0 ).Set( "bio", 0 ).Set( "rad", 0 );
		}

		public Obj_Item_Clothing_Suit_Wizrobe_Magician_Fake ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}