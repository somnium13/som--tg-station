// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Outfit_Ctf_Blue : Outfit_Ctf {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.ears = typeof(Obj_Item_Device_Radio_Headset_HeadsetCent_Commander);
			this.suit = typeof(Obj_Item_Clothing_Suit_Space_Hardsuit_Shielded_Ctf_Blue);
		}

		// Function from file: capture_the_flag.dm
		public override void post_equip( Mob H = null, int? visualsOnly = null ) {
			Obj_Item_Device_Radio R = null;

			R = ((dynamic)H).ears;
			R.set_frequency( GlobalVars.CENTCOM_FREQ );
			R.freqlock = true;
			return;
		}

	}

}