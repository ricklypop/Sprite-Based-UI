using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UiSpriteCanvas : MonoBehaviour {
	private HashSet<UISprite> uiObjects = new HashSet<UISprite>();
	private bool transitionedIn { get; set; }

	void Start () {
		GetComponent<Canvas> ().worldCamera = Camera.main;
		setUpCanvas (transform);
	}

	void Update(){

		if (!transitionedIn) {
			
			transitionIn ();
			transitionedIn = true;

		}

	}

	void setUpCanvas(Transform parent){
		
		foreach (Transform child in parent) {
			UISprite uiObject = child.GetComponent<UISprite> ();

			if (uiObject != null) {
				
				uiObject.canvas = this;
				uiObjects.Add (uiObject);

			}

			setUpCanvas (child);
		}

	}

	public IEnumerator transitionOut(Transform transitionTo){
		
		foreach (UISprite sprite in uiObjects) {

			StartCoroutine(sprite.onDestroyUI ());

		}

		while (uiObjects.Count != 0)
			yield return new WaitForSeconds (0.25f);

		Instantiate(transitionTo, transform.position, transform.rotation);

		GameObject.Destroy (transform);

	}

	public void transitionIn(){

		foreach (UISprite sprite in uiObjects) {

			sprite.onCreateUI ();

		}

	}

	public void onUIObjectDestroy(UISprite sprite){
		uiObjects.Remove (sprite);
	}

}
