using UnityEngine;
using System.Collections;

public abstract class Transition : MonoBehaviour {
	public float transitionTime;
	public bool isInTransition{ get; set; }

	public abstract void doTrasition ();

}
