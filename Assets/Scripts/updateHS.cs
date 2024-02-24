using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateHS : MonoBehaviour
{
    [Header("Text object")]
    public Text HighScore;
    // Start is called before the first frame update
    void Start()
    {
        HighScore.text = "Highscore:" + PlayerPrefs.GetInt("hiScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
