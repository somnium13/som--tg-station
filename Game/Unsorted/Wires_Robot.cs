// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Wires_Robot : Wires {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.holder_type = typeof(Mob_Living_Silicon_Robot);
			this.randomize = true;
		}

		// Function from file: robot.dm
		public Wires_Robot ( Mob_Living_Silicon_Robot holder = null ) : base( holder ) {
			this.wires = new ByTable(new object [] { "ai", "camera", "lawsync", "lockdown" });
			this.add_duds( 2 );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: robot.dm
		public override void on_cut( dynamic wire = null, int? mend = null ) {
			Obj R = null;

			R = this.holder;

			dynamic _a = wire; // Was a switch-case, sorry for the mess.
			if ( _a=="ai" ) {
				
				if ( !Lang13.Bool( mend ) ) {
					((dynamic)R).connected_ai = null;
				}
			} else if ( _a=="lawsync" ) {
				
				if ( Lang13.Bool( mend ) ) {
					
					if ( !Lang13.Bool( ((dynamic)R).emagged ) ) {
						((dynamic)R).lawupdate = GlobalVars.TRUE;
					}
				} else {
					((dynamic)R).lawupdate = GlobalVars.FALSE;
				}
			} else if ( _a=="camera" ) {
				
				if ( !( ((dynamic)R).camera == null ) && !Lang13.Bool( ((dynamic)R).scrambledcodes ) ) {
					((dynamic)R).camera.status = mend;
					((Obj_Machinery_Camera)((dynamic)R).camera).toggle_cam( Task13.User, false );
					R.visible_message( "" + R + "'s camera lense focuses loudly.", "Your camera lense focuses loudly." );
				}
			} else if ( _a=="lockdown" ) {
				((dynamic)R).SetLockdown( !Lang13.Bool( mend ) );
			}
			return;
		}

		// Function from file: robot.dm
		public override void on_pulse( string wire = null ) {
			Obj R = null;
			dynamic new_ai = null;

			R = this.holder;

			switch ((string)( wire )) {
				case "ai":
					
					if ( !Lang13.Bool( ((dynamic)R).emagged ) ) {
						new_ai = GlobalFuncs.select_active_ai( R );

						if ( Lang13.Bool( new_ai ) && new_ai != ((dynamic)R).connected_ai ) {
							((dynamic)R).connected_ai = new_ai;
							((dynamic)R).notify_ai( GlobalVars.TRUE );
						}
					}
					break;
				case "camera":
					
					if ( !( ((dynamic)R).camera == null ) && !Lang13.Bool( ((dynamic)R).scrambledcodes ) ) {
						((Obj_Machinery_Camera)((dynamic)R).camera).toggle_cam( Task13.User, false );
						R.visible_message( "" + R + "'s camera lense focuses loudly.", "Your camera lense focuses loudly." );
					}
					break;
				case "lawsync":
					
					if ( Lang13.Bool( ((dynamic)R).lawupdate ) ) {
						R.visible_message( "" + R + " gently chimes.", "LawSync protocol engaged." );
						((dynamic)R).lawsync();
						((dynamic)R).show_laws();
					}
					break;
				case "lockdown":
					((dynamic)R).SetLockdown( !Lang13.Bool( ((dynamic)R).lockcharge ) );
					break;
			}
			return;
		}

		// Function from file: robot.dm
		public override ByTable get_status(  ) {
			Obj R = null;
			ByTable status = null;

			R = this.holder;
			status = new ByTable();
			status.Add( "The law sync module is " + ( Lang13.Bool( ((dynamic)R).lawupdate ) ? "on" : "off" ) + "." );
			status.Add( "The intelligence link display shows " + ( Lang13.Bool( ((dynamic)R).connected_ai ) ? ((dynamic)R).connected_ai.name : "NULL" ) + "." );
			status.Add( "The camera light is " + ( !( ((dynamic)R).camera == null ) && Lang13.Bool( ((dynamic)R).camera.status ) ? "on" : "off" ) + "." );
			status.Add( "The lockdown indicator is " + ( Lang13.Bool( ((dynamic)R).lockcharge ) ? "on" : "off" ) + "." );
			return status;
		}

		// Function from file: robot.dm
		public override int? interactable( dynamic user = null ) {
			Obj R = null;

			R = this.holder;

			if ( Lang13.Bool( ((dynamic)R).wiresexposed ) ) {
				return GlobalVars.TRUE;
			}
			return null;
		}

	}

}