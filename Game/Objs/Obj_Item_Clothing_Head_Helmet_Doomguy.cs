// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Doomguy : Obj_Item_Clothing_Head_Helmet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "doom";
			this.armor = new ByTable().Set( "melee", 50 ).Set( "bullet", 40 ).Set( "laser", 40 ).Set( "energy", 40 ).Set( "bomb", 5 ).Set( "bio", 0 ).Set( "rad", 0 );
			this.icon_state = "doom";
		}

		public Obj_Item_Clothing_Head_Helmet_Doomguy ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}