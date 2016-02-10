// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Migration : Game_Data {

		public string name = "";
		public string package = "";
		public string dbms = "";
		public int? id = 1;
		public dynamic MC = null;

		// Function from file: migration.dm
		public Migration ( dynamic mc = null ) {
			this.MC = mc;
			return;
		}

		// Function from file: vgstation13.dme
		public virtual dynamic hasColumn( string tableName = null, string columnName = null ) {
			return null;
		}

		// Function from file: migration.dm
		public virtual dynamic hasTable( string tableName = null ) {
			return null;
		}

		// Function from file: migration.dm
		public virtual bool? execute( string sql = null ) {
			return null;
		}

		// Function from file: migration.dm
		public virtual dynamic hasResult( string sql = null ) {
			return null;
		}

		// Function from file: migration.dm
		public virtual dynamic query( string sql = null ) {
			return null;
		}

		// Function from file: migration.dm
		public virtual bool? down(  ) {
			return GlobalVars.TRUE;
		}

		// Function from file: migration.dm
		public virtual bool? up(  ) {
			return GlobalVars.TRUE;
		}

	}

}