using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColor : MonoBehaviour {

    public void ChangeRed()
    {
        transform.GetComponent<Light>().color = Color.red;
    }
}
