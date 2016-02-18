// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Job_Mining : Job {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.title = "Shaft Miner";
			this.flag = 256;
			this.department_head = new ByTable(new object [] { "Head of Personnel" });
			this.department_flag = 4;
			this.faction = "Station";
			this.total_positions = 3;
			this.spawn_positions = 3;
			this.supervisors = "the quartermaster and the head of personnel";
			this.selection_color = "#dcba97";
			this.outfit = typeof(Outfit_Job_Miner);
			this.access = new ByTable(new object [] { 12, 50, 31, 34, 41, 48, 54, 64 });
			this.minimal_access = new ByTable(new object [] { 48, 54, 50, 64 });
		}

	}

}