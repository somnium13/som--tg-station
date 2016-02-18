// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_MassSpectrometer : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Mass-Spectrometer";
			this.desc = "A device for analyzing chemicals in the blood.";
			this.id = "mass_spectrometer";
			this.req_tech = new ByTable().Set( "biotech", 2 ).Set( "magnets", 2 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$metal", 30 ).Set( "$glass", 20 );
			this.reliability = 76;
			this.build_path = typeof(Obj_Item_Device_MassSpectrometer);
			this.category = new ByTable(new object [] { "Medical Designs" });
		}

	}

}