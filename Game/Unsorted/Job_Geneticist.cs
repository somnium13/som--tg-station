// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Job_Geneticist : Job {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.title = "Geneticist";
			this.flag = 32;
			this.department_head = new ByTable(new object [] { "Chief Medical Officer", "Research Director" });
			this.department_flag = 2;
			this.faction = "Station";
			this.total_positions = 2;
			this.spawn_positions = 2;
			this.supervisors = "the chief medical officer and research director";
			this.selection_color = "#ffeef0";
			this.outfit = typeof(Outfit_Job_Geneticist);
			this.access = new ByTable(new object [] { 5, 6, 33, 39, 9, 47, 55, 29, 64, 23 });
			this.minimal_access = new ByTable(new object [] { 5, 6, 9, 47 });
		}

	}

}