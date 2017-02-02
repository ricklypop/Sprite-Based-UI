using UnityEngine;
using System.Collections;

public abstract class SpriteEventListener : MonoBehaviour {
	private Vector2 mouse;
	private bool[,] playerClicks;
	private Vector2 pixelPos;
	private Vector2 pixelSize;

	void Update () {
		
		updateInputs ();
		checkPressed ();
		checkHover ();

	}

	void updateInputs(){
		
		playerClicks = new bool[2, 3];
		bool[] buttonPressUp = new bool[3];
		bool[] buttonPressDown = new bool[3];
		for (int click = 0; click < 3; click++) {
			
			if (Input.GetMouseButtonUp (click)) {
				playerClicks [0, click] = true;
				buttonPressUp [click] = true;
			}

			if (Input.GetMouseButtonDown (click)) {
				playerClicks [1, click] = true;
				buttonPressDown [click] = true;
			}

		}

		for (int click = 0; click < 3; click++) {
			
			if (buttonPressUp [click]) {
				spriteButtonUp (buttonPressUp);
				break;
			}

		}

		for (int click = 0; click < 3; click++) {

			if (buttonPressDown [click]) {
				spriteButtonDown (buttonPressDown);
				break;
			}

		}
				

		mouse = getMousePos ();

		pixelPos = getPixelPos ();

		pixelSize = GetComponent<UISpriteSizeHandler> ().getSize ();
	}

	void checkPressed(){

		for (int upDown = 0; upDown < 2; upDown++) {

			bool[] spritePress = new bool[3];
			bool go = false;
			for (int click = 0; click < 3; click++) {
				
				spritePress [click] = playerClicks [upDown, click];

				if (playerClicks[upDown, click])
					go = true;
			
			}

			if (go) {

				if (mouse.x >= pixelPos.x - (pixelSize.x / 2) && mouse.x <= pixelPos.x + (pixelSize.x / 2)
				    && mouse.y >= pixelPos.y - (pixelSize.y / 2) && mouse.y <= pixelPos.y + (pixelSize.y / 2)) {

					if(upDown == 0)
						spritePressedUp (spritePress);
					else if(upDown == 1)
						spritePressedDown (spritePress);
					
				}

			}

		}
	}

	void checkHover(){
		
		if (mouse.x >= pixelPos.x - (pixelSize.x / 2) && mouse.x <= pixelPos.x + (pixelSize.x / 2)
			&& mouse.y >= pixelPos.y - (pixelSize.y / 2) && mouse.y <= pixelPos.y + (pixelSize.y / 2))
				spriteHover ();

	}

	public Vector2 getPixelPos(){
		return new Vector2 ((transform.position.x + (GetComponent<UISpriteSizeHandler> ().getRes().x / 2)),
			(transform.position.y + (GetComponent<UISpriteSizeHandler> ().getRes().y / 2)));
	}

	public Vector2 getMousePos(){
		return new Vector2(Input.mousePosition.x, Input.mousePosition.y);
	}

	protected abstract void spritePressedDown (bool[] spritePress);

	protected abstract void spritePressedUp (bool[] spritePress);

	protected abstract void spriteHover ();

	protected abstract void spriteButtonUp (bool[] buttonPress);

	protected abstract void spriteButtonDown (bool[] buttonPress);

}
