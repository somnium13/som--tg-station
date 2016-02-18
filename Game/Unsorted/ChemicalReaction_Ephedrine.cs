// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Ephedrine : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Ephedrine";
			this.id = "ephedrine";
			this.result = "ephedrine";
			this.required_reagents = new ByTable().Set( "sugar", 1 ).Set( "oil", 1 ).Set( "hydrogen", 1 ).Set( "diethylamine", 1 );
			this.result_amount = 4;
			this.mix_message = "The solution fizzes and gives off toxic fumes.";
		}

	}

}