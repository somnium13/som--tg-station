// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Power_Changeling_DigitalCamoflague : Power_Changeling {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Digital Camoflauge";
			this.desc = "We evolve the ability to distort our form and proprtions, defeating common altgorthms used to detect lifeforms on cameras.";
			this.helptext = "We cannot be tracked by camera while using this skill.  However, humans looking at us will find us.. uncanny.  We must constantly expend chemicals to maintain our form like this.";
			this.genomecost = 3;
			this.allowduringlesserform = true;
			this.verbpath = typeof(Mob).GetMethod( "changeling_digitalcamo" );
		}

	}

}