// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Riot : Obj_Item_Clothing_Head_Helmet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.armor = new ByTable().Set( "melee", 82 ).Set( "bullet", 15 ).Set( "laser", 5 ).Set( "energy", 5 ).Set( "bomb", 5 ).Set( "bio", 2 ).Set( "rad", 0 );
			this.eyeprot = 1;
			this.icon_state = "riot";
		}

		public Obj_Item_Clothing_Head_Helmet_Riot ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}