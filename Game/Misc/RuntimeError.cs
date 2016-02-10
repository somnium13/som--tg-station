// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RuntimeError : Game_Data {

		public string name = null;
		public string message = null;
		public Stack stack = null;

		// Function from file: Errors.dm
		[VerbInfo( name: "ToString" )]
		public string f_ToString(  ) {
			string _default = null;

			dynamic stmt = null;

			_default = "" + this.name + ": " + this.message;

			if ( !Lang13.Bool( this.stack.Top() ) ) {
				return _default;
			}
			_default += "\nStack:";

			while (Lang13.Bool( this.stack.Top() )) {
				stmt = this.stack.Pop();
				_default += "\n	 " + stmt.func_name + "()";
			}
			return _default;
		}

	}

}