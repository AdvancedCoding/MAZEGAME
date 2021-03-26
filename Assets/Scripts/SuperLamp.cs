using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SuperLamp : MonoBehaviour
{
[SerializeField] private Animator animator = null; //oton animation

    public float fuel = 60;
    public bool superLampIsOn = false;
    public GameObject enemyBody;
    // public Transform enemyBody; //useless ? 
    /*public GameObject newEnemyPos1;
    public GameObject newEnemyPos2;
    public GameObject newEnemyPos3;*/
    public float enemyRespawnTimer = 0.5f;
    public List<Vector3> spawnpointsV; // DO NOT USE THESE IN EDITOR
    public Transform[] spawnpoints;
    public Light lightStrenght;
    public int defaultLightStrenght = 2;
    public Inventory inventory;


    private void Start()
    {
        lightStrenght.intensity = defaultLightStrenght;

        spawnpointsV.Clear();
        for (int i = 0; i<spawnpoints.Length;i++)
        {
            Vector3 newEnemyVec = spawnpoints[i].position;
            spawnpointsV.Add(newEnemyVec);    //<-- http://prntscr.com/10tp4qq
        } 

    }


    //https://answers.unity.com/questions/753481/ontriggerenter-not-working-tried-everything-c.html
    private void OnTriggerEnter(Collider enemyCollision)
    { 
        if (enemyCollision.CompareTag("Enemy") && superLampIsOn==true) //requires rigidbody component for ai
        {
            Debug.Log("Enemy destroyed / moved");
            enemyBody.transform.position = new Vector3(56, 2, -43);  //THROW CUBE somewhere off map 
            Invoke("enemyDeath", enemyRespawnTimer);  //and wait for timer amount the spawn to new location
        }
       
    }

    void enemyDeath()
    {
        Debug.Log("Enemy spawned");
        //Destroy(enemyBody); //delete npc - bugs somehow ? new clone does not work with out the original or stmh
        int spAmount =  spawnpointsV.Count;
        int nextSP = UnityEngine.Random.Range(0, spAmount);
        enemyBody.transform.position = spawnpointsV[nextSP];
       //Instantiate(enemyBody, spawnpoints[nextSP], transform.rotation);   //spawns new clone of enemy
    }
    
                   
        	

    // Update is called once per frame
    void Update()
    {
        //CURRENT BUGS IF IN ZONE IN COLLIDER ZONE LIGHT != EFFECT ENEMY!!!!!!!!!!!!!!!!! 
        //THIS NEEDS FIX!!
        
        //Input.getdown   edit -> Project settings -> Input manager  -> Axes all default input buttons
        if (Input.GetButton("Fire1"))
        {
            int fuelAmount = Convert.ToInt32(fuel);
            Debug.Log(fuel.ToString());  //TODO SHOW UI WITH LAMP FUEL
            if (fuel > 0f)
            {
                lightStrenght.intensity = 7;
                superLampIsOn = true;
                fuel -= 10 * Time.deltaTime;  //fuel nerf 1*time --> 10*time

                inventory.UpdateInventory("fuel", fuelAmount);

            }
            else if (fuel < 0f) { fuel = 0f; superLampIsOn = false; lightStrenght.intensity = defaultLightStrenght; }
            else { superLampIsOn = false; }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("lightOn"); //Plays lantern animation
        }

        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetTrigger("lightOn");
            lightStrenght.intensity = defaultLightStrenght;
            superLampIsOn = false;
        }
  
    }
}
