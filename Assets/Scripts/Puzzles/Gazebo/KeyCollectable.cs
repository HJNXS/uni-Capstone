using ForestOfChaosLib.Extensions;
using System;
using UnityEngine;

public class KeyCollectable : MonoBehaviour
{
    public static event Action<KeyCollectable> OnPickUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            OnPickUp.Trigger(this);
            gameObject.SetActive(false);
        }
    }
}
