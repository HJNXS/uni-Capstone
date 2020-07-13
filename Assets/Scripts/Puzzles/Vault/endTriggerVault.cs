using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class endTriggerVault : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("ScoreBoard");
    }
}
