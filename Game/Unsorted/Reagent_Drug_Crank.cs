// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Drug_Crank : Reagent_Drug {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Crank";
			this.id = "crank";
			this.description = "Reduces stun times by about 200%. If overdosed or addicted it will deal significant Toxin, Brute and Brain damage.";
			this.color = "#60A584";
			this.overdose_threshold = 20;
			this.addiction_threshold = 10;
		}

		// Function from file: drug_reagents.dm
		public override void addiction_act_stage4( dynamic M = null ) {
			((Mob_Living)M).adjustBrainLoss( 5 );
			((Mob_Living)M).adjustToxLoss( 5 );
			((Mob_Living)M).adjustBruteLoss( 5 );
			base.addiction_act_stage4( (object)(M) );
			return;
		}

		// Function from file: drug_reagents.dm
		public override void addiction_act_stage3( dynamic M = null ) {
			((Mob_Living)M).adjustBruteLoss( 5 );
			base.addiction_act_stage3( (object)(M) );
			return;
		}

		// Function from file: drug_reagents.dm
		public override void addiction_act_stage2( dynamic M = null ) {
			((Mob_Living)M).adjustToxLoss( 5 );
			base.addiction_act_stage2( (object)(M) );
			return;
		}

		// Function from file: drug_reagents.dm
		public override void addiction_act_stage1( dynamic M = null ) {
			((Mob_Living)M).adjustBrainLoss( 5 );
			base.addiction_act_stage1( (object)(M) );
			return;
		}

		// Function from file: drug_reagents.dm
		public override void overdose_process( dynamic M = null ) {
			((Mob_Living)M).adjustBrainLoss( 2 );
			((Mob_Living)M).adjustToxLoss( 2 );
			((Mob_Living)M).adjustBruteLoss( 2 );
			base.overdose_process( (object)(M) );
			return;
		}

		// Function from file: drug_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			dynamic high_message = null;

			high_message = Rand13.Pick(new object [] { "You feel jittery.", "You feel like you gotta go fast.", "You feel like you need to step it up." });

			if ( Rand13.PercentChance( 5 ) ) {
				M.WriteMsg( "<span class='notice'>" + high_message + "</span>" );
			}
			((Mob)M).AdjustParalysis( -1 );
			((Mob)M).AdjustStunned( -1 );
			((Mob)M).AdjustWeakened( -1 );
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}