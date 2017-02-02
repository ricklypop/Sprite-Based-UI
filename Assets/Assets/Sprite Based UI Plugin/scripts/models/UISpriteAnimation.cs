using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public abstract class UISpriteAnimation : MonoBehaviour {
	public List<string> animationNames;
	public List<Texture2D> animationSet;
	public List<Vector2> animationDimensions;
	public List<float> animationUpdate;

	public abstract void doAnimation ();

	public IEnumerator animate(string animationName, bool endAsOriginal){

		Sprite original = GetComponent<SpriteRenderer> ().sprite;
		Texture2D spriteSheet = animationSet [animationNames.IndexOf (animationName)];
		Vector2 dimensions = animationDimensions [animationNames.IndexOf (animationName)];
		for (int y = 0; y < (spriteSheet.height / dimensions.y); y++) {
			
			for (int x = 0; x < (spriteSheet.width / dimensions.x); x++) {
				GetComponent<SpriteRenderer> ().sprite = Sprite.Create (spriteSheet, 
					new Rect (new Vector2 (x * dimensions.x, y * dimensions.y), dimensions),
					new Vector2(0.5f, 0.5f));

				yield return new WaitForSeconds(animationUpdate [animationNames.IndexOf (animationName)]);
			}

		}

		if (endAsOriginal) {
			GetComponent<SpriteRenderer> ().sprite = original;
		}
		
		yield return new WaitForSeconds(0);
	}
}
