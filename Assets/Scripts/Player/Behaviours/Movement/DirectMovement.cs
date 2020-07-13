using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;


public class DirectMovement : MonoBehaviour {

    public int playerId;
    [SerializeField] float speed;
    [Range(0.1f,1.0f)]
    [SerializeField] float noiseDelay;
    Rigidbody rb;
    Transform camTransform;
    //Attributes noise;
    [HideInInspector] public Vector3 lastVel;

    // Use this for initialization
    void Start () {
        camTransform = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        //noise = GetComponent<AvailableAttributes>().FindAttribute(ItemAttributes.Noise);
        StartCoroutine(MakingNoise());
    }
	
    public void Sneak() {
        speed /= 2;
        StopAllCoroutines();
    }

    public void StopSneak() {
        speed *= 2;
        StartCoroutine(MakingNoise());
    }



	// Update is called once per frame
	void FixedUpdate ()
    {
        float h = 0.0f;
        float v = 0.0f;

        h = ReInput.players.GetPlayer(playerId).GetAxisRaw("Horizontal");
        v = ReInput.players.GetPlayer(playerId).GetAxisRaw("Vertical");

        Vector3 moveVector = v * camTransform.forward + h * camTransform.right;
        moveVector.Normalize();
        rb.velocity = moveVector * speed;
        if (moveVector != Vector3.zero)
        {
            lastVel = rb.velocity;
            transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
        }


    }

    private IEnumerator MakingNoise()
    {

        while (true)
        {
            if (rb.velocity.magnitude > 1)
            {
                //NoiseHandler.instance.Execute((Noise)noise, gameObject.transform);               
            }
            yield return new WaitForSeconds(noiseDelay);
        }
    }
}
