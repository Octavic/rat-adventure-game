using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public static class Elementalizer
{
	/// <summary>
	/// Key is the combination of all elements
	/// </summary>
	private static Dictionary<int, Compound> Combinations = new Dictionary<int, Compound>();

	static Elementalizer()
	{
		SetCombination(Compound.Water, new List<Element>() { Element.Hydrogen, Element.Oxygen });
		SetCombination(Compound.Hydrogen, new List<Element>() { Element.Hydrogen});
		SetCombination(Compound.Oxygen, new List<Element>() { Element.Oxygen });
	}

	private static int GetKey(List<Element> elements)
	{
		return elements.Sum(element => element.Number);
	}

	private static void SetCombination(Compound result, List<Element> sourceElements)
	{
		var combined = GetKey(sourceElements);
		if (Combinations.ContainsKey(combined))
		{
			throw new Exception("Duplicate entry for " + result);
		}

		Combinations[combined] = result;
	}

	public static Compound GetCombination(List<ElementNames> elementNames)
	{
		return GetCombination(elementNames.Select(elementName => Element.GetElement(elementName)).ToList());
	}

	public static Compound GetCombination(List<Element> elements)
	{
		Compound result;
		if(!Combinations.TryGetValue(GetKey(elements), out result))
		{
			return null;
		}

		return result;
	}
}
