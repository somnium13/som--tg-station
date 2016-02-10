// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Automation_Binary_Subtract : Automation_Binary {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "subtract";
			this.returntype = true;
			this.v_operator = "-";
		}

		public Automation_Binary_Subtract ( Obj_Machinery_Computer_GeneralAirControl_AtmosAutomation aa = null ) : base( aa ) {
			
		}

		// Function from file: statements.dm
		public override dynamic do_operation( dynamic a = null, dynamic b = null ) {
			return a - b;
		}

	}

}