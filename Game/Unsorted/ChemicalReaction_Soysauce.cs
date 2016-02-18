// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Soysauce : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Soy Sauce";
			this.id = "soysauce";
			this.result = "soysauce";
			this.required_reagents = new ByTable().Set( "soymilk", 4 ).Set( "sacid", 1 );
			this.result_amount = 5;
		}

	}

}