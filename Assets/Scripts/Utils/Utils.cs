using System;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
	public static Dictionary<T, U> DictionaryFromLists<T, U>(IList<T> keys, IList<U> values)
	{
		if (keys.Count != values.Count)
		{
			throw new ArgumentException("Mismatch keys/values count");
		}

		var result = new Dictionary<T, U>();
		for (int i = 0; i < keys.Count; i++)
		{
			result[keys[i]] = values[i];
		}

		return result;
	}

	public static void DestroyAllChildren(this GameObject obj)
	{
		for(var i = 0; i < obj.transform.childCount; i++)
		{
			GameObject.Destroy(obj.transform.GetChild(0));
		}
	}
}