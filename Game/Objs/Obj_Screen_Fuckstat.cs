// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Screen_Fuckstat : Obj_Screen {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/fuckstat.dmi";
			this.icon_state = "fuckstat";
		}

		public Obj_Screen_Fuckstat ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: mob.dm
		public override bool Click( dynamic loc = null, string control = null, string _params = null ) {
			Mob M = null;

			M = Task13.User;

			if ( !( M is Mob ) ) {
				return false;
			}
			M.stat_fucked = !M.stat_fucked;
			return false;
		}

	}

}