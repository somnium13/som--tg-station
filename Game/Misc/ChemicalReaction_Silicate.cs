// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Silicate : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Silicate";
			this.id = "silicate";
			this.result = "silicate";
			this.required_reagents = new ByTable().Set( "aluminum", 1 ).Set( "silicon", 1 ).Set( "oxygen", 1 );
			this.result_amount = 3;
		}

	}

}