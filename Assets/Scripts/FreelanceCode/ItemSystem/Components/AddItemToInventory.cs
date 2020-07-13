using System;
using UnityEngine;

namespace JMiles42.ItemSystem
{
	public class AddItemToInventory: MonoBehaviour
	{
		public Inventory Inventory;
		public Item      ItemToAdd;

        [ContextMenu("Add Item")]
		public ItemStack AddItem()
		{
			return AddItem(ItemToAdd);
		}

		public ItemStack AddItem(Item item)
		{
			if(Inventory == null)
				throw new NullReferenceException("The Inventory reference is null, please assign in editor, or via another script.");

			return Inventory.Add(item);
		}
	}
}