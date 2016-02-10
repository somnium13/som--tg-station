// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_WishGranterDark : Obj_Machinery {

		public int chargesa = 1;
		public int insistinga = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.use_power = 0;
			this.icon = "icons/obj/device.dmi";
			this.icon_state = "syndbeacon";
		}

		public Obj_Machinery_WishGranterDark ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: wildwest.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic wish = null;
			Objective_Hijack hijack = null;
			int obj_count = 0;
			Objective OBJ = null;
			Mob_Living_SimpleAnimal_Hostile_Faithless F = null;

			Task13.User.set_machine( this );

			if ( this.chargesa <= 0 ) {
				GlobalFuncs.to_chat( a, "The Wish Granter lies silent." );
				return null;
			} else if ( !( a is Mob_Living_Carbon_Human ) ) {
				GlobalFuncs.to_chat( a, "You feel a dark stirring inside of the Wish Granter, something you want nothing of. Your instincts are better than any man's." );
				return null;
			} else if ( GlobalFuncs.is_special_character( a ) != 0 ) {
				GlobalFuncs.to_chat( a, "Even to a heart as dark as yours, you know nothing good will come of this.  Something instinctual makes you pull away." );
			} else if ( !( this.insistinga != 0 ) ) {
				GlobalFuncs.to_chat( a, "Your first touch makes the Wish Granter stir, listening to you.  Are you really sure you want to do this?" );
				this.insistinga++;
			} else {
				this.chargesa--;
				this.insistinga = 0;
				wish = Interface13.Input( "You want...", "Wish", null, null, new ByTable(new object [] { "Power", "Wealth", "Immortality", "To Kill", "Peace" }), InputType.Null | InputType.Any );

				dynamic _c = wish; // Was a switch-case, sorry for the mess.
				if ( _c=="Power" ) {
					GlobalFuncs.to_chat( a, "<B>Your wish is granted, but at a terrible cost...</B>" );
					GlobalFuncs.to_chat( a, "The Wish Granter punishes you for your selfishness, claiming your soul and warping your body to match the darkness in your heart." );
					Interface13.Stat( null, a.mutations.Contains( 9 ) );

					if ( !false ) {
						a.mutations.Add( 9 );
						GlobalFuncs.to_chat( a, "ÿ!You feel pressure building behind your eyes." );
					}
					Interface13.Stat( null, a.mutations.Contains( 2 ) );

					if ( !( !false ) ) {
						a.mutations.Add( 2 );
						GlobalFuncs.to_chat( a, "ÿ!Your body feels warm." );
					}
					Interface13.Stat( null, a.mutations.Contains( 106 ) );

					if ( !( !( !false ) ) ) {
						a.mutations.Add( 106 );
						GlobalFuncs.to_chat( a, "ÿ!Your skin feels icy to the touch." );
					}
					Interface13.Stat( null, a.mutations.Contains( 3 ) );

					if ( !( !( !( !false ) ) ) ) {
						a.mutations.Add( 3 );
						a.sight |= 28;
						a.see_in_dark = 8;
						a.see_invisible = 45;
						GlobalFuncs.to_chat( a, "ÿ!The walls suddenly disappear." );
					}
					a.dna.mutantrace = "shadow";
					((Mob_Living_Carbon_Human)a).update_mutantrace();
				} else if ( _c=="Wealth" ) {
					GlobalFuncs.to_chat( a, "<B>Your wish is granted, but at a terrible cost...</B>" );
					GlobalFuncs.to_chat( a, "The Wish Granter punishes you for your selfishness, claiming your soul and warping your body to match the darkness in your heart." );
					new Obj_Structure_Closet_Syndicate_Resources_Everything( this.loc );
					a.dna.mutantrace = "shadow";
					((Mob_Living_Carbon_Human)a).update_mutantrace();
				} else if ( _c=="Immortality" ) {
					GlobalFuncs.to_chat( a, "<B>Your wish is granted, but at a terrible cost...</B>" );
					GlobalFuncs.to_chat( a, "The Wish Granter punishes you for your selfishness, claiming your soul and warping your body to match the darkness in your heart." );
					a.verbs += typeof(Mob_Living_Carbon).GetMethod( "immortality" );
					a.dna.mutantrace = "shadow";
					((Mob_Living_Carbon_Human)a).update_mutantrace();
				} else if ( _c=="To Kill" ) {
					GlobalFuncs.to_chat( a, "<B>Your wish is granted, but at a terrible cost...</B>" );
					GlobalFuncs.to_chat( a, "The Wish Granter punishes you for your wickedness, claiming your soul and warping your body to match the darkness in your heart." );
					GlobalVars.ticker.mode.traitors.Add( a.mind );
					a.mind.special_role = "traitor";
					hijack = new Objective_Hijack();
					hijack.owner = a.mind;
					a.mind.objectives += hijack;
					GlobalFuncs.to_chat( a, "<B>Your inhibitions are swept away, the bonds of loyalty broken, you are free to murder as you please!</B>" );
					obj_count = 1;

					foreach (dynamic _a in Lang13.Enumerate( a.mind.objectives, typeof(Objective) )) {
						OBJ = _a;
						
						GlobalFuncs.to_chat( a, "<B>Objective #" + obj_count + "</B>: " + OBJ.explanation_text );
						obj_count++;
					}
					a.dna.mutantrace = "shadow";
					((Mob_Living_Carbon_Human)a).update_mutantrace();
				} else if ( _c=="Peace" ) {
					GlobalFuncs.to_chat( a, "<B>Whatever alien sentience that the Wish Granter possesses is satisfied with your wish. There is a distant wailing as the last of the Faithless begin to die, then silence.</B>" );
					GlobalFuncs.to_chat( a, "You feel as if you just narrowly avoided a terrible fate..." );

					foreach (dynamic _b in Lang13.Enumerate( GlobalVars.mob_list, typeof(Mob_Living_SimpleAnimal_Hostile_Faithless) )) {
						F = _b;
						
						F.health = -10;
						F.stat = 2;
						F.icon_state = "faithless_dead";
					}
				}
			}
			return null;
		}

	}

}