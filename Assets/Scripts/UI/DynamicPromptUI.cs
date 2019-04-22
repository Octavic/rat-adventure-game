using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DynamicPromptUI : MonoBehaviour
{
	public List<DynamicMessage> Messages;

	[Serializable]
	public class DynamicMessageOption
	{
		public string Option;
		public string NextMessageName;
		public string EventEmitted;
	}

	[Serializable]
	public class DynamicMessage
	{
		/// <summary>
		/// A unique identifier to 
		/// </summary>
		public string Name;

		/// <summary>
		/// The actual message itself
		/// </summary>
		public string Message;

		/// <summary>
		/// The list  of options that the player can choose from
		/// </summary>
		public List<DynamicMessageOption> Options;
	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
