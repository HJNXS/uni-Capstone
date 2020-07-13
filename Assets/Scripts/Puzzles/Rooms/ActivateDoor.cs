using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDoor : MonoBehaviour {

    public List<GameObject> triggers = new List<GameObject>();
    private bool opened = false;

	// Use this for initialization
	void Start ()
    {
	}



    public void Invoke(GameObject pp)
    {
        if (triggers.Contains(pp))
            triggers.Remove(pp);

        if (triggers.Count == 0 && !opened)
        {
            opened = true;
        }
    }



}
