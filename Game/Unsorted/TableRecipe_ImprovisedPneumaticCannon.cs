// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_ImprovisedPneumaticCannon : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Pneumatic Cannon";
			this.result = typeof(Obj_Item_Weapon_PneumaticCannon_Ghetto);
			this.tools = new ByTable(new object [] { typeof(Obj_Item_Weapon_Weldingtool), typeof(Obj_Item_Weapon_Wrench) });
			this.reqs = new ByTable().Set( typeof(Obj_Item_Stack_Sheet_Metal), 4 ).Set( typeof(Obj_Item_Stack_PackageWrap), 8 ).Set( typeof(Obj_Item_Pipe), 2 );
			this.time = 300;
			this.category = "Weaponry";
		}

	}

}