// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Radio_Headset_Heads_Hop : Obj_Item_Device_Radio_Headset_Heads {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "com_headset";
		}

		// Function from file: headset.dm
		public Obj_Item_Device_Radio_Headset_Heads_Hop (  ) {
			this.keyslot2 = new Obj_Item_Device_Encryptionkey_Heads_Hop();
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}