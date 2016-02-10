// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Dna_Gene_Disability_Horns : Dna_Gene_Disability {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Horns";
			this.desc = "Enables the growth of a compacted keratin formation on the subject's head.";
			this.activation_message = "A pair of horns erupt from your head.";
			this.deactivation_message = "Your horns crumble away into nothing.";
			this.flags = 2;
		}

		// Function from file: goon_disabilities.dm
		public Dna_Gene_Disability_Horns (  ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.block = GlobalVars.HORNSBLOCK;
			return;
		}

		// Function from file: goon_disabilities.dm
		public override dynamic OnDrawUnderlays( Mob_Living_Carbon_Human M = null, string g = null, string fat = null ) {
			return "horns_s";
		}

	}

}