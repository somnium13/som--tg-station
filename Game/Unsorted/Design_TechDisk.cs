// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_TechDisk : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Technology Data Storage Disk";
			this.desc = "Produce additional disks for storing technology data.";
			this.id = "tech_disk";
			this.req_tech = new ByTable().Set( "programming", 1 );
			this.build_type = 6;
			this.materials = new ByTable().Set( "$metal", 30 ).Set( "$glass", 10 );
			this.build_path = typeof(Obj_Item_Weapon_Disk_TechDisk);
			this.category = new ByTable(new object [] { "Electronics" });
		}

	}

}