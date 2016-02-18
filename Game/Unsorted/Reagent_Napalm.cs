// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Napalm : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Napalm";
			this.id = "napalm";
			this.description = "Very flammable.";
			this.color = "#FF9999";
		}

		// Function from file: pyrotechnic_reagents.dm
		public override double reaction_mob( dynamic M = null, int? method = null, double? reac_volume = null, bool? show_message = null, dynamic touch_protection = null, Mob_Camera_Blob O = null ) {
			method = method ?? GlobalVars.TOUCH;

			
			if ( M is Mob_Living ) {
				
				if ( method != GlobalVars.INGEST && method != GlobalVars.INJECT ) {
					((Mob_Living)M).adjust_fire_stacks( Num13.MinInt( ((int)( ( reac_volume ??0) / 4 )), 20 ) );
				}
			}
			return 0;
		}

		// Function from file: pyrotechnic_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			((Mob_Living)M).adjust_fire_stacks( 1 );
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}