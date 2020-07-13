using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using System;
//using System.Data;
using JMiles42.ItemSystem;
//using Mono.Data.Sqlite;

public class HighScoreManager : MonoBehaviour {

    /*private string connectionString;

    private List<HighScore> highScores = new List<HighScore>();

    public GameObject scorePrefab;

    public Transform scoreParent;

    public int topRanks = 5;

	public Inventory inventory; //need to find a better place to put Clear inventory

	public LevelLists levelLists;

	private void OnEnable()
	{
		levelLists.index = 0;
		inventory.ClearInventory();
	}

	// Use this for initialization
	void Start () {
        connectionString = "URI=file:" + Application.dataPath + "/Database/HighScoreDB.sqlite";
        InsertScore("Player", PlayerPrefs.GetInt("Profit"));
        //DeleteScore(2);
        //GetScores();
        ShowScores();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void InsertScore(string name, int newScore)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = string.Format("INSERT INTO HighScore(Name, Score) VALUES(\'{0}\', {1})", name, newScore);

                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
            }
        }
    }

    private void GetScores()
    {
        highScores.Clear();

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM HighScore";

                dbCmd.CommandText = sqlQuery;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        highScores.Add(new HighScore(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
        highScores.Sort();
    }

    private void DeleteScore(int id)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = string.Format("DELETE FROM HighScore WHERE PlayerID = {0}",id);

                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
            }
        }
    }

    private void ShowScores()
    {
        GetScores();
        for (int i = 0; i < topRanks; i++)
        {
            if (i <= highScores.Count - 1)
            {
                GameObject tmpObj = Instantiate(scorePrefab);

                HighScore tmpScore = highScores[i];

                tmpObj.GetComponent<HighScoreScrpt>().SetScore((i + 1).ToString(), tmpScore.Name, tmpScore.Score.ToString());

                tmpObj.transform.SetParent(scoreParent);

                tmpObj.GetComponent<RectTransform>().localScale = new Vector3(7.922966f, 0.6190367f, 1);
            }
        }
        
    }*/
}
