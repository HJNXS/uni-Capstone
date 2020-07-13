using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Rewired;

public class Controls : MonoBehaviour {

    private bool selected;
    private Button playButton;

    //TODO: add score

    //called on awake, makes sure popup is active, stops all in game movement
    private void Awake()
    {
        gameObject.SetActive(true);
        //Time.timeScale = 0;
        playButton = transform.GetChild(0).GetChild(1).GetComponent<Button>();
        selected = false;
    }

    void Update()
    {
        //checks if player 1 presses any button
        if (ReInput.players.GetPlayer(0).GetAnyButtonDown())
        {
            //sets button to 'highlighted' state on first key press
            if (selected == false)
            {
                playButton.Select();
                playButton.OnSelect(null);
                selected = true;
            }

            //must press enter/select button after highlighted, rather than any key again. 
            
        }
        if (ReInput.players.GetPlayer(0).GetButtonDown("PickUp") && selected)
        {
            Debug.Log("called");
            playButton.onClick.Invoke();
            //should do the same
            //DeactivateControlPopup()
        }
    }

    public void DeactivateControlPopup()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
