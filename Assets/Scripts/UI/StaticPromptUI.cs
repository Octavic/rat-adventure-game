using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StaticPromptUI : BasePromptUI
{
	/// <summary>
	/// All messages for the prompt
	/// </summary>
	public List<string> Messages;

	/// <summary>
	/// Which one of the message are we on right now
	/// </summary>
	private int messageIndex = 0;

	public void Activate()
	{
		this.PlayMessage(this.Messages[0]);
	}

	protected override void OnCurrentMessageEnd()
	{
		this.messageIndex++;
		if (this.messageIndex >= this.Messages.Count)
		{
			base.OnCurrentMessageEnd();
		}
		else
		{
			this.PlayMessage(this.Messages[this.messageIndex]);
		}
	}
}
