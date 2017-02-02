using UnityEngine;
using System.Collections;

public class UiSpriteButton : UISprite {
	private bool down  { get; set; }

	protected override void spritePressedDown (bool[] spritePress){
		if (!down) {
			GetComponent<ButtonClick> ().doAnimation ();
			down = true;
		}
	}

	protected override void spriteHover (){}

	protected override void spriteButtonUp(bool[] buttonPress){
		if (down) {
			GetComponent<ButtonClick> ().doAnimation ();
			down = false;
		}
	}

}

