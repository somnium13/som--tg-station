// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_BarbersAid : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "barbers_aid";
			this.id = "barbers_aid";
			this.result = "barbers_aid";
			this.required_reagents = new ByTable().Set( "carpet", 1 ).Set( "radium", 1 ).Set( "space_drugs", 1 );
			this.result_amount = 5;
		}

	}

}