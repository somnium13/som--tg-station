// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Glass : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Glass";
			this.id = "glass";
			this.build_type = 4;
			this.materials = new ByTable().Set( "$glass", 2000 );
			this.build_path = typeof(Obj_Item_Stack_Sheet_Glass);
			this.category = new ByTable(new object [] { "initial", "Construction" });
			this.maxstack = 50;
		}

	}

}