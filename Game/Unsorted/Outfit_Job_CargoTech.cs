// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Outfit_Job_CargoTech : Outfit_Job {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Cargo Technician";
			this.belt = typeof(Obj_Item_Device_Pda_Cargo);
			this.ears = typeof(Obj_Item_Device_Radio_Headset_HeadsetCargo);
			this.uniform = typeof(Obj_Item_Clothing_Under_Rank_Cargotech);
		}

	}

}