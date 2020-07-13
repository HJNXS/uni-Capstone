using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {
    //changes colour of wire to green

    public Renderer wire;
    public Material ActiveWire;

    private void Start()
    {

    }


    public void LeverFlipped()
    {  
        Material[] mats = wire.materials;
        mats[0] = ActiveWire;
        wire.materials = mats;
    }
}
