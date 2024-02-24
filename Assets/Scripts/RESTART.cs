using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RESTART : MonoBehaviour
{
    public Button Replay;
    public Button Menu;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    private void OnEnable()
    {
        Replay.onClick.AddListener(StartGame);
        Menu.onClick.AddListener(MenuStart);

    }

    private void OnDisable()
    {
        Replay.onClick.RemoveListener(StartGame);
        Menu.onClick.RemoveListener(MenuStart);

    }

    private void StartGame()
    {
        Time.timeScale = 1f;
        Replay.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }
    private void MenuStart()
    {
        Time.timeScale = 1f;
        Menu.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }

}
