// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Holiday_Birthday : Holiday {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Birthday of Space Station 13";
			this.begin_day = 16;
			this.begin_month = 2;
		}

		// Function from file: holidays.dm
		public override string greet(  ) {
			double game_age = 0;
			string Fact = null;

			game_age = ( String13.ParseNumber( String13.FormatTime( Game13.timeofday, "YY" ) ) ??0) - 3;

			switch ((int)( game_age )) {
				case 16:
					Fact = " SS13 is now old enough to drive!";
					break;
				case 18:
					Fact = " SS13 is now legal!";
					break;
				case 21:
					Fact = " SS13 can now drink!";
					break;
				case 26:
					Fact = " SS13 can now rent a car!";
					break;
				case 30:
					Fact = " SS13 can now go home and be a family man!";
					break;
				case 40:
					Fact = " SS13 can now suffer a midlife crisis!";
					break;
				case 50:
					Fact = " Happy golden anniversary!";
					break;
				case 65:
					Fact = " SS13 can now start thinking about retirement!";
					break;
				case 96:
					Fact = " Please send a time machine back to pick me up, I need to update the time formatting for this feature!";
					break;
			}

			if ( !Lang13.Bool( Fact ) ) {
				Fact = " SS13 is now " + game_age + " years old!";
			}
			return "Say 'Happy Birthday' to Space Station 13, first publicly playable on February 16th, 2003!" + Fact;
		}

	}

}