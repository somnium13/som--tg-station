// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Pacid : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Polytrinic acid";
			this.id = "pacid";
			this.description = "Polytrinic acid is a an extremely corrosive chemical substance.";
			this.reagent_state = 2;
			this.color = "#8E18A9";
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool reaction_obj( dynamic O = null, double volume = 0 ) {
			Obj_Effect_Decal_Cleanable_MoltenItem I = null;
			Obj_Effect_Decal_Cleanable_MoltenItem I2 = null;
			dynamic K = null;

			
			if ( base.reaction_obj( (object)(O), volume ) ) {
				return true;
			}

			if ( Lang13.Bool( O.unacidable ) ) {
				return false;
			}

			if ( O is Obj_Item || O is Obj_Effect_Glowshroom ) {
				I = new Obj_Effect_Decal_Cleanable_MoltenItem( O.loc );
				I.desc = new Txt( "Looks like this was " ).a( O ).item().str( " some time ago." ).ToString();
				((Ent_Static)O).visible_message( new Txt( "<span class='warning'>" ).The( O ).item().str( " melts.</span>" ).ToString() );
				GlobalFuncs.qdel( O );
			} else if ( O is Obj_Effect_Plantsegment ) {
				I2 = new Obj_Effect_Decal_Cleanable_MoltenItem( O.loc );
				I2.desc = "Looks like these were some " + O.name + " some time ago.";
				K = O;
				((Obj_Effect_Plantsegment)K).die_off();
			}
			return false;
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool reaction_mob( dynamic M = null, int? method = null, double volume = 0 ) {
			method = method ?? GlobalVars.TOUCH;

			dynamic H = null;
			dynamic affecting = null;
			dynamic MK = null;
			dynamic H2 = null;
			dynamic affecting2 = null;

			
			if ( base.reaction_mob( (object)(M), method, volume ) ) {
				return true;
			}

			if ( method == GlobalVars.TOUCH ) {
				
				if ( M is Mob_Living_Carbon_Human ) {
					H = M;

					if ( Lang13.Bool( H.wear_mask ) ) {
						
						if ( !Lang13.Bool( H.wear_mask.unacidable ) ) {
							GlobalFuncs.qdel( H.wear_mask );
							H.wear_mask = null;
							((Mob)H).update_inv_wear_mask();
							GlobalFuncs.to_chat( H, "<span class='warning'>Your mask melts away but protects you from the acid!</span>" );
						} else {
							GlobalFuncs.to_chat( H, "<span class='warning'>Your mask protects you from the acid!</span>" );
						}
						return false;
					}

					if ( Lang13.Bool( H.head ) && !( H.head is Obj_Item_Weapon_ReagentContainers_Glass_Bucket ) ) {
						
						if ( Rand13.PercentChance( 15 ) && !Lang13.Bool( H.head.unacidable ) ) {
							GlobalFuncs.qdel( H.head );
							H.head = null;
							((Mob)H).update_inv_head();
							GlobalFuncs.to_chat( H, "<span class='warning'>Your helmet melts away but protects you from the acid</span>" );
						} else {
							GlobalFuncs.to_chat( H, "<span class='warning'>Your helmet protects you from the acid!</span>" );
						}
						return false;
					}

					if ( !Lang13.Bool( H.unacidable ) ) {
						affecting = ((Mob_Living_Carbon_Human)H).get_organ( "head" );

						if ( Lang13.Bool( affecting.take_damage( 15, 0 ) ) ) {
							((Mob_Living)H).UpdateDamageIcon( true );
						}
						((Mob)H).emote( "scream", null, null, true );
					}
				} else if ( M is Mob_Living_Carbon_Monkey ) {
					MK = M;

					if ( Lang13.Bool( MK.wear_mask ) ) {
						
						if ( !Lang13.Bool( MK.wear_mask.unacidable ) ) {
							GlobalFuncs.qdel( MK.wear_mask );
							MK.wear_mask = null;
							((Mob)MK).update_inv_wear_mask();
							GlobalFuncs.to_chat( MK, "<span class='warning'>Your mask melts away but protects you from the acid!</span>" );
						} else {
							GlobalFuncs.to_chat( MK, "<span class='warning'>Your mask protects you from the acid!</span>" );
						}
						return false;
					}

					if ( !Lang13.Bool( MK.unacidable ) ) {
						((Mob_Living)MK).take_organ_damage( Num13.MinInt( 15, ((int)( volume * 4 )) ) );
					}
				}
			} else if ( !Lang13.Bool( M.unacidable ) ) {
				
				if ( M is Mob_Living_Carbon_Human ) {
					H2 = M;
					affecting2 = ((Mob_Living_Carbon_Human)H2).get_organ( "head" );

					if ( Lang13.Bool( affecting2.take_damage( 15, 0 ) ) ) {
						((Mob_Living)H2).UpdateDamageIcon( true );
					}
					((Mob)H2).emote( "scream", null, null, true );
					H2.status_flags |= 16384;
				} else {
					((Mob_Living)M).take_organ_damage( Num13.MinInt( 15, ((int)( volume * 4 )) ) );
				}
			}
			return false;
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			
			if ( base.on_mob_life( M, alien ) ) {
				return true;
			}
			M.adjustToxLoss( 0.5 );
			return false;
		}

		// Function from file: hydroponics_reagents.dm
		public override void on_plant_life( Obj_Machinery_PortableAtmospherics_Hydroponics T = null ) {
			base.on_plant_life( T );
			T.toxins += 20;
			T.weedlevel -= 4;

			if ( T.seed != null && !T.dead ) {
				T.health -= 8;
			}
			return;
		}

	}

}