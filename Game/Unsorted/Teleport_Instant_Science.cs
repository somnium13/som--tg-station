// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Teleport_Instant_Science : Teleport_Instant {

		// Function from file: teleport.dm
		public override bool setPrecision( dynamic aprecision = null ) {
			ByTable bagholding = null;
			Ent_Dynamic MM = null;

			base.setPrecision( (object)(aprecision) );

			if ( this.teleatom is Obj_Item_Weapon_Storage_Backpack_Holding ) {
				this.precision = Rand13.Int( 1, 100 );
			}
			bagholding = this.teleatom.search_contents_for( typeof(Obj_Item_Weapon_Storage_Backpack_Holding) );

			if ( bagholding.len != 0 ) {
				this.precision = Num13.MaxInt( Rand13.Int( 1, 100 ) * bagholding.len, 100 );

				if ( this.teleatom is Mob_Living ) {
					MM = this.teleatom;
					((dynamic)MM).WriteMsg( "<span class='warning'>The bluespace interface on your bag of holding interferes with the teleport!</span>" );
				}
			}
			return true;
		}

		// Function from file: teleport.dm
		public override bool setEffects( dynamic aeffectin = null, dynamic aeffectout = null ) {
			EffectSystem_SparkSpread aeffect = null;

			
			if ( aeffectin == null || aeffectout == null ) {
				aeffect = new EffectSystem_SparkSpread();
				aeffect.set_up( 5, 1, this.teleatom );
				this.effectin = this.effectin || aeffect != null;
				this.effectout = this.effectout || aeffect != null;
				return true;
			} else {
				return base.setEffects( (object)(aeffectin), (object)(aeffectout) );
			}
		}

	}

}