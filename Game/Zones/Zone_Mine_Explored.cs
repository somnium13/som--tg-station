// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Zone_Mine_Explored : Zone_Mine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.always_unpowered = true;
			this.poweralm = false;
			this.power_environ = false;
			this.power_equip = false;
			this.power_light = false;
			this.ambientsounds = new ByTable(new object [] { "sound/ambience/ambimine.ogg" });
			this.icon_state = "explored";
		}

		public Zone_Mine_Explored ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}