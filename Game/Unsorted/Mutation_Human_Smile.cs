// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mutation_Human_Smile : Mutation_Human {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Smile";
			this.quality = 3;
			this.dna_block = -1;
			this.text_gain_indication = "<span class='notice'>You feel so happy. Nothing can be wrong with anything. :)</span>";
			this.text_lose_indication = "<span class='notice'>Everything is terrible again. :(</span>";
		}

		// Function from file: mutations.dm
		public override dynamic say_mod( dynamic message = null ) {
			
			if ( Lang13.Bool( message ) ) {
				message = " " + message + " ";
				message = GlobalFuncs.replacetext( message, " stupid ", " smart " );
				message = GlobalFuncs.replacetext( message, " retard ", " genius " );
				message = GlobalFuncs.replacetext( message, " unrobust ", " robust " );
				message = GlobalFuncs.replacetext( message, " dumb ", " smart " );
				message = GlobalFuncs.replacetext( message, " awful ", " great " );
				message = GlobalFuncs.replacetext( message, " gay ", Rand13.Pick(new object [] { " nice ", " ok ", " alright " }) );
				message = GlobalFuncs.replacetext( message, " horrible ", " fun " );
				message = GlobalFuncs.replacetext( message, " terrible ", " terribly fun " );
				message = GlobalFuncs.replacetext( message, " terrifying ", " wonderful " );
				message = GlobalFuncs.replacetext( message, " gross ", " cool " );
				message = GlobalFuncs.replacetext( message, " disgusting ", " amazing " );
				message = GlobalFuncs.replacetext( message, " loser ", " winner " );
				message = GlobalFuncs.replacetext( message, " useless ", " useful " );
				message = GlobalFuncs.replacetext( message, " oh god ", " cheese and crackers " );
				message = GlobalFuncs.replacetext( message, " jesus ", " gee wiz " );
				message = GlobalFuncs.replacetext( message, " weak ", " strong " );
				message = GlobalFuncs.replacetext( message, " kill ", " hug " );
				message = GlobalFuncs.replacetext( message, " murder ", " tease " );
				message = GlobalFuncs.replacetext( message, " ugly ", " beautiful " );
				message = GlobalFuncs.replacetext( message, " douchbag ", " nice guy " );
				message = GlobalFuncs.replacetext( message, " whore ", " lady " );
				message = GlobalFuncs.replacetext( message, " nerd ", " smart guy " );
				message = GlobalFuncs.replacetext( message, " moron ", " fun person " );
				message = GlobalFuncs.replacetext( message, " IT'S LOOSE ", " EVERYTHING IS FINE " );
				message = GlobalFuncs.replacetext( message, " sex ", " hug fight " );
				message = GlobalFuncs.replacetext( message, " idiot ", " genius " );
				message = GlobalFuncs.replacetext( message, " fat ", " thin " );
				message = GlobalFuncs.replacetext( message, " beer ", " water with ice " );
				message = GlobalFuncs.replacetext( message, " drink ", " water " );
				message = GlobalFuncs.replacetext( message, " feminist ", " empowered woman " );
				message = GlobalFuncs.replacetext( message, " i hate you ", " you're mean " );
				message = GlobalFuncs.replacetext( message, " nigger ", " african american " );
				message = GlobalFuncs.replacetext( message, " jew ", " jewish " );
				message = GlobalFuncs.replacetext( message, " shit ", " shiz " );
				message = GlobalFuncs.replacetext( message, " crap ", " poo " );
				message = GlobalFuncs.replacetext( message, " slut ", " tease " );
				message = GlobalFuncs.replacetext( message, " ass ", " butt " );
				message = GlobalFuncs.replacetext( message, " damn ", " dang " );
				message = GlobalFuncs.replacetext( message, " fuck ", "  " );
				message = GlobalFuncs.replacetext( message, " penis ", " privates " );
				message = GlobalFuncs.replacetext( message, " cunt ", " privates " );
				message = GlobalFuncs.replacetext( message, " dick ", " jerk " );
				message = GlobalFuncs.replacetext( message, " vagina ", " privates " );
			}
			return GlobalFuncs.trim( message );
		}

	}

}