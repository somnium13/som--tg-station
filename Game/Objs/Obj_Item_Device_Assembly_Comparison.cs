// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Assembly_Comparison : Obj_Item_Device_Assembly {

		public dynamic check_this = 1;
		public dynamic checked_value_1 = null;
		public dynamic check_type = "EQUAL TO";
		public dynamic check_against = 1;
		public dynamic checked_value_2 = null;
		public dynamic pulse_if_true = null;
		public dynamic pulse_if_false = null;
		public ByTable device_pool = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.starting_materials = new ByTable().Set( "$iron", 100 ).Set( "$glass", 25 );
			this.origin_tech = "programming=1";
			this.connection_text = "connected to";
			this.accessible_values = new ByTable().Set( "Operation", "check_type;text" );
			this.icon_state = "circuit_=";
		}

		public Obj_Item_Device_Assembly_Comparison ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: comparison.dm
		public override void disconnected( dynamic A = null, bool? in_frame = null ) {
			base.disconnected( (object)(A), in_frame );
			this.device_pool.Remove( A );

			if ( this.check_this == A ) {
				this.check_this = 1;
			}

			if ( this.check_against == A ) {
				this.check_against = 1;
			}

			if ( this.pulse_if_true == A ) {
				this.pulse_if_true = null;
			}

			if ( this.pulse_if_false == A ) {
				this.pulse_if_false = null;
			}
			return;
		}

		// Function from file: comparison.dm
		public override void connected( dynamic A = null, bool? in_frame = null ) {
			base.connected( (object)(A), in_frame );
			this.device_pool.Or( A );
			return;
		}

		// Function from file: comparison.dm
		public override void set_value( string var_name = null, dynamic new_value = null ) {
			
			if ( var_name == "check_type" ) {
				
				if ( !( GlobalVars.comparison_circuit_operations.Find( new_value ) != 0 ) ) {
					return;
				}
			}
			base.set_value( var_name, (object)(new_value) ); return;
		}

		// Function from file: comparison.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic choice = null;
			dynamic choice2 = null;
			dynamic new_num = null;
			dynamic A = null;
			dynamic new_value = null;
			string new_values_params = null;
			ByTable L = null;
			dynamic choice3 = null;
			dynamic new_num2 = null;
			dynamic A2 = null;
			dynamic new_value2 = null;
			string new_values_params2 = null;
			ByTable L2 = null;
			dynamic choice4 = null;
			dynamic choice5 = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return null;
			}

			if ( Lang13.Bool( href_list["change_check_type"] ) ) {
				choice = Interface13.Input( Task13.User, new Txt( "Select a new check type for " ).the( this ).item().str( "." ).ToString(), new Txt().The( this ).item().ToString(), null, GlobalVars.comparison_circuit_operations, InputType.Null | InputType.Any );

				if ( choice == null ) {
					return null;
				}

				if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
					return null;
				}
				GlobalFuncs.to_chat( Task13.User, "<span class='info'>You change the check from " + this.check_type + " to " + choice + ".</span>" );
				this.check_type = choice;
			}

			if ( Lang13.Bool( href_list["change_check_this"] ) ) {
				choice2 = Interface13.Input( Task13.User, new Txt( "Select a new checked value #1 for " ).the( this ).item().str( "." ).ToString(), new Txt().The( this ).item().ToString(), null, this.device_pool + "Constant number", InputType.Null | InputType.Any );

				if ( choice2 == null ) {
					return null;
				}

				if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
					return null;
				}

				if ( choice2 == "Constant number" ) {
					new_num = Interface13.Input( Task13.User, "Please type in a number that will be used as value #1.", new Txt().The( this ).item().ToString(), null, null, InputType.Num | InputType.Null );

					if ( new_num == null ) {
						return null;
					}

					if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
						return null;
					}
					this.check_this = new_num;
					GlobalFuncs.to_chat( Task13.User, "<span class='info'>Value #1 set to be " + this.check_against + "</span>" );
				} else {
					A = choice2;

					if ( !( A is Obj_Item_Device_Assembly ) ) {
						return null;
					}

					if ( !( A.accessible_values != null ) || !( A.accessible_values.len != 0 ) ) {
						GlobalFuncs.to_chat( Task13.User, new Txt( "<span class='info'>" ).The( A ).item().str( " has no accessible values." ).ToString() );
						return null;
					}
					new_value = Interface13.Input( Task13.User, new Txt( "Select which of " ).the( A ).item().str( "'s values is used as " ).the( this ).item().str( "'s value #1." ).ToString(), new Txt().The( this ).item().ToString(), null, A.accessible_values, InputType.Null | InputType.Any );

					if ( new_value == null ) {
						return null;
					}

					if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
						return null;
					}
					new_values_params = A.accessible_values[new_value];
					L = String13.ParseUrlParams( new_values_params );

					if ( L[2] != "number" ) {
						GlobalFuncs.to_chat( Task13.User, new Txt( "<span class='info'>Only numbers may be used in " ).the( this ).item().str( ".</span>" ).ToString() );
						return null;
					}

					if ( !( this.device_pool.Find( choice2 ) != 0 ) ) {
						return null;
					}
					this.check_this = choice2;
					this.checked_value_1 = new_value;
					GlobalFuncs.to_chat( Task13.User, "<span class='info'>Value #1 set to be " + this.check_this + " - " + this.checked_value_1 + "</span>" );
				}
			}

			if ( Lang13.Bool( href_list["change_check_against"] ) ) {
				choice3 = Interface13.Input( Task13.User, new Txt( "Select a new checked value #2 for " ).the( this ).item().str( "." ).ToString(), new Txt().The( this ).item().ToString(), null, this.device_pool + "Constant number", InputType.Null | InputType.Any );

				if ( choice3 == null ) {
					return null;
				}

				if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
					return null;
				}

				if ( choice3 == "Constant number" ) {
					new_num2 = Interface13.Input( Task13.User, "Please type in a number that will be used as value #2.", new Txt().The( this ).item().ToString(), null, null, InputType.Num | InputType.Null );

					if ( new_num2 == null ) {
						return null;
					}

					if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
						return null;
					}
					this.check_against = new_num2;
					GlobalFuncs.to_chat( Task13.User, "<span class='info'>Value #2 set to be " + this.check_against + "</span>" );
				} else {
					A2 = choice3;

					if ( !( A2 is Obj_Item_Device_Assembly ) ) {
						return null;
					}

					if ( !( A2.accessible_values != null ) || !( A2.accessible_values.len != 0 ) ) {
						GlobalFuncs.to_chat( Task13.User, new Txt( "<span class='info'>" ).The( A2 ).item().str( " has no accessible values." ).ToString() );
						return null;
					}
					new_value2 = Interface13.Input( Task13.User, new Txt( "Select which of " ).the( A2 ).item().str( "'s values is used as " ).the( this ).item().str( "'s value #2." ).ToString(), new Txt().The( this ).item().ToString(), null, A2.accessible_values, InputType.Null | InputType.Any );

					if ( new_value2 == null ) {
						return null;
					}

					if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
						return null;
					}
					new_values_params2 = A2.accessible_values[new_value2];
					L2 = String13.ParseUrlParams( new_values_params2 );

					if ( L2[2] != "number" ) {
						GlobalFuncs.to_chat( Task13.User, new Txt( "<span class='info'>Only numbers may be used in " ).the( this ).item().str( ".</span>" ).ToString() );
						return null;
					}

					if ( !( this.device_pool.Find( choice3 ) != 0 ) ) {
						return null;
					}
					this.check_against = choice3;
					this.checked_value_2 = new_value2;
					GlobalFuncs.to_chat( Task13.User, "<span class='info'>Value #2 set to be " + this.check_against + " - " + this.checked_value_2 + "</span>" );
				}
			}

			if ( Lang13.Bool( href_list["change_pulse_if_true"] ) ) {
				choice4 = Interface13.Input( Task13.User, "Select an assembly that will be pulsed if the condition is true.", new Txt().The( this ).item().ToString(), null, this.device_pool + "Nothing", InputType.Null | InputType.Any );

				if ( !Lang13.Bool( choice4 ) ) {
					return null;
				}

				if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
					return null;
				}

				if ( choice4 == "Nothing" ) {
					this.pulse_if_true = null;
				} else {
					
					if ( !( this.device_pool.Find( choice4 ) != 0 ) ) {
						return null;
					}
					this.pulse_if_true = choice4;
				}
				GlobalFuncs.to_chat( Task13.User, "<span class='info'>If the condition is true, " + ( Lang13.Bool( this.pulse_if_true ) ? this.pulse_if_true : ((dynamic)( "nothing" )) ) + " will be pulsed.</span>" );
			}

			if ( Lang13.Bool( href_list["change_pulse_if_false"] ) ) {
				choice5 = Interface13.Input( Task13.User, "Select an assembly that will be pulsed if the condition is false.", new Txt().The( this ).item().ToString(), null, this.device_pool + "Nothing", InputType.Null | InputType.Any );

				if ( !Lang13.Bool( choice5 ) ) {
					return null;
				}

				if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
					return null;
				}

				if ( choice5 == "Nothing" ) {
					this.pulse_if_false = null;
				} else {
					
					if ( !( this.device_pool.Find( choice5 ) != 0 ) ) {
						return null;
					}
					this.pulse_if_false = choice5;
				}
				GlobalFuncs.to_chat( Task13.User, "<span class='info'>If the condition is false, " + ( Lang13.Bool( this.pulse_if_false ) ? this.pulse_if_false : ((dynamic)( "nothing" )) ) + " will be pulsed.</span>" );
			}

			if ( Task13.User != null ) {
				this.attack_self( Task13.User );
			}
			return null;
		}

		// Function from file: comparison.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			string dat = null;
			double i = 0;
			Browser popup = null;

			dat = "";
			dat += "CONDITON:<br>";
			dat += new Txt( "<a href='?src=" ).Ref( this ).str( ";change_check_this=1'>" ).item( this.check_this ).str( "</a>" ).ToString();

			if ( !Lang13.Bool( Lang13.IsNumber( this.check_this ) ) ) {
				dat += " (" + this.checked_value_1 + ")";
			}
			dat += new Txt( " is <a href='?src=" ).Ref( this ).str( ";change_check_type=1'>" ).item( this.check_type ).str( "</a> " ).ToString();
			dat += new Txt( "<a href='?src=" ).Ref( this ).str( ";change_check_against=1'>" ).item( this.check_against ).str( "</a>" ).ToString();

			if ( !Lang13.Bool( Lang13.IsNumber( this.check_against ) ) ) {
				dat += " (" + this.checked_value_2 + ")";
			}
			dat += "<BR>";
			dat += new Txt( "IF <b>TRUE</b>: <a href='?src=" ).Ref( this ).str( ";change_pulse_if_true=1'>" ).item( ( Lang13.Bool( this.pulse_if_true ) ? "pulse " + this.pulse_if_true : "do nothing" ) ).str( "</a><BR>" ).ToString();
			dat += new Txt( "IF <b>FALSE</b>: <a href='?src=" ).Ref( this ).str( ";change_pulse_if_false=1'>" ).item( ( Lang13.Bool( this.pulse_if_false ) ? "pulse " + this.pulse_if_false : "do nothing" ) ).str( "</a><BR><hr>" ).ToString();
			dat += "Connected devices: ";

			if ( this.device_pool.len != 0 ) {
				
				foreach (dynamic _a in Lang13.IterateRange( 1, this.device_pool.len )) {
					i = _a;
					
					dat += "" + this.device_pool[i];

					if ( i != this.device_pool.len ) {
						dat += ", ";
					}
				}
			}
			popup = new Browser( user, "circuit2", "" + this, 500, 300, this );
			popup.set_content( dat );
			popup.open();
			GlobalFuncs.onclose( user, "circuit2" );
			return null;
		}

		// Function from file: comparison.dm
		public override bool activate(  ) {
			dynamic value_1 = null;
			dynamic value_2 = null;
			bool result = false;

			
			if ( !base.activate() ) {
				return false;
			}
			value_1 = 0;

			if ( Lang13.Bool( Lang13.IsNumber( this.check_this ) ) ) {
				value_1 = this.check_this;
			} else if ( Lang13.Bool( this.check_this ) ) {
				value_1 = this.check_this.get_value( this.checked_value_1 );
			}
			value_2 = 0;

			if ( Lang13.Bool( Lang13.IsNumber( this.check_against ) ) ) {
				value_2 = this.check_against;
			} else if ( Lang13.Bool( this.check_this ) ) {
				value_2 = this.check_this.get_value( this.checked_value_2 );
			}
			result = false;

			dynamic _a = this.check_type; // Was a switch-case, sorry for the mess.
			if ( _a=="EQUAL TO" ) {
				result = value_1 == value_2;
			} else if ( _a=="LESS THAN" ) {
				result = Convert.ToDouble( value_1 ) < Convert.ToDouble( value_2 );
			} else if ( _a=="MORE THAN" ) {
				result = Convert.ToDouble( value_1 ) > Convert.ToDouble( value_2 );
			} else if ( _a=="LESS THAN OR EQUAL TO" ) {
				result = Convert.ToDouble( value_1 ) <= Convert.ToDouble( value_2 );
			} else if ( _a=="MORE THAN OR EQUAL TO" ) {
				result = Convert.ToDouble( value_1 ) >= Convert.ToDouble( value_2 );
			} else if ( _a=="NOT EQUAL TO" ) {
				result = value_1 != value_2;
			}

			switch ((bool)( result )) {
				case 0:
					
					if ( Lang13.Bool( this.pulse_if_false ) ) {
						((Obj_Item_Device_Assembly)this.pulse_if_false).pulsed();
					}
					break;
				default:
					
					if ( Lang13.Bool( this.pulse_if_true ) ) {
						((Obj_Item_Device_Assembly)this.pulse_if_true).pulsed();
					}
					break;
			}
			return false;
		}

	}

}