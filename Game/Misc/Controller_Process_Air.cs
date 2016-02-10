// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Controller_Process_Air : Controller_Process {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.schedule_interval = 31;
		}

		public Controller_Process_Air ( dynamic scheduler = null ) : base( (object)(scheduler) ) {
			
		}

		// Function from file: vgstation13.dme
		public override bool doWork(  ) {
			dynamic e = null;

			
			try {
				
				if ( !( GlobalVars.air_processing_killed == true ) ) {
					
					if ( !GlobalVars.air_master.Tick() ) {
						GlobalVars.air_master.failed_ticks++;

						if ( GlobalVars.air_master.failed_ticks > 5 ) {
							GlobalFuncs.to_chat( typeof(Game13), "<SPAN CLASS='danger'>RUNTIMES IN ATMOS TICKER.  Killing air simulation!</SPAN>" );
							Game13.log.WriteMsg( "### ZAS SHUTDOWN" );
							GlobalFuncs.message_admins( "ZASALERT: Shutting down! status: " + GlobalVars.air_master.tick_progress );
							GlobalFuncs.log_admin( "ZASALERT: Shutting down! status: " + GlobalVars.air_master.tick_progress );
							GlobalVars.air_processing_killed = GlobalVars.TRUE;
							GlobalVars.air_master.failed_ticks = 0;
						}
					}
					this.scheck();
				}
			} catch (Exception __) {
				e = __
				Game13.Error( e );
				return false;
			}
			return false;
		}

		// Function from file: air.dm
		public override void setup(  ) {
			this.name = "air";

			if ( !( GlobalVars.air_master != null ) ) {
				GlobalVars.air_master = new Controller_AirSystem();
				GlobalVars.air_master.Setup();
			}
			return;
		}

	}

}