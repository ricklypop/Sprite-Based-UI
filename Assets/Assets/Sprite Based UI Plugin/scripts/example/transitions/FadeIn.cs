using UnityEngine;
using System.Collections;

public class FadeIn : Transition {
	public float timeSteps;

	private bool transitionStarted = false;
	private float opacity = 0;
	private float time = 0;

	void Start () {
		isInTransition = true;
		GetComponent<SpriteRenderer>().color = new Color (1f, 1f, 1f, 0f);
	}

	void Update () {
		
		time += Time.deltaTime;

		if (transitionStarted && time >= transitionTime / timeSteps) {
			opacity += 1/timeSteps;
			GetComponent<SpriteRenderer>().color = new Color (1f, 1f, 1f, opacity);

			if (opacity > (1 / timeSteps) * (timeSteps - 1)) {
				transitionStarted = false;
				GetComponent<SpriteRenderer>().color = new Color (1f, 1f, 1f, 1f);
			}

			time = 0;
		}

	}
		
	public override void doTrasition ()
	{
		transitionStarted = true;
	}

}
