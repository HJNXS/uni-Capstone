using System.Collections;
using System.Collections.Generic;
using JMiles42.ItemSystem;
using UnityEngine;

[CreateAssetMenu(fileName = "CyanCollectedCheck", menuName = "Puzzle/Checks/Gazebo/ItemCollectedCheck")]
public class ItemCollectedCheck : PuzzleCheck {

    public Item item;

	public int amount;

    public override bool Check(Inventory invent)
    {
		if (amount > 0)
		{
			if (invent.CheckAmount(item) >= amount && !oneTime)
			{
				oneTime = true;
				return true;
			}
		}
        return false;
    }
}
