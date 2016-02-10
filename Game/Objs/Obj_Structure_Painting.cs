// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Painting : Obj_Structure {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.autoignition_temperature = 573.1500244140625;
			this.icon = "icons/obj/paintings.dmi";
			this.icon_state = "blank";
		}

		// Function from file: paintings.dm
		public Obj_Structure_Painting ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.update_painting();
			return;
		}

		// Function from file: paintings.dm
		public override dynamic cultify(  ) {
			Obj_Structure_Painting_Narsie N = null;

			N = new Obj_Structure_Painting_Narsie( this.loc );
			N.pixel_x = this.pixel_x;
			N.pixel_y = this.pixel_y;
			base.cultify();
			return null;
		}

		// Function from file: paintings.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Obj_Item_Mounted_Frame_Painting P = null;

			GlobalFuncs.to_chat( a, new Txt( "<span class='notice'>You pick up " ).the( this ).item().str( "...</span>" ).ToString() );
			this.add_fingerprint( a );
			P = new Obj_Item_Mounted_Frame_Painting( this.loc );
			P.paint = this.icon_state;
			P.update_painting();
			GlobalFuncs.transfer_fingerprints( this, P );
			GlobalFuncs.playsound( this.loc, "sound/weapons/thudswoosh.ogg", 25, 1 );
			P.attack_hand( a );
			GlobalFuncs.qdel( this );
			return null;
		}

		// Function from file: paintings.dm
		public void update_painting(  ) {
			
			switch ((string)( this.icon_state )) {
				case "narsie":
					this.name = "ÿPapa Narnar";
					this.desc = "A painting of Nar-Sie. You feel as if it's watching you.";
					break;
				case "monkey":
					this.name = "ÿMr. Deempisi portrait";
					this.desc = "Under the painting a plaque reads: 'While the meat grinder may not have spared you, fear not. Not one part of you has gone to waste... You were delicious.'";
					break;
				case "duck":
					this.name = "ÿDuck";
					this.desc = "A painting of a duck. It has a crazed look in its eyes.";
					break;
				case "mario":
					this.name = "ÿMario and Coin";
					this.desc = "A painting of an italian plumber and an oversized golden plate. Apparently he's a video game mascot of sorts.";
					break;
				case "gradius":
					this.name = "ÿVic Viper";
					this.desc = "A painting of a space ship. It makes you feel like diving right into an alien base and release your blasters right onto its core.";
					break;
				case "justice":
					this.name = "ÿJustice";
					this.desc = "A painting of a golden scale. Those are often found within courtrooms.";
					break;
				case "kudzu":
					this.name = "ÿScythe on Kudzu";
					this.desc = "A painting of a scythe and some vines.";
					break;
				case "dwarf":
					this.name = "ÿDwarven Miner";
					this.desc = "A painting of a dwarf mining adamantine. A long lost high-value metal that was said to be impossibly lightweight, strong, and sharp.";
					break;
				case "xenolisa":
					this.name = "ÿXeno Lisa";
					this.desc = "A painting of a xenomorph queen, wearing some human clothing. The hands are particularly well-painted.";
					break;
				case "bottles":
					this.name = "ÿBottle and Bottle";
					this.desc = "A painting of two glass bottles filled with blue and red liquids. You can almost feel the intensity of the artistic discussions that led to this creation.";
					break;
				case "aymao":
					this.name = "ÿAy Mao";
					this.desc = "A painting of the glorious leader of the Grey Democratic Republic. He looks dignified, and a bit high too.";
					break;
				case "flowey":
					this.name = "ÿFlowey the Flower";
					this.desc = "A painting of your best friend. Also SERIAL MURDERER.";
					break;
				case "sunset":
					this.name = "ÿPath toward the Sunset";
					this.desc = "A painting by D.T.Link. The colours fill you with hope and determination.";
					break;
				case "Flowereater":
					this.name = "ÿBlumenliebhaber";
					this.desc = "A painting by Guertena Weiss. An odd painting that fills you with hesitation. Its said you can hear cackling at night wherever its hung.";
					break;
				case "Sadclown":
					this.name = "ÿPagliacci";
					this.desc = "A morose painting of a sad clown. Is it possible that beneath that cheerful latext mask lays a somber and tired heart? Probably not.";
					break;
				case "hospital":
					this.name = "ÿKattelox Hospital";
					this.desc = "A painting depicting a compact but efficient hospital. The red really helps make the normally drab pallet pop.";
					break;
				case "prophecy":
					this.name = "ÿProphetic Mural";
					this.desc = "A copy of an ancient mural. It depicts a blue armored warrior fighting off an inhuman monstrocity. Its said many still wait for its conclusion.";
					break;
				case "anatomy":
					this.name = "ÿAnatomy Poster";
					this.desc = "A NT approved anatomy poster! Remember, eat a burger every 20-30 minutes. For your health.";
					break;
				case "Mime":
					this.name = "ÿPretencious Mime Painting";
					this.desc = "There are no words to discribe this painting.";
					break;
				case "wizard":
					this.name = "ÿNausiating Glow in the Dark Velvet Wizard Poster";
					this.desc = "Oh god he's looking right at me, what do I do what do I do!?";
					break;
				case "bland":
					this.name = "ÿPitcher and Orange";
					this.desc = "A painfully standard painting, used to decorate dining rooms and bathrooms alike.";
					break;
				case "Blu":
					this.name = "ÿWai-Blu";
					this.desc = "Faithfully Serving Nanotrasen during her shift, gladly serving YOU after.";
					break;
				case "Kate":
					this.name = "ÿCindy Kate";
					this.desc = "Through the carnage and bloodshed she's gunning for you, champ.";
					break;
				case "daddy":
					this.name = "ÿI <3 Daddy!";
					this.desc = "'Nanotrasen respects the right for all associates and their families to be able to express their indivuality though many media. However, soliciting Nanotrasen related merchandise without proper warrant is strictly prohibited. Luckly for you, you can now own your very own contraband Nanotrasen merch without the threat of *REDACTED*!'";
					break;
				case "carp":
					this.name = "ÿ'Singing' Mounted Carp";
					this.desc = "Too unrobust to beat a carp to death with your bare hands and mount it on a plank of wood? Then this professionally taxidermied trophy is just for you! Note: Does not actually sing.";
					break;
				default:
					this.name = "painting";
					this.desc = "a blank painting.";
					break;
			}
			return;
		}

	}

}