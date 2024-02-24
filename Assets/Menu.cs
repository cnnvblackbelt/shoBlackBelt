using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button MainMenu;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    private void OnEnable()
    {
        MainMenu.onClick.AddListener(StartGame);
    }

    private void OnDisable()
    {
        MainMenu.onClick.RemoveListener(StartGame);
    }

    private void StartGame()
    {
        Time.timeScale = 1f;
        MainMenu.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
