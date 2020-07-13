
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehaviour : MonoBehaviour {

    public GameEvent stunnedEvent;
    private Animator anim;
    private PlayerController playerController;
    //public ParticleSystem particleSystem;
    public bool isStunned = false;
    public float waitTime = 5f;


    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }
	

    public void Stun()
    {
        StartCoroutine(Stunned());
    }


    private IEnumerator Stunned()
    {
        yield return StunEffect();
    }

    private IEnumerator StunEffect()
    {
        isStunned = true;
        Debug.Log("Stunned");
        anim.SetTrigger("StunStart");
        stunnedEvent.Invoke();
        //particleSystem.Play();
		playerController.moveSettings.allowedMovement = false;
        yield return new WaitForSeconds(waitTime);
        anim.SetTrigger("StunEnd");
        isStunned = false;
		playerController.moveSettings.allowedMovement = true;
        //particleSystem.Stop();
    }
}
