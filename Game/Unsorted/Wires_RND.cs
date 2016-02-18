// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Wires_RND : Wires {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.holder_type = typeof(Obj_Machinery_RND);
			this.randomize = true;
		}

		// Function from file: r_n_d.dm
		public Wires_RND ( Obj_Machinery_RND holder = null ) : base( holder ) {
			this.wires = new ByTable(new object [] { "hack", "disable", "shock" });
			this.add_duds( 5 );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: r_n_d.dm
		public override void on_cut( dynamic wire = null, int? mend = null ) {
			Obj R = null;

			R = this.holder;

			dynamic _a = wire; // Was a switch-case, sorry for the mess.
			if ( _a=="hack" ) {
				((dynamic)R).hacked = !Lang13.Bool( mend );
			} else if ( _a=="disable" ) {
				((dynamic)R).disabled = !Lang13.Bool( mend );
			} else if ( _a=="shock" ) {
				((dynamic)R).shocked = !Lang13.Bool( mend );
			}
			return;
		}

		// Function from file: r_n_d.dm
		public override void on_pulse( string wire = null ) {
			Obj R = null;

			R = this.holder;

			switch ((string)( wire )) {
				case "hack":
					((dynamic)R).hacked = !Lang13.Bool( ((dynamic)R).hacked );
					break;
				case "disable":
					((dynamic)R).disabled = !Lang13.Bool( ((dynamic)R).disabled );
					break;
				case "shock":
					((dynamic)R).shocked = GlobalVars.TRUE;
					Task13.Schedule( 100, (Task13.Closure)(() => {
						
						if ( R != null ) {
							((dynamic)R).shocked = GlobalVars.FALSE;
						}
						return;
					}));
					break;
			}
			return;
		}

		// Function from file: r_n_d.dm
		public override ByTable get_status(  ) {
			Obj R = null;
			ByTable status = null;

			R = this.holder;
			status = new ByTable();
			status.Add( "The red light is " + ( Lang13.Bool( ((dynamic)R).disabled ) ? "off" : "on" ) + "." );
			status.Add( "The green light is " + ( Lang13.Bool( ((dynamic)R).shocked ) ? "off" : "on" ) + "." );
			status.Add( "The blue light is " + ( Lang13.Bool( ((dynamic)R).hacked ) ? "off" : "on" ) + "." );
			return status;
		}

		// Function from file: r_n_d.dm
		public override int? interactable( dynamic user = null ) {
			Obj R = null;

			R = this.holder;

			if ( Lang13.Bool( ((dynamic)R).panel_open ) ) {
				return GlobalVars.TRUE;
			}
			return null;
		}

	}

}