// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_PodParts_PodFrame_AftPort : Obj_Item_PodParts_PodFrame {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.link_to = typeof(Obj_Item_PodParts_PodFrame_ForePort);
			this.icon_state = "pod_ap";
		}

		public Obj_Item_PodParts_PodFrame_AftPort ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}