using UnityEngine;
using System.Collections.Generic;


public static class ItemInteraction 
{
	private class ItemPair
	{
		ItemNames ItemA;
		ItemNames ItemB;
		public ItemPair(ItemNames itemA, ItemNames itemB)
		{
			this.ItemA = itemA;
			this.ItemB = itemB;
		}
		public override bool Equals(object obj)
		{
			ItemPair b = obj as ItemPair;
			if (b == null)
			{
				return base.Equals(b);
			}

			return (this.ItemA == b.ItemA && this.ItemB == b.ItemB) 
				|| (this.ItemA == b.ItemB && this.ItemB == b.ItemA);
		}
	}

	private static Dictionary<ItemPair, ItemNames> ItemInteractions = new Dictionary<ItemPair, ItemNames>()
	{
		{ new ItemPair(ItemNames.OxygenBalloon, ItemNames.Needle), ItemNames.EmptyBalloon },
		{ new ItemPair(ItemNames.HydrogenBalloon, ItemNames.Needle), ItemNames.EmptyBalloon },
		{ new ItemPair(ItemNames.DangerousBalloon, ItemNames.Needle), ItemNames.EmptyBalloon },
	};
}
