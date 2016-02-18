// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Simulated_Wall_Cult : Tile_Simulated_Wall {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.walltype = "cult";
			this.icon = "icons/turf/walls/cult_wall.dmi";
			this.icon_state = "cult";
		}

		// Function from file: walls_misc.dm
		public Tile_Simulated_Wall_Cult ( dynamic loc = null ) : base( (object)(loc) ) {
			GlobalFuncs.PoolOrNew( typeof(Obj_Effect_Overlay_Temp_Cult_Turf), this );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: walls_misc.dm
		public override void narsie_act(  ) {
			return;
		}

		// Function from file: walls_misc.dm
		public override void devastate_wall(  ) {
			new Obj_Effect_Decal_Cleanable_Blood( this );
			new Obj_Effect_Decal_Remains_Human( this );
			return;
		}

		// Function from file: walls_misc.dm
		public override Obj_Structure break_wall(  ) {
			new Obj_Effect_Decal_Cleanable_Blood( this );
			return new Obj_Structure_Cultgirder( this );
		}

	}

}