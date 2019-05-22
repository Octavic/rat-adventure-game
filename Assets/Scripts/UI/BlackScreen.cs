using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlackScreen : MonoBehaviour
{
	private static BlackScreen currentInstance;
	private Image imageComp;

	private static float alphaVelocity;

	public static void FadeIn(float duration = 0.3f)
	{
		alphaVelocity = 1 / duration;
	}

	public static void FadeOut(float duration = 0.3f)
	{
		alphaVelocity = -1 / duration;
	}

	private void Start()
	{
		currentInstance = this;
		this.imageComp = currentInstance.GetComponent<Image>();
		FadeOut();
	}

	private void Update()
	{
		if (alphaVelocity != 0)
		{
			var oldColor = this.imageComp.color;
			this.imageComp.color = oldColor.WithAlpha(oldColor.a + alphaVelocity * Time.deltaTime);
			var newColor = this.imageComp.color;
			if (newColor.a <= 0 || newColor.a >= 1)
			{
				alphaVelocity = 0;
			}
		}
	}
}
