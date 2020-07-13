using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

/// <summary>
/// StealItem stores the functionality of stealing an item,
/// which displays a series of combination and handles input.
/// </summary>
/// <remarks>Using InputHandler as component to call coroutine inside
/// scriptable object. May introduce coupling issues.
/// </remarks>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <SecondContributor>Daniel Newman</SecondContributor>
/// <LastEdited>28/07/18</LastEdited>
[CreateAssetMenu(menuName = "Actions/Steal")]
public class StealItem : OldAction {

	public int playerId = 0;
    private StealComboGenerator steal;
    private Queue<CombinationElement> combo;
    public CombinationElement[] displayArray;
	
	public override void Execute(GameObject player, GameObject target, bool isAllowed)
	{
		if (player.GetComponent<PlayerController>().moveSettings.allowedMovement)
		{
			target.GetComponent<PopupScript>().IsInteractable = false;
			steal = target.GetComponentInParent<StealComboGenerator>();
			if (steal)
			{
				steal.Execute(target);
				combo = steal.ComboPool;
				player.GetComponent<InputHandler>().StartCoroutine(HandleStealing(player, target));
				return;
			}
		}
	}

    IEnumerator HandleStealing(GameObject player, GameObject target)
    {
        player.GetComponent<PlayerController>().moveSettings.allowedMovement= false;
        while (combo.Count > 0)
        {
            CombinationElement current = combo.Peek();
            Debug.Log(current.inputComparitor.ToString());

            /*Controller implementation*/
            Debug.Log(ReInput.players.GetPlayer(playerId).GetAxisPrev("Vertical"));
            if (ReInput.players.GetPlayer(playerId).GetAxis("Vertical") == 1 && ReInput.players.GetPlayer(playerId).GetAxisPrev("Vertical") == ReInput.players.GetPlayer(playerId).GetAxis("Vertical") && current.inputComparitor.Equals(ComboItems.Up)) //up
            {
                combo.Dequeue();
                steal.redraw = true;
            }
            else if (ReInput.players.GetPlayer(playerId).GetAxis("Vertical") == -1  && ReInput.players.GetPlayer(playerId).GetAxisPrev("Vertical") == ReInput.players.GetPlayer(playerId).GetAxis("Vertical") && current.inputComparitor.Equals(ComboItems.Down)) //down
            {
                combo.Dequeue();
                steal.redraw = true;
            }
            else if (ReInput.players.GetPlayer(playerId).GetAxis("Horizontal") == -1  && ReInput.players.GetPlayer(playerId).GetAxisPrev("Horizontal") ==  ReInput.players.GetPlayer(playerId).GetAxis("Horizontal") && current.inputComparitor.Equals(ComboItems.Left)) //left
            {
                combo.Dequeue();
                steal.redraw = true;
            }
            else if (ReInput.players.GetPlayer(playerId).GetAxis("Horizontal") == 1  && ReInput.players.GetPlayer(playerId).GetAxisPrev("Horizontal") == ReInput.players.GetPlayer(playerId).GetAxis("Horizontal") && current.inputComparitor.Equals(ComboItems.Right)) //right
            {
                combo.Dequeue();
                steal.redraw = true;
            }
            else if (ReInput.players.GetPlayer(playerId).GetButtonDown("A") && current.inputComparitor.Equals(ComboItems.A)) //A
            {
                combo.Dequeue();
                steal.redraw = true;
            }
            else if (ReInput.players.GetPlayer(playerId).GetButtonDown("B") && current.inputComparitor.Equals(ComboItems.B)) //B
            {
                combo.Dequeue();
                steal.redraw = true;
            }
            else if (ReInput.players.GetPlayer(playerId).GetButtonDown("X") && current.inputComparitor.Equals(ComboItems.X)) //X
            {
                combo.Dequeue();
                steal.redraw = true;
            }
            else if (ReInput.players.GetPlayer(playerId).GetButtonDown("Y") && current.inputComparitor.Equals(ComboItems.Y)) //Y
            {
                combo.Dequeue();
                steal.redraw = true;
            }
            else if (ReInput.players.GetPlayer(playerId).GetButtonDown("LB") && current.inputComparitor.Equals(ComboItems.LB)) //LB
            {
                combo.Dequeue();
                steal.redraw = true;
            }
            else if (ReInput.players.GetPlayer(playerId).GetButtonDown("LT") && current.inputComparitor.Equals(ComboItems.LT)) //LT
            {
                combo.Dequeue();
                steal.redraw = true;
            }
            else if (ReInput.players.GetPlayer(playerId).GetButtonDown("RB") && current.inputComparitor.Equals(ComboItems.RB)) //RB
            {
                combo.Dequeue();
                steal.redraw = true;
            }
            else if (ReInput.players.GetPlayer(playerId).GetButtonDown("RT") && current.inputComparitor.Equals(ComboItems.RT)) //RT
            {
                combo.Dequeue();
                steal.redraw = true;
            }



            yield return null;
        }

        // stealing is successfull, then do ...
        player.GetComponent<PlayerController>().moveSettings.allowedMovement= true;
        target.GetComponent<ItemDescription>().itemEvent.Invoke();
        disposeItem(target, player);

    }

    public void disposeItem(GameObject obj, GameObject player)
    {
        obj.layer = LayerMask.NameToLayer("Default");
		player.GetComponent<FindInteractObjCollision>().Invicinity.Remove(obj);
        Destroy(obj);
    }
}
