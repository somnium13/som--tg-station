// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Cabinet : Obj_Structure_Closet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_closed = "cabinet_closed";
			this.icon_opened = "cabinet_open";
			this.icon_state = "cabinet_closed";
		}

		public Obj_Structure_Closet_Cabinet ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: gimmick.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			if ( !this.opened ) {
				this.icon_state = this.icon_closed;
			} else {
				this.icon_state = this.icon_opened;
			}
			return null;
		}

	}

}