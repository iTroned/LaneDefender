using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    private float speed;
    private float startHp;
    private float damage;
    private float range;
    private float attackSpeed;
    private float sight;
    private float hitbox;

    private float timer;
    Vector3 LeftLane;
    Vector3 RightLane;
    Vector3 Final;
    Vector3 LeftLane2;
    Vector3 RightLane2;
    Vector3 Friendly;
    private bool movingToLast = false;
    private bool movingToLeft = false;
    private bool movingToRight = false;
    private float health;
    private GameObject attack;
    private float dist;
    private string enemyPlayer;
    private string friendlyPlayer;
    

    GameManager ur;

    

    void Start()
    {
      




    }


    // Update is called once per frame
    void Update()
    {
        
        if (enemyPlayer == "Player1")
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        timer -= Time.deltaTime;
        gameObject.tag = friendlyPlayer;
       

        if (friendlyPlayer == "Player1")
        {
            enemyPlayer = "Player2";
            Friendly = new Vector3(-20, 0, 0);
        }
        else
        {
            enemyPlayer = "Player1";
            Friendly = new Vector3(20, 0, 0);
        }
        FindClosestEnemy();
        if (attack != null)
        {
            if (Vector3.Distance(transform.position, attack.transform.position) < range + attack.GetComponent<Health>().hitbox)
            {
                if (timer <= 0)
                {
                    AttackTarget();
                    timer = attackSpeed;

                }
            }
           
            else
            {

                if (Vector3.Distance(transform.position, attack.transform.position) > sight)
                {
                    if (movingToLeft == true)
                    {
                        MoveTow(LeftLane2);
                    }
                    if (movingToRight == true)
                    {
                        MoveTow(RightLane2);
                    }
                    if (Vector3.Distance(transform.position, LeftLane) < 2)
                    {
                        movingToLeft = true;
                    }
                    if (Vector3.Distance(transform.position, RightLane) < 2)
                    {
                        movingToRight = true;
                    }
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
                        if (Vector3.Distance(transform.position, LeftLane) <= Vector3.Distance(transform.position, RightLane))
                        {
                            MoveTow(LeftLane);
                        }
                        else if (Vector3.Distance(transform.position, LeftLane) > Vector3.Distance(transform.position, RightLane))
                        {
                            MoveTow(RightLane);
                        }

                    }
                    else if (movingToLast == true)
                    {
                        movingToRight = false;
                        movingToLeft = false;

                        MoveTow(Final);
                    }
                }
                else
                {
                    MoveTow(attack.transform.position);
                }
            }
        }
        

       
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] ems;
        ems = GameObject.FindGameObjectsWithTag(enemyPlayer);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject em in ems)
        {
            Vector3 diff = em.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = em;
                distance = curDistance;
            }
        }
        attack = closest;
        
        return closest;
    }
    public void SetInfo(string name)
    {
        //Sets the stats to the current tier of the player who spawned the character
        ur = GameObject.Find("Canvas").GetComponent<GameManager>();
        friendlyPlayer = name;
        if (friendlyPlayer == "Player2")
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            damage = ur.kDamageP2;
            startHp = ur.kHealthP2;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            damage = ur.kDamageP1;
            startHp = ur.kHealthP1;
        }
        //Sets the info for the character
        speed = ur.knightSpeed;
        sight = ur.knightSight;
        hitbox = ur.knightHB;
        range = ur.knightRange;
        attackSpeed = ur.knightAtkSpd;

        //Sets health info
        gameObject.GetComponent<Health>().setHealth(startHp);

        gameObject.GetComponent<Health>().setHitbox(hitbox);

        SetLanes();
    }
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
    //Just attacks the chosen target and removes some health from it equal to this characters damage
    private void AttackTarget()
    {
        attack.GetComponent<Health>().TakeDmg(damage);
    }
    private void MoveTow(Vector3 tar)
    {
        transform.position = Vector3.MoveTowards(transform.position, tar, speed * Time.deltaTime);
    }
    

}
