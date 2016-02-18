// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Sodiumchloride : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Sodium Chloride";
			this.id = "sodiumchloride";
			this.result = "sodiumchloride";
			this.required_reagents = new ByTable().Set( "water", 1 ).Set( "sodium", 1 ).Set( "chlorine", 1 );
			this.result_amount = 3;
		}

	}

}