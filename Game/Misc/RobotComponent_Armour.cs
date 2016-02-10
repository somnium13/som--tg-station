// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RobotComponent_Armour : RobotComponent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "armour plating";
			this.external_type = typeof(Obj_Item_RobotParts_RobotComponent_Armour);
			this.max_damage = 60;
		}

		public RobotComponent_Armour ( Mob_Living_Silicon_Robot R = null ) : base( R ) {
			
		}

	}

}