using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float hp;
    public float hitbox;
    private int bloodcount;
    private float spread = 360;
    private float vel;

    private GameManager ur;
    private GameObject blood;
    

    // Start is called before the first frame update
    void Start()
    {
        //Gets info from UpdateResource
        ur = GameObject.Find("Canvas").GetComponent<GameManager>();
        bloodcount = ur.bloodCount;
        blood = ur.blood;
        vel = ur.bloodVelocity;
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if(hp <= 0)
        {
            Destroy(gameObject, 0);
            explode();
        }
    }
    //When a character with this script takes dmg it runs through this and removes the dealt damage from current hp
    public void TakeDmg(float dmg)
    {
        hp -= dmg;
    }
    //When a character is summoned the health is set to the start hp
    public void setHealth(float health)
    {
        hp = health;
    }
    //When a character is summoned the hitbox is set to a certain range
    public void setHitbox(float hb)
    {
        hitbox = hb;
    }
    //Method that occurs when hp reaches 0. Summons blooddrops equal to the bloodcount and gives them a random rotation and a velocity
    private void explode()
    {
        for (int i = 0; i < bloodcount; i++)
        {
            GameObject b = Instantiate(blood, transform.position, transform.rotation);
            b.transform.rotation = Quaternion.RotateTowards(b.transform.rotation, Random.rotation, spread);
            b.GetComponent<Rigidbody>().AddForce(b.transform.forward * vel * -1);
            
        }
    }
}
