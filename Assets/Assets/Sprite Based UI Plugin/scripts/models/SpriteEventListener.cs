using UnityEngine;
using System.Collections;

public abstract class SpriteEventListener : MonoBehaviour {
	private Vector2 mouse;
	private bool[] playerClicks;
	private Vector2 pixelPos;
	private Vector2 pixelSize;
	
	void Start () {

	}

	void Update () {
		
		updateInputs ();
		checkPressed ();
		checkHover ();

	}

	void updateInputs(){
		playerClicks = new bool[3];

		for (int click = 0; click < 3; click++) {
			
			if (Input.GetMouseButtonUp (click)) {
				playerClicks [click] = true;
			}

			if (Input.GetMouseButtonDown (click)) {
				playerClicks [click] = true;
			}

		}

		mouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

		pixelPos = new Vector2 ((transform.position.x + (GetComponent<UISpriteSizeHandler> ().getRes().x / 2)),
			(transform.position.y + (GetComponent<UISpriteSizeHandler> ().getRes().y / 2)));

		pixelSize = GetComponent<UISpriteSizeHandler> ().getSize ();
	}

	void checkPressed(){
		
		bool go = false;
		foreach (bool click in playerClicks) {
			
			if (click)
				go = true;
			
		}

		if (go) {

			if (mouse.x >= pixelPos.x - (pixelSize.x / 2) && mouse.x <= pixelPos.x + (pixelSize.x / 2)
			   && mouse.y >= pixelPos.y - (pixelSize.y / 2) && mouse.y <= pixelPos.y + (pixelSize.y / 2))
				spritePressed (playerClicks);
		}

	}

	void checkHover(){
		
		if (mouse.x >= pixelPos.x - (pixelSize.x / 2) && mouse.x <= pixelPos.x + (pixelSize.x / 2)
			&& mouse.y >= pixelPos.y - (pixelSize.y / 2) && mouse.y <= pixelPos.y + (pixelSize.y / 2))
				spriteHover ();

	}

	protected abstract void spritePressed (bool[] spritePress);

	protected abstract void spriteHover ();

}
