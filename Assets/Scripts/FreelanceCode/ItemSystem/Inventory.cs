using System;
using System.Collections.Generic;
using UnityEngine;

namespace JMiles42.ItemSystem
{
	[CreateAssetMenu(fileName = "New Inventory", menuName = "Item System/New Inventory", order = 0)]
	public class Inventory: ScriptableObject, IJsonSaveable
	{
		[SerializeField] private List<ItemStack> items = new List<ItemStack>();
		public int totalScore = 0;
		/// <summary>
		/// It is recommended not to edit this list e.g. add items, as this could cause duplicate stacks
		/// Use this to loop through the list
		/// </summary>
		public List<ItemStack> Items
		{
			get { return items; }
		}

		public int Count
		{
			get { return items.Count; }
		}

		public int Capacity
		{
			get { return items.Capacity; }
			set { items.Capacity = value; }
		}

        /// <summary>
		/// Adds the item stack to the existing stack, or creates a new stack.
        /// Use in event handler.
		/// </summary>
		/// <param name="item"></param>
		public void Adding(Item item)
        {
            var iStack = FindStack(item);

            if (iStack)
            {
                iStack++;
            } else
            {
                var stack = new ItemStack(item);
                items.Add(stack);
            }
			totalScore += item.Value; 
        }

        /// <summary>
        /// Adds the item stack to the existing stack, or creates a new stack
        /// </summary>
        /// <param name="item"></param>
        /// <returns>The Added or Modified Stack</returns>
        public ItemStack Add(Item item)
		{
			var iStack = FindStack(item);
            
            if (iStack)
			{
				iStack++;

				return iStack;
            }else {
                var stack = new ItemStack(item);
                items.Add(stack);
                return stack;
            }

            return null;
		}

		/// <summary>
		/// Adds the item stack to the existing stack, or creates a new stack
		/// </summary>
		/// <param name="item"></param>
		/// <param name="amount"></param>
		/// <returns>The Added or Modified Stack</returns>
		public ItemStack Add(Item item, int amount)
		{
			var iStack = FindStack(item);

            if (iStack)
			{
				iStack += amount;

				return iStack;
			}else
            {
                var stack = new ItemStack(item);
                items.Add(stack);
                return stack;
            }

            return null;
		}

		/// <summary>
		/// Adds the item stack to the existing stack, or creates a new stack
		/// It adds the Amount of the stack as well
		/// </summary>
		/// <param name="item"></param>
		/// <returns>The Added or Modified Stack</returns>
		public ItemStack Add(ItemStack item)
		{
			var iStack = FindStack(item);

            if (iStack)
            {
                iStack.Amount += item.Amount;

                return iStack;
            }
            else
            {
                var stack = new ItemStack(item);
                items.Add(stack);
                return stack;
            }

            return null;
		}

		/// <summary>
		/// Adds the item stack to the existing stack, or creates a new stack
		/// </summary>
		/// <param name="item"></param>
		public void Remove(Item item, bool ignoreEmptyCheck = false)
		{
			var iStack = FindStack(item);

			if(iStack)
			{
				iStack--;

				if(ignoreEmptyCheck)
					return;

				if(iStack.Amount <= 0)
					items.Remove(iStack);
			}
		}

		/// <summary>
		/// Adds the item stack to the existing stack, or creates a new stack
		/// </summary>
		/// <param name="item"></param>
		/// <param name="amount"></param>
		public void Remove(Item item, int amount, bool ignoreEmptyCheck = false)
		{
			var iStack = FindStack(item);

			if(iStack)
			{
				iStack.Amount -= amount;

				if(ignoreEmptyCheck)
					return;

				if(iStack.Amount <= 0)
					items.Remove(iStack);
			}
		}

		/// <summary>
		/// Adds the item stack to the existing stack, or creates a new stack
		/// It adds the Amount of the stack as well
		/// </summary>
		/// <param name="item"></param>
		public void Remove(ItemStack item, bool ignoreEmptyCheck = false)
		{
			var iStack = FindStack(item);

			if(iStack)
			{
				iStack.Amount -= item.Amount;

				if(ignoreEmptyCheck)
					return;

				if(iStack.Amount <= 0)
					items.Remove(iStack);
			}
		}

		/// <summary>
		/// Finds stack that contains the Item
		/// </summary>
		/// <param name="item"></param>
		/// <returns>The Found Stack</returns>
		public ItemStack FindStack(Item item)
		{
			foreach(var itemStack in items)
			{
				if(itemStack.Item == item)
				{
					return itemStack;
				}
			}

			return null;
		}

		/// <summary>
		/// Finds stack that contains BOTH the Item and >= Amount
		/// </summary>
		/// <param name="item"></param>
		/// <returns>The Found Stack</returns>
		public ItemStack FindStack(ItemStack item)
		{
			foreach(var itemStack in items)
			{
				if((itemStack.Item == item) && (itemStack.Amount >= item.Amount))
				{
					return itemStack;
				}
			}

			return null;
		}

        /// <summary>
		/// Finds the amount of an item.
        /// Use in event handler
		/// </summary>
		/// <param name="item"></param>
		public int CheckAmount(Item item)
        {
            if (item != null)
            {
                foreach (var itemStack in Items)
                {
                    if(item.Name == itemStack.Item.Name) //FIX: Need to compare by name bcuz reference are not equal between scenes.
                    {
                        return itemStack.Amount;
                    }
                }
            }
            return -1; // erroneous data
        }

		public void ClearInventory()
		{
			items.Clear();
		}

        #region SaveLoad
        /// <summary>
        /// Get the data to save to disk from the Inventory, used with "SetLoadedData" to return to current state
        /// </summary>
        /// <returns>Data required to be saved to disk, for the persistent inventory</returns>
        public string GetSaveData()
		{
			return JsonUtility.ToJson(this);
		}

		/// <summary>
		/// Set the data saved from "GetSaveData" usually loaded from disk
		/// </summary>
		/// <param name="json">The string to load from</param>
		public void SetLoadedData(string json)
		{
			JsonUtility.FromJsonOverwrite(json, this);
		}
#endregion
	}
}