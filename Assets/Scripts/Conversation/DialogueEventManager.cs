using UnityEngine;
using System.Collections.Generic;

public static class DialogueEventManager
{
	public static HashSet<IDialogueEventListener> Listeners = new HashSet<IDialogueEventListener>();

	public static void RegisterListener(IDialogueEventListener listener)
	{
		Listeners.Add(listener);
	}

	public static void RemoveListener(IDialogueEventListener listener)
	{
		Listeners.Remove(listener);
	}

	public static void OnSelectDialogueOption(DialogueOption option)
	{
		foreach(var listener in Listeners)
		{
			listener.OnSelectDialogueOption(option);
		}
	}
}
