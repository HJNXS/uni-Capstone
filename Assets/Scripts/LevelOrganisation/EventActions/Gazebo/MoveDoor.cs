using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoor : MonoBehaviour {

    private Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }

    public void RotateDoor()
    {
        anim.Play();
        //transform.Rotate(new Vector3(0, 0, 1), 100f);
    }
}
