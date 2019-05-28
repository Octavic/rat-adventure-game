using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
	public void OnClick()
	{
		StartCoroutine(this.NextSceneCoroutine());
	}

	private IEnumerator NextSceneCoroutine()
	{
		BlackScreen.FadeIn();
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene(Config.Scenes.PlayScene);
	}

	/// <summary>
	/// Called once per frame
	/// </summary>
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			this.OnClick();
		}
	}
}
