
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour {

    public GameEvent gameEvent;
    public List<CollectPointObject> collectedPoints = new List<CollectPointObject>();

    private Text scoreText;
    private int score = 0;

    private void Start()
    {
        scoreText = GetComponent<Text>();
        UpdateScoreElement();
    }
    // Use this for initialization
    public void IncreaseScore(int amount)
    {
        score += amount;        
        UpdateScoreElement();
        CheckForCompletion();
    }


    void UpdateScoreElement()
    {
        scoreText.text = "Score: " + score;
    }

    void CheckForCompletion()
    {
        Debug.Log(collectedPoints.Count);
        if (collectedPoints.Count <= 1)
        {
            Debug.Log("Complete Level");
            gameEvent.Invoke();
        }
    }
}
