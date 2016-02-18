// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease_Fluspanish : Disease {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Spanish inquisition Flu";
			this.max_stages = 3;
			this.spread_text = "Airborne";
			this.cure_text = "Spaceacillin & Anti-bodies to the common flu";
			this.cures = new ByTable(new object [] { "spaceacillin" });
			this.cure_chance = 10;
			this.agent = "1nqu1s1t10n flu virion";
			this.viable_mobtypes = new ByTable(new object [] { typeof(Mob_Living_Carbon_Human) });
			this.permeability_mod = 0.75;
			this.desc = "If left untreated the subject will burn to death for being a heretic.";
			this.severity = "Dangerous!";
		}

		// Function from file: fluspanish.dm
		public override void stage_act(  ) {
			base.stage_act();

			switch ((int?)( this.stage )) {
				case 2:
					this.affected_mob.bodytemperature += 10;

					if ( Rand13.PercentChance( 5 ) ) {
						((Mob)this.affected_mob).emote( "sneeze" );
					}

					if ( Rand13.PercentChance( 5 ) ) {
						((Mob)this.affected_mob).emote( "cough" );
					}

					if ( Rand13.PercentChance( 1 ) ) {
						this.affected_mob.WriteMsg( "<span class='danger'>You're burning in your own skin!</span>" );
						((Mob_Living)this.affected_mob).take_organ_damage( 0, 5 );
					}
					break;
				case 3:
					this.affected_mob.bodytemperature += 20;

					if ( Rand13.PercentChance( 5 ) ) {
						((Mob)this.affected_mob).emote( "sneeze" );
					}

					if ( Rand13.PercentChance( 5 ) ) {
						((Mob)this.affected_mob).emote( "cough" );
					}

					if ( Rand13.PercentChance( 5 ) ) {
						this.affected_mob.WriteMsg( "<span class='danger'>You're burning in your own skin!</span>" );
						((Mob_Living)this.affected_mob).take_organ_damage( 0, 5 );
					}
					break;
			}
			return;
		}

	}

}