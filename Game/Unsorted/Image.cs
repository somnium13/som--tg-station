// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Image : Base_Image {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.layer = -1;
		}

		public Image ( dynamic icon = null, dynamic loc = null, dynamic icon_state = null, dynamic layer = null, dynamic dir = null, int? pixel_x = null, int? pixel_y = null ) : base( (object)(icon), (object)(loc), (object)(icon_state), (object)(layer), (object)(dir), pixel_x, pixel_y ) {
			
		}

		// Function from file: pool.dm
		public override void ResetVars( params object[] _ ) {
			ByTable _args = new ByTable( new object[] {  } ).Extend(_);

			base.ResetVars();
			((dynamic)this).loc = null;
			return;
		}

	}

}