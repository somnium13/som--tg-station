// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Blood : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.data = new ByTable()
				.Set( "donor", null )
				.Set( "viruses", null )
				.Set( "blood_DNA", null )
				.Set( "blood_type", null )
				.Set( "resistances", null )
				.Set( "trace_chem", null )
				.Set( "mind", null )
				.Set( "ckey", null )
				.Set( "gender", null )
				.Set( "real_name", null )
				.Set( "cloneable", null )
				.Set( "factions", null )
			;
			this.name = "Blood";
			this.id = "blood";
			this.color = "#C80000";
		}

		// Function from file: other_reagents.dm
		public override void reaction_turf( dynamic T = null, double? volume = null ) {
			dynamic blood_prop = null;
			Disease D = null;
			dynamic newVirus = null;
			dynamic blood_prop2 = null;
			Disease D2 = null;
			dynamic newVirus2 = null;
			dynamic blood_prop3 = null;
			Disease D3 = null;
			dynamic newVirus3 = null;

			
			if ( !( T is Tile_Simulated ) ) {
				return;
			}

			if ( ( volume ??0) < 3 ) {
				return;
			}

			if ( !Lang13.Bool( this.data["donor"] ) || this.data["donor"] is Mob_Living_Carbon_Human ) {
				blood_prop = Lang13.FindIn( typeof(Obj_Effect_Decal_Cleanable_Blood), T );

				if ( !Lang13.Bool( blood_prop ) ) {
					blood_prop = new Obj_Effect_Decal_Cleanable_Blood( T );
					blood_prop.blood_DNA[this.data["blood_DNA"]] = this.data["blood_type"];
				}

				foreach (dynamic _a in Lang13.Enumerate( this.data["viruses"], typeof(Disease) )) {
					D = _a;
					
					newVirus = D.Copy( true );
					blood_prop.viruses += newVirus;
					newVirus.holder = blood_prop;
				}
			} else if ( this.data["donor"] is Mob_Living_Carbon_Monkey ) {
				blood_prop2 = Lang13.FindIn( typeof(Obj_Effect_Decal_Cleanable_Blood), T );

				if ( !Lang13.Bool( blood_prop2 ) ) {
					blood_prop2 = new Obj_Effect_Decal_Cleanable_Blood( T );
					blood_prop2.blood_DNA["Non-Human DNA"] = "A+";
				}

				foreach (dynamic _b in Lang13.Enumerate( this.data["viruses"], typeof(Disease) )) {
					D2 = _b;
					
					newVirus2 = D2.Copy( true );
					blood_prop2.viruses += newVirus2;
					newVirus2.holder = blood_prop2;
				}
			} else if ( this.data["donor"] is Mob_Living_Carbon_Alien ) {
				blood_prop3 = Lang13.FindIn( typeof(Obj_Effect_Decal_Cleanable_Xenoblood), T );

				if ( !Lang13.Bool( blood_prop3 ) ) {
					blood_prop3 = new Obj_Effect_Decal_Cleanable_Xenoblood( T );
					blood_prop3.blood_DNA["UNKNOWN DNA STRUCTURE"] = "X*";
				}

				foreach (dynamic _c in Lang13.Enumerate( this.data["viruses"], typeof(Disease) )) {
					D3 = _c;
					
					newVirus3 = D3.Copy( true );
					blood_prop3.viruses += newVirus3;
					newVirus3.holder = blood_prop3;
				}
			}
			return;
		}

		// Function from file: other_reagents.dm
		public override bool on_merge( dynamic data = null ) {
			dynamic mix1 = null;
			dynamic mix2 = null;
			ByTable to_mix = null;
			Disease_Advance AD = null;
			Disease_Advance AD2 = null;
			dynamic AD3 = null;
			ByTable preserve = null;
			Disease_Advance D = null;

			
			if ( Lang13.Bool( this.data ) && Lang13.Bool( data ) ) {
				this.data["cloneable"] = 0;

				if ( Lang13.Bool( this.data["viruses"] ) || Lang13.Bool( data["viruses"] ) ) {
					mix1 = this.data["viruses"];
					mix2 = data["viruses"];
					to_mix = new ByTable();

					foreach (dynamic _a in Lang13.Enumerate( mix1, typeof(Disease_Advance) )) {
						AD = _a;
						
						to_mix.Add( AD );
					}

					foreach (dynamic _b in Lang13.Enumerate( mix2, typeof(Disease_Advance) )) {
						AD2 = _b;
						
						to_mix.Add( AD2 );
					}
					AD3 = GlobalFuncs.Advance_Mix( to_mix );

					if ( Lang13.Bool( AD3 ) ) {
						preserve = new ByTable(new object [] { AD3 });

						foreach (dynamic _c in Lang13.Enumerate( this.data["viruses"], typeof(Disease_Advance) )) {
							D = _c;
							
						}
						this.data["viruses"] = preserve;
					}
				}
			}
			return true;
		}

		// Function from file: other_reagents.dm
		public override void on_new( dynamic data = null ) {
			
			if ( data is ByTable ) {
				GlobalFuncs.SetViruses( this, data );
			}
			return;
		}

		// Function from file: other_reagents.dm
		public override double reaction_mob( dynamic M = null, int? method = null, double? reac_volume = null, bool? show_message = null, dynamic touch_protection = null, Mob_Camera_Blob O = null ) {
			method = method ?? GlobalVars.TOUCH;

			Disease D = null;

			
			if ( Lang13.Bool( this.data ) && Lang13.Bool( this.data["viruses"] ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.data["viruses"], typeof(Disease) )) {
					D = _a;
					

					if ( ( D.spread_flags & 1 ) != 0 || ( D.spread_flags & 2 ) != 0 ) {
						continue;
					}

					if ( method == GlobalVars.TOUCH || method == GlobalVars.VAPOR ) {
						((Mob)M).ContractDisease( D );
					} else {
						((Mob)M).ForceContractDisease( D );
					}
				}
			}
			return 0;
		}

	}

}