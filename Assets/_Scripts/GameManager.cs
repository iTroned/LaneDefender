using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Player coins
    public int amountP1;
    public int amountP2;
    //Max coins
    private int maxCoins = 10;
    //Starting coins
    private int startAmount = 5;
    //How many coins added each time
    private int added = 1;
    //Timer for each player for adding coins
    private float timer1;
    private float timer2;
    //Experience for each player
    private float startXp = 0;
    private int addedLvls = 1;
    private float xpToLvl = 100;
    private float xpTimer;
    private float xpTimerStart = .1f;
    private float xpIncrease = 1;
    private float expP1;
    private float expP2;
    private int xplvlP1 = 0;
    private int xplvlP2 = 0;
    private int lvlPrUpgrade = 1;

    //Cannon info
    public float cannonStartHP = 1200;
    public float cannonHitbox = 2;

    //Cannon damage for each tier
    public float cannonDmg1 = 20;
    public float cannonDmg2 = 20;

    private float cDmg2 = 35;
    private float cDmg3 = 50;

    //Cost info for characters
    public int knightCost = 1;
    public int rangerCost = 1;
    public int hellfishCost = 1;

    //Ranger info and upgrades
    public float rangerSpeed = 7;
    public float rangerArrowspeed = 30;
    public float rangerRange = 11;
    public float rangerAtkSpd = 1.2f;
    public float rangerSight = 11;
    public float rangerHB = .5f;

    public float rDamageP1 = 20;
    public float rDamageP2 = 20;

    private float rDamageT2 = 30;
    private float rDamageT3 = 45;

    public float rHealthP1 = 50;
    public float rHealthP2 = 50;

    private float rHealthT2 = 70;
    private float rHealthT3 = 90; 
    
    //Knight info and upgrades
    public float knightSpeed = 5;
   
    public float knightRange = 2.5f;
    public float knightAtkSpd = 1.1f;
    public float knightSight = 7;
    public float knightHB = .5f;

    public float kDamageP1 = 25;
    public float kDamageP2 = 25;

    private float kDamageT2 = 35;
    private float kDamageT3 = 50;

    public float kHealthP1 = 100;
    public float kHealthP2 = 100;

    private float kHealthT2 = 150;
    private float kHealthT3 = 200;
    
    //Hellfish info and upgrades
    public float hellfishSpeed = 12;
    public int hellfishCount = 2;
    public float hellfishRange = 1.5f;
    public float hellfishAtkSpd = 1f;
    public float hellfishSight = 7;
    public float hellfishHB = .5f;

    public float hellDamageP1 = 35;
    public float hellDamageP2 = 35;

    private float hellDamageT2 = 50;
    private float hellDamageT3 = 60;

    public float hellHealthP1 = 40;
    public float hellHealthP2 = 40;

    private float hellHealthT2 = 60;
    private float hellHealthT3 = 80;

    //Standard time between outpays
    private float gainedTime = 2;
    //Time multiplier for outpays
    private float multiplier = 1;
    //Timer for increasing multiplier
    private float multiTimer;
    //Standard time between multipliers
    private float startmTimer = 30;
    //The timer that will be amplified by the multiplier
    private float speed = 1;

    //All TMPs
    public TextMeshProUGUI coinsP1;
    public TextMeshProUGUI coinsP2;
    public TextMeshProUGUI Q;
    public TextMeshProUGUI W;
    public TextMeshProUGUI E;
    public TextMeshProUGUI I;
    public TextMeshProUGUI O;
    public TextMeshProUGUI P;
    public TextMeshProUGUI He1;
    public TextMeshProUGUI He2;
    public TextMeshProUGUI multi;
    public TextMeshProUGUI mTimer;
    public TextMeshProUGUI xp1;
    public TextMeshProUGUI xp2;

    //Light Models
    public GameObject Light1;
    public GameObject Light2;
    public GameObject Light3;
    public GameObject Light4;

    //Cannon Models
    public GameObject P1T1;
    public GameObject P1T2;
    public GameObject P1T3;
    public GameObject P2T1;
    public GameObject P2T2;
    public GameObject P2T3;

    //Upgrade Menus
    public GameObject Menu1;
    public GameObject Menu2;
    public GameObject openMenu1;
    public GameObject openMenu2;

    //Current level of each players cannon
    private int canLvl1 = 1;
    private int canLvl2 = 1;

    //Vectors for pathfinding for each character
    public Vector3 LL = new Vector3(-8.2f, 0, 15f);
    public Vector3 LL2 = new Vector3(8.2f, 0, 15f);
    public Vector3 RL = new Vector3(-8.2f, 0, -15f);
    public Vector3 RL2 = new Vector3(8.2f, 0, -15f);
    public Vector3 F1 = new Vector3(20, 0, 0);
    public Vector3 F2 = new Vector3(-20, 0, 0);

    //Blood model and info
    public GameObject blood;
    public int bloodCount = 25;
    public float bloodVelocity = 30;

    
    //Health bars
    public Transform bar1;
    public Transform bar2;

    //XP bars
    public Transform xpBar1;
    public Transform xpBar2;

    //Start size of bars
    private float size1 = 1;
    private float size2 = 1;
    private float xpSize1;
    private float xpSize2;

    private float n1;
    private float n2;

    //Light variables
    public bool light1Left;
    public bool light2Left = false;

    //A buffer added in order to make the bar stay the right size if taken excess damage
    public float bufferHp = 200;

    Health h1;
    Health h2;
    CannonInfo ci;
    Spawn sp;

   
    //Starting models and upgraded models for each of the three characters
    public GameObject KnightP1;
    public GameObject KnightP2;
    public GameObject KnightT2;
    public GameObject KnightT3;
    public GameObject RangerP1;
    public GameObject RangerP2;
    public GameObject RangerT2;
    public GameObject RangerT3;
    public GameObject HellfishP1;
    public GameObject HellfishP2;
    public GameObject HellfishT2;
    public GameObject HellfishT3;

    //Current levels for each of the players characters
    private int KnightLvl1 = 1;
    private int KnightLvl2 = 1;
    private int RangerLvl1 = 1;
    private int RangerLvl2 = 1;
    private int HellfishLvl1 = 1;
    private int HellfishLvl2 = 1;

    //Pausemenu and Winscreen
    public PauseMenu pm;
    public WinScreen ws;

    void Start()
    {
        pm = GameObject.Find("Canvas").GetComponent<PauseMenu>();
        ws = GameObject.Find("Canvas").GetComponent<WinScreen>();

        ci = GameObject.Find("CoreP1").GetComponent<CannonInfo>();
        h1 = GameObject.Find("CoreP1").GetComponent<Health>();
        h2 = GameObject.Find("CoreP2").GetComponent<Health>();
        //Gets component from this object
        sp = gameObject.GetComponent<Spawn>();
        
        amountP1 = startAmount;
        amountP2 = startAmount;
        timer1 = gainedTime;
        timer2 = gainedTime;

        multiTimer = startmTimer;
        //Starts with hiding the upgrademenus
        HideMenu1();
        HideMenu2();
        expP1 = startXp;
        expP2 = startXp;

        
    }

    
    void Update()
    {
       //Retrieves info of where the characters are instantiated
        light1Left = sp.P1IsLeft;
        light2Left = sp.P2IsLeft;
        
       
        //Changes which light is active 
        if(light1Left == true)
        {
            Light1.SetActive(true);
            Light2.SetActive(false);
        }
        else
        {
            Light1.SetActive(false);
            Light2.SetActive(true);
        }
        if(light2Left == false)
        {
            Light3.SetActive(false);
            Light4.SetActive(true);
        }
        else
        {
            Light3.SetActive(true);
            Light4.SetActive(false);
        }


        xp1.text = "" + xplvlP1;
        xp2.text = "" + xplvlP2;
        xpTimer -= Time.deltaTime;
        if(xpTimer <= 0)
        {
            expP1 += xpIncrease;
            expP2 += xpIncrease;
            xpTimer = xpTimerStart;
        }
        if(expP1 >= xpToLvl)
        {
            xplvlP1 += addedLvls;
            expP1 = startXp;
        }
        if (expP2 >= xpToLvl)
        {
            xplvlP2 += addedLvls;
            expP2 = startXp;
        }

        //Onclick R or U opens and closes Upgrade menus for each player
        if (Input.GetKeyDown(KeyCode.R) && pm.GetGIP() == false && ws.GetGIPW() == false)
        {
            if(menuOpen1 == false)
            {
                ShowMenu1();
            }
            else
            {
                HideMenu1();
            }
           
        }
        if (Input.GetKeyDown(KeyCode.U) && pm.GetGIP() == false && ws.GetGIPW() == false) 
        {
            if (menuOpen2 == false)
            {
                ShowMenu2();
            }
            else
            {
                HideMenu2();
            }
        }
        //Makes the bar stay at the size relative to the hp left
        bar1.localScale = new Vector3(size1 , 1, 0);
        bar2.localScale = new Vector3(size2 , 1, 0);

        //Xp bars
        xpBar1.localScale = new Vector3(xpSize1, 1, 0);
        xpBar2.localScale = new Vector3(xpSize2, 1, 0);
        
        //The multiplier makes time between outpays shorter
        speed = 1 / multiplier;
        timer1 -= Time.deltaTime;
        timer2 -= Time.deltaTime;
        multiTimer -= Time.deltaTime;

        size1 = (h1.hp - bufferHp) / (ci.startHp - bufferHp);
        size2 = (h2.hp - bufferHp) / (ci.startHp - bufferHp);

        xpSize1 = expP1 / xpToLvl;
        xpSize2 = expP2 / xpToLvl;

        n1 = h1.hp - bufferHp;
        n2 = h2.hp - bufferHp;

        //Changes the number on the healthbars
        He1.text = "" + n1;
        He2.text = "" + n2;

        //Shows the timer before increased multiplier
        multi.text = "x" + multiplier;
        //Removes the decimals since the timer is a float
        mTimer.text = "" + multiTimer.ToString("F0");

        //Increases the multiplier
        if (multiTimer <= 0)
        {
           if (multiplier == 1)
            {
                multiplier = 1.5f;
            }
           //Max multiplier (for now)
            else
            {
                multiplier = 2;
            }
            multiTimer = startmTimer;
        }
        //Adds money to player1s balance if it doesnt exceed max coins. The reason the two players have different timers is so the players have to wait the normal time when exceeding max coins
        if (timer1 <= 0 && amountP1 < maxCoins)
        {
            amountP1 = amountP1 + added;

            timer1 = gainedTime * speed;

           
        }
        if (timer2 <= 0 && amountP2 < maxCoins)
        {
            amountP2 = amountP2 + added;

            timer2 = gainedTime * speed;


        }
        //Edits the TMpro so it shows amount of money
        coinsP1.text = "" + amountP1;
        coinsP2.text = "" + amountP2;
        
        //This is the buffer. Prevents some issues in the script. Should be fixed so it doesnt have a buffer. PS. The problem is that it shares Health script with characters
        if (h1.hp < bufferHp)
        {
            h1.hp = bufferHp;
        }
        if (h2.hp < bufferHp)
        {
            h2.hp = bufferHp;
        }
        //All the keybinds ready to be replaced later on if needed
        if (Input.GetKeyDown(KeyCode.S))
        {
            UpP1Can();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            UpP2Can();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            UpP1Knight();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            UpP1Ranger();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            UpP1Hellfish();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            UpP2Knight();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            UpP2Ranger();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            UpP2Hellfish();
        }
    }

    //Bools to check if the menu is open and the player can tier up
    private bool menuOpen1 = false;
    private bool menuOpen2 = false;

    //Upgrades the cannon for player 1, if they have enough lvls and changes the model of the cannon
    private void UpP1Can()
    {
        if(canLvl1 == 1 && menuOpen1 == true && xplvlP1 >= lvlPrUpgrade)
        {
            //Changes model
            P1T2.SetActive(true);
            canLvl1 = 2;
            //New damage
            cannonDmg1 = cDmg2;

            //Removes lvls
            xplvlP1 -= lvlPrUpgrade;
            HideMenu1();
        }
        else if(canLvl1 == 2 && menuOpen1 == true && xplvlP1 >= lvlPrUpgrade)
        {
            P1T1.SetActive(false);
            P1T2.SetActive(false);
            P1T3.SetActive(true);
            canLvl1 = 3;
            cannonDmg1 = cDmg3;

            xplvlP1 -= lvlPrUpgrade;
            HideMenu1();
        }
        
    }
    //Upgrades the cannon for player 2, if they have enough lvls and changes the model of the cannon
    private void UpP2Can()
    {
        if(canLvl2 == 1 && menuOpen2 == true && xplvlP2 >= lvlPrUpgrade)
        {
            //Changes model
            P2T2.SetActive(true);
            canLvl2 = 2;
            //New damage
            cannonDmg2 = cDmg2;

            //Removes lvls
            xplvlP2 -= lvlPrUpgrade;
            HideMenu2();
        }
        else if(canLvl2 == 2 && menuOpen2 == true && xplvlP2 >= lvlPrUpgrade)
        {
            //Changes models in unity
            P2T1.SetActive(false);
            P2T2.SetActive(false);
            P2T3.SetActive(true);
            canLvl2 = 3;
            cannonDmg2 = cDmg3;

            xplvlP2 -= lvlPrUpgrade;
            HideMenu2();
        }
    }
    //Hides the upgrade menu by deactivating it
    private void HideMenu1()
    {
        Menu1.SetActive(false);
        openMenu1.SetActive(true);
        menuOpen1 = false;
    }
    //Shows the upgrade menu by activating it
    private void ShowMenu1()
    {
        Menu1.SetActive(true);
        openMenu1.SetActive(false);
        menuOpen1 = true;
    }
    //Hides the upgrade menu by deactivating it
    private void HideMenu2()
    {
        Menu2.SetActive(false);
        openMenu2.SetActive(true);
        menuOpen2 = false;
    }
    //Shows the upgrade menu by activating it
    private void ShowMenu2()
    {
        Menu2.SetActive(true);
        openMenu2.SetActive(false);
        menuOpen2 = true;
    }
    //Checks if upgrademenu is open and adds one lvl to the selected minion/cannon for the selected player
    private void UpP1Knight()
    {
        if (KnightLvl1 == 1 && menuOpen1 == true && xplvlP1 >= lvlPrUpgrade)
        {
            KnightP1 = KnightT2;
            KnightLvl1 = 2;
            kDamageP1 = kDamageT2;
            kHealthP1 = kHealthT2;

            xplvlP1 -= lvlPrUpgrade;
            HideMenu1();
        }
        else if (KnightLvl1 == 2 && menuOpen1 == true && xplvlP1 >= lvlPrUpgrade)
        {
            KnightP1 = KnightT3;
            KnightLvl1 = 3;
            kDamageP1 = kDamageT3;
            kHealthP1 = kHealthT3;

            xplvlP1 -= lvlPrUpgrade;
            HideMenu1();
        }

    }
    //Checks if upgrademenu is open and adds one lvl to the selected minion/cannon for the selected player
    private void UpP2Knight()
    {
        if (KnightLvl2 == 1 && menuOpen2 == true && xplvlP2 >= lvlPrUpgrade)
        {
            KnightP2 = KnightT2;
            KnightLvl2 = 2;
            kDamageP2 = kDamageT2;
            kHealthP2 = kHealthT2;

            xplvlP2 -= lvlPrUpgrade;
            HideMenu2();
        }
        else if (KnightLvl2 == 2 && menuOpen2 == true && xplvlP2 >= lvlPrUpgrade)
        {
            KnightP2 = KnightT3;
            KnightLvl2 = 3;
            kDamageP2 = kDamageT3;
            kHealthP2 = kHealthT3;

            xplvlP2 -= lvlPrUpgrade;
            HideMenu2();
        }

    }
    //Checks if upgrademenu is open and adds one lvl to the selected minion/cannon for the selected player
    private void UpP1Ranger()
    {
        if (RangerLvl1 == 1 && menuOpen1 == true && xplvlP1 >= lvlPrUpgrade)
        {
            RangerP1 = RangerT2;
            RangerLvl1 = 2;
            rDamageP1 = rDamageT2;
            rHealthP1 = rHealthT2;

            xplvlP1 -= lvlPrUpgrade;
            HideMenu1();
        }
        else if (RangerLvl1 == 2 && menuOpen1 == true && xplvlP1 >= lvlPrUpgrade)
        {
            RangerP1 = RangerT3;
            RangerLvl1 = 3;
            rDamageP1 = rDamageT3;
            rHealthP1 = rHealthT3;

            xplvlP1 -= lvlPrUpgrade;
            HideMenu1();
        }

    }
    //Checks if upgrademenu is open and adds one lvl to the selected minion/cannon for the selected player
    private void UpP2Ranger()
    {
        if (RangerLvl2 == 1 && menuOpen2 == true && xplvlP2 >= lvlPrUpgrade)
        {
            RangerP2 = RangerT2;
            RangerLvl2 = 2;
            rDamageP2 = rDamageT2;
            rHealthP2 = rHealthT2;

            xplvlP2 -= lvlPrUpgrade;
            HideMenu2();
        }
        else if (RangerLvl2 == 2 && menuOpen2 == true && xplvlP2 >= lvlPrUpgrade)
        {
            RangerP2 = RangerT3;
            RangerLvl2 = 3;
            rDamageP2 = rDamageT3;
            rHealthP2 = rHealthT3;

            xplvlP2 -= lvlPrUpgrade;
            HideMenu2();
        }

    }
    //Checks if upgrademenu is open and adds one lvl to the selected minion/cannon for the selected player
    private void UpP1Hellfish()
    {
        if (HellfishLvl1 == 1 && menuOpen1 == true && xplvlP1 >= lvlPrUpgrade)
        {
            HellfishP1 = HellfishT2;
            HellfishLvl1 = 2;
            hellDamageP1 = hellDamageT2;
            hellHealthP1 = hellHealthT2;

            xplvlP1 -= lvlPrUpgrade;
            HideMenu1();
        }
        else if (HellfishLvl1 == 2 && menuOpen1 == true && xplvlP1 >= lvlPrUpgrade)
        {
            HellfishP1 = HellfishT3;
            HellfishLvl1 = 3;
            hellDamageP1 = hellDamageT3;
            hellHealthP1 = hellHealthT3;

            xplvlP1 -= lvlPrUpgrade;
            HideMenu1();
        }

    }
    //Checks if upgrademenu is open and adds one lvl to the selected minion/cannon for the selected player
    private void UpP2Hellfish()
    {
        if (HellfishLvl2 == 1 && menuOpen2 == true && xplvlP2 >= lvlPrUpgrade)
        {
            HellfishP2 = HellfishT2;
            HellfishLvl2 = 2;
            hellDamageP2 = hellDamageT2;
            hellHealthP2 = hellHealthT2;

            xplvlP2 -= lvlPrUpgrade;
            HideMenu2();
        }
        else if (HellfishLvl2 == 2 && menuOpen2 == true && xplvlP2 >= lvlPrUpgrade)
        {
            HellfishP2 = HellfishT3;
            HellfishLvl2 = 3;
            hellDamageP2 = hellDamageT3;
            hellHealthP2 = hellHealthT3;

            xplvlP2 -= lvlPrUpgrade;
            HideMenu2();
        }

    }
}
