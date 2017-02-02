using UnityEngine;
using System.Collections;

public class UiSpriteButton : UISprite {

	protected override void spritePressed (bool[] spritePress){
		GetComponent<ButtonClick> ().doAnimation ();
	}

	protected override void spriteHover (){}

}
