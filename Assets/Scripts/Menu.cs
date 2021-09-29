using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject MenuScreen;
    public int Status = 0;
    public bool inGame;
    public String Winner;
    [SerializeField] private TextMeshProUGUI WinnerText;
    public void Start()
    {
        if (inGame == true)
        {
            MenuScreen.SetActive(false);
        }
        Time.timeScale = 1;
    }

    public void Update()
    {
        if (inGame == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.LogWarningFormat("press");
                Debug.LogWarningFormat(Status.ToString());
                if (Status == 0)
                {
                    MenuScreen.SetActive(true);
                    Status = 1;
                    Time.timeScale = 0;
                }
                else
                {
                    MenuScreen.SetActive(false);
                    Status = 0;
                    Time.timeScale = 1;
                }
            }
        }
    }

    public void PvP()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void Random()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    
    public void MCTS()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void Quit()
    {
        Debug.Log("Le jeu a quitté");
        Application.Quit();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnPVP()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
    public void ReturnRandom()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    
    public void ReturnMCTS()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }

    public void End()
    {
        MenuScreen.SetActive(true);
        Time.timeScale = 0;
        WinnerText.text = Winner+" WIN!!!";
    }
}
