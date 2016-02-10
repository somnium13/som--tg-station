// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Softwall : Obj_Structure {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/bomberman.dmi";
			this.icon_state = "softwall";
		}

		// Function from file: bomberman.dm
		public Obj_Structure_Softwall ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalVars.bombermangear.Add( this );
			return;
		}

		// Function from file: bomberman.dm
		public override bool singuloCanEat(  ) {
			return false;
		}

		// Function from file: bomberman.dm
		public override dynamic cultify(  ) {
			return null;
		}

		// Function from file: bomberman.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			this.pulverized();
			return false;
		}

		// Function from file: bomberman.dm
		public void pick_a_powerup(  ) {
			dynamic powerup = null;

			powerup = Rand13.PickWeighted(new object [] { 16803, typeof(Obj_Structure_Powerup_Bombup), 33606, typeof(Obj_Structure_Powerup_Fire), 50409, typeof(Obj_Structure_Powerup_Skate), 53769, typeof(Obj_Structure_Powerup_Kick), 57129, typeof(Obj_Structure_Powerup_Line), 60489, typeof(Obj_Structure_Powerup_Power), 63849, typeof(Obj_Structure_Powerup_Skull), 65535, typeof(Obj_Structure_Powerup_Full) });
			Lang13.Call( powerup, GlobalFuncs.get_turf( this ) );
			return;
		}

		// Function from file: bomberman.dm
		public void pulverized(  ) {
			this.icon_state = "softwall_break";
			this.density = false;
			this.mouse_opacity = 0;
			Task13.Schedule( 5, (Task13.Closure)(() => {
				
				if ( Rand13.PercentChance( 45 ) ) {
					this.pick_a_powerup();
				}
				Task13.Schedule( 5, (Task13.Closure)(() => {
					GlobalFuncs.qdel( this );
					return;
				}));
				return;
			}));
			return;
		}

		// Function from file: bomberman.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			base.Destroy( (object)(brokenup) );
			GlobalVars.bombermangear.Remove( this );
			return null;
		}

	}

}