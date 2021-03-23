using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperLamp : MonoBehaviour
{
    public float fuel = 60;
    public bool superLampIsOn = false;
    // public Transform enemyBody; //useless ? 
    public GameObject enemyBody;


    //https://answers.unity.com/questions/753481/ontriggerenter-not-working-tried-everything-c.html
    private void OnTriggerEnter(Collider enemyCollision)
    { 
        if (enemyCollision.CompareTag("Enemy") && superLampIsOn==true) //requires rigidbody component for ai
        {
            enemyDeath();  
        }
    }

    void enemyDeath()
    {
        Debug.Log("enemyhit!");
        Destroy(enemyBody); //delete npc
            // TODO add to new pos
    }

    // Update is called once per frame
    void Update()
    {
        //Input.getdown   edit -> Project settings -> Input manager  -> Axes all default input buttons
        if (Input.GetButtonDown("Fire1"))
        {
            if (fuel > 0f) { superLampIsOn = true; }
            else
            {
                superLampIsOn = false;
                // Debug.Log(fuel.ToString());
            }

            if (fuel > 0) { fuel -= Time.deltaTime; } //fuel cant go to lesser than 0 
   
        }
  
    }
}
