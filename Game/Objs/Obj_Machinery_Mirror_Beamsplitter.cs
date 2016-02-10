// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Mirror_Beamsplitter : Obj_Machinery_Mirror {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.mirror_state = "splitter";
			this.nsplits = 2;
			this.icon_state = "splitter";
		}

		// Function from file: splitter.dm
		public Obj_Machinery_Mirror_Beamsplitter ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.component_parts = new ByTable(new object [] { new Obj_Item_Stack_Sheet_Glass_Plasmarglass( this, 5 ) });
			return;
		}

		// Function from file: splitter.dm
		public override ByTable get_deflections( int in_dir = 0 ) {
			Interface13.Stat( null, new ByTable(new object [] { GlobalVars.EAST, GlobalVars.WEST }).Contains( this.dir ) );

			if ( false ) {
				
				switch ((int)( in_dir )) {
					case 1:
						return new ByTable(new object [] { GlobalVars.SOUTH, GlobalVars.EAST });
						break;
					case 2:
						return new ByTable(new object [] { GlobalVars.NORTH, GlobalVars.WEST });
						break;
					case 4:
						return new ByTable(new object [] { GlobalVars.NORTH, GlobalVars.WEST });
						break;
					case 8:
						return new ByTable(new object [] { GlobalVars.SOUTH, GlobalVars.EAST });
						break;
				}
			} else {
				
				switch ((int)( in_dir )) {
					case 1:
						return new ByTable(new object [] { GlobalVars.SOUTH, GlobalVars.WEST });
						break;
					case 2:
						return new ByTable(new object [] { GlobalVars.NORTH, GlobalVars.EAST });
						break;
					case 4:
						return new ByTable(new object [] { GlobalVars.SOUTH, GlobalVars.WEST });
						break;
					case 8:
						return new ByTable(new object [] { GlobalVars.NORTH, GlobalVars.EAST });
						break;
				}
			}
			return null;
		}

	}

}