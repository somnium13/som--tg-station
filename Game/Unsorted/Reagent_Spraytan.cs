// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Spraytan : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Spray Tan";
			this.id = "spraytan";
			this.description = "A substance applied to the skin to darken the skin.";
			this.color = "#FFC080";
			this.metabolization_rate = 4;
			this.overdose_threshold = 11;
		}

		// Function from file: other_reagents.dm
		public override void overdose_process( dynamic M = null ) {
			dynamic N = null;

			this.metabolization_rate = 0.4;

			if ( M is Mob_Living_Carbon_Human ) {
				N = M;

				if ( N.dna.species.id == "human" ) {
					N.skin_tone = "orange";
					N.hair_style = "Spiky";
					N.hair_color = "000";
				}

				if ( N.dna.species.specflags.Contains( 1 ) ) {
					N.dna.features["mcolor"] = "f80";
				}
				((Mob)N).regenerate_icons();

				if ( Rand13.PercentChance( 7 ) ) {
					
					if ( Lang13.Bool( N.w_uniform ) ) {
						((Ent_Static)M).visible_message( Rand13.Pick(new object [] { "<b>" + M + "</b>'s collar pops up without warning.</span>", "<b>" + M + "</b> flexes their arms." }) );
					} else {
						((Ent_Static)M).visible_message( "<b>" + M + "</b> flexes their arms." );
					}
				}
			}

			if ( Rand13.PercentChance( 10 ) ) {
				((Ent_Dynamic)M).say( Rand13.Pick(new object [] { "Check these sweet biceps bro!", "Deal with it.", "CHUG! CHUG! CHUG! CHUG!", "Winning!", "NERDS!", "My name is John and I hate every single one of you." }) );
			}
			base.overdose_process( (object)(M) );
			return;
		}

		// Function from file: other_reagents.dm
		public override double reaction_mob( dynamic M = null, int? method = null, double? reac_volume = null, bool? show_message = null, dynamic touch_protection = null, Mob_Camera_Blob O = null ) {
			method = method ?? GlobalVars.TOUCH;
			show_message = show_message ?? true;

			dynamic N = null;
			string newcolor = null;
			int? len = null;
			int? i = null;
			int ascii = 0;

			
			if ( M is Mob_Living_Carbon_Human ) {
				
				if ( method == GlobalVars.PATCH || method == GlobalVars.VAPOR ) {
					N = M;

					if ( N.dna.species.id == "human" ) {
						
						dynamic _a = N.skin_tone; // Was a switch-case, sorry for the mess.
						if ( _a=="african1" ) {
							N.skin_tone = "african2";
						} else if ( _a=="indian" ) {
							N.skin_tone = "african1";
						} else if ( _a=="arab" ) {
							N.skin_tone = "indian";
						} else if ( _a=="asian2" ) {
							N.skin_tone = "arab";
						} else if ( _a=="asian1" ) {
							N.skin_tone = "asian2";
						} else if ( _a=="mediterranean" ) {
							N.skin_tone = "african1";
						} else if ( _a=="latino" ) {
							N.skin_tone = "mediterranean";
						} else if ( _a=="caucasian3" ) {
							N.skin_tone = "mediterranean";
						} else if ( _a=="caucasian2" ) {
							N.skin_tone = Rand13.Pick(new object [] { "caucasian3", "latino" });
						} else if ( _a=="caucasian1" ) {
							N.skin_tone = "caucasian2";
						} else if ( _a=="albino" ) {
							N.skin_tone = "caucasian1";
						}
					}

					if ( N.dna.species.specflags.Contains( 1 ) ) {
						newcolor = "";
						len = Lang13.Length( N.dna.features["mcolor"] );
						i = null;
						i = 1;

						while (( i ??0) <= ( len ??0)) {
							ascii = String13.GetCharCode( N.dna.features["mcolor"], i );

							dynamic _b = ascii; // Was a switch-case, sorry for the mess.
							if ( 49<=_b&&_b<=57 ) {
								newcolor += String13.GetCharFromCode( ascii - 1 );
							} else if ( 98<=_b&&_b<=102 ) {
								newcolor += String13.GetCharFromCode( ascii - 1 );
							} else if ( 66<=_b&&_b<=70 ) {
								newcolor += String13.GetCharFromCode( ascii + 31 );
							} else if ( _b==48 ) {
								newcolor += "0";
							} else if ( _b==97 ) {
								newcolor += "9";
							} else if ( _b==65 ) {
								newcolor += "9";
							} else {
								break;
							}
							i += 1;
						}

						if ( Convert.ToDouble( GlobalFuncs.ReadHSV( newcolor )[3] ) >= Convert.ToDouble( GlobalFuncs.ReadHSV( "#7F7F7F" )[3] ) ) {
							N.dna.features["mcolor"] = newcolor;
						}
					}
					((Mob)N).regenerate_icons();
				}

				if ( method == GlobalVars.INGEST ) {
					
					if ( show_message == true ) {
						M.WriteMsg( "<span class='notice'>That tasted horrible.</span>" );
					}
					((Mob)M).AdjustStunned( 2 );
					((Mob)M).AdjustWeakened( 2 );
				}
			}
			base.reaction_mob( (object)(M), method, reac_volume, show_message, (object)(touch_protection), O );
			return 0;
		}

	}

}