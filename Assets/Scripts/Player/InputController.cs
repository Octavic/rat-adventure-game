using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
	public static Canvas MainCanvas
	{
		get
		{
			if (_mainCanvs == null)
			{
				_mainCanvs = GameObject.FindObjectOfType<Canvas>();
			}
			return _mainCanvs;
		}
	}
	private static Canvas _mainCanvs;
}
