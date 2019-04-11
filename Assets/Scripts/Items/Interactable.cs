using UnityEngine;
using System.Collections;

public interface Interactable 
{
	bool IsEnabled();
	void OnInteract();
}
