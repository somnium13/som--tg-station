// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class WritingStyle_Pen_NanoPaper : WritingStyle_Pen {

		// Function from file: pen.dm
		public WritingStyle_Pen_NanoPaper (  ) {
			this.addExpression( ":" + GlobalFuncs.REG_BBTAG( "video" ) + "(" + "[^\\[]+" + ")" + GlobalFuncs.REG_BBTAG( "/video" ) + ":gi", typeof(SpeechFilterAction_Bbcode_Video), new ByTable() );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}