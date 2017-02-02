using UnityEngine;
using System.Collections;

public class UISprite : SpriteEventListener {
	public Transform transitionTo;

	public UiSpriteCanvas canvas{ get; set; }

	void Start(){
		UISpriteSizeHandler sizeHandler = gameObject.AddComponent<UISpriteSizeHandler>();
	}

	public IEnumerator onDestroyUI(){

		float maxTime = 0f;
		foreach (Transition outTransition in GetComponents<Transition>()) {
			
			if (!outTransition.isInTransition) {
				
				outTransition.doTrasition ();

				if (outTransition.transitionTime > maxTime)
					maxTime = outTransition.transitionTime;

			}
			
		}

		yield return new WaitForSeconds (maxTime);

		canvas.onUIObjectDestroy (this);
		GameObject.Destroy (transform);

	}

	public void onCreateUI(){
		
		foreach (Transition inTransition in GetComponents<Transition>()) {
			if (inTransition.isInTransition)
				inTransition.doTrasition ();
			
		}

	}

	public void fullTransition(){
		StartCoroutine(canvas.transitionOut (transitionTo));
	}

	protected override void spritePressed (bool[] spritePress){}
	
	protected override void spriteHover (){}

}
