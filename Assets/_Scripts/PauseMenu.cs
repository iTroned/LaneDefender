using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    //GIP bool variable
    public static bool gameIsPaused = false;

    //The different GUIs
    public GameObject PauseMenuUI;
    public GameObject ConfirmationUI;
    public GameObject yesQuitButton;
    public GameObject yesMenuButton;
    public GameObject OutLay;

    public WinScreen ws;

    void Start()
    {
       ws = GameObject.Find("Canvas").GetComponent<WinScreen>();
    }

    //Returns the (GameIsPaused)GIP variable to be used in other scripts
    public bool GetGIP()
    {
        return gameIsPaused;
    }

    void Update()
    {
        //Always running the method to update the variable
        GetGIP();
        
                                                           // v - so that you cant use 'escape' to leave the menu
        if (Input.GetKeyDown(KeyCode.Escape) && (gameIsPaused == false) && (ws.GetGIPW() == false))
        {                                                                              // ^ - so that you cant open the pausemenu when the winscreen is active

            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        //Disabling the rest of the GUI when the game is paused
        if (gameIsPaused)
        {
            OutLay.SetActive(false);

        }
    }

    //ONCLICK 'Resume' in PauseMenu
    public void Resume()
    {
        gameIsPaused = false;

        //deavtivate Pausemenu
        PauseMenuUI.SetActive(false);
        ConfirmationUI.SetActive(false);

        //reset timeScale
        Time.timeScale = 1f;

        //activate rest of GUI
        OutLay.SetActive(true);
    }


    //When pressing 'escape'
    private void Pause()
    {
        PauseMenuUI.SetActive(true);

        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    //ONCLICK 'menu' in PauseMenu
    public void LoadMenu()
    {
        ConfirmationUI.SetActive(true);
        PauseMenuUI.SetActive(false);

        yesQuitButton.SetActive(false);
        yesMenuButton.SetActive(true);

    }

    //ONCLICK 'quit' in PauseMenu
    public void QuitGame()
    {
        ConfirmationUI.SetActive(true);
        PauseMenuUI.SetActive(false);
        yesMenuButton.SetActive(false);
        yesQuitButton.SetActive(true);
    }

    //ONCLICK 'yes' (agree go to menu)
    public void YesMenu()
    {
        gameIsPaused = false;
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    //ONCLICK 'no' (both confirmation-menus)
    public void No()
    {
        ConfirmationUI.SetActive(false);
        PauseMenuUI.SetActive(true);

    }

    //ONCLICK 'yes' (agree to quit game) 
    public void YesQuitPause()
    {
        Application.Quit();
    }

    
}
