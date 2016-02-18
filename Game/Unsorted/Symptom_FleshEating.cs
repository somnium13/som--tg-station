// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Symptom_FleshEating : Symptom {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Necrotizing Fasciitis";
			this.stealth = -3;
			this.resistance = -4;
			this.transmittable = -4;
			this.level = 6;
			this.severity = 5;
		}

		// Function from file: tgstation.dme
		public override void Activate( Disease_Advance A = null ) {
			dynamic M = null;

			base.Activate( A );

			if ( Rand13.PercentChance( GlobalVars.SYMPTOM_ACTIVATION_PROB ) ) {
				M = A.affected_mob;

				switch ((int?)( A.stage )) {
					case 2:
					case 3:
						M.WriteMsg( "<span class='warning'>" + Rand13.Pick(new object [] { "You feel a sudden pain across your body.", "Drops of blood appear suddenly on your skin." }) + "</span>" );
						break;
					case 4:
					case 5:
						M.WriteMsg( "<span class='userdanger'>" + Rand13.Pick(new object [] { "You cringe as a violent pain takes over your body.", "It feels like your body is eating itself inside out.", "IT HURTS." }) + "</span>" );
						((Mob_Living)M).adjustBruteLoss( 5 );
						break;
				}
			}
			return;
		}

	}

}