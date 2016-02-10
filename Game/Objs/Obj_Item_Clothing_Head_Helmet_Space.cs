// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Space : Obj_Item_Clothing_Head_Helmet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.pressure_resistance = 506.625;
			this.item_state = "space";
			this.permeability_coefficient = 0.01;
			this.armor = new ByTable().Set( "melee", 0 ).Set( "bullet", 0 ).Set( "laser", 0 ).Set( "energy", 0 ).Set( "bomb", 0 ).Set( "bio", 100 ).Set( "rad", 50 );
			this.body_parts_covered = 47105;
			this.siemens_coefficient = 081;
			this.heat_conductivity = 0;
			this.species_restricted = new ByTable(new object [] { "exclude", "Diona", "Muton" });
			this.eyeprot = 1;
			this.cold_breath_protection = 230;
			this.icon_state = "space";
		}

		public Obj_Item_Clothing_Head_Helmet_Space ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}