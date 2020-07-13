using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Add to list in here

    public void SendInfo(Transform transform)
    {
        GetComponent<StateController>().lightInfoPos.Add(transform);
    }
}
