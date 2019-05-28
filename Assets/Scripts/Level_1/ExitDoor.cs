using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : RoomChangeDoor
{

	public override bool OnInteractItem(ItemUI holdingItem)
	{
		StartCoroutine(this.FadeOutCoroutine());
		return false;
	}

	private IEnumerator FadeOutCoroutine()
	{
		BlackScreen.FadeIn();
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene(Config.Scenes.DemoEndScene);
	}
}
