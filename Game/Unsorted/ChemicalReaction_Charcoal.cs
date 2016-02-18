// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Charcoal : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Charcoal";
			this.id = "charcoal";
			this.result = "charcoal";
			this.required_reagents = new ByTable().Set( "ash", 1 ).Set( "sodiumchloride", 1 );
			this.result_amount = 2;
			this.mix_message = "The mixture yields a fine black powder.";
			this.required_temp = 380;
		}

	}

}