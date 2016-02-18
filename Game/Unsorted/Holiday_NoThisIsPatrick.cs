// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Holiday_NoThisIsPatrick : Holiday {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "St. Patrick's Day";
			this.begin_day = 17;
			this.begin_month = 3;
		}

		// Function from file: holidays.dm
		public override string getStationPrefix(  ) {
			return Rand13.Pick(new object [] { "Blarney", "Green", "Leprechaun", "Booze" });
		}

	}

}