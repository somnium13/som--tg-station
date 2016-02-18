// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_CafeLatte : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Cafe Latte";
			this.id = "cafe_latte";
			this.result = "cafe_latte";
			this.required_reagents = new ByTable().Set( "coffee", 1 ).Set( "milk", 1 );
			this.result_amount = 2;
		}

	}

}