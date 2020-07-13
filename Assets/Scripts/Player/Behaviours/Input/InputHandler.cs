using HardlightAnvil.RunWithIt.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using JMiles42.ItemSystem;

/// <summary>
/// InputHandler handles the input and their respective action associated with input on an item.
/// </summary>
/// <PrimaryContributor>Daniel Newman</PrimaryContributor>
/// <SecondContributor>Dinys Monvoisin</SecondContributor>
/// <LastEdited>28/07/18</LastEdited>
public class InputHandler : MonoBehaviour {

	private IInputManager input;

	[Header("Interactable Objects Inventory")]
	public Inventory inventory;

	[Header("Entity Buttons")]
	/*Need to look how to create a serialisable dictionary in unity*/
	public List<ButtonScriptable> buttonScriptables;

	public bool IsAllowed { private get; set; }

    // Use this for initialization
    void Start () {
		input = InputManager.instance;
		IsAllowed = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
		GetInput();
	}
	
	/// <summary>
	/// Get input from user and call methods.
	/// </summary>
	void GetInput()
	{
		if (ReInput.players.GetPlayer(0).GetButtonDown("A"))
		{
			executeButton("A");
		}

		if (ReInput.players.GetPlayer(0).GetButtonDown("B"))
		{
			executeButton("B");
		}
	}

	/// <summary>
	/// Execute the actions on match of button name in list.
	/// </summary>
	/// <param name="buttonName"></param>
	private void executeButton(string buttonName)
	{
		foreach (var button in buttonScriptables)
		{
			if (button.buttonName == buttonName)
			{
				executeActionOnObj(button);

			}
		}
	}

	/// <summary>
	/// Execute the action of the button and on the objects required.
	/// </summary>
	/// <param name="button"></param>
	private void executeActionOnObj(ButtonScriptable button)
	{
		foreach (GameObject interactableObj in transform.GetComponentInChildren<FindInteractObjCollision>().Invicinity)
		{
			for (int i = 0; i < button.actionLayerMask.Count; i++)
			{
				if (((1 << interactableObj.gameObject.layer) & button.actionLayerMask[i].value) != 0)
				{
					button.buttonAction[i].Execute(transform.gameObject, interactableObj, IsAllowed);
				}
			}
		}
	}
}
