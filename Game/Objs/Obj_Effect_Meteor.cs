// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Meteor : Obj_Effect {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.pass_flags = 1;
			this.icon = "icons/obj/meteor.dmi";
			this.icon_state = "medium";
		}

		public Obj_Effect_Meteor ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: meteors.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			Map13.Walk( this, 0, 0 );
			base.Destroy( (object)(brokenup) );
			return null;
		}

		// Function from file: meteors.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Obj_Item_Weapon_Pickaxe ) {
				GlobalFuncs.qdel( this );
			}
			base.attackby( (object)(a), (object)(b), (object)(c) );
			return null;
		}

		// Function from file: meteors.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			base.Move( (object)(NewLoc), Dir, step_x, step_y );
			return false;
		}

		// Function from file: meteors.dm
		public override dynamic Bump( Obj Obstacle = null, dynamic yes = null ) {
			GlobalFuncs.explosion( GlobalFuncs.get_turf( this ), 2, 4, 6, 8, 0, true, false );
			GlobalFuncs.qdel( this );
			return null;
		}

		// Function from file: meteors.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 1.5;
			air_group = air_group ?? false;

			
			if ( mover is Obj_Effect_Meteor ) {
				return true;
			} else {
				return base.CanPass( (object)(mover), (object)(target), height, air_group );
			}
		}

		// Function from file: meteors.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			return false;
		}

	}

}