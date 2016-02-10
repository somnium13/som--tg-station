// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease_Cold : Disease {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "The Cold";
			this.max_stages = 3;
			this.spread = "Airborne";
			this.cure = "Rest & Spaceacillin";
			this.cure_id = "spaceacillin";
			this.agent = "XY-rhinovirus";
			this.affected_species = new ByTable(new object [] { "Human", "Monkey" });
			this.permeability_mod = 0.5;
			this.desc = "If left untreated the subject will contract the flu.";
			this.severity = "Minor";
		}

		public Disease_Cold ( bool? process = null, Disease_Advance D = null ) : base( process, D ) {
			
		}

		// Function from file: cold.dm
		public override bool stage_act(  ) {
			Disease_Flu Flu = null;

			base.stage_act();

			switch ((int?)( this.stage )) {
				case 2:
					
					if ( this.affected_mob.lying == true && Rand13.PercentChance( 40 ) ) {
						GlobalFuncs.to_chat( this.affected_mob, "<span class='notice'>You feel better.</span>" );
						this.f_cure();
						return false;
					}

					if ( Rand13.PercentChance( 1 ) && Rand13.PercentChance( 5 ) ) {
						GlobalFuncs.to_chat( this.affected_mob, "<span class='notice'>You feel better.</span>" );
						this.f_cure();
						return false;
					}

					if ( Rand13.PercentChance( 1 ) ) {
						((Mob)this.affected_mob).emote( "sneeze" );
					}

					if ( Rand13.PercentChance( 1 ) ) {
						((Mob)this.affected_mob).emote( "cough" );
					}

					if ( Rand13.PercentChance( 1 ) ) {
						GlobalFuncs.to_chat( this.affected_mob, "<span class='warning'>Your throat feels sore.</span>" );
					}

					if ( Rand13.PercentChance( 1 ) ) {
						GlobalFuncs.to_chat( this.affected_mob, "<span class='warning'>Mucous runs down the back of your throat.</span>" );
					}
					break;
				case 3:
					
					if ( this.affected_mob.lying == true && Rand13.PercentChance( 25 ) ) {
						GlobalFuncs.to_chat( this.affected_mob, "<span class='notice'>You feel better.</span>" );
						this.f_cure();
						return false;
					}

					if ( Rand13.PercentChance( 1 ) && Rand13.PercentChance( 1 ) ) {
						GlobalFuncs.to_chat( this.affected_mob, "<span class='notice'>You feel better.</span>" );
						this.f_cure();
						return false;
					}

					if ( Rand13.PercentChance( 1 ) ) {
						((Mob)this.affected_mob).emote( "sneeze" );
					}

					if ( Rand13.PercentChance( 1 ) ) {
						((Mob)this.affected_mob).emote( "cough" );
					}

					if ( Rand13.PercentChance( 1 ) ) {
						GlobalFuncs.to_chat( this.affected_mob, "<span class='warning'>Your throat feels sore.</span>" );
					}

					if ( Rand13.PercentChance( 1 ) ) {
						GlobalFuncs.to_chat( this.affected_mob, "<span class='warning'>Mucous runs down the back of your throat.</span>" );
					}

					if ( Rand13.PercentChance( 1 ) && Rand13.PercentChance( 50 ) ) {
						
						if ( !( this.affected_mob.resistances.Find( typeof(Disease_Flu) ) != 0 ) ) {
							Flu = new Disease_Flu( false );
							((Mob)this.affected_mob).contract_disease( Flu, true );
							this.f_cure();
						}
					}
					break;
			}
			return false;
		}

	}

}