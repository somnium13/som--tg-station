// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_SecureCloset_Personal_Patient : Obj_Structure_Closet_SecureCloset_Personal {

		// Function from file: personal.dm
		public Obj_Structure_Closet_SecureCloset_Personal_Patient ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Schedule( 4, (Task13.Closure)(() => {
				this.contents = new ByTable();
				new Obj_Item_Clothing_Under_Color_White( this );
				new Obj_Item_Clothing_Shoes_White( this );
				return;
			}));
			return;
		}

	}

}