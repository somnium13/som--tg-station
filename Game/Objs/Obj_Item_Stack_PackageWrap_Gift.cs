// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Stack_PackageWrap_Gift : Obj_Item_Stack_PackageWrap {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.smallpath = typeof(Obj_Item_Weapon_Gift);
			this.bigpath = null;
			this.manpath = typeof(Obj_Structure_StrangePresent);
			this.icon_state = "wrap_paper";
		}

		public Obj_Item_Stack_PackageWrap_Gift ( dynamic loc = null, int? amount = null ) : base( (object)(loc), amount ) {
			
		}

	}

}