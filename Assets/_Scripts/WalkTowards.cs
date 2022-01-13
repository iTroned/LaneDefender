using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTowards : MonoBehaviour
{
    private float speed = 10;

    Vector3 LeftLane;
    Vector3 RightLane;
    Vector3 Final;
    Vector3 LeftLane2;
    Vector3 RightLane2;
    private bool movingToLast = false;
    private bool movingToLeft = false;
    private bool movingToRight = false;
    private float health;
    private float startHp = 100;

    void Start()
    {
        health = startHp;
       
        
        
        LeftLane = new Vector3(0, 0, 14.6f);
        LeftLane2 = new Vector3(8, 0, 14.6f);
        RightLane = new Vector3(0, 0, -14.6f);
        RightLane2 = new Vector3(8, 0, -14.6f);
        Final = new Vector3(20, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if(movingToLeft == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, LeftLane2, speed * Time.deltaTime);
        }
        if (movingToRight == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, RightLane2, speed * Time.deltaTime);
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
        if(movingToLast == false && movingToRight == false && movingToLeft == false)
        {
            if (Vector3.Distance(transform.position, LeftLane) <= Vector3.Distance(transform.position, RightLane))
            {
                transform.position = Vector3.MoveTowards(transform.position, LeftLane, speed * Time.deltaTime);
            }
            else if(Vector3.Distance(transform.position, LeftLane) > Vector3.Distance(transform.position, RightLane))
            {
                transform.position = Vector3.MoveTowards(transform.position, RightLane, speed * Time.deltaTime);
            }
           
        }
        else if(movingToLast == true)
        {
            movingToRight = false;
            movingToLeft = false;

            transform.position = Vector3.MoveTowards(transform.position, Final, speed * Time.deltaTime);
        }
        if(Vector3.Distance(transform.position, Final) < 1)
        {
            Die();
        }
        if (health <= 0) {
            Die();
        }
        
        
    }
    private void Die()
    {
        Destroy(gameObject, 0);
       
    }
    public void takeDmg(float dmg)
    {
        health -= dmg;
    }
}
