using NUnit.Framework;
using UnityEngine;

namespace JMiles42.ItemSystem
{
	public static class DoesInventoryHaveItemTests
	{
		[Test(Author = "JMiles42")]
		public static void CheckReturnWithANullInventoryAndItemOnMethodDoesInventoryContainItem()
		{
			var go  = new GameObject("Tester");
			var com = go.AddComponent<DoesInventoryHaveItem>();
			Assert.False(com.DoesInventoryContainItem());
		}

		[Test(Author = "JMiles42")]
		public static void CheckReturnWithOnMethodDoesInventoryContainItem()
		{
			var go  = new GameObject("Tester");
			var com = go.AddComponent<DoesInventoryHaveItem>();
			com.Inventory       = ScriptableObject.CreateInstance<Inventory>();
			var item = com.ItemToSearchFor = ScriptableObject.CreateInstance<Item>();
			com.Inventory.Add(item);

			Assert.True(com.DoesInventoryContainItem());
		}

		[Test(Author = "JMiles42")]
		public static void CheckReturnWithOnMethodDoesInventoryContainItem2()
		{
			var go  = new GameObject("Tester");
			var com = go.AddComponent<DoesInventoryHaveItem>();
			com.Inventory = ScriptableObject.CreateInstance<Inventory>();
			var item = ScriptableObject.CreateInstance<Item>();
			com.Inventory.Add(item);

			Assert.True(com.DoesInventoryContainItem(item));
		}

		[Test(Author = "JMiles42")]
		public static void CheckReturnWithANullInventoryAndItemOnMethodGetItemStackFromInventory()
		{
			var go  = new GameObject("Tester");
			var com = go.AddComponent<DoesInventoryHaveItem>();
			Assert.Null(com.GetItemStackFromInventory());
		}

		[Test(Author = "JMiles42")]
		public static void CheckReturnWithOnMethodGetItemStackFromInventory()
		{
			var go  = new GameObject("Tester");
			var com = go.AddComponent<DoesInventoryHaveItem>();
			com.Inventory       = ScriptableObject.CreateInstance<Inventory>();
			var item = com.ItemToSearchFor = ScriptableObject.CreateInstance<Item>();
			com.Inventory.Add(item);

			Assert.NotNull(com.GetItemStackFromInventory());
		}

		[Test(Author = "JMiles42")]
		public static void CheckReturnWithOnMethodGetItemStackFromInventory2()
		{
			var go  = new GameObject("Tester");
			var com = go.AddComponent<DoesInventoryHaveItem>();
			com.Inventory = ScriptableObject.CreateInstance<Inventory>();
			var item = ScriptableObject.CreateInstance<Item>();
			com.Inventory.Add(item);

			Assert.NotNull(com.GetItemStackFromInventory(item));
		}

		[Test(Author = "JMiles42")]
		public static void CheckReturnWithOnMethodGetItemStackFromEmptyInventory()
		{
			var go  = new GameObject("Tester");
			var com = go.AddComponent<DoesInventoryHaveItem>();
			com.Inventory       = ScriptableObject.CreateInstance<Inventory>();
			com.ItemToSearchFor = ScriptableObject.CreateInstance<Item>();

			Assert.Null(com.GetItemStackFromInventory());
		}

		[Test(Author = "JMiles42")]
		public static void CheckReturnWithOnMethodGetItemStackFromEmptyInventory2()
		{
			var go  = new GameObject("Tester");
			var com = go.AddComponent<DoesInventoryHaveItem>();
			com.Inventory = ScriptableObject.CreateInstance<Inventory>();
			var item = ScriptableObject.CreateInstance<Item>();

			Assert.Null(com.GetItemStackFromInventory(item));
		}
	}
}