// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Decal_Cleanable_Blood_Gibs_Robot_Limb : Obj_Effect_Decal_Cleanable_Blood_Gibs_Robot {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.random_icon_states = new ByTable(new object [] { "gibarm", "gibleg" });
		}

		public Obj_Effect_Decal_Cleanable_Blood_Gibs_Robot_Limb ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}