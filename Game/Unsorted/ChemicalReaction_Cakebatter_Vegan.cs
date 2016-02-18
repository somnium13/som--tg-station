// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Cakebatter_Vegan : ChemicalReaction_Cakebatter {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.id = "vegancakebatter";
			this.required_reagents = new ByTable().Set( "soymilk", 15 ).Set( "flour", 15 ).Set( "sugar", 5 );
		}

	}

}