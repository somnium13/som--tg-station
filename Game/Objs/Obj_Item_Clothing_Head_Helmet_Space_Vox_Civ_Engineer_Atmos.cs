// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Space_Vox_Civ_Engineer_Atmos : Obj_Item_Clothing_Head_Helmet_Space_Vox_Civ_Engineer {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.armor = new ByTable().Set( "melee", 5 ).Set( "bullet", 5 ).Set( "laser", 5 ).Set( "energy", 5 ).Set( "bomb", 0 ).Set( "bio", 100 ).Set( "rad", 10 );
			this.max_heat_protection_temperature = 30000;
			this.icon_state = "vox-civ-atmos";
		}

		public Obj_Item_Clothing_Head_Helmet_Space_Vox_Civ_Engineer_Atmos ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}