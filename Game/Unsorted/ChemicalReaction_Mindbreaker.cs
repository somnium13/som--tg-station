// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Mindbreaker : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Mindbreaker Toxin";
			this.id = "mindbreaker";
			this.result = "mindbreaker";
			this.required_reagents = new ByTable().Set( "silicon", 1 ).Set( "hydrogen", 1 ).Set( "charcoal", 1 );
			this.result_amount = 5;
		}

	}

}