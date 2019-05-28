using UnityEngine;
using System.Collections;

public static class Config 
{
	public static Color OutOfRangeColor = new Color(0.7f, 0.7f, 0.7f);
	public static Color InRangeColor = new Color(1, 1, 1);

	public static class Scenes
	{
		public const int TitleScene = 0;
		public const int PlayScene = 1;
		public const int DemoEndScene = 2;
	}
}
