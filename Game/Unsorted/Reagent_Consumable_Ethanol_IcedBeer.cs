// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Consumable_Ethanol_IcedBeer : Reagent_Consumable_Ethanol {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Iced Beer";
			this.id = "iced_beer";
			this.description = "A beer which is so cold the air around it freezes.";
			this.color = "#664300";
			this.boozepwr = 55;
		}

		// Function from file: alcohol_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			
			if ( Convert.ToDouble( M.bodytemperature ) > 270 ) {
				M.bodytemperature = Num13.MaxInt( 270, Convert.ToInt32( M.bodytemperature - 30 ) );
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}