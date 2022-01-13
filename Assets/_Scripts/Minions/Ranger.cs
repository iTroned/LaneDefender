using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranger : MonoBehaviour
{
    //Info that later will be set
    private float speed;
    private float arrowspeed;
    private float startHp;
    private float damage;
    private float range;
    private float attackSpeed;
    private float sight;
    private float hitbox;


    private float timer;
    //The lanes that will be retrieved from GameManager
    Vector3 LeftLane;
    Vector3 RightLane;
    Vector3 Final;
    Vector3 LeftLane2;
    Vector3 RightLane2;

    //Some booleans which acts like some sort of pathfinder
    private bool movingToLast = false;
    private bool movingToLeft = false;
    private bool movingToRight = false;
    
    //Variables that will be used later and set in methods etc.
    private GameObject attackTarget;
    private float dist;
    private string enemyPlayer;
    private string friendlyPlayer;
    public GameObject arrow;
    
    //The usual GameManager script from Canvas
    GameManager ur;


    void Start()
    {
        
        
       



    }


    
    void Update()
    {
        //Changes the rotation of the character after which way it is going
        
        timer -= Time.deltaTime;
        gameObject.tag = friendlyPlayer;
        

        //Sets enemy player
        if (friendlyPlayer == "Player1")
        {
            enemyPlayer = "Player2";
        }
        else
        {
            enemyPlayer = "Player1";
        }
        FindClosestEnemy();
        //If it has found a thing to attack that is in range it attacks it
        if (attackTarget != null)
        {
            //Checks distance between this character and the closest enemy
            if (Vector3.Distance(transform.position, attackTarget.transform.position) < range + attackTarget.GetComponent<Health>().hitbox)
            {
                //Attack speed
                if (timer <= 0)
                {
                    AttackTarget();
                    timer = attackSpeed;

                }
            }
           //If there is not an attackable target
            else
            {
                //If it can't "see" a target, moves towards the selected lane
                if (Vector3.Distance(transform.position, attackTarget.transform.position) > sight)
                {
                    //If left is closest
                    if (movingToLeft == true)
                    {
                        MoveTow(LeftLane2);
                    }
                    //If right is closest
                    if (movingToRight == true)
                    {
                        MoveTow(RightLane2);
                    }
                    //Checks which lane it is the closest to. Can be bugged if it is right in between but it has not occured yet
                    if (Vector3.Distance(transform.position, LeftLane) < 2)
                    {
                        movingToLeft = true;
                    }
                    if (Vector3.Distance(transform.position, RightLane) < 2)
                    {
                        movingToRight = true;
                    }
                    //Makes it move towards the back of the opponents cannon
                    if (Vector3.Distance(transform.position, Final) < 20)
                    {
                        movingToLast = true;
                    }
                    else
                    {
                        movingToLast = false;
                    }
                    if (movingToLast == false && movingToRight == false && movingToLeft == false)
                    {
                        //Makes the character move towards the first selected lane
                        if (Vector3.Distance(transform.position, LeftLane) <= Vector3.Distance(transform.position, RightLane))
                        {
                            MoveTow(LeftLane);
                        }
                        else if (Vector3.Distance(transform.position, LeftLane) > Vector3.Distance(transform.position, RightLane))
                        {
                            MoveTow(RightLane);
                        }

                    }
                    //Makes it move towards the final destination, before selecting a new target which is the core
                    else if (movingToLast == true)
                    {
                        movingToRight = false;
                        movingToLeft = false;

                        MoveTow(Final);
                    }
                }
                //If the closest enemy is in sight but not in range, the character moves towards the closest enemy
                else
                {
                    MoveTow(attackTarget.transform.position);
                }
            }
        }
        
        

    }
    //A method that moves towards the selcted target with a set speed
    private void MoveTow(Vector3 tar)
    {
        transform.position = Vector3.MoveTowards(transform.position, tar, speed * Time.deltaTime);
    }
    //Finds the closest gameobject tagged with the enemyplayer and returns it as a target
    public GameObject FindClosestEnemy()
    {
        //Makes a list with all objects tagged with enemy
        GameObject[] ems;
        ems = GameObject.FindGameObjectsWithTag(enemyPlayer);
        GameObject closest = null;
        //Sets the distance to infinite in order to not make a mess
        float distance = Mathf.Infinity;
        //Gets the position of the object
        Vector3 position = transform.position;
        foreach (GameObject em in ems)
        {
            //
            Vector3 diff = em.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            //Checks if the distance of the new object is less than the previously shortest object
            if (curDistance < distance)
            {
                closest = em;
                distance = curDistance;
            }
        }
        //Returns the closest enemy as the target
        attackTarget = closest;

        return closest;
    }
    //When the character is instantiated it recieves a tag to which player it belongs to
    public void SetInfo(string name)
    {
        //Sets the stats to the current tier of the player who spawned the character
        ur = GameObject.Find("Canvas").GetComponent<GameManager>();
        friendlyPlayer = name;
        if (friendlyPlayer == "Player2")
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            damage = ur.rDamageP2;
            startHp = ur.rHealthP2;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            damage = ur.rDamageP1;
            startHp = ur.rHealthP1;
        }
        //Sets the info for the character
        speed = ur.rangerSpeed;
        sight = ur.rangerSight;
        hitbox = ur.rangerHB;
        range = ur.rangerRange;
      
        arrowspeed = ur.rangerArrowspeed;
        attackSpeed = ur.rangerAtkSpd;

        //Sets health info
        gameObject.GetComponent<Health>().setHealth(startHp);

        gameObject.GetComponent<Health>().setHitbox(hitbox);

        SetLanes();
    }
    //Sets the lanes the character it is supposed to move relative to which player is the enemy
    private void SetLanes()
    {

        if (friendlyPlayer == "Player1")
        {
            LeftLane = ur.LL;
            LeftLane2 = ur.LL2;
            RightLane = ur.RL;
            RightLane2 = ur.RL2;
            Final = ur.F1;
        }
        else
        {
            LeftLane = ur.LL2;
            LeftLane2 = ur.LL;
            RightLane = ur.RL2;
            RightLane2 = ur.RL;
            Final = ur.F2;
        }
    }
    //When this character attacks it instansiates an arrow which it sets the enemyplayer the target, arrowspeed and damage
    private void AttackTarget()
    {
        GameObject a = Instantiate(arrow, transform.position, Quaternion.identity);
        a.GetComponent<Arrow>().setEnemy(enemyPlayer);
        a.GetComponent<Arrow>().setTarget(attackTarget);
        a.GetComponent<Arrow>().setSpeed(arrowspeed);
        a.GetComponent<Arrow>().setDmg(damage);
    }
}
