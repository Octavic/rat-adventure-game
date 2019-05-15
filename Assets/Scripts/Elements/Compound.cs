using UnityEngine;
using System.Collections;

public class Compound
{
	public static readonly Compound Water = new Compound(CompoundNames.Water, "H2O");
	public static readonly Compound Oxygen = new Compound(CompoundNames.Oxygen, "O2");
	public static readonly Compound Hydrogen = new Compound(CompoundNames.Hydrogen, "H2");

	public CompoundNames CompoundName { get; private set; }
	public string Formula { get; private set; }

	private Compound(CompoundNames name, string formula)
	{
		this.CompoundName = name;
		this.Formula = formula;
	}
}
