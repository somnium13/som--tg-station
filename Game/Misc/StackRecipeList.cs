// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class StackRecipeList : Game_Data {

		public string title = "ERROR";
		public ByTable recipes = null;
		public int? req_amount = 1;

		// Function from file: stack.dm
		public StackRecipeList ( string title = null, ByTable recipes = null, int? req_amount = null ) {
			req_amount = req_amount ?? 1;

			this.title = title;
			this.recipes = recipes;
			this.req_amount = req_amount;
			return;
		}

	}

}