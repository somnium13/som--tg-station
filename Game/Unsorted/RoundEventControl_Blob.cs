// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RoundEventControl_Blob : RoundEventControl {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Blob";
			this.typepath = typeof(RoundEvent_Blob);
			this.weight = 5;
			this.max_occurrences = 1;
			this.earliest_start = 48000;
			this.gamemode_blacklist = new ByTable(new object [] { "blob" });
		}

	}

}