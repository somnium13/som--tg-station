// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Medicine_PotassIodide : Reagent_Medicine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Potassium Iodide";
			this.id = "potass_iodide";
			this.description = "Efficiently restores low radiation damage.";
			this.color = "#C8A5DC";
			this.metabolization_rate = 0.8;
		}

		// Function from file: medicine_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			
			if ( M.radiation > 0 ) {
				M.radiation--;
			}

			if ( M.radiation < 0 ) {
				M.radiation = 0;
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}