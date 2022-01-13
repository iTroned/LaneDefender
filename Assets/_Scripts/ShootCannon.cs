using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCannon : MonoBehaviour
{
    public GameObject cannonball;
    private float timer;
    private float fireTime = 1;
    public Transform spawn;
    private float dist;
    private float shootdistance = 400;
    private GameObject attack;
    private float dmg;

    private string enemyPlayer;
    Vector3 check = new Vector3(1, 0, 0);

    GameManager ur;
    void Start()
    {
        ur = GameObject.Find("Canvas").GetComponent<GameManager>();
        timer = fireTime;
        if(Vector3.Distance(transform.position, check) < 20)
        {
            enemyPlayer = "Player1";
        }
        else
        {
            enemyPlayer = "Player2";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyPlayer == "Player1")
        {
            dmg = ur.cannonDmg2;
        }
        else
        {
            dmg = ur.cannonDmg1;
        }
        FindClosestEnemy();
        if(timer <= 0 && dist < shootdistance)
        {
            GameObject a = Instantiate(cannonball, spawn.transform.position, Quaternion.identity);
            a.GetComponent<ShootDmg>().setEnemy(enemyPlayer);
            a.GetComponent<ShootDmg>().setTarget(attack);
            a.GetComponent<ShootDmg>().setDmg(dmg);
            timer = fireTime;
        }
        timer -= Time.deltaTime;
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
        dist = distance;
        return closest;
    }
}
