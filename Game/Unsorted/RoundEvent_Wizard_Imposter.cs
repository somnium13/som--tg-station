// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RoundEvent_Wizard_Imposter : RoundEvent_Wizard {

		// Function from file: imposter.dm
		public override bool start(  ) {
			Mind M = null;
			dynamic W = null;
			ByTable candidates = null;
			dynamic C = null;
			Mob_Living_Carbon_Human I = null;
			Objective_Protect protect_objective = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.ticker.mode.wizards, typeof(Mind) )) {
				M = _a;
				

				if ( !( M.current is Mob_Living_Carbon_Human ) ) {
					continue;
				}
				W = M.current;
				candidates = GlobalFuncs.get_candidates( "wizard" );

				if ( !( candidates != null ) ) {
					return false;
				}
				C = Rand13.PickFromTable( candidates );
				GlobalFuncs.PoolOrNew( typeof(Obj_Effect_ParticleEffect_Smoke), W.loc );
				I = new Mob_Living_Carbon_Human( W.loc );
				new ByTable().Set( 1, I ).Set( "transfer_SE", 1 ).Apply( Lang13.BindFunc( W.dna, "transfer_identity" ) );
				I.real_name = I.dna.real_name;
				I.name = I.dna.real_name;
				I.updateappearance( null, true );
				I.domutcheck();

				if ( Lang13.Bool( W.ears ) ) {
					I.equip_to_slot_or_del( Lang13.Call( W.ears.type ), 8 );
				}

				if ( Lang13.Bool( W.w_uniform ) ) {
					I.equip_to_slot_or_del( Lang13.Call( W.w_uniform.type ), 14 );
				}

				if ( Lang13.Bool( W.shoes ) ) {
					I.equip_to_slot_or_del( Lang13.Call( W.shoes.type ), 12 );
				}

				if ( Lang13.Bool( W.wear_suit ) ) {
					I.equip_to_slot_or_del( Lang13.Call( W.wear_suit.type ), 13 );
				}

				if ( Lang13.Bool( W.head ) ) {
					I.equip_to_slot_or_del( Lang13.Call( W.head.type ), 11 );
				}

				if ( Lang13.Bool( W.back ) ) {
					I.equip_to_slot_or_del( Lang13.Call( W.back.type ), 1 );
				}
				I.key = C.key;
				I.mind.AddSpell( new Obj_Effect_ProcHolder_Spell_Targeted_AreaTeleport_Teleport( null ) );
				I.mind.AddSpell( new Obj_Effect_ProcHolder_Spell_Targeted_TurfTeleport_Blink( null ) );
				I.mind.AddSpell( new Obj_Effect_ProcHolder_Spell_Targeted_EtherealJaunt( null ) );
				GlobalVars.ticker.mode.apprentices.Add( I.mind );
				I.mind.special_role = "imposter";
				protect_objective = new Objective_Protect();
				protect_objective.owner = I.mind;
				protect_objective.target = W.mind;
				protect_objective.explanation_text = "Protect " + W.real_name + ", the wizard.";
				I.mind.objectives.Add( protect_objective );
				((GameMode)GlobalVars.ticker.mode).update_wiz_icons_added( I.mind );
				I.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <font color='red'>Is an imposter!</font>" );
				I.WriteMsg( "<B>You are an imposter! Trick and confuse the crew to misdirect malice from your handsome original!</B>" );
				I.WriteMsg( new Sound( "sound/effects/magic.ogg" ) );
			}
			return false;
		}

	}

}