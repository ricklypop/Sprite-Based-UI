using UnityEngine;
using System.Collections;

public class IETest : MonoBehaviour {

	void Start () {	
		for (int i = 0; i < 10000; i++)
			StartCoroutine(IE());
	}

	public IEnumerator IE () {
		yield return new WaitForSeconds (1);
		Debug.Log ("Did I crash?");
	}
}
