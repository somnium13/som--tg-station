// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SpeechFilterAction_Bbcode_Video : SpeechFilterAction_Bbcode {

		public SpeechFilterAction_Bbcode_Video ( dynamic orig = null, dynamic args = null ) : base( (object)(orig), (object)(args) ) {
			
		}

		// Function from file: pen.dm
		public override string Run( string text = null, Mob user = null, dynamic P = null ) {
			string rtxt = null;

			this.expr.index = 1;

			while (Lang13.Bool( this.expr.FindNext( text ) )) {
				GlobalFuncs.message_admins( "" + GlobalFuncs.key_name_admin( user ) + " added a video (" + String13.HtmlEncode( this.expr.GroupText( 1 ) ) + ") to " + P + " at " + GlobalFuncs.formatJumpTo( GlobalFuncs.get_turf( P ) ) );
				rtxt = "<embed src=\"" + String13.HtmlEncode( this.expr.GroupText( 1 ) ) + "\" width=\"420\" height=\"344\" type=\"x-ms-wmv\" volume=\"85\" autoStart=\"0\" autoplay=\"true\" />";
				text = String13.SubStr( text, 1, Convert.ToInt32( this.expr.match ) ) + rtxt + String13.SubStr( text, Convert.ToInt32( this.expr.index ), 0 );
				this.expr.index = this.expr.match + Lang13.Length( rtxt );
			}
			return text;
		}

	}

}