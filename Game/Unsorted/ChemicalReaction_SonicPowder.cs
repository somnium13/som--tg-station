// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_SonicPowder : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "sonic_powder";
			this.id = "sonic_powder";
			this.result = "sonic_powder";
			this.required_reagents = new ByTable().Set( "oxygen", 1 ).Set( "cola", 1 ).Set( "phosphorus", 1 );
			this.result_amount = 3;
		}

		// Function from file: pyrotechnics.dm
		public override void on_reaction( Reagents holder = null, double? created_volume = null ) {
			dynamic location = null;
			Mob_Living_Carbon C = null;

			
			if ( Lang13.Bool( holder.has_reagent( "stabilizing_agent" ) ) ) {
				return;
			}
			holder.remove_reagent( "sonic_powder", created_volume );
			location = GlobalFuncs.get_turf( holder.my_atom );
			GlobalFuncs.playsound( location, "sound/effects/bang.ogg", 25, 1 );

			foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_hearers_in_view( ( created_volume ??0) / 10, location ), typeof(Mob_Living_Carbon) )) {
				C = _a;
				

				if ( C.check_ear_prot() ) {
					continue;
				}
				C.show_message( "<span class='warning'>BANG</span>", 2 );
				C.Stun( 5 );
				C.Weaken( 5 );
				C.setEarDamage( C.ear_damage + Rand13.Int( 0, 5 ), Num13.MaxInt( ((int)( C.ear_deaf ??0 )), 15 ) );

				if ( C.ear_damage >= 15 ) {
					C.WriteMsg( "<span class='warning'>Your ears start to ring badly!</span>" );
				} else if ( C.ear_damage >= 5 ) {
					C.WriteMsg( "<span class='warning'>Your ears start to ring!</span>" );
				}
			}
			return;
		}

	}

}