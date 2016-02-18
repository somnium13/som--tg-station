// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Spraytan : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Spray Tan";
			this.id = "spraytan";
			this.result = "spraytan";
			this.required_reagents = new ByTable().Set( "orangejuice", 1 ).Set( "oil", 1 );
			this.result_amount = 2;
		}

	}

}