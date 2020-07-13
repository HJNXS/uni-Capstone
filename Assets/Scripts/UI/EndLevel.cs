using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndLevel : MonoBehaviour {

	public GameEvent gameEvent;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
            gameEvent.Invoke();
    }

}
