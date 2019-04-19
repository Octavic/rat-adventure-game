using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class BasePromptUI : MonoBehaviour
{
	/// <summary>
	/// How fast the text scrolls by
	/// </summary>
	public float CrawSpeed;

	/// <summary>
	/// The text box component
	/// </summary>
	public Text TextBox;

	public static BasePromptUI ActivePrompt { get; private set; }

	public string CurrentMessage { get; private set; }

	private bool IsScrolling
	{
		get
		{
			return this.currentCharIndex < this.CurrentMessage.Length;
		}
	}

	private float currentCharIndex;


	protected void PlayMessage(string message)
	{
		this.CurrentMessage = message;
		this.currentCharIndex = 0;
	}

	/// <summary>
	/// Called when the player hits J or space
	/// </summary>
	private void OnPlayerPressSkip()
	{
		if (this.IsScrolling)
		{
			this.TextBox.text = this.CurrentMessage;
			this.currentCharIndex = this.CurrentMessage.Length;
		}
		else
		{
			this.OnCurrentMessageEnd();
		}
	}

	/// <summary>
	/// Called when the current message is done playing
	/// </summary>
	protected virtual void OnCurrentMessageEnd()
	{
		Destroy(this.gameObject);
	}

	// Use this for initialization
	protected virtual void Start()
	{
		if (ActivePrompt != null)
		{
			Debug.LogError("A prompt is still active, cannot start a new prompt!");
			Destroy(this.gameObject);
			return;
		}

		ActivePrompt = this;
		this.currentCharIndex = 0;
	}

	// Update is called once per frame
	protected virtual void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			this.OnPlayerPressSkip();
		}

		if (this.IsScrolling)
		{
			this.currentCharIndex += this.CrawSpeed * Time.deltaTime;
			this.TextBox.text = this.CurrentMessage.Substring(0, (int)this.currentCharIndex);
		}
	}
}
