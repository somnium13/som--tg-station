// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Wound_Cut_Flesh : Wound_Cut {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.max_bleeding_stage = 3;
			this.stages = new ByTable().Set( "ugly ripped flesh wound", 35 ).Set( "ugly flesh wound", 30 ).Set( "flesh wound", 25 ).Set( "blood soaked clot", 15 ).Set( "large scab", 5 ).Set( "fresh skin", 0 );
		}

		public Wound_Cut_Flesh ( int damage = 0 ) : base( damage ) {
			
		}

	}

}