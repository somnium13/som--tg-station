// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_SuspensionField : Obj_Effect {

		public string field_type = "chlorine";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/effects/effects.dmi";
		}

		public Obj_Effect_SuspensionField ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: suspension_generator.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			Obj I = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this, typeof(Obj) )) {
				I = _a;
				
				I.loc = this.loc;
			}
			base.Destroy( (object)(brokenup) );
			return null;
		}

	}

}