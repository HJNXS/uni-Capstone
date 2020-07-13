using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

	void PickUpItem(GameObject target)
    {
        if (target.GetComponent<CollectPointObject>())
            target.GetComponent<CollectPointObject>().Collect();
            
    }
}
