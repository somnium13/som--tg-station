// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Bananahonk : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Banana Honk";
			this.id = "bananahonk";
			this.result = "bananahonk";
			this.required_reagents = new ByTable().Set( "banana", 1 ).Set( "cream", 1 ).Set( "sugar", 1 );
			this.result_amount = 3;
		}

	}

}