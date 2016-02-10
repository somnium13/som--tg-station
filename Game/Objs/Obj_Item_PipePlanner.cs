// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_PipePlanner : Obj_Item {

		public ContextClick_PipePlanner planner = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 4;
			this.icon = "icons/obj/pipe-item.dmi";
			this.icon_state = "pipe-planner";
			this.layer = 2.85;
		}

		// Function from file: pipe_planner.dm
		public Obj_Item_PipePlanner ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.planner = new ContextClick_PipePlanner( this );
			return;
		}

		// Function from file: pipe_planner.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.dir = Num13.Rotate( this.dir, 90 );
			base.attack_self( (object)(user), (object)(flag), emp );
			return null;
		}

		// Function from file: pipe_planner.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( GlobalFuncs.get_turf( this ) == this.loc ) {
				return this.planner.action( a, b, c );
			}
			return base.attackby( (object)(a), (object)(b), (object)(c) );
		}

	}

}