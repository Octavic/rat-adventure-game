using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogueUI : MonoBehaviour
{
	/// <summary>
	/// Where to place the portrait
	/// </summary>
	public GameObject PortraitSlot;

	/// <summary>
	/// A collection of what index option + movement would move to what option
	/// </summary>
	public static Dictionary<int, Dictionary<Directions, int>> Neighbors = new Dictionary<int, Dictionary<Directions, int>>
	{
		{
			0, new Dictionary<Directions, int>()
			{
				{ Directions.Right, 1},
				{ Directions.Down, 2 },
			}
		},
		{
			1, new Dictionary<Directions, int>()
			{
				{ Directions.Left, 0},
				{ Directions.Down, 3 },
			}
		},
		{
			2, new Dictionary<Directions, int>()
			{
				{ Directions.Right, 3 },
				{ Directions.Up, 0 }
			}
		},
		{
			3, new Dictionary<Directions, int>()
			{
				{Directions.Left, 2 },
				{Directions.Up, 1 },
			}
		},
	};

	/// <summary>
	/// The options
	/// </summary>
	public List<DialogueOptionUI> OptionUIs;

	/// <summary>
	/// How fast the text scrolls by
	/// </summary>
	public float CrawlSpeed;

	/// <summary>
	/// How soon can skips be performed on dialogue
	/// </summary>
	public float SkipCooldown;

	/// <summary>
	/// How long we wait between showing the options
	/// </summary>
	public float SecondsBetweenDisplayOptions;

	/// <summary>
	/// The text box component
	/// </summary>
	public Text TextBox;

	/// <summary>
	/// The message that's being displayed currently
	/// </summary>
	public Dialogue CurrentDialogue { get; private set; }

	/// <summary>
	/// Index of the message that's on screen
	/// </summary>
	public int MessageIndex { get; private set; }

	/// <summary>
	/// The current message that'll go on screen
	/// </summary>
	public DialogueMessage CurrentMessage
	{
		get
		{
			return this.CurrentDialogue.Messages[this.MessageIndex];
		}
	}

	/// <summary>
	/// If the prompt is still scrolling
	/// </summary>
	protected bool IsScrolling
	{
		get
		{
			return this.currentCharIndex < this.CurrentMessage.Message.Length;
		}
	}

	private bool isOptionsReady = false;

	/// <summary>
	/// The index of where the char is at during scroll
	/// </summary>
	private float currentCharIndex;

	/// <summary>
	/// All options that are useful
	/// </summary>
	private List<DialogueOptionUI> ValidOptions;

	/// <summary>
	/// If the player can skip the scroll to display everything yet
	/// </summary>
	private bool canSkip;

	/// <summary>
	/// Index of the current option
	/// </summary>
	private int currentOptionIndex;

	/// <summary>
	/// Plays the target dialogue
	/// </summary>
	/// <param name="targetDialogue">The dialogue to be displayed</param>
	public void PlayDialogue(Dialogue targetDialogue)
	{
		// Sets the dialogue and starts the cooldown
		this.CurrentDialogue = targetDialogue;
		StartCoroutine(this.StartSkipCooldown(this.SkipCooldown));

		// Initialize index
		this.MessageIndex = 0;
		this.currentCharIndex = 0;
		this.UpdatePortrait();

		// Construct valid options
		this.ValidOptions = new List<DialogueOptionUI>();

		// Loop through all available options and display valid ones, while hiding the rest
		for (int i = 0; i < 4; i++)
		{
			if (i < targetDialogue.Options.Count)
			{
				var validOption = this.OptionUIs[i];
				validOption.SetOption(targetDialogue.Options[i]);
				this.ValidOptions.Add(validOption);
				validOption.gameObject.SetActive(false);
			}
			else
			{
				this.OptionUIs[i].gameObject.SetActive(false);
			}
		}

		// Check if the message is empty
		if (string.IsNullOrWhiteSpace(this.CurrentMessage.Message))
		{
			this.OnScrollToEnd();
		}
	}

	private void OnPlayerChangeSelection(Directions direction)
	{
		int nextOption;
		// No where to go
		if (!Neighbors[this.currentOptionIndex].TryGetValue(direction, out nextOption))
		{
			return;
		}

		// Check if next position is a valid option
		if (nextOption < this.ValidOptions.Count)
		{
			this.ValidOptions[nextOption].OnSelect();
			currentOptionIndex = nextOption;
		}
	}

	private void OnScrollToEnd()
	{
		if (this.ValidOptions.Count == 0)
		{
			// No options, see if there's more 
			DialogueEventManager.EmitEvent(this.CurrentDialogue.EventEmitted);
			var nextDialogue = this.CurrentDialogue.NextDialogue;
			if (!string.IsNullOrEmpty(nextDialogue))
			{
				DialogueUIController.CurrentInstance.PlayDialogue(nextDialogue);
			}
			else
			{
				Destroy(this.gameObject);
			}

			return;
		}

		if (!this.isOptionsReady)
		{
			StartCoroutine(this.ShowOptions());
		}
		else
		{
			this.OnPlayerChooseSelection();
		}

		StartCoroutine(this.DisablePortraitCoroutine());
	}

	private IEnumerator DisablePortraitCoroutine()
	{
		yield return new WaitForSeconds(0.1f);
		this.PortraitSlot.GetComponentInChildren<Animator>().enabled = false;
	}

	private void OnPlayerChooseSelection()
	{
		if (DialogueOptionUI.CurrentSelected == null)
		{
			return;
		}

		DialogueUIController.CurrentInstance.PlayDialogue(DialogueOptionUI.CurrentSelected.TargetOption.NextDialogue);
		Destroy(this.gameObject);
	}

	private void UpdatePortrait()
	{
		this.PortraitSlot.DestroyAllChildren();

		var targetMessage = this.CurrentDialogue.Messages[this.MessageIndex];
		if (targetMessage.PortraiPrefab != null)
		{
			var newPortrait = Instantiate(targetMessage.PortraiPrefab, this.PortraitSlot.transform);
			newPortrait.transform.localPosition = new Vector3();
			this.PortraitSlot.SetActive(true);
		}
		else
		{
			this.PortraitSlot.SetActive(false);
		}
	}

	/// <summary>
	/// Called when the player hits J or space
	/// </summary>
	private void OnPlayerInput()
	{
		// Text is still scrolling
		if (this.IsScrolling)
		{
			if (this.canSkip)
			{
				this.TextBox.text = this.CurrentMessage.Message;
				this.currentCharIndex = this.CurrentMessage.Message.Length;
			}
			return;
		}

		// If there are more messages to be played before we decide end/show options
		if (this.MessageIndex < this.CurrentDialogue.Messages.Count - 1)
		{
			// Start new message
			this.MessageIndex++;
			this.currentCharIndex = 0;
			this.UpdatePortrait();

			StartCoroutine(this.StartSkipCooldown(this.SkipCooldown));
			return;
		}

		// Reached the end of messages
		this.OnScrollToEnd();
	}

	private IEnumerator ShowOptions()
	{
		this.currentOptionIndex = 0;

		foreach (var option in this.ValidOptions)
		{
			yield return new WaitForSeconds(this.SecondsBetweenDisplayOptions);
			option.gameObject.SetActive(true);
		}

		this.ValidOptions[0].OnSelect();
		this.isOptionsReady = true;
	}

	// Update is called once per frame
	protected virtual void Update()
	{
		if (Input.GetKeyUp(KeyCode.E))
		{
			this.OnPlayerInput();
		}

		if (Input.GetKeyDown(KeyCode.W))
		{
			this.OnPlayerChangeSelection(Directions.Up);
		}
		else if (Input.GetKeyDown(KeyCode.A))
		{
			this.OnPlayerChangeSelection(Directions.Left);
		}
		else if (Input.GetKeyDown(KeyCode.S))
		{
			this.OnPlayerChangeSelection(Directions.Down);
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			this.OnPlayerChangeSelection(Directions.Right);
		}

		if (this.IsScrolling)
		{
			this.currentCharIndex += this.CrawlSpeed * Time.deltaTime;
			this.TextBox.text = this.CurrentMessage.Message.Substring(0, (int)this.currentCharIndex);
		}
	}

	private IEnumerator StartSkipCooldown(float seconds)
	{
		this.canSkip = false;
		yield return new WaitForSeconds(seconds);
		this.canSkip = true;
	}
}
