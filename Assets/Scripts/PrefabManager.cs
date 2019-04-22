using UnityEngine;
using System.Collections;

public class PrefabManager : MonoBehaviour
{
	public static PrefabManager CurrentInstance
	{
		get
		{
			if (_currentInstance == null)
			{
				_currentInstance = GameObject.FindObjectOfType<PrefabManager>();
			}
			return _currentInstance;
		}
	}
	private static PrefabManager _currentInstance;

	public StaticPromptUI StaticPromptPrefab;
}
