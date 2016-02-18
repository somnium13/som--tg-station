// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Action_ItemAction_Jetpack_Cycle : Action_ItemAction_Jetpack {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Jetpack Mode";
		}

		public Action_ItemAction_Jetpack_Cycle ( Obj_Item_Weapon_Tank Target = null ) : base( Target ) {
			
		}

		// Function from file: jetpack.dm
		public override bool Trigger(  ) {
			dynamic J = null;

			
			if ( !this.Checks() ) {
				return false;
			}
			J = this.target;
			((Obj_Item_Weapon_Tank_Jetpack)J).cycle( this.owner );
			return true;
		}

	}

}