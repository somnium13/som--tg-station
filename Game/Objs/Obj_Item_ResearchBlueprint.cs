// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_ResearchBlueprint : Obj_Item {

		public Design stored_design = null;
		public dynamic build_type = "";
		public bool delete_on_use = true;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/machines/mechanic.dmi";
			this.icon_state = "blueprint";
		}

		// Function from file: blueprint.dm
		public Obj_Item_ResearchBlueprint ( dynamic new_loc = null, dynamic printed_design = null ) : base( (object)(new_loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( !( printed_design is Design ) ) {
				return;
			}
			this.stored_design = printed_design;
			this.build_type = this.stored_design.build_type;

			if ( this.stored_design != null ) {
				this.name = "" + ( this.build_type == 64 ? "machine" : "item" ) + " " + this.name + ( " (" + printed_design.name + ")" );
			}
			this.pixel_x = Rand13.Int( -3, 3 );
			this.pixel_y = Rand13.Int( -5, 6 );
			return;
		}

	}

}