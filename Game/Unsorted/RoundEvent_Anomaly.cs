// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RoundEvent_Anomaly : RoundEvent {

		public dynamic impact_area = null;
		public Obj_Effect_Anomaly newAnomaly = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.announceWhen = 1;
		}

		// Function from file: anomaly.dm
		public override void end(  ) {
			
			if ( this.newAnomaly != null ) {
				GlobalFuncs.qdel( this.newAnomaly );
			}
			return;
		}

		// Function from file: anomaly.dm
		public override void tick(  ) {
			
			if ( !( this.newAnomaly != null ) ) {
				this.kill();
				return;
			}
			this.newAnomaly.anomalyEffect();
			return;
		}

		// Function from file: anomaly.dm
		public override bool start(  ) {
			dynamic T = null;

			T = GlobalFuncs.safepick( GlobalFuncs.get_area_turfs( this.impact_area ) );

			if ( Lang13.Bool( T ) ) {
				this.newAnomaly = new Obj_Effect_Anomaly_Flux( T );
			}
			return false;
		}

		// Function from file: anomaly.dm
		public override void announce(  ) {
			GlobalFuncs.priority_announce( "Localized energetic flux wave detected on long range scanners. Expected location of impact: " + this.impact_area.name + ".", "Anomaly Alert" );
			return;
		}

		// Function from file: anomaly.dm
		public override void setup( int? loop = null ) {
			loop = loop ?? 0;

			int? safety_loop = null;
			ByTable turf_test = null;

			safety_loop = ( loop ??0) + 1;

			if ( ( safety_loop ??0) > 50 ) {
				this.kill();
				this.end();
			}
			this.impact_area = this.findEventArea();

			if ( !Lang13.Bool( this.impact_area ) ) {
				this.setup( safety_loop );
			}
			turf_test = GlobalFuncs.get_area_turfs( this.impact_area );

			if ( !( turf_test.len != 0 ) ) {
				this.setup( safety_loop );
			}
			return;
		}

	}

}