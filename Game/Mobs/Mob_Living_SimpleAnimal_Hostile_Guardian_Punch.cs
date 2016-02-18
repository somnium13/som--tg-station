// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Guardian_Punch : Mob_Living_SimpleAnimal_Hostile_Guardian {

		public string battlecry = "AT";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.melee_damage_lower = 20;
			this.melee_damage_upper = 20;
			this.playstyle_string = "As a standard type you have no special abilities, but have a high damage resistance and a powerful attack capable of smashing through walls.";
			this.environment_smash = 2;
			this.magic_fluff_string = "..And draw the Assistant, faceless and generic, but never to be underestimated.";
			this.tech_fluff_string = "Boot sequence complete. Standard combat modules loaded. Holoparasite swarm online.";
		}

		public Mob_Living_SimpleAnimal_Hostile_Guardian_Punch ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: guardian.dm
		public override bool AttackingTarget(  ) {
			base.AttackingTarget();

			if ( this.target is Mob_Living ) {
				this.say( "" + this.battlecry + this.battlecry + this.battlecry + this.battlecry + this.battlecry + this.battlecry + this.battlecry + this.battlecry + this.battlecry + this.battlecry + this.battlecry + this.battlecry + this.battlecry + this.battlecry + this.battlecry );
				GlobalFuncs.playsound( this.loc, this.attack_sound, 50, 1, 1 );
				GlobalFuncs.playsound( this.loc, this.attack_sound, 50, 1, 1 );
				GlobalFuncs.playsound( this.loc, this.attack_sound, 50, 1, 1 );
				GlobalFuncs.playsound( this.loc, this.attack_sound, 50, 1, 1 );
			}
			return false;
		}

		// Function from file: guardian.dm
		[Verb]
		[VerbInfo( name: "Set Battlecry", desc: "Choose what you shout as you punch", group: "Guardian" )]
		public void Battlecry(  ) {
			string input = null;

			input = GlobalFuncs.stripped_input( this, "What do you want your battlecry to be? Max length of 5 characters.", null, "", 6 );

			if ( Lang13.Bool( input ) ) {
				this.battlecry = input;
			}
			return;
		}

	}

}