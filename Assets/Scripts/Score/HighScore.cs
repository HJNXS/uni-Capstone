using System.Collections;
using System.Collections.Generic;
using System;

public class HighScore : IComparable<HighScore>{

    public int Score { get; set; }
    public string Name { get; set; }
    public int ID { get; set; }

    public HighScore(int id, string name, int score)
    {
        this.ID = id;
        this.Name = name;
        this.Score = score;
    }

    public int CompareTo(HighScore other)
    {
        // first > second return -1
        //first < second return 1
        //first == second return 0

        if (other.Score < this.Score)
        {
            return -1;
        } else if (other.Score > this.Score)
        {
            return 1;
        }
        return 0;
    }
}
