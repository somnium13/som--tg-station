// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Language_Xenocommon : Language {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Xenomorph";
			this.colour = "alien";
			this.desc = "The common tongue of the xenomorphs.";
			this.speech_verb = "hisses";
			this.ask_verb = "hisses";
			this.exclaim_verb = "hisses";
			this.key = "4";
			this.flags = 2;
			this.syllables = new ByTable(new object [] { "sss", "sSs", "SSS" });
		}

		// Function from file: language.dm
		public override dynamic say_misunderstood( dynamic M = null, string message = null ) {
			return this.speech_verb;
		}

	}

}