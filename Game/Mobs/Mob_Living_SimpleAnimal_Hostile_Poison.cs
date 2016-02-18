// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Poison : Mob_Living_SimpleAnimal_Hostile {

		public dynamic poison_per_bite = 5;
		public string poison_type = "toxin";

		public Mob_Living_SimpleAnimal_Hostile_Poison ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: giant_spider.dm
		public override bool AttackingTarget(  ) {
			dynamic L = null;

			base.AttackingTarget();

			if ( this.target is Mob_Living ) {
				L = this.target;

				if ( Lang13.Bool( L.reagents ) ) {
					L.reagents.add_reagent( this.poison_type, this.poison_per_bite );
				}
			}
			return false;
		}

	}

}