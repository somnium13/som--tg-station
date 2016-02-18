// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Construction : Game_Data {

		public ByTable steps = null;
		public Game_Data holder = null;
		public string result = null;
		public dynamic steps_desc = null;

		// Function from file: construction_datum.dm
		public Construction ( Game_Data atom = null ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.holder = atom;

			if ( !( this.holder != null ) ) {
				GlobalFuncs.qdel( this );
			}
			this.set_desc( this.steps.len );
			return;
		}

		// Function from file: construction_datum.dm
		public void set_desc( int? index = null ) {
			dynamic step = null;

			step = this.steps[index];
			((dynamic)this.holder).desc = step["desc"];
			return;
		}

		// Function from file: construction_datum.dm
		public virtual void spawn_result(  ) {
			
			if ( Lang13.Bool( this.result ) ) {
				Lang13.Call( this.result, GlobalFuncs.get_turf( this.holder ) );
				GlobalFuncs.qdel( this.holder );
			}
			return;
		}

		// Function from file: construction_datum.dm
		public bool check_all_steps( dynamic used_atom = null, dynamic user = null ) {
			int? i = null;
			dynamic L = null;

			i = null;
			i = 1;

			while (( i ??0) <= this.steps.len) {
				L = this.steps[i];

				if ( Lang13.Bool( L["key"].IsInstanceOfType( used_atom ) ) ) {
					
					if ( this.custom_action( i, used_atom, user ) ) {
						this.steps[i] = null;
						GlobalFuncs.listclearnulls( this.steps );

						if ( !( this.steps.len != 0 ) ) {
							this.spawn_result();
						}
						return true;
					}
				}
				i++;
			}
			return false;
		}

		// Function from file: construction_datum.dm
		public virtual bool custom_action( int? index = null, dynamic diff = null, dynamic used_atom = null, dynamic user = null ) {
			return true;
		}

		// Function from file: construction_datum.dm
		public virtual int is_right_key( dynamic used_atom = null ) {
			dynamic L = null;

			L = this.steps[this.steps.len];

			if ( Lang13.Bool( L["key"].IsInstanceOfType( used_atom ) ) ) {
				return this.steps.len;
			}
			return 0;
		}

		// Function from file: construction_datum.dm
		public virtual bool check_step( dynamic used_atom = null, dynamic user = null ) {
			int? valid_step = null;

			valid_step = this.is_right_key( used_atom );

			if ( Lang13.Bool( valid_step ) ) {
				
				if ( this.custom_action( valid_step, used_atom, user ) ) {
					this.next_step();
					return true;
				}
			}
			return false;
		}

		// Function from file: construction_datum.dm
		public virtual bool action( dynamic used_atom = null, dynamic user = null ) {
			return false;
		}

		// Function from file: construction_datum.dm
		public void next_step(  ) {
			this.steps.len--;

			if ( !( this.steps.len != 0 ) ) {
				this.spawn_result();
			} else {
				this.set_desc( this.steps.len );
			}
			return;
		}

	}

}