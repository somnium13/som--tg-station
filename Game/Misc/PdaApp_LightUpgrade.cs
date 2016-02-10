// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class PdaApp_LightUpgrade : PdaApp {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "PDA Flashlight Enhancer";
			this.desc = "Slightly increases the luminosity of your PDA's flashlight.";
			this.price = 60;
		}

		// Function from file: apps.dm
		public override void onInstall( dynamic device = null ) {
			base.onInstall( (object)(device) );
			this.pda_device.f_lum = 3;

			if ( this.pda_device.fon ) {
				((Ent_Static)this.pda_device).set_light( this.pda_device.f_lum );
			}
			return;
		}

	}

}