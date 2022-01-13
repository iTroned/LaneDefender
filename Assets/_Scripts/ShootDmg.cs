using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootDmg : MonoBehaviour
{
    private float bdmg;
    public float speed;
    public float dist;
    private GameObject attack;
    private string enemyPlayer;
    private float timer = 1;

    GameManager ur;
    void Start()
    {
        ur = GameObject.Find("Canvas").GetComponent<GameManager>();
    }
    public void setEnemy(string name)
    {
        enemyPlayer = name;
    }
    public void setTarget(GameObject tar)
    {
        attack = tar;
    }
    public void setDmg(float dmgs)
    {
        bdmg = dmgs;
    }

    
    void Update()
    {
        
        if (attack == null)
        {
            Destroy(gameObject, 0);
        }
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(gameObject, 0);
        }
        
        transform.position = Vector3.MoveTowards(transform.position, attack.transform.position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == enemyPlayer)
        {
            if(1 == 1)
            {


                collision.gameObject.GetComponent<Health>().TakeDmg(bdmg);
                Destroy(gameObject, 0);
            }
        }
        
        
    }
    
    
        
    
}
