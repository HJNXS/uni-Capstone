using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public Material Dark;

    // Use this for initialization
    public void Off()
    {
        Material[] mats = GetComponent<Renderer>().materials;

        mats[0] = Dark;
        mats[1] = Dark;

        GetComponent<Renderer>().materials = mats;
    }
}
