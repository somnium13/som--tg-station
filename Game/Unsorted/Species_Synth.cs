// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Species_Synth : Species {

		public ByTable initial_specflags = new ByTable(new object [] { 16384, 256, 4096 });
		public double? disguise_fail_health = 75;
		public Image damaged_synth_flesh = null;
		public dynamic fake_species = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Synth";
			this.id = "synth";
			this.say_mod = "beep boops";
			this.sexes = false;
			this.specflags = new ByTable(new object [] { 16384, 256, 4096 });
			this.safe_oxygen_min = 0;
			this.safe_toxins_max = 0;
			this.safe_co2_max = 0;
			this.SA_para_min = 0;
			this.SA_sleep_min = 0;
			this.dangerous_existence = true;
			this.blacklisted = true;
			this.need_nutrition = false;
			this.meat = null;
		}

		// Function from file: species_types.dm
		public override dynamic handle_speech( dynamic message = null, Mob_Living_Carbon_Human H = null ) {
			H.updatehealth();

			if ( Convert.ToDouble( H.health ) > ( this.disguise_fail_health ??0) ) {
				
				if ( Lang13.Bool( this.fake_species ) ) {
					return this.fake_species.handle_speech( message, H );
				} else {
					return base.handle_speech( (object)(message), H );
				}
			} else {
				return base.handle_speech( (object)(message), H );
			}
			return null;
		}

		// Function from file: species_types.dm
		public override dynamic get_spans(  ) {
			
			if ( Lang13.Bool( this.fake_species ) ) {
				return this.fake_species.get_spans();
			}
			return new ByTable();
		}

		// Function from file: species_types.dm
		public override void handle_mutant_bodyparts( dynamic H = null, string forced_colour = null ) {
			((Mob_Living)H).updatehealth();

			if ( Convert.ToDouble( H.health ) > ( this.disguise_fail_health ??0) ) {
				
				if ( Lang13.Bool( this.fake_species ) ) {
					((Species)this.fake_species).handle_body( H );
				}
			}
			return;
		}

		// Function from file: species_types.dm
		public override void handle_body( dynamic H = null ) {
			((Mob_Living)H).updatehealth();

			if ( Convert.ToDouble( H.health ) > ( this.disguise_fail_health ??0) ) {
				
				if ( Lang13.Bool( this.fake_species ) ) {
					((Species)this.fake_species).handle_body( H );
				}
			}
			return;
		}

		// Function from file: species_types.dm
		public override void handle_hair( dynamic H = null, string forced_colour = null ) {
			((Mob_Living)H).updatehealth();

			if ( Convert.ToDouble( H.health ) > ( this.disguise_fail_health ??0) ) {
				
				if ( Lang13.Bool( this.fake_species ) ) {
					((Species)this.fake_species).handle_hair( H, forced_colour );
				}
			}
			return;
		}

		// Function from file: species_types.dm
		public override void update_color( dynamic H = null, string forced_colour = null ) {
			((Mob_Living)H).updatehealth();

			if ( Convert.ToDouble( H.health ) > ( this.disguise_fail_health ??0) ) {
				
				if ( Lang13.Bool( this.fake_species ) ) {
					((Species)this.fake_species).update_color( H, forced_colour );
				}
			}
			return;
		}

		// Function from file: species_types.dm
		public override dynamic update_base_icon_state( Mob_Living_Carbon H = null ) {
			dynamic _default = null;

			H.updatehealth();

			if ( Convert.ToDouble( H.health ) > ( this.disguise_fail_health ??0) ) {
				
				if ( Lang13.Bool( this.fake_species ) ) {
					return this.fake_species.update_base_icon_state( H );
				} else {
					return base.update_base_icon_state( H );
				}
			} else {
				_default = base.update_base_icon_state( H );
			}
			return _default;
		}

		// Function from file: species_types.dm
		public override bool apply_damage( dynamic damage = null, dynamic damagetype = null, dynamic def_zone = null, double? blocked = null, Mob_Living_Carbon_Human H = null ) {
			damagetype = damagetype ?? "brute";

			bool _default = false;

			_default = base.apply_damage( (object)(damage), (object)(damagetype), (object)(def_zone), blocked, H );
			this.handle_disguise( H );
			return _default;
		}

		// Function from file: species_types.dm
		public void handle_disguise( dynamic H = null ) {
			int? add_overlay = null;
			Image I = null;

			
			if ( Lang13.Bool( H ) && Lang13.Bool( this.fake_species ) ) {
				((Mob_Living)H).updatehealth();
				add_overlay = GlobalVars.FALSE;

				if ( Convert.ToDouble( H.health ) < ( this.disguise_fail_health ??0) ) {
					H.underwear = "";
					H.undershirt = "";
					H.socks = "";
					add_overlay = GlobalVars.TRUE;
				} else {
					H.overlays -= this.damaged_synth_flesh;

					if ( H.overlays_standing[27] == this.damaged_synth_flesh ) {
						H.overlays_standing[27] = null;
					}
				}
				((Mob)H).regenerate_icons();

				if ( Lang13.Bool( add_overlay ) ) {
					((Mob_Living_Carbon)H).remove_overlay( 27 );
					I = new Image( null, null, null, -27 );
					I.appearance = this.damaged_synth_flesh.appearance;

					if ( this.specflags.Contains( 1 ) ) {
						I.color = "#" + H.dna.features["mcolor"];
					}
					this.damaged_synth_flesh = I;
					H.overlays_standing[27] = this.damaged_synth_flesh;
					((Mob_Living_Carbon)H).apply_overlay( 27 );
				}
			}
			return;
		}

		// Function from file: species_types.dm
		public void build_disguise( dynamic H = null ) {
			dynamic _base = null;
			Icon base_flesh = null;
			Icon damage = null;

			_base = "";

			if ( Lang13.Bool( this.fake_species ) ) {
				_base = this.fake_species.update_base_icon_state( H );

				if ( Lang13.Bool( GlobalVars.synth_flesh_disguises[_base] ) ) {
					this.damaged_synth_flesh = GlobalVars.synth_flesh_disguises[_base];
				} else {
					base_flesh = new Icon( H.icon, "" + _base + "_s" );
					damage = new Icon( H.icon, "synthflesh_damage" );
					base_flesh.Blend( damage, 2 );
					this.damaged_synth_flesh = new Image( base_flesh, null, null, -27 );
					GlobalVars.synth_flesh_disguises[_base] = this.damaged_synth_flesh;
				}
			} else {
				this.damaged_synth_flesh = null;
			}
			return;
		}

		// Function from file: species_types.dm
		public void assume_disguise( Species S = null, dynamic H = null ) {
			
			if ( S != null && !Lang13.Bool( ((dynamic)this.type).IsInstanceOfType( S ) ) ) {
				this.name = S.name;
				this.say_mod = S.say_mod;
				this.sexes = S.sexes;
				this.specflags = this.initial_specflags.Copy();
				this.specflags.Add( S.specflags );
				this.attack_verb = S.attack_verb;
				this.attack_sound = S.attack_sound;
				this.miss_sound = S.miss_sound;
				this.meat = S.meat;
				this.mutant_bodyparts = S.mutant_bodyparts.Copy();
				this.default_features = S.default_features.Copy();
				this.nojumpsuit = S.nojumpsuit;
				this.no_equip = S.no_equip.Copy();
				this.fake_species = Lang13.Call( S.type );
			} else {
				this.name = Lang13.Initial( this, "name" );
				this.say_mod = Lang13.Initial( this, "say_mod" );
				this.specflags = this.initial_specflags.Copy();
				this.attack_verb = Lang13.Initial( this, "attack_verb" );
				this.attack_sound = Lang13.Initial( this, "attack_sound" );
				this.miss_sound = Lang13.Initial( this, "miss_sound" );
				this.mutant_bodyparts = new ByTable();
				this.default_features = new ByTable();
				this.nojumpsuit = Lang13.Initial( this, "nojumpsuit" );
				this.no_equip = new ByTable();
				GlobalFuncs.qdel( this.fake_species );
				this.fake_species = null;
				this.meat = Lang13.Initial( this, "meat" );
			}
			this.build_disguise( H );
			this.handle_disguise( H );
			return;
		}

		// Function from file: species_types.dm
		public override bool handle_chemicals( dynamic chem = null, Mob_Living H = null ) {
			
			if ( chem.id == "synthflesh" ) {
				((Reagent)chem).reaction_mob( H, GlobalVars.TOUCH, 2, false );
				this.handle_disguise( H );
				H.reagents.remove_reagent( chem.id, 0.4 );
				return true;
			}
			return false;
		}

		// Function from file: species_types.dm
		public override void admin_set_species( dynamic H = null, Species old_species = null ) {
			this.assume_disguise( old_species, H );
			return;
		}

	}

}