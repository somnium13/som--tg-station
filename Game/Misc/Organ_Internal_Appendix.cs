// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Organ_Internal_Appendix : Organ_Internal {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "appendix";
			this.parent_organ = "groin";
			this.removed_type = typeof(Obj_Item_Organ_Appendix);
		}

		public Organ_Internal_Appendix ( Mob_Living_Carbon_Human H = null ) : base( H ) {
			
		}

	}

}