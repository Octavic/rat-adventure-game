using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A simple message board that displays a message when interacted with
/// When given multiple messages, each will take up its own screen (For possible comedic effect)
/// </summary>
public class MessageBoard : BaseInteractable
{
	public List<string> Messages;

	private static Canvas MainCanvas
	{
		get
		{
			if (_mainCanvs == null)
			{
				_mainCanvs = GameObject.FindObjectOfType<Canvas>();
			}
			return _mainCanvs;
		}
	}
	private static Canvas _mainCanvs;

	public override void OnInteract()
	{
		var newStaticPrompt = Instantiate(PrefabManager.CurrentInstance.StaticPromptPrefab, MainCanvas.transform);
		newStaticPrompt.Messages = this.Messages;
		newStaticPrompt.Activate();
	}
}
