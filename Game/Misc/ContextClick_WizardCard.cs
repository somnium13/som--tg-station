// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ContextClick_WizardCard : ContextClick {

		public ContextClick_WizardCard ( Obj_Item to_hold = null ) : base( to_hold ) {
			
		}

		// Function from file: wizard_cards.dm
		public override dynamic action( dynamic used_item = null, dynamic user = null, dynamic _params = null ) {
			Obj_Item card = null;

			card = this.holder;

			if ( !Lang13.Bool( used_item ) ) {
				
				dynamic _a = this.return_clicked_id_by_params( _params ); // Was a switch-case, sorry for the mess.
				if ( _a=="portrait" ) {
					return ((dynamic)card).special_effect();
				} else {
					return ((dynamic)card).Flip();
				}
			}
			return null;
		}

		// Function from file: wizard_cards.dm
		public override dynamic return_clicked_id( double? x_pos = null, double? y_pos = null ) {
			
			if ( 14 <= ( x_pos ??0) && ( x_pos ??0) <= 19 ) {
				
				if ( 7 <= ( y_pos ??0) && ( y_pos ??0) <= 20 ) {
					return "portrait";
				}
			}
			return "flip";
		}

	}

}