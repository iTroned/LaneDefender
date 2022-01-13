using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private float bdmg;
    private float rspeed;
    private float dist;
    private GameObject attack;
    private string enemyPlayer;
    //Time before it despawn
    private float timer = 1f;

    void Start()
    {

    }
    //Sets the opponent player
    public void setEnemy(string name)
    {
        enemyPlayer = name;
    }
    //Sets the target which the object follows
    public void setTarget(GameObject tar)
    {
        attack = tar;
    }

    //Sets the dmg of the arrow. This way all projectiles can use this script
    public void setDmg(float dmg)
    {
        bdmg = dmg;
    }
    //Sets the speed of the projectile
    public void setSpeed(float speed)
    {
        rspeed = speed;
    }


    void Update()
    {
        //Checks which rotation the arrow shall have. Quite ineffective but due to the way the game is made it doesnt really matter as all characters will be relative to each others the same way all the time, and it really doesnt need a different rotation
        if (enemyPlayer == "Player1")
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        //If the target dies, destroy the projectile
        if (attack == null)
        {
            Destroy(gameObject, 0);
        }
        //Destroy the projectile after a certain time
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(gameObject, 0);
        }
        //Sends the projectile against the target with set speed and dmg
        transform.position = Vector3.MoveTowards(transform.position, attack.transform.position, rspeed * Time.deltaTime);
    }
    //When the projectile enters a trigger it deals damage to all characters there which are marked with the enemy team. Then it destroys itself
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == enemyPlayer)
        {
            other.gameObject.GetComponent<Health>().TakeDmg(bdmg);
            Destroy(gameObject, 0);
        }


    }
}
