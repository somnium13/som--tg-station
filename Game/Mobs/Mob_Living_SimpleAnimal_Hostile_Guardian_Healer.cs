// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Guardian_Healer : Mob_Living_SimpleAnimal_Hostile_Guardian {

		public dynamic beacon = null;
		public int beacon_cooldown = 0;
		public int? toggle = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.friendly = "heals";
			this.damage_coeff = new ByTable().Set( "brute", 061 ).Set( "fire", 061 ).Set( "tox", 061 ).Set( "clone", 061 ).Set( "stamina", 0 ).Set( "oxy", 061 );
			this.playstyle_string = "As a Support type, you may toggle your basic attacks to a healing mode. In addition, Alt-Clicking on an adjacent mob will warp them to your bluespace beacon after a short delay.";
			this.magic_fluff_string = "..And draw the CMO, a potent force of life...and death.";
			this.tech_fluff_string = "Boot sequence complete. Medical modules active. Bluespace modules activated. Holoparasite swarm online.";
		}

		// Function from file: guardian.dm
		public Mob_Living_SimpleAnimal_Hostile_Guardian_Healer ( dynamic loc = null ) : base( (object)(loc) ) {
			AtomHud medsensor = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			medsensor = GlobalVars.huds[4];
			medsensor.add_hud_to( this );
			return;
		}

		// Function from file: guardian.dm
		public override void AltClickOn( Ent_Static A = null ) {
			GasMixture Z = null;
			ByTable Z_gases = null;
			int? trace_gases = null;
			dynamic id = null;
			double pressure = 0;

			
			if ( !( A is Ent_Dynamic ) ) {
				return;
			}

			if ( this.loc == this.summoner ) {
				this.WriteMsg( "<span class='danger'><B>You must be manifested to warp a target!</span></B>" );
				return;
			}

			if ( !Lang13.Bool( this.beacon ) ) {
				this.WriteMsg( "<span class='danger'><B>You need a beacon placed to warp things!</span></B>" );
				return;
			}

			if ( !this.Adjacent( A ) ) {
				this.WriteMsg( "<span class='danger'><B>You must be adjacent to your target!</span></B>" );
				return;
			}

			if ( Lang13.Bool( ((dynamic)A).anchored ) ) {
				this.WriteMsg( "<span class='danger'><B>Your target cannot be anchored!</span></B>" );
				return;
			}
			this.WriteMsg( "<span class='danger'><B>You begin to warp " + A + "</span></B>" );

			if ( GlobalFuncs.do_mob( this, A, 50 ) ) {
				
				if ( !Lang13.Bool( ((dynamic)A).anchored ) ) {
					
					if ( Lang13.Bool( this.beacon ) ) {
						
						if ( Lang13.Bool( this.beacon.air ) ) {
							Z = this.beacon.air;
							Z_gases = Z.gases;
							trace_gases = GlobalVars.FALSE;

							foreach (dynamic _a in Lang13.Enumerate( Z_gases )) {
								id = _a;
								

								if ( GlobalVars.hardcoded_gases.Contains( id ) ) {
									continue;
								}
								trace_gases = GlobalVars.TRUE;
								break;
							}

							if ( Lang13.Bool( Z_gases["o2"] ) && Convert.ToDouble( Z_gases["o2"][1] ) >= 16 && !Lang13.Bool( Z_gases["plasma"] ) && ( !Lang13.Bool( Z_gases["co2"] ) || Convert.ToDouble( Z_gases["co2"][1] ) < 10 ) && !Lang13.Bool( trace_gases ) ) {
								
								if ( Convert.ToDouble( Z.temperature ) > 270 && Convert.ToDouble( Z.temperature ) < 360 ) {
									pressure = Z.return_pressure();

									if ( pressure > 20 && pressure < 550 ) {
										GlobalFuncs.PoolOrNew( typeof(Obj_Effect_Overlay_Temp_Guardian_Phase_Out), GlobalFuncs.get_turf( A ) );
										GlobalFuncs.do_teleport( A, this.beacon, 0 );
										GlobalFuncs.PoolOrNew( typeof(Obj_Effect_Overlay_Temp_Guardian_Phase), GlobalFuncs.get_turf( A ) );
									}
								} else {
									this.WriteMsg( "<span class='danger'><B>The beacon isn't in a safe location!</span></B>" );
								}
							} else {
								this.WriteMsg( "<span class='danger'><B>The beacon isn't in a safe location!</span></B>" );
							}
						}
					} else {
						this.WriteMsg( "<span class='danger'><B>You need a beacon to warp things!</span></B>" );
					}
				}
			} else {
				this.WriteMsg( "<span class='danger'><B>You need to hold still!</span></B>" );
			}
			return;
		}

		// Function from file: guardian.dm
		public override void ToggleMode(  ) {
			
			if ( this.loc == this.summoner ) {
				
				if ( Lang13.Bool( this.toggle ) ) {
					this.a_intent = "harm";
					this.speed = 0;
					this.damage_coeff = new ByTable().Set( "brute", 061 ).Set( "fire", 061 ).Set( "tox", 061 ).Set( "clone", 061 ).Set( "stamina", 0 ).Set( "oxy", 061 );
					this.melee_damage_lower = 15;
					this.melee_damage_upper = 15;
					this.WriteMsg( "<span class='danger'><B>You switch to combat mode.</span></B>" );
					this.toggle = GlobalVars.FALSE;
				} else {
					this.a_intent = "help";
					this.speed = 1;
					this.damage_coeff = new ByTable().Set( "brute", 1 ).Set( "fire", 1 ).Set( "tox", 1 ).Set( "clone", 1 ).Set( "stamina", 0 ).Set( "oxy", 1 );
					this.melee_damage_lower = 0;
					this.melee_damage_upper = 0;
					this.WriteMsg( "<span class='danger'><B>You switch to healing mode.</span></B>" );
					this.toggle = GlobalVars.TRUE;
				}
			} else {
				this.WriteMsg( "<span class='danger'><B>You have to be recalled to toggle modes!</span></B>" );
			}
			return;
		}

		// Function from file: guardian.dm
		public override bool AttackingTarget(  ) {
			dynamic C = null;

			
			if ( base.AttackingTarget() ) {
				
				if ( this.toggle == GlobalVars.TRUE ) {
					
					if ( this.target is Mob_Living_Carbon ) {
						C = this.target;
						((Mob_Living)C).adjustBruteLoss( -5 );
						((Mob_Living)C).adjustFireLoss( -5 );
						((Mob_Living)C).adjustOxyLoss( -5 );
						((Mob_Living)C).adjustToxLoss( -5 );
					}
				}
			}
			return false;
		}

		// Function from file: guardian.dm
		[Verb]
		[VerbInfo( name: "Place Bluespace Beacon", desc: "Mark a floor as your beacon point, allowing you to warp targets to it. Your beacon will not work in unfavorable atmospheric conditions.", group: "Guardian" )]
		public void Beacon(  ) {
			dynamic beacon_loc = null;
			dynamic F = null;

			
			if ( this.beacon_cooldown < Game13.time ) {
				beacon_loc = GlobalFuncs.get_turf( this.loc );

				if ( beacon_loc is Tile_Simulated_Floor ) {
					F = beacon_loc;
					F.icon = "icons/turf/floors.dmi";
					F.name = "bluespace recieving pad";
					F.desc = "A recieving zone for bluespace teleportations. Building a wall over it should disable it.";
					F.icon_state = "light_on-w";
					this.WriteMsg( "<span class='danger'><B>Beacon placed! You may now warp targets to it, including your user, via Alt+Click. </span></B>" );

					if ( Lang13.Bool( this.beacon ) ) {
						((Tile)this.beacon).ChangeTurf( typeof(Tile_Simulated_Floor_Plating) );
					}
					this.beacon = F;
					this.beacon_cooldown = Game13.time + 3000;
				}
			} else {
				this.WriteMsg( "<span class='danger'><B>Your power is on cooldown. You must wait five minutes between placing beacons.</span></B>" );
			}
			return;
		}

	}

}