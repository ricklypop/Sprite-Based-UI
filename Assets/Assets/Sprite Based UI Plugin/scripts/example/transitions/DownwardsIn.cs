using UnityEngine;
using System.Collections;

public class DownwardsIn : Transition {
	public float timeSteps;

	private float moveDown { get; set; }
	private Vector3 originalPos { get; set; }
	private bool startTransition { get; set; }
	private float currentStep { get; set; }
	private float time { get; set; }

	void Start () {
		isInTransition = true;
	}

	void Update () {
		
		time += Time.deltaTime;

		if (startTransition && time >= transitionTime / timeSteps) {

			transform.localPosition = new Vector3 (transform.localPosition.x, 
				transform.localPosition.y - ((moveDown / timeSteps)), transform.localPosition.z);

			if (currentStep == timeSteps) {
				startTransition = false;
				currentStep = 0;
				transform.localPosition = originalPos;
			}

			currentStep += 1;
			time = 0;

		} 
			
	}
		
	public override void doTrasition ()
	{
		startTransition = true;

		UISprite sprite = GetComponent<UISprite> ();
		UISpriteSizeHandler handler = GetComponent<UISpriteSizeHandler> ();
		originalPos = transform.localPosition;
		moveDown = (handler.getRes().y / 2) + (-transform.localPosition.y) + (handler.getSize().y / 2);
		transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y + moveDown, transform.localPosition.z);


	}

}
