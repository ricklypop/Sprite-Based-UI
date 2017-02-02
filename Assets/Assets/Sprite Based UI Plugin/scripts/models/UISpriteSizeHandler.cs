using UnityEngine;
using System.Collections;

public class UISpriteSizeHandler : MonoBehaviour {
	private Vector2 defaultRes { get; set; }
	private Vector2 defaultSize;

	void Update () {
		if (defaultSize == Vector2.zero) {
			defaultSize = new Vector2 (transform.localScale.x, transform.localScale.y);
			defaultRes = new Vector2 (UIConstants.DEFAULT_SCREEN_WIDTH, UIConstants.DEFAULT_SCREEN_HEIGHT);
		}

		Vector2 currentRes = getRes ();

		if (currentRes != defaultRes) {

			Vector3 error = new Vector3 (-((defaultRes.x - Screen.width) / defaultRes.x),
				-((defaultRes.y - Screen.height) / defaultRes.y), 1);

			defaultRes = currentRes;

			transform.localScale += new Vector3 (transform.localScale.x * (error.x), transform.localScale.y * (error.y), 0);
		}
	}

	public Vector2 getRes(){
		return new Vector2 (Screen.width, Screen.height);
	}

	public Vector2 getSize(){
		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
		return new Vector2 (transform.localScale.x* (sprite.sprite.rect.size.x/sprite.sprite.pixelsPerUnit), 
			transform.localScale.y* (sprite.sprite.rect.size.y/sprite.sprite.pixelsPerUnit));
	}
}
