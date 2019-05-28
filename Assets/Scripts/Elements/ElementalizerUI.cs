using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Linq;

public class ElementalizerUI : MonoBehaviour, IDialogueEventListener
{
	[Serializable]
	public class CompoundUI
	{
		public CompoundNames CompoundName;
		public Sprite CompoundSprite;
	}

	public Image CompoundImage;
	public List<CompoundUI> AllCompoundSprites;
	private Dictionary<CompoundNames, CompoundUI> hashedCompoundSprite;

	public Compound CurrentCompound
	{
		get
		{
			return _currentCompound;
		}
		set
		{
			this._currentCompound = value;
			if (value == null)
			{
				this.CompoundImage.gameObject.SetActive(false);
			}
			else
			{
				this.CompoundImage.gameObject.SetActive(true);
				this.CompoundImage.sprite = this.hashedCompoundSprite[value.CompoundName].CompoundSprite;
			}
		}
	}
	private Compound _currentCompound;

	public static ElementalizerUI CurrentInstance
	{
		get
		{
			if (_currentInstnace == null)
			{
				_currentInstnace = GameObject.FindObjectOfType<ElementalizerUI>();
			}
			return _currentInstnace;
		}
	}
	private static ElementalizerUI _currentInstnace;

	private Dictionary<ElementNames, ElementUI> ElementUIs = new Dictionary<ElementNames, ElementUI>();

	public void RegisterElementUI(ElementUI ui)
	{
		this.ElementUIs[ui.ElementName] = ui;
	}

	public ElementUI GetElementUI(ElementNames element)
	{
		return this.ElementUIs[element];
	}

	public void OnChangeElement()
	{
		var activeElements = new List<Element>();
		foreach (var ui in this.ElementUIs.Values)
		{
			if (ui.IsElementActive)
			{
				activeElements.Add(ui.TargetElement);
			}
		}
		this.CurrentCompound = Elementalizer.GetCombination(activeElements);
	}

	/// <summary>
	/// Used for initialization
	/// </summary>
	protected void Start()
	{
		this.CurrentCompound = null;
		this.hashedCompoundSprite = this.AllCompoundSprites.ToDictionary(compoundUI => compoundUI.CompoundName);

		DialogueEventManager.RegisterListener(DialogueEvents.ELEMENTALIZER_GIVEN, this);
	}

	public void OnEventTrigger(DialogueEvents e)
	{
		this.GetComponent<Animator>().SetBool("IsShowing", true);
	}
}
