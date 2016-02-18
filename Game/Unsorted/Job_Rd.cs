// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Job_Rd : Job {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.title = "Research Director";
			this.flag = 1;
			this.department_head = new ByTable(new object [] { "Captain" });
			this.department_flag = 2;
			this.faction = "Station";
			this.total_positions = 1;
			this.spawn_positions = 1;
			this.supervisors = "the captain";
			this.selection_color = "#ffddff";
			this.req_admin_notify = true;
			this.minimal_player_age = 7;
			this.outfit = typeof(Outfit_Job_Rd);
			this.access = new ByTable(new object [] { 30, 19, 7, 9, 6, 8, 17, 63, 47, 29, 55, 16, 59, 60, 62, 64, 23, 65 });
			this.minimal_access = new ByTable(new object [] { 30, 19, 7, 9, 6, 8, 17, 63, 47, 29, 55, 16, 59, 60, 62, 64, 23, 65 });
		}

	}

}