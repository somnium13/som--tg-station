// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Screen_Schematics : Obj_Screen {

		public RcdSchematic ourschematic = null;

		// Function from file: screen_objects.dm
		public Obj_Screen_Schematics ( dynamic loc = null, dynamic ourschematic = null ) : base( (object)(loc) ) {
			
			if ( !Lang13.Bool( ourschematic ) ) {
				GlobalFuncs.qdel( this );
				return;
			}
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.ourschematic = ourschematic;
			this.icon = ourschematic.icon;
			this.icon_state = ourschematic.icon_state;
			this.name = ourschematic.name;
			this.transform = this.transform * 0.8;
			return;
		}

		// Function from file: screen_objects.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			this.ourschematic = null;
			base.Destroy( (object)(brokenup) );
			return null;
		}

		// Function from file: screen_objects.dm
		public override bool Click( dynamic loc = null, string control = null, string _params = null ) {
			
			if ( this.ourschematic != null ) {
				this.ourschematic.clicked( Task13.User );
			}
			return false;
		}

	}

}