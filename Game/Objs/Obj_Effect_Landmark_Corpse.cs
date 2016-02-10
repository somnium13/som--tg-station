// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Landmark_Corpse : Obj_Effect_Landmark {

		public string mobname = "Unknown";
		public Type corpseuniform = null;
		public Type corpsesuit = null;
		public Type corpseshoes = null;
		public Type corpsegloves = null;
		public Type corpseradio = null;
		public Type corpseglasses = null;
		public Type corpsemask = null;
		public Type corpsehelmet = null;
		public Type corpsebelt = null;
		public Type corpsepocket1 = null;
		public dynamic corpsepocket2 = null;
		public Type corpseback = null;
		public bool corpseid = false;
		public string corpseidjob = null;
		public string corpseidaccess = null;
		public dynamic corpseidicon = null;
		public string mutantrace = "human";

		// Function from file: corpse.dm
		public Obj_Effect_Landmark_Corpse ( dynamic loc = null ) : base( (object)(loc) ) {
			
			if ( GlobalVars.ticker != null ) {
				this.initialize();
			}
			return;
		}

		// Function from file: corpse.dm
		public void createCorpse(  ) {
			Mob_Living_Carbon_Human M = null;
			Obj_Item_Weapon_Card_Id W = null;
			dynamic jobdatum = null;
			dynamic jobtype = null;
			dynamic J = null;

			M = new Mob_Living_Carbon_Human( this.loc );
			M.dna.mutantrace = this.mutantrace;
			M.real_name = this.name;
			M.adjustOxyLoss( 200 );
			M.iscorpse = true;

			if ( this.corpseuniform != null ) {
				M.equip_to_slot_or_del( Lang13.Call( this.corpseuniform, M ), 14 );
			}

			if ( this.corpsesuit != null ) {
				M.equip_to_slot_or_del( Lang13.Call( this.corpsesuit, M ), 13 );
			}

			if ( this.corpseshoes != null ) {
				M.equip_to_slot_or_del( Lang13.Call( this.corpseshoes, M ), 12 );
			}

			if ( this.corpsegloves != null ) {
				M.equip_to_slot_or_del( Lang13.Call( this.corpsegloves, M ), 10 );
			}

			if ( this.corpseradio != null ) {
				M.equip_to_slot_or_del( Lang13.Call( this.corpseradio, M ), 8 );
			}

			if ( this.corpseglasses != null ) {
				M.equip_to_slot_or_del( Lang13.Call( this.corpseglasses, M ), 9 );
			}

			if ( this.corpsemask != null ) {
				M.equip_to_slot_or_del( Lang13.Call( this.corpsemask, M ), 2 );
			}

			if ( this.corpsehelmet != null ) {
				M.equip_to_slot_or_del( Lang13.Call( this.corpsehelmet, M ), 11 );
			}

			if ( this.corpsebelt != null ) {
				M.equip_to_slot_or_del( Lang13.Call( this.corpsebelt, M ), 6 );
			}

			if ( this.corpsepocket1 != null ) {
				M.equip_to_slot_or_del( Lang13.Call( this.corpsepocket1, M ), 16 );
			}

			if ( Lang13.Bool( this.corpsepocket2 ) ) {
				M.equip_to_slot_or_del( Lang13.Call( this.corpsepocket2, M ), 15 );
			}

			if ( this.corpseback != null ) {
				M.equip_to_slot_or_del( Lang13.Call( this.corpseback, M ), 1 );
			}

			if ( this.corpseid ) {
				W = new Obj_Item_Weapon_Card_Id( M );
				W.name = "" + M.real_name + "'s ID Card";

				foreach (dynamic _a in Lang13.Enumerate( Lang13.GetTypes( typeof(Job) ) )) {
					jobtype = _a;
					
					J = Lang13.Call( jobtype );

					if ( J.title == this.corpseidaccess ) {
						jobdatum = J;
						break;
					}
				}

				if ( Lang13.Bool( this.corpseidicon ) ) {
					W.icon_state = this.corpseidicon;
				}

				if ( Lang13.Bool( this.corpseidaccess ) ) {
					
					if ( Lang13.Bool( jobdatum ) ) {
						W.access = ((Job)jobdatum).get_access();
					} else {
						W.access = new ByTable();
					}
				}

				if ( Lang13.Bool( this.corpseidjob ) ) {
					W.assignment = this.corpseidjob;
				}
				W.registered_name = M.real_name;
				M.equip_to_slot_or_del( W, 7 );
			}
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: corpse.dm
		public override bool initialize( bool? suppress_icon_check = null ) {
			this.createCorpse();
			return false;
		}

	}

}