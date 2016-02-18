// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RoundEvent_CarpMigration : RoundEvent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.announceWhen = 3;
			this.startWhen = 50;
		}

		// Function from file: carp_migration.dm
		public override bool start(  ) {
			Obj_Effect_Landmark C = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.landmarks_list, typeof(Obj_Effect_Landmark) )) {
				C = _a;
				

				if ( C.name == "carpspawn" ) {
					
					if ( Rand13.PercentChance( 95 ) ) {
						new Mob_Living_SimpleAnimal_Hostile_Carp( C.loc );
					} else {
						new Mob_Living_SimpleAnimal_Hostile_Carp_Megacarp( C.loc );
					}
				}
			}
			return false;
		}

		// Function from file: carp_migration.dm
		public override void announce(  ) {
			GlobalFuncs.priority_announce( "Unknown biological entities have been detected near " + GlobalFuncs.station_name() + ", please stand-by.", "Lifesign Alert" );
			return;
		}

		// Function from file: carp_migration.dm
		public override void setup( int? loop = null ) {
			this.startWhen = Rand13.Int( 40, 60 );
			return;
		}

	}

}