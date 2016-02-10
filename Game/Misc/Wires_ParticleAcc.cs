// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Wires_ParticleAcc : Wires {

		public Wires_ParticleAcc ( Obj holder = null ) : base( holder ) {
			
		}

		// Function from file: particle_accelerator.dm
		public override string GetInteractWindow(  ) {
			string _default = null;

			_default += base.GetInteractWindow();
			_default += "<BR>The keyboard light is " + ( this.IsIndexCut( GlobalVars.PARTICLE_INTERFACE_WIRE ) != 0 ? "flashing" : "on" ) + ".<BR>\n	The regulator light is " + ( this.IsIndexCut( GlobalVars.PARTICLE_LIMIT_POWER_WIRE ) != 0 ? "purple" : "teal" ) + ".<BR>";
			return _default;
		}

	}

}