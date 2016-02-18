// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Job_Detective : Job {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.title = "Detective";
			this.flag = 8;
			this.department_head = new ByTable(new object [] { "Head of Security" });
			this.department_flag = 1;
			this.faction = "Station";
			this.total_positions = 1;
			this.spawn_positions = 1;
			this.supervisors = "the head of security";
			this.selection_color = "#ffeeee";
			this.minimal_player_age = 7;
			this.outfit = typeof(Outfit_Job_Detective);
			this.access = new ByTable(new object [] { 63, 4, 6, 12, 42, 66, 2, 1 });
			this.minimal_access = new ByTable(new object [] { 63, 4, 6, 12, 42, 66 });
		}

	}

}