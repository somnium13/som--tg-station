// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_AcceleratedParticle_Powerful : Obj_Effect_AcceleratedParticle {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.movement_range = 20;
			this.energy = 50;
			this.icon_state = "particle3";
		}

		public Obj_Effect_AcceleratedParticle_Powerful ( dynamic loc = null, int? dir = null, bool? move = null ) : base( (object)(loc), dir, move ) {
			
		}

		// Function from file: particle.dm
		public override dynamic resetVariables( string args = null, params object[] _ ) {
			ByTable _args = new ByTable( new object[] { args } ).Extend(_);

			base.resetVariables( "energy", "movement_range" );
			this.energy = 50;
			this.movement_range = 20;
			return null;
		}

	}

}