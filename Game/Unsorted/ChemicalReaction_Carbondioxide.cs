// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Carbondioxide : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Direct Carbon Oxidation";
			this.id = "burningcarbon";
			this.result = "co2";
			this.required_reagents = new ByTable().Set( "carbon", 1 ).Set( "oxygen", 2 );
			this.required_temp = 777;
			this.result_amount = 3;
		}

	}

}