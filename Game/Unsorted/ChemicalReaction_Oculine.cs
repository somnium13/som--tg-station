// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Oculine : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Oculine";
			this.id = "oculine";
			this.result = "oculine";
			this.required_reagents = new ByTable().Set( "charcoal", 1 ).Set( "carbon", 1 ).Set( "hydrogen", 1 );
			this.result_amount = 3;
			this.mix_message = "The mixture sputters loudly and becomes a pale pink color.";
		}

	}

}