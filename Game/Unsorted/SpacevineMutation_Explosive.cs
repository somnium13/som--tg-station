// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SpacevineMutation_Explosive : SpacevineMutation {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "explosive";
			this.hue = "#ff0000";
			this.quality = 2;
			this.severity = 2;
		}

		// Function from file: spacevine.dm
		public override void on_death( Obj_Effect_Spacevine holder = null, dynamic hitter = null, dynamic I = null ) {
			GlobalFuncs.explosion( holder.loc, 0, 0, this.severity, 0, 0 );
			return;
		}

		// Function from file: spacevine.dm
		public override bool on_explosion( double? severity = null, dynamic target = null, Obj_Effect_Spacevine holder = null ) {
			bool _default = false;

			
			if ( ( severity ??0) < 3 ) {
				GlobalFuncs.qdel( this );
			} else {
				_default = true;
				Task13.Schedule( 5, (Task13.Closure)(() => {
					GlobalFuncs.qdel( this );
					return;
				}));
			}
			return _default;
		}

	}

}