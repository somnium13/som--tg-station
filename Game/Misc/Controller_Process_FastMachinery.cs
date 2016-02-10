// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Controller_Process_FastMachinery : Controller_Process {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.schedule_interval = 7;
		}

		public Controller_Process_FastMachinery ( dynamic scheduler = null ) : base( (object)(scheduler) ) {
			
		}

		// Function from file: fast_machinery.dm
		public override bool doWork(  ) {
			double? i = null;
			Obj M = null;
			int time_start = 0;
			int time_end = 0;
			dynamic e = null;

			
			if ( !( GlobalVars.fast_machines != null ) || !( GlobalVars.fast_machines.len != 0 ) ) {
				return false;
			}

			foreach (dynamic _a in Lang13.IterateRange( 1, GlobalVars.fast_machines.len )) {
				i = _a;
				

				if ( ( i ??0) > GlobalVars.fast_machines.len ) {
					break;
				}

				try {
					M = GlobalVars.fast_machines[i];

					if ( M is Obj_Machinery && !Lang13.Bool( M.gcDestroyed ) ) {
						
						if ( M.timestopped ) {
							continue;
						}
						time_start = Game13.timeofday;

						if ( M.process() == 26 ) {
							((dynamic)M).inMachineList = 0;
							GlobalVars.fast_machines.Remove( M );
							continue;
						}

						if ( M != null && Lang13.Bool( ((dynamic)M).use_power ) ) {
							((Obj_Machinery)M).auto_use_power();
						}

						if ( M is Obj_Machinery ) {
							time_end = Game13.timeofday;
							Interface13.Stat( null, GlobalVars.machine_profiling.Contains( M.type ) );

							if ( !false ) {
								GlobalVars.machine_profiling[M.type] = 0;
							}
							GlobalVars.machine_profiling[M.type] += time_end - time_start;
						} else if ( !GlobalVars.fast_machines.Remove( M ) ) {
							GlobalVars.fast_machines.Cut( ((int?)( i )), ((int)( ( i ??0) + 1 )) );
						}
					} else {
						
						if ( M != null ) {
							((dynamic)M).inMachineList = 0;
						}

						if ( !GlobalVars.fast_machines.Remove( M ) ) {
							GlobalVars.fast_machines.Cut( ((int?)( i )), ((int)( ( i ??0) + 1 )) );
						}
					}
				} catch (Exception __) {
					e = __
					Game13.Error( e );
					continue;
				}

				if ( !( ( i ??0) % 20 != 0 ) ) {
					this.scheck();
				}
			}
			return false;
		}

		// Function from file: fast_machinery.dm
		public override void setup(  ) {
			this.name = "fast_machinery";
			return;
		}

	}

}