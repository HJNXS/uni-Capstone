using NUnit.Framework;
using UnityEngine;

namespace JMiles42.ItemSystem
{
	public static class AddItemToInventoryTests
	{
		[Test(Author = "JMiles42")]
		public static void CheckAddItem()
		{
			var go  = new GameObject("Tester");
			var com = go.AddComponent<AddItemToInventory>();
			com.Inventory = ScriptableObject.CreateInstance<Inventory>();
			var item = com.ItemToAdd = ScriptableObject.CreateInstance<Item>();

			Assert.NotNull(com.AddItem());
		}

		[Test(Author = "JMiles42")]
		public static void CheckAddItem2()
		{
			var go  = new GameObject("Tester");
			var com = go.AddComponent<AddItemToInventory>();
			com.Inventory = ScriptableObject.CreateInstance<Inventory>();
			var item = com.ItemToAdd = ScriptableObject.CreateInstance<Item>();

			Assert.NotNull(com.AddItem(item));
		}
	}
}