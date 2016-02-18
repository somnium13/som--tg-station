// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_GinFizz : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Gin Fizz";
			this.id = "ginfizz";
			this.result = "ginfizz";
			this.required_reagents = new ByTable().Set( "gin", 2 ).Set( "sodawater", 1 ).Set( "limejuice", 1 );
			this.result_amount = 4;
		}

	}

}