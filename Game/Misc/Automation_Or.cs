// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Automation_Or : Automation {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "OR statement";
			this.returntype = true;
			this.valid_child_returntypes = new ByTable(new object [] { 1 });
		}

		public Automation_Or ( Obj_Machinery_Computer_GeneralAirControl_AtmosAutomation aa = null ) : base( aa ) {
			
		}

		// Function from file: statements.dm
		public override string GetText(  ) {
			string _default = null;

			Automation stmt = null;

			_default = new Txt( "OR (<a href=\"?src=" ).Ref( this ).str( ";add=1\">Add</a>)" ).ToString();

			if ( this.children.len > 0 ) {
				_default += "<ul>";

				foreach (dynamic _a in Lang13.Enumerate( this.children, typeof(Automation) )) {
					stmt = _a;
					
					_default += new Txt( "<li>\n						[<a href=\"?src=" ).Ref( this ).str( ";reset=" ).Ref( stmt ).str( "\">Reset</a> |\n						<a href=\"?src=" ).Ref( this ).str( ";remove=" ).Ref( stmt ).str( "\">&times;</a>]\n						" ).item( stmt.GetText() ).str( "\n					</li>" ).ToString();
				}
				_default += "</ul>";
			} else {
				_default += "<blockquote><i>No statements to evaluate.</i></blockquote>";
			}
			return _default;
		}

		// Function from file: statements.dm
		public override dynamic Evaluate(  ) {
			Automation stmt = null;

			
			if ( !( this.children.len != 0 ) ) {
				return 0;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.children, typeof(Automation) )) {
				stmt = _a;
				

				if ( Lang13.Bool( stmt.Evaluate() ) ) {
					return 1;
				}
			}
			return 0;
		}

	}

}