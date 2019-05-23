using UnityEngine;
using System.Collections.Generic;

public static class DialogueEventManager
{
	public static Dictionary<DialogueEvents, List<IDialogueEventListener>> Listeners = 
		      new Dictionary<DialogueEvents, List<IDialogueEventListener>>();

	public static void RegisterListener(DialogueEvents e, IDialogueEventListener listener)
	{
		if (!Listeners.ContainsKey(e))
		{
			Listeners[e] = new List<IDialogueEventListener>();
		}

		Listeners[e].Add(listener);
	}

	public static void RemoveListener(DialogueEvents e, IDialogueEventListener listener)
	{
		Listeners[e].Remove(listener);
	}

	public static void EmitEvent(DialogueEvents e)
	{
		List<IDialogueEventListener> listeners;
		if (Listeners.TryGetValue(e, out listeners))
		{
			foreach (var listener in listeners)
			{
				listener.OnEventTrigger(e);
			}
		}
	}
}
