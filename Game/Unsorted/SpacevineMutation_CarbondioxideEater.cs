// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SpacevineMutation_CarbondioxideEater : SpacevineMutation {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "CO2 consuming";
			this.hue = "#00ffff";
			this.severity = 3;
			this.quality = 1;
		}

		// Function from file: spacevine.dm
		public override void process_mutation( Obj_Effect_Spacevine holder = null ) {
			Ent_Static T = null;
			GasMixture GM = null;

			T = holder.loc;

			if ( T is Tile_Simulated_Floor ) {
				GM = ((dynamic)T).air;

				if ( !Lang13.Bool( GM.gases["co2"] ) ) {
					return;
				}
				GM.gases["co2"][1] -= ( this.severity ??0) * holder.energy;
				GM.garbage_collect();
			}
			return;
		}

	}

}