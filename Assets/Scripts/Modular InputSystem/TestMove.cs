using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour {

    private IInputManager input;
    Rigidbody rb;
    public int playerId;
    public int speed;
    [SerializeField] Vector3 velDisplay;
    // Use this for initialization
    void Start () {
        input = InputManager.instance;
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (input.GetButton(0, InputAction.Interact))
        {
            transform.position += Vector3.up;
        }
    }

    //This function is for the Input Manager to call
    //TODO: Consolidate this function and all like it in to a single player actions script
    public void Move(Vector3 movementVector)
    {
        movementVector.Normalize();
        rb.velocity = movementVector * speed;
        if (movementVector != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
        }
    }



    private void FixedUpdate()
    {
        float h = input.GetAxisRaw(0, InputAction.MoveHorizontal);
        float v = input.GetAxisRaw(0, InputAction.MoveVertical);

        Debug.Log(h);
        Vector3 moveVector = new Vector3(-h, 0, -v);
        moveVector.Normalize();
        velDisplay = rb.velocity;

        if (moveVector != Vector3.zero)
        {
            rb.velocity = moveVector * speed;
            transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
        }
    }
}
