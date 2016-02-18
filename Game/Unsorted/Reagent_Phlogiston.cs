// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Phlogiston : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Phlogiston";
			this.id = "phlogiston";
			this.description = "Catches you on fire and makes you ignite.";
			this.color = "#FF9999";
		}

		// Function from file: pyrotechnic_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			double burndmg = 0;

			((Mob_Living)M).adjust_fire_stacks( 1 );
			burndmg = Num13.MaxInt( ((int)( M.fire_stacks * 0.3 )), ((int)( 0.3 )) );
			((Mob_Living)M).adjustFireLoss( burndmg );
			base.on_mob_life( (object)(M) );
			return false;
		}

		// Function from file: pyrotechnic_reagents.dm
		public override double reaction_mob( dynamic M = null, int? method = null, double? reac_volume = null, bool? show_message = null, dynamic touch_protection = null, Mob_Camera_Blob O = null ) {
			method = method ?? GlobalVars.TOUCH;

			((Mob_Living)M).IgniteMob();
			base.reaction_mob( (object)(M), method, reac_volume, show_message, (object)(touch_protection), O );
			return 0;
		}

	}

}