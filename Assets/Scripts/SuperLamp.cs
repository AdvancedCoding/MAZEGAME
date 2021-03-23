using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperLamp : MonoBehaviour
{
    public float fuel = 60;
    public bool superLampIsOn = false;
    // public Transform enemyBody; //useless ? 
    public GameObject enemyBody;
    public GameObject newEnemyPos1;
    public GameObject newEnemyPos2;
    public GameObject newEnemyPos3;
    public float enemyRespawnTimer = 0.5f;
    public List<Vector3> spawnpoints;


    private void Start()
    {
     Vector3 newEnemyVec1 = newEnemyPos1.transform.position;
     Vector3 newEnemyVec2 = newEnemyPos2.transform.position;
     Vector3 newEnemyVec3 = newEnemyPos3.transform.position;
    
    spawnpoints.Add(newEnemyVec1);
    spawnpoints.Add(newEnemyVec2);
    spawnpoints.Add(newEnemyVec3);
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
        int spAmount =  spawnpoints.Count;
        int nextSP = Random.Range(0, spAmount);
        enemyBody.transform.position = spawnpoints[nextSP];
       //Instantiate(enemyBody, spawnpoints[nextSP], transform.rotation);   //spawns new clone of enemy
    }

    // Update is called once per frame
    void Update()
    {
        //CURRENT BUGS IF IN ZONE IN COLLIDER ZONE LIGHT != EFFECT ENEMY!!!!!!!!!!!!!!!!! 
        //THIS NEEDS FIX!!

        //Input.getdown   edit -> Project settings -> Input manager  -> Axes all default input buttons
        if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log(fuel.ToString());  //TODO SHOW UI WITH LAMP FUEL
                if (fuel > 0f) 
                { 
                    superLampIsOn = true; 
                    fuel -= 1*Time.deltaTime;
                }
                else  {superLampIsOn = false;}   
            }

        if (Input.GetButtonUp("Fire1"))
        {
            superLampIsOn = false;
        }
  
    }
}
