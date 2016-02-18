// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Blob_ReplicatingFoam : Reagent_Blob {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Replicating Foam";
			this.id = "replicating_foam";
			this.description = "will do medium brute damage and replicate when damaged.";
			this.shortdesc = "will do medium brute damage.";
			this.color = "#7B5A57";
		}

		// Function from file: blob_reagents.dm
		public override void expand_reaction( Obj_Effect_Blob B = null, Obj_Effect_Blob_Normal newB = null, dynamic T = null ) {
			
			if ( Rand13.PercentChance( 50 ) ) {
				newB.expand();
			}
			return;
		}

		// Function from file: blob_reagents.dm
		public override dynamic damage_reaction( Obj_Effect_Blob B = null, double original_health = 0, dynamic damage = null, dynamic damage_type = null, dynamic cause = null ) {
			dynamic newB = null;

			
			if ( Convert.ToDouble( damage ) > 0 && original_health - Convert.ToDouble( damage ) > 0 ) {
				newB = B.expand();

				if ( Lang13.Bool( newB ) ) {
					newB.health = original_health - Convert.ToDouble( damage );
					((Obj_Effect_Blob)newB).check_health( cause );
					newB.update_icon();
				}
			}
			return base.damage_reaction( B, original_health, (object)(damage), (object)(damage_type), (object)(cause) );
		}

		// Function from file: blob_reagents.dm
		public override double reaction_mob( dynamic M = null, int? method = null, double? reac_volume = null, bool? show_message = null, dynamic touch_protection = null, Mob_Camera_Blob O = null ) {
			method = method ?? GlobalVars.TOUCH;

			reac_volume = base.reaction_mob( (object)(M), method, reac_volume, show_message, (object)(touch_protection), O );
			((Mob_Living)M).apply_damage( ( reac_volume ??0) * 0.6, "brute" );
			return 0;
		}

	}

}