using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public Text scoreText;

    public void AddToScore(int num)
    {
        score += num;
        scoreText.text = "Score:" + score.ToString();
    }
    public int getScore()
    {
        return score;
    }
}
