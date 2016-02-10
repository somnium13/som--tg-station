// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class GlobalIterator_MechaEnergyRelay : GlobalIterator {

		public GlobalIterator_MechaEnergyRelay ( ByTable arguments = null, bool? autostart = null ) : base( arguments, autostart ) {
			
		}

		// Function from file: tools.dm
		public override bool process( Obj port = null, dynamic mecha = null ) {
			dynamic cur_charge = null;
			dynamic A = null;
			dynamic pow_chan = null;
			dynamic c = null;
			double delta = 0;

			
			if ( !Lang13.Bool( ((dynamic)port).chassis ) || ((Obj_Mecha)((dynamic)port).chassis).hasInternalDamage( 4 ) != 0 ) {
				this.stop();
				((dynamic)port).set_ready_state( 1 );
				return false;
			}
			cur_charge = ((Obj_Mecha)((dynamic)port).chassis).get_charge();

			if ( cur_charge == null || !Lang13.Bool( ((dynamic)port).chassis.cell ) ) {
				this.stop();
				((dynamic)port).set_ready_state( 1 );
				((dynamic)port).occupant_message( "No powercell detected." );
				return false;
			}

			if ( Convert.ToDouble( cur_charge ) < Convert.ToDouble( ((dynamic)port).chassis.cell.maxcharge ) ) {
				A = GlobalFuncs.get_area( ((dynamic)port).chassis );

				if ( Lang13.Bool( A ) ) {
					
					foreach (dynamic _a in Lang13.Enumerate( new ByTable(new object [] { 1, 3, 2 }) )) {
						c = _a;
						

						if ( Lang13.Bool( A.powered( c ) ) ) {
							pow_chan = c;
							break;
						}
					}

					if ( Lang13.Bool( pow_chan ) ) {
						delta = Num13.MinInt( 12, Convert.ToInt32( ((dynamic)port).chassis.cell.maxcharge - cur_charge ) );
						((Obj_Mecha)((dynamic)port).chassis).give_power( delta );
						A.use_power( delta * Convert.ToDouble( ((dynamic)port).coeff ), pow_chan );
					}
				}
			}
			return false;
		}

	}

}