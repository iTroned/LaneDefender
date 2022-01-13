using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonInfo : MonoBehaviour
{
    public float startHp;
    public float hitbox;
    private Health hp;
    public GameObject ws;

    public string winner;
    public bool dead = false;

    private GameManager ur;
    void Start()
    {
        ur = GameObject.Find("Canvas").GetComponent<GameManager>();
        startHp = ur.cannonStartHP;
        hitbox = ur.cannonHitbox;
        //Sets its own health and hitbox to the right size
        gameObject.GetComponent<Health>().setHealth(startHp);
        gameObject.GetComponent<Health>().setHitbox(hitbox);
        //Retrieves its own hp
        hp = gameObject.GetComponent<Health>();

    }

    // Update is called once per frame
    void Update()
    {
        //If its hp is lower than buffer the opponent wins
        if(hp.hp <= ur.bufferHp)
        {

            dead = true;
            //Opens winscreen
            ws.SetActive(true);
        }
    }

    
}
