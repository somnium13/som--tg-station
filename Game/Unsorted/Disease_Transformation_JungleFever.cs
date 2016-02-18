// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease_Transformation_JungleFever : Disease_Transformation {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Jungle Fever";
			this.cure_text = "Bananas";
			this.cures = new ByTable(new object [] { "banana" });
			this.spread_text = "Monkey Bites";
			this.viable_mobtypes = new ByTable(new object [] { typeof(Mob_Living_Carbon_Monkey), typeof(Mob_Living_Carbon_Human) });
			this.cure_chance = 1;
			this.disease_flags = 6;
			this.longevity = 30;
			this.desc = "Monkeys with this disease will bite humans, causing humans to mutate into a monkey.";
			this.severity = "BIOHAZARD THREAT!";
			this.agent = "Kongey Vibrion M-909";
			this.new_form = typeof(Mob_Living_Carbon_Monkey);
			this.stage1 = null;
			this.stage2 = null;
			this.stage3 = null;
			this.stage4 = new ByTable(new object [] { 
				"<span class='warning'>Your back hurts.</span>", 
				"<span class='warning'>You breathe through your mouth.</span>", 
				"<span class='warning'>You have a craving for bananas.</span>", 
				"<span class='warning'>Your mind feels clouded.</span>"
			 });
			this.stage5 = new ByTable(new object [] { "<span class='warning'>You feel like monkeying around.</span>" });
		}

		// Function from file: transformation.dm
		public override void cure( dynamic resistance = null ) {
			((GameMode)GlobalVars.ticker.mode).remove_monkey( this.affected_mob.mind );
			base.cure( (object)(resistance) );
			return;
		}

		// Function from file: transformation.dm
		public override void stage_act(  ) {
			base.stage_act();

			switch ((int?)( this.stage )) {
				case 2:
					
					if ( Rand13.PercentChance( 2 ) ) {
						this.affected_mob.WriteMsg( "<span class='notice'>Your " + Rand13.Pick(new object [] { "back", "arm", "leg", "elbow", "head" }) + " itches.</span>" );
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( 4 ) ) {
						this.affected_mob.WriteMsg( "<span class='danger'>You feel a stabbing pain in your head.</span>" );
						this.affected_mob.confused += 10;
					}
					break;
				case 4:
					
					if ( Rand13.PercentChance( 3 ) ) {
						((Ent_Dynamic)this.affected_mob).say( Rand13.Pick(new object [] { "Eeek, ook ook!", "Eee-eeek!", "Eeee!", "Ungh, ungh." }) );
					}
					break;
			}
			return;
		}

		// Function from file: transformation.dm
		public override void do_disease_transformation( dynamic affected_mob = null ) {
			
			if ( !( affected_mob is Mob_Living_Carbon_Monkey ) ) {
				((GameMode)GlobalVars.ticker.mode).add_monkey( affected_mob.mind );
				((Mob_Living_Carbon)affected_mob).monkeyize( 311 );
			}
			return;
		}

	}

}