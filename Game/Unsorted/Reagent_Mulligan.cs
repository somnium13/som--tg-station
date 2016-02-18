// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Mulligan : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Mulligan Toxin";
			this.id = "mulligan";
			this.description = "This toxin will rapidly change the DNA of human beings. Commonly used by Syndicate spies and assassins in need of an emergency ID change.";
			this.color = "#5EFF3B";
			this.metabolization_rate = Double.PositiveInfinity;
		}

		// Function from file: other_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			base.on_mob_life( (object)(M) );
			M.WriteMsg( "<span class='warning'><b>You grit your teeth in pain as your body rapidly mutates!</b></span>" );
			((Ent_Static)M).visible_message( "<b>" + M + "</b> suddenly transforms!" );
			GlobalFuncs.randomize_human( M );
			return true;
		}

	}

}