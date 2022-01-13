using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Renders the gamescene
    public void PlayGame()
    {
        SceneManager.LoadScene(1);

        //(SceneManager.GetActiveScene().buildIndex + 1)
    }

    //Closes the application
    public void ExitGame()
    {
        Application.Quit();
    }

}
