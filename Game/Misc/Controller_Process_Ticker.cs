// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Controller_Process_Ticker : Controller_Process {

		public double lastTickerTimeDuration = 0;
		public int lastTickerTime = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.schedule_interval = 20;
		}

		public Controller_Process_Ticker ( dynamic scheduler = null ) : base( (object)(scheduler) ) {
			
		}

		// Function from file: ticker.dm
		public double getLastTickerTimeDuration(  ) {
			return this.lastTickerTimeDuration;
		}

		// Function from file: ticker.dm
		public override bool doWork(  ) {
			int currentTime = 0;

			this.scheck();
			currentTime = Game13.timeofday;

			if ( currentTime < this.lastTickerTime ) {
				this.lastTickerTimeDuration = ( currentTime - ( this.lastTickerTime - GlobalVars.TICKS_IN_DAY ) ) / GlobalVars.TICKS_IN_SECOND;
			} else {
				this.lastTickerTimeDuration = ( currentTime - this.lastTickerTime ) / GlobalVars.TICKS_IN_SECOND;
			}
			this.lastTickerTime = currentTime;
			GlobalVars.ticker.process();
			return false;
		}

		// Function from file: ticker.dm
		public override void setup(  ) {
			this.name = "ticker";
			this.lastTickerTime = Game13.timeofday;

			if ( !( GlobalVars.ticker != null ) ) {
				GlobalVars.ticker = new Controller_Gameticker();
			}
			GlobalVars.tickerProcess = this;
			Task13.Schedule( 0, (Task13.Closure)(() => {
				
				if ( GlobalVars.ticker != null ) {
					GlobalVars.ticker.pregame();
				}
				return;
			}));
			return;
		}

	}

}