using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //Character models which will be retrieved from GameManager
    private GameObject KnightP1;
    private GameObject KnightP2;
    private GameObject HellDogP1;
    private GameObject HellDogP2;
    private GameObject RangerP1;
    private GameObject RangerP2;
   
    //The places the characters will be instantiated
    private Vector3 P1Left;
    private Vector3 P2Left;
    private Vector3 P1Right;
    private Vector3 P2Right;
    private Vector3 P1Going;
    private Vector3 P2Going;

    //Info will be retrieved from GameManager
    private int costKnight;
    private int costRanger;
    private int costHellfish;
    
  
    public bool P1IsLeft = false;
    public bool P2IsLeft = true;

    
    private PauseMenu pm;

    private GameManager ur;

    private WinScreen ws;

    private float timer1;
    private float timer2;
    private float spawnTime = .3f;
    void Start()
    {
        ur = GameObject.Find("Canvas").GetComponent<GameManager>();

        pm = GameObject.Find("Canvas").GetComponent<PauseMenu>();

        ws = GameObject.Find("Canvas").GetComponent<WinScreen>();

        //Sets the spawnpoints
        P1Left = new Vector3(-17.3f, 0, -6.95f);
        P1Right = new Vector3(-17.3f, 0, 6.95f);
        P2Left = new Vector3(17.3f, 0, -6.95f);
        P2Right = new Vector3(17.3f, 0, 6.95f);
        P1Going = P1Left;
        P2Going = P2Left;
        P1IsLeft = false;
        P2IsLeft = false;
        costKnight = ur.knightCost;
        costRanger = ur.rangerCost;
        costHellfish = ur.hellfishCost;
    }

    //Swaps the lane to instantiate in for player 1
    private void P1Swap()
    {
        if(P1Going == P1Left)
        {
            P1Going = P1Right;
            P1IsLeft = true;
        }
        else
        {
            P1Going = P1Left;
            P1IsLeft = false;
        }
    }
    //Swaps the lane to instantiate in for player 2
    private void P2Swap()
    {
        if(P2Going == P2Left)
        {
            P2Going = P2Right;
            P2IsLeft = true;
        }
        else
        {
            P2Going = P2Left;
            P2IsLeft = false;
        }
    }
    
 
   
    void Update()
    {
        //Models to instantiate
        KnightP1 = ur.KnightP1;
        KnightP2 = ur.KnightP2;
        RangerP1 = ur.RangerP1;
        RangerP2 = ur.RangerP2;
        HellDogP1 = ur.HellfishP1;
        HellDogP2 = ur.HellfishP2;
        
        
        timer1 -= Time.deltaTime;
        timer2 -= Time.deltaTime;
      if (Input.GetKeyDown(KeyCode.A) && pm.GetGIP() == false && ws.GetGIPW() == false)
        {
            P1Swap();
        }
        if (Input.GetKeyDown(KeyCode.L) && pm.GetGIP() == false && ws.GetGIPW() == false)
        {
            P2Swap();
        }

        //Instantiates a knight for player 1 and deducts money
        if (Input.GetKeyDown(KeyCode.Q) && ur.amountP1 >= costKnight && timer1 <= 0 && pm.GetGIP() == false && ws.GetGIPW() == false)
        {
            GameObject a = Instantiate(KnightP1, P1Going, Quaternion.identity);
            a.GetComponent<Warrior>().SetInfo("Player1");
            ur.amountP1 -= costKnight;
            timer1 = spawnTime;
        }
        //Instantiates a knight for player 2 and deducts money
        if (Input.GetKeyDown(KeyCode.I) && ur.amountP2 >= costKnight && timer2 <= 0 && pm.GetGIP() == false && ws.GetGIPW() == false)
        {
            GameObject a = Instantiate(KnightP2, P2Going, Quaternion.identity);
            a.GetComponent<Warrior>().SetInfo("Player2");
            ur.amountP2 -= costKnight;
            timer2 = spawnTime;
        }
        //Instantiates a ranger for player 1 and deducts money
        if (Input.GetKeyDown(KeyCode.W) && ur.amountP1 >= costRanger && timer1 <= 0 && pm.GetGIP() == false && ws.GetGIPW() == false) 
        {
            GameObject a = Instantiate(RangerP1, P1Going, Quaternion.identity);
            a.GetComponent<Ranger>().SetInfo("Player1");
            ur.amountP1 -= costRanger;
            timer1 = spawnTime;
        }
        //Instantiates a ranger for player 2 and deducts money
        if (Input.GetKeyDown(KeyCode.O) && ur.amountP2 >= costRanger && timer2 <= 0 && pm.GetGIP() == false && ws.GetGIPW() == false)
        {
            GameObject a = Instantiate(RangerP2, P2Going, Quaternion.identity);
            a.GetComponent<Ranger>().SetInfo("Player2");
            ur.amountP2 -= costRanger;
            timer2 = spawnTime;
        }
        //Spawns a number of hellfishes equal to numHellfish and deducts money for player 1
        if (Input.GetKeyDown(KeyCode.E) && ur.amountP1 >= costHellfish && timer1 <= 0 && pm.GetGIP() == false && ws.GetGIPW() == false)
        {
            for (int i = 0; i < ur.hellfishCount; i++)
            {
                GameObject a = Instantiate(HellDogP1, P1Going, Quaternion.identity);
                a.GetComponent<HellDog>().SetInfo("Player1");
            }
            
            ur.amountP1 -= costHellfish;
            timer1 = spawnTime;
        }
        //Spawns a number of hellfishes equal to numHellfish and deducts money for player 2
        if (Input.GetKeyDown(KeyCode.P) && ur.amountP2 >= costHellfish && timer2 <= 0 && pm.GetGIP() == false && ws.GetGIPW() == false)
        {
            for (int i = 0; i < ur.hellfishCount; i++)
            {
                GameObject a = Instantiate(HellDogP2, P2Going, Quaternion.identity);
                a.GetComponent<HellDog>().SetInfo("Player2");
            }
            
            ur.amountP2 -= costHellfish;
            timer2 = spawnTime;
        }


    }
}
