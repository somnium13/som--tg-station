// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Wires_Explosive : Wires {

		// Function from file: explosive.dm
		public Wires_Explosive ( Obj_Item holder = null ) : base( holder ) {
			this.add_duds( 2 );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: explosive.dm
		public virtual void explode(  ) {
			return;
		}

		// Function from file: explosive.dm
		public override void on_cut( dynamic wire = null, int? mend = null ) {
			this.explode();
			return;
		}

		// Function from file: explosive.dm
		public override void on_pulse( string wire = null ) {
			this.explode();
			return;
		}

	}

}