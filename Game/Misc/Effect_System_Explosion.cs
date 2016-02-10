// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Effect_System_Explosion : Effect_System {

		public dynamic location = null;

		// Function from file: explosion_particles.dm
		public void start(  ) {
			Effect_System_ExplParticles P = null;
			Effect_Effect_System_SmokeSpread S = null;

			new Obj_Effect_Explosion( this.location );
			P = new Effect_System_ExplParticles();
			P.set_up( 10, this.location );
			P.start();
			Task13.Schedule( 5, (Task13.Closure)(() => {
				S = new Effect_Effect_System_SmokeSpread();
				S.set_up( 5, 0, this.location, null );
				S.start();
				return;
			}));
			return;
		}

		// Function from file: explosion_particles.dm
		public void set_up( dynamic loca = null ) {
			
			if ( loca is Tile ) {
				this.location = loca;
			} else {
				this.location = GlobalFuncs.get_turf( loca );
			}
			return;
		}

	}

}