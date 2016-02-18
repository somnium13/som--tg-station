// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease_Cold : Disease {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "The Cold";
			this.max_stages = 3;
			this.cure_text = "Rest & Spaceacillin";
			this.cures = new ByTable(new object [] { "spaceacillin" });
			this.agent = "XY-rhinovirus";
			this.viable_mobtypes = new ByTable(new object [] { typeof(Mob_Living_Carbon_Human), typeof(Mob_Living_Carbon_Monkey) });
			this.permeability_mod = 0.5;
			this.desc = "If left untreated the subject will contract the flu.";
			this.severity = "Minor";
		}

		// Function from file: cold.dm
		public override void stage_act(  ) {
			Disease_Flu Flu = null;

			base.stage_act();

			switch ((int?)( this.stage )) {
				case 2:
					
					if ( Lang13.Bool( this.affected_mob.lying ) && Rand13.PercentChance( 40 ) ) {
						this.affected_mob.WriteMsg( "<span class='notice'>You feel better.</span>" );
						this.cure();
						return;
					}

					if ( Rand13.PercentChance( 1 ) && Rand13.PercentChance( 5 ) ) {
						this.affected_mob.WriteMsg( "<span class='notice'>You feel better.</span>" );
						this.cure();
						return;
					}

					if ( Rand13.PercentChance( 1 ) ) {
						((Mob)this.affected_mob).emote( "sneeze" );
					}

					if ( Rand13.PercentChance( 1 ) ) {
						((Mob)this.affected_mob).emote( "cough" );
					}

					if ( Rand13.PercentChance( 1 ) ) {
						this.affected_mob.WriteMsg( "<span class='danger'>Your throat feels sore.</span>" );
					}

					if ( Rand13.PercentChance( 1 ) ) {
						this.affected_mob.WriteMsg( "<span class='danger'>Mucous runs down the back of your throat.</span>" );
					}
					break;
				case 3:
					
					if ( Lang13.Bool( this.affected_mob.lying ) && Rand13.PercentChance( 25 ) ) {
						this.affected_mob.WriteMsg( "<span class='notice'>You feel better.</span>" );
						this.cure();
						return;
					}

					if ( Rand13.PercentChance( 1 ) && Rand13.PercentChance( 1 ) ) {
						this.affected_mob.WriteMsg( "<span class='notice'>You feel better.</span>" );
						this.cure();
						return;
					}

					if ( Rand13.PercentChance( 1 ) ) {
						((Mob)this.affected_mob).emote( "sneeze" );
					}

					if ( Rand13.PercentChance( 1 ) ) {
						((Mob)this.affected_mob).emote( "cough" );
					}

					if ( Rand13.PercentChance( 1 ) ) {
						this.affected_mob.WriteMsg( "<span class='danger'>Your throat feels sore.</span>" );
					}

					if ( Rand13.PercentChance( 1 ) ) {
						this.affected_mob.WriteMsg( "<span class='danger'>Mucous runs down the back of your throat.</span>" );
					}

					if ( Rand13.PercentChance( 1 ) && Rand13.PercentChance( 50 ) ) {
						
						if ( !( this.affected_mob.resistances.Find( typeof(Disease_Flu) ) != 0 ) ) {
							Flu = new Disease_Flu( /* Pruned args, no ctor exists. */ );
							((Mob)this.affected_mob).ContractDisease( Flu );
							this.cure();
						}
					}
					break;
			}
			return;
		}

	}

}