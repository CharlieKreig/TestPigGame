using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public GameObject WinPanel;
    public GameObject GameOverPanel;
    public void WinGame()
    {
        Time.timeScale = 0f; 
        WinPanel.SetActive(true);
    }
    public void GameOver()
    {
        Time.timeScale = 0f; 
        GameOverPanel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f; 
    }
}
