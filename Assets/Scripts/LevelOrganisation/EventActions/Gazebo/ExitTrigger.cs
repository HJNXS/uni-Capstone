using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour {

    public GameEvent SwitchLvl;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SwitchLvl.Invoke();
        }
    }
}
