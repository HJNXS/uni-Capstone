/*
* Author: Daniel Newman
* Last Edited: 24/05/18
* Summary: Container class that houses all the available actions
* that can be done to an object.
* All actions are defined as ScriptableObjects and cannot be applied to gameobject
* without Monobehaviour scripts
* 
* TODO: After more research into SO's, These can be refactored so that they dont need this container class
* Instead can use events that relate to references of the appropriate action. Simplify!
*/
using System.Collections.Generic;
using UnityEngine;

public class AvailableActions : MonoBehaviour {

    [SerializeField] List<Action> actionList = new List<Action>();
	
	public Action FindAction(string name)
    { /*
        foreach(Action action in actionList)
        {
            if (action.GetName() == name)
                return action;
        } */
        return null;
    }

    void printAvailableActions()
    {
        foreach(Action action in actionList)
        {
            //print(action.GetName());
        }
    }
}
