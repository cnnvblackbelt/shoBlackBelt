using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Start : MonoBehaviour
{
    public Button Play;
    public Button TwoPlayer;
    public Button Credits;
    public Button Controls;


    private void Awake()
    {
        Time.timeScale = 1f;
    }

    private void OnEnable()
    {
        Play.onClick.AddListener(StartGame);
        TwoPlayer.onClick.AddListener(StartTwoPlayer);
        Credits.onClick.AddListener(StartCredits);
        Controls.onClick.AddListener(ControlsScene);


    }

    private void OnDisable()
    {
        Play.onClick.RemoveListener(StartGame);
        TwoPlayer.onClick.RemoveListener(StartTwoPlayer);
        Credits.onClick.RemoveListener(StartCredits);
        Controls.onClick.RemoveListener(ControlsScene);

    }

    private void StartGame()
    {
        Time.timeScale = 1f;
        Play.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }

    private void StartCredits()
    {
        Time.timeScale = 1f;
        Play.gameObject.SetActive(false);
        SceneManager.LoadScene(3);
    }

    private void ControlsScene()
    {
        Time.timeScale = 1f;
        Controls.gameObject.SetActive(false);
        SceneManager.LoadScene(4);
    }
    void StartTwoPlayer()
    {
        Time.timeScale = 1f;
        Play.gameObject.SetActive(false);
        SceneManager.LoadScene(5);
    }
}
