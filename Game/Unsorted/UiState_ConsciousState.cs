// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UiState_ConsciousState : UiState {

		// Function from file: conscious.dm
		public override int can_use_topic( Game_Data src_object = null, dynamic user = null ) {
			
			if ( Lang13.Bool( user.stat ) == false ) {
				return 2;
			}
			return -1;
		}

	}

}