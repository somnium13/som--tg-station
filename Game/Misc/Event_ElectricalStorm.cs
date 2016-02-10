// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Event_ElectricalStorm : Event {

		public int? lightsoutAmount = 1;
		public int lightsoutRange = 25;

		public Event_ElectricalStorm ( Obj_Item_MechaParts_MechaEquipment_Tool_CableLayer tlistener = null, string tprocname = null ) : base( tlistener, tprocname ) {
			
		}

		// Function from file: electrical_storm.dm
		public override bool start(  ) {
			ByTable epicentreList = null;
			int? i = null;
			ByTable possibleEpicentres = null;
			Obj_Effect_Landmark newEpicentre = null;
			Obj_Effect_Landmark epicentre = null;
			Obj_Machinery_Power_Apc apc = null;

			epicentreList = new ByTable();
			i = null;
			i = 1;

			while (( i ??0) <= ( this.lightsoutAmount ??0)) {
				possibleEpicentres = new ByTable();

				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.landmarks_list, typeof(Obj_Effect_Landmark) )) {
					newEpicentre = _a;
					

					if ( newEpicentre.name == "lightsout" && !false ) {
						possibleEpicentres.Add( newEpicentre );
					}
				}

				if ( possibleEpicentres.len != 0 ) {
					epicentreList.Add( Rand13.PickFromTable( possibleEpicentres ) );
				} else {
					break;
				}
				i++;
			}

			if ( !( epicentreList.len != 0 ) ) {
				return false;
			}

			foreach (dynamic _c in Lang13.Enumerate( epicentreList, typeof(Obj_Effect_Landmark) )) {
				epicentre = _c;
				

				foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInRange( this.lightsoutRange, epicentre ), typeof(Obj_Machinery_Power_Apc) )) {
					apc = _b;
					
					apc.overload_lighting();
				}
			}
			return false;
		}

		// Function from file: electrical_storm.dm
		public override void announce(  ) {
			GlobalFuncs.command_alert( "An electrical storm has been detected in your area, please repair potential electronic overloads.", "Electrical Storm Alert" );
			return;
		}

	}

}