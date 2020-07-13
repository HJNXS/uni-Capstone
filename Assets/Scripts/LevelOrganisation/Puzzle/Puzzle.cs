using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JMiles42.ItemSystem;

/// <summary>
/// Puzzle is a scriptable object which check if puzzle check (condition)
/// has been met. If so, it triggers an event for that condition being met.
/// </summary>
/// <remarks>Attached to a LevelScene</remarks>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>01/08/18</LastEdited>
[CreateAssetMenu(fileName = "New Puzzle", menuName = "Puzzle/New Puzzle")]
public class Puzzle : ScriptableObject // can use scriptable, puzzle just check if complete then fire an event to tell all object do there thing
{
    public Inventory inventory;

    /*Note: gameEvent and puzzleCheck index should map to each other*/

    public GameEvent[] gameEvent; //FIX: Need to us a better data structure to regroup event and puzzlecheck

    public PuzzleCheck[] puzzleCheck;

    //public void OnPuzzleComplete(); //change this to an event

    // use inventory.findItem to check if we have the item
    // use an if statement then call OnPuzzleComplete //need to make something like decision
    public void UpdatePuzzle()
    {
        for (int i = 0; i < puzzleCheck.Length; i++)
        {
            if (puzzleCheck[i].Check(inventory))
            {
               gameEvent[i].Invoke();
            }
        }
        
    }
    
}
