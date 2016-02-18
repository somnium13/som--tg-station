// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class AIModule_Small_OverloadMachine : AIModule_Small {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.module_name = "Machine Overload";
			this.mod_pick_name = "overload";
			this.description = "Overloads an electrical machine, causing a small explosion. 2 uses.";
			this.uses = 2;
			this.cost = 20;
			this.power_type = typeof(Mob_Living_Silicon_Ai).GetMethod( "overload_machine" );
		}

	}

}