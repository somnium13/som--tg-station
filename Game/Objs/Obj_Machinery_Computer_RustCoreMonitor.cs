// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_RustCoreMonitor : Obj_Machinery_Computer {

		public Base_Data linked_core = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.light_color = "#E1E17D";
			this.circuit = typeof(Obj_Item_Weapon_Circuitboard_RustCoreMonitor);
			this.icon_state = "power";
		}

		public Obj_Machinery_Computer_RustCoreMonitor ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: core_monitor.dm
		public override bool unlinkFrom( Mob user = null, Base_Data buffer = null ) {
			bool _default = false;

			this.linked_core = null;
			_default = true;
			return _default;
		}

		// Function from file: core_monitor.dm
		public override Base_Data getLink( double? idx = null ) {
			Base_Data _default = null;

			_default = this.linked_core;
			return _default;
		}

		// Function from file: core_monitor.dm
		public override bool linkWith( Mob user = null, Base_Data buffer = null, ByTable context = null ) {
			bool _default = false;

			this.linked_core = buffer;
			_default = true;
			return _default;
		}

		// Function from file: core_monitor.dm
		public override bool? isLinkedWith( Base_Data O = null ) {
			bool? _default = null;

			_default = this.linked_core == O;
			return _default;
		}

		// Function from file: core_monitor.dm
		public override bool canLink( Base_Data O = null, ByTable context = null ) {
			bool _default = false;

			
			if ( O is Obj_Machinery_Power_RustCore && !( this.linked_core != null ) ) {
				_default = true;
			}
			return _default;
		}

		// Function from file: core_monitor.dm
		public override string linkMenu( Base_Data O = null ) {
			string _default = null;

			
			if ( O is Obj_Machinery_Power_RustCore ) {
				_default = new Txt( "<a href='?src=" ).Ref( this ).str( ";link=1'>[LINK]</a> " ).ToString();
			}
			return _default;
		}

		// Function from file: core_monitor.dm
		public override string multitool_menu( dynamic user = null, dynamic P = null ) {
			string _default = null;

			
			if ( this.linked_core != null ) {
				_default = new Txt( "\n			<b>Linked R-UST Mk. 7 pattern Electromagnetic Field Generator:<br>\n			" ).item( ((dynamic)this.linked_core).id_tag ).str( " <a href='?src=" ).Ref( this ).str( ";unlink=1'>[X]</a></b>\n		" ).ToString();
			} else {
				_default = "\n			<b>No Linked R-UST Mk. 7 pattern Electromagnetic Field Generator</b>\n		";
			}
			return _default;
		}

		// Function from file: core_monitor.dm
		public bool check_core_status(  ) {
			bool _default = false;

			
			if ( !( this.linked_core is Obj_Machinery_Power_RustCore ) ) {
				return _default;
			}

			if ( Lang13.Bool( ((dynamic)this.linked_core).stat & 1 ) ) {
				return _default;
			}

			if ( Convert.ToDouble( ((dynamic)this.linked_core).avail() ) < Convert.ToDouble( ((dynamic)this.linked_core).idle_power_usage ) ) {
				return _default;
			}
			_default = true;
			return _default;
		}

		// Function from file: core_monitor.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			dynamic _default = null;

			string power_color = null;
			dynamic reagent = null;
			Browser popup = null;

			
			if ( this.linked_core != null ) {
				_default = "\n			<b>Device ID tag:</b> " + ((dynamic)this.linked_core).id_tag + "<br>\n		";

				if ( !this.check_core_status() ) {
					_default += "\n			<b><span style='color: red'>ERROR: Device unresponsive</b><span>\n			";
				} else {
					power_color = ( Convert.ToDouble( ((dynamic)this.linked_core).avail() ) < Convert.ToDouble( ((dynamic)this.linked_core).active_power_usage ) ? "orange" : "green" );
					_default += "\n			<b>Device power status: </b><span style='color: " + power_color + "'>" + ((dynamic)this.linked_core).avail() + "/" + ((dynamic)this.linked_core).active_power_usage + " W</span><br>\n			<b>Device field status: </b><span style='color: " + ( Lang13.Bool( ((dynamic)this.linked_core).owned_field ) ? "green" : "red" ) + "'>" + ( Lang13.Bool( ((dynamic)this.linked_core).owned_field ) ? "enabled" : "disabled" ) + "</span><hr>\n			<b>Field power density (W.m<sup>-3</sup>):</b> " + ((dynamic)this.linked_core).field_strength + "<br>\n			<b>Field frequency (MHz):</b> " + ((dynamic)this.linked_core).field_frequency + "<br>\n			";

					if ( Lang13.Bool( ((dynamic)this.linked_core).owned_field ) ) {
						_default += "\n			<b>Approximate field diameter (m):</b> " + ((dynamic)this.linked_core).owned_field.size + "<br>\n			<b>Field mega energy:</b> " + ((dynamic)this.linked_core).owned_field.mega_energy + "<br>\n			<b>Field sub-mega energy:</b> " + ((dynamic)this.linked_core).owned_field.energy + @"<hr>
			<b>Field dormant reagents:</b><br>
			<table>
				<tr>
					<th><b>Name</b></th>
					<th><b>Amount</b></th>
				</tr>
				";

						foreach (dynamic _a in Lang13.Enumerate( ((dynamic)this.linked_core).owned_field.dormant_reactant_quantities )) {
							reagent = _a;
							
							_default += "\n				<tr>\n					<td>" + reagent + "</td>\n					<td>" + ((dynamic)this.linked_core).owned_field.dormant_reactant_quantities[reagent] + "</td>\n				</tr>\n					";
						}
					}
					_default += "\n			</table>\n			";
				}
			} else {
				_default = "\n			<span style='color: red'><b>No linked R-UST Mk. 7 pattern Electromagnetic Field Generator</b></span>\n		";
			}
			popup = new Browser( user, "rust_core_monitor", this.name, 500, 400, this );
			popup.set_content( _default );
			popup.open();
			((Mob)user).set_machine( this );
			return _default;
		}

		// Function from file: core_monitor.dm
		public override dynamic attack_ai( dynamic user = null ) {
			this.attack_hand( user );
			return null;
		}

		// Function from file: core_monitor.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic _default = null;

			_default = base.attack_hand( (object)(a), (object)(b), (object)(c) );

			if ( Lang13.Bool( _default ) ) {
				((Mob)a).unset_machine();
				return _default;
			}
			this.interact( a );
			return _default;
		}

	}

}