// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Lithiumsodiumtungstate : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Lithium Sodium Tungstate";
			this.id = "lithiumsodiumtungstate";
			this.result = "lithiumsodiumtungstate";
			this.required_reagents = new ByTable().Set( "lithium", 1 ).Set( "sodium", 2 ).Set( "tungsten", 1 ).Set( "oxygen", 4 );
			this.result_amount = 8;
		}

	}

}