using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePanel : MonoBehaviour {

    public ActivateDoor door;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision other)
    {
        door.Invoke(gameObject);
        meshRenderer.material.color = Color.red;
        //door.triggers.Remove(gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }
}
