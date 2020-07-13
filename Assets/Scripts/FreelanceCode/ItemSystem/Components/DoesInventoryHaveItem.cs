using System;
using UnityEngine;

namespace JMiles42.ItemSystem
{
	public class DoesInventoryHaveItem: MonoBehaviour
	{
		public Inventory Inventory;
		public Item      ItemToSearchFor;

		public bool DoesInventoryContainItem()
		{
			return DoesInventoryContainItem(ItemToSearchFor);
		}

		public bool DoesInventoryContainItem(Item item)
		{
			if(Inventory == null)
				throw new NullReferenceException("The Inventory reference is null, please assign in editor, or via another script.");

			return Inventory.FindStack(item);
		}

		public ItemStack GetItemStackFromInventory()
		{
			return GetItemStackFromInventory(ItemToSearchFor);
		}

		public ItemStack GetItemStackFromInventory(Item item)
		{
			if(Inventory == null)
				throw new NullReferenceException("The Inventory reference is null, please assign in editor, or via another script.");

			return Inventory.FindStack(item);
		}
	}
}