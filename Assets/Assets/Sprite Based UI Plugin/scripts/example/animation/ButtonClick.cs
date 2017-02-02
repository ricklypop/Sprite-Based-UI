using UnityEngine;
using System.Collections;

public class ButtonClick : UISpriteAnimation {
	private bool upClick { get; set; }

	public override void doAnimation ()
	{
		if (upClick) {
			StartCoroutine(animate ("Up Click", false));
		} else {
			StartCoroutine(animate ("Down Click", false));
		}

		upClick = !upClick;
	}
	
}
