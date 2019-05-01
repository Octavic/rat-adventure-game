using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ElementUI : MonoBehaviour
{
	public Color ActiveColor;
	public Color InactiveColor;

	public ElementNames ElementName;
	public bool IsElementActive
	{
		get
		{
			return isActive;
		}
		private set
		{
			this.isActive = value;
			this.ImageComp.color = this.IsElementActive ? ActiveColor : InactiveColor;
		}
	}
	private bool isActive;
	public Element TargetElement { get; private set; }

	private Image ImageComp;

	protected void Start()
	{
		this.TargetElement = Element.GetElement(this.ElementName);
		this.ImageComp = this.GetComponent<Image>();

		this.IsElementActive = false;
		ElementalizerUI.CurrentInstance.RegisterElementUI(this);
	}

	public void OnClick()
	{
		this.IsElementActive = !this.IsElementActive;
		ElementalizerUI.CurrentInstance.OnChangeElement();
	}
}
