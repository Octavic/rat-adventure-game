using UnityEngine;
using System.Collections;

public abstract class BaseInventoryEntity : MonoBehaviour
{
	public GameObject Boarder;
	public static BaseInventoryEntity CurrentlySelected;

	public void OnClick()
	{
		if (CurrentlySelected == null)
		{
			CurrentlySelected = this;
			this.Boarder.SetActive(true);
		}
		else
		{
			CurrentlySelected.Boarder.SetActive(false);
			if (CurrentlySelected != this)
			{
				CurrentlySelected = this;
			}
			else
			{
				CurrentlySelected = null;
			}
		}
	}

	// Use this for initialization
	protected virtual void Start()
	{

	}

	// Update is called once per frame
	protected virtual void Update()
	{

	}
}
