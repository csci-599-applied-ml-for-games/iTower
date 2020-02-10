using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu, optionsMenu;

    public void Options()
    {
        if (optionsMenu.activeSelf) // if the options menu is active
        {
            mainMenu.SetActive(true);
            optionsMenu.SetActive(false);
        }
        else  // if the options menu is not active
        {
            mainMenu.SetActive(false);
            optionsMenu.SetActive(true);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
