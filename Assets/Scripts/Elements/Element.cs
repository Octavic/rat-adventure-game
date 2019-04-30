using UnityEngine;
using System.Collections;

public class Element
{
	public static readonly Element Oxygen = new Element(ElementNames.Oxygen, 1);
	public static readonly Element Hydrogen = new Element(ElementNames.Oxygen, 2);
	public static readonly Element Iron = new Element(ElementNames.Iron, 4);

	public ElementNames Name { get; private set; }
	public int Number { get; private set; }

	public static Element GetElement(ElementNames name)
	{
		switch (name)
		{
			case ElementNames.Oxygen:
				return Element.Oxygen;
			case ElementNames.Hydrogen:
				return Element.Hydrogen;
			default:
				return Element.Iron;
		}
	}

	private Element(ElementNames name, int number)
	{
		this.Name = name;
		this.Number = number;
	}
}
