using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class TransitLevel : MonoBehaviour {

    public int playerId = 0;
    public LevelSelection select;

    private void Update()
    {
        if (ReInput.players.GetPlayer(playerId).GetButtonDown("UISubmit"))
        {
            select.LoadScene();
        }
    }
}
