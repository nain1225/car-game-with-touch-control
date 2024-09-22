using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menuUi;
    public GameObject PlayerUI;
    public static bool isgameStopped = false;

    public void Resume()
    {
        menuUi.SetActive(false);
        PlayerUI.SetActive(true);
        Time.timeScale = 1f;
        isgameStopped = false;
    }
    public void Pause()
    {
        PlayerUI.SetActive(false);
        menuUi.SetActive(true);
        Time.timeScale = 0f;
        isgameStopped = true;
    }
    public void Restart()
    {
        SceneManager.LoadScene("scene_day");
        Time.timeScale = 1f;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Garage");
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
