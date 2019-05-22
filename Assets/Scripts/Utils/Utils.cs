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
			GameObject.Destroy(obj.transform.GetChild(0).gameObject);
		}
	}

	public static Color WithAlpha(this Color c, float newAlpha)
	{
		return new Color(c.r, c.g, c.b, newAlpha);
	}

	public static Vector3 WithZ(this Vector3 v, float z)
	{
		return new Vector3(v.x, v.y, z);
	}
}