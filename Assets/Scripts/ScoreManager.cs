using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // singleton instance of the ScoreManager

    public int score; // current score

    private void Awake()
    {
        // initialize the singleton instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void AddPoints(int points)
    {
        // add points to the score
        score += points;
    }

    public void ResetScore()
    {
        // reset the score to 0
        score = 0;
    }
}
