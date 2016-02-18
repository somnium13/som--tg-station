// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mutation_Human_Chav : Mutation_Human {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Chav";
			this.quality = 3;
			this.dna_block = -1;
			this.text_gain_indication = "<span class='notice'>Ye feel like a reet prat like, innit?</span>";
			this.text_lose_indication = "<span class='notice'>You no longer feel like being rude and sassy.</span>";
		}

		// Function from file: mutations.dm
		public override dynamic say_mod( dynamic message = null ) {
			
			if ( Lang13.Bool( message ) ) {
				message = " " + message + " ";
				message = GlobalFuncs.replacetext( message, " looking at  ", "  gawpin' at " );
				message = GlobalFuncs.replacetext( message, " great ", " bangin' " );
				message = GlobalFuncs.replacetext( message, " man ", " mate " );
				message = GlobalFuncs.replacetext( message, " friend ", Rand13.Pick(new object [] { " mate ", " bruv ", " bledrin " }) );
				message = GlobalFuncs.replacetext( message, " what ", " wot " );
				message = GlobalFuncs.replacetext( message, " drink ", " wet " );
				message = GlobalFuncs.replacetext( message, " get ", " giz " );
				message = GlobalFuncs.replacetext( message, " what ", " wot " );
				message = GlobalFuncs.replacetext( message, " no thanks ", " wuddent fukken do one " );
				message = GlobalFuncs.replacetext( message, " i don't know ", " wot mate " );
				message = GlobalFuncs.replacetext( message, " no ", " naw " );
				message = GlobalFuncs.replacetext( message, " robust ", " chin " );
				message = GlobalFuncs.replacetext( message, "  hi  ", " how what how " );
				message = GlobalFuncs.replacetext( message, " hello ", " sup bruv " );
				message = GlobalFuncs.replacetext( message, " kill ", " bang " );
				message = GlobalFuncs.replacetext( message, " murder ", " bang " );
				message = GlobalFuncs.replacetext( message, " windows ", " windies " );
				message = GlobalFuncs.replacetext( message, " window ", " windy " );
				message = GlobalFuncs.replacetext( message, " break ", " do " );
				message = GlobalFuncs.replacetext( message, " your ", " yer " );
				message = GlobalFuncs.replacetext( message, " security ", " coppers " );
			}
			return GlobalFuncs.trim( message );
		}

	}

}