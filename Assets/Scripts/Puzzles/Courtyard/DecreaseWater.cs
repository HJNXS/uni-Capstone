using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseWater : MonoBehaviour {

	int index = 0;

    public Transform trapDoor;
	/// <summary>
	/// List of gameevent to lower the water and open trap door
	/// </summary>
	/// <remarks>Need to be in order of the water level decrease</remarks>
	public List<GameEvent> waterLevelDec;
    public GameObject player;
    public GameObject exitCollider;
    [HideInInspector] public FindInteractObjCollision interactObjColScript;

    private void Start()
    {
        interactObjColScript = player.GetComponentInChildren<FindInteractObjCollision>();
    }

    public void decreaseWater()
	{
		waterLevelDec[index].Invoke();
        index++;
        if (index == 4)
            OpenTrapDoor();
	}

    public void OpenTrapDoor()
    {
        trapDoor.Rotate(new Vector3(0, 1, 0), 110f);
        exitCollider.GetComponent<BoxCollider>().enabled = true;
    }


    //TODO:
    //Add a method to allow the player into the fountain
    //Play animation,
    //Move the characters pos into fountain. 
    //needs a popup
	
}
