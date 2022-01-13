    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinScreen : MonoBehaviour
{
    //Bool variable for pausing game
    public static bool gameIsPaused = false;

    //GUIs
    public GameObject WinScreenUI;
    public GameObject OutLay;

    //Winnertext
    public TextMeshProUGUI Winner;

    //Info for the two cannons
    private CannonInfo Cinfo1;
    private CannonInfo Cinfo2;

    void Start()
    {
        Cinfo1 = GameObject.Find("CoreP1").GetComponent<CannonInfo>();
        Cinfo2 = GameObject.Find("CoreP2").GetComponent<CannonInfo>();

    }
    
    //Returns the (GameIsPaused)GIP variable to be used in other scripts
    public bool GetGIPW()
    {
        return gameIsPaused;
    }

    void Update()
    {
        //Always running the method to update the variable
        GetGIPW();
        
        //Checking if the cannon 'died'
        if (Cinfo2.dead == true)
        {
            Winner.text = "Player1 WINS!";
        }

        if (Cinfo1.dead == true)
        {
            Winner.text = "Player2 WINS!";
        }
        
        //When the WinScreen is active
        if (WinScreenUI.activeSelf)
        {
            Time.timeScale = 0f;

            gameIsPaused = true;

            OutLay.SetActive(false);

        }

    }

    //ONCLICK 'restart' on WinScreen GUI; loads start screen, unpauses game and disables the WinScreen GUI
    public void Restart()
    {
        SceneManager.LoadScene(1);

        gameIsPaused = false;
        Time.timeScale = 1f;
        WinScreenUI.SetActive(false);
    }

    //ONCLICK 'return'; loads the game-scene to refresh the game
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }


}
