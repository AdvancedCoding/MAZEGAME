using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SuperLamp : MonoBehaviour
{
[SerializeField] private Animator animator = null; //P animation
[SerializeField] public Animator klonkkuAnimator = null; //klonkun animation controller




    [Header("Light stuff")]
    public static float fuel = 0;
    // public float fuel = 60;
    public bool superLampIsOn = false;
    public Light lightStrenght;
    public int defaultLightStrenght = 4;
    public int defaultLightRange = 6;
    public int powerLightStrenght = 8;
    public int powerLightRange = 12;
    [Space]
    [Header("Npc")]
    public Transform[] spawnpoints;
    public Inventory inventory;
    public NpcMove NpcMove;
    public int patrolTimer = 10;
    public GameObject enemyBody;
    public float enemyRespawnTimer = 0.5f;
    [Space]
    [Header("Audio")]
    [SerializeField] private AudioClip deathScreechSfx; //sfx
    private AudioSource audioSource;

    public float ratBlindtime = 6f;
    private bool ratIsBlind = false;

    private void Start()
    {
        lightStrenght.intensity = defaultLightStrenght;
        fuel = 0; // when level is restarted this value is loaded
    }


    //https://answers.unity.com/questions/753481/ontriggerenter-not-working-tried-everything-c.html
    private void OnTriggerEnter(Collider enemyCollision)
    { 
        if (enemyCollision.CompareTag("Enemy") && superLampIsOn==true && !NpcAttack.npcIsDead) //requires rigidbody component for ai
        {
            Debug.Log("Enemy destroyed /moved by  ENTER");
            
            enemyDeath();
            //enemyBody.transform.position = new Vector3(56, 2, -43);  //THROW CUBE somewhere off map 
            //  Invoke("enemyDeath", enemyRespawnTimer);  //and wait for timer amount the spawn to new location
        }
        if (enemyCollision.CompareTag("Rat") && superLampIsOn == true && !ratIsBlind) 
        {
            blindRats();
        }

    }

    private void OnTriggerStay(Collider enemyCollision)
    {
        if (enemyCollision.CompareTag("Enemy") && superLampIsOn == true && !NpcAttack.npcIsDead) //requires rigidbody component for ai
        {
            Debug.Log("Enemy destroyed / moved by ontriggre stay");

            enemyDeath();
        }

        if (enemyCollision.CompareTag("Rat") && superLampIsOn == true && !ratIsBlind)
        {
            blindRats();
        }

    }

    void blindRats()
    {
        NpcMove.ratDetectDistance = 0.1f;
        StartCoroutine(timerRatBlinded()); //w
    }

    IEnumerator timerRatBlinded()
    {
        ratIsBlind = true;
        yield return new WaitForSecondsRealtime(ratBlindtime);
        NpcMove.ratDetectDistance = NpcMove.defaultAiDetectDistance;

        ratIsBlind = false;
    }


    void enemyDeath()
    {
       // Debug.Log("Enemy spawned");
        klonkkuAnimator.SetTrigger("blindMonster");
        NpcMove.aiDetectDistance = 0.1f;
        NpcAttack.npcIsDead = true;
        audioSource = GetComponent<AudioSource>(); //play sfx
        audioSource.PlayOneShot(deathScreechSfx);
        StartCoroutine(timerDetectDistance()); //why is needed to done this way, thanks unity


        /* int spAmount =  spawnpoints.Length;
           int nextSP = UnityEngine.Random.Range(0, spAmount);
           enemyBody.transform.position = spawnpoints[nextSP].position;*/

        //Destroy(enemyBody); //delete npc - bugs somehow ? new clone does not work with out the original or stmh
        //Instantiate(enemyBody, spawnpoints[nextSP], transform.rotation);   //spawns new clone of enemy
    }
    IEnumerator timerDetectDistance()
    {
        yield return new WaitForSecondsRealtime(patrolTimer);
        NpcMove.aiDetectDistance = NpcMove.defaultAiDetectDistance;
    
        NpcAttack.npcIsDead = false;
    }
                   
        	

  
    void Update()
    {
      
        //Input.getdown   edit -> Project settings -> Input manager  -> Axes all default input buttons
        if (Input.GetButton("Fire1") && inventory.inventoryEnabled == false) //cant use lamp when inventory is visible
        {
            
           // Debug.Log(fuel.ToString());  
            if (fuel > 0f)
            {
                lightStrenght.intensity = powerLightStrenght;
                lightStrenght.range = powerLightRange;
                superLampIsOn = true;
                fuel -= 10 * Time.deltaTime;  //fuel nerf 1*time --> 10*time
                int fuelAmount = Convert.ToInt32(fuel);

                inventory.UpdateInventory("fuel", fuelAmount);

            }
            else if (fuel < 0f) { fuel = 0f; superLampIsOn = false; lightStrenght.intensity = defaultLightStrenght; 
            lightStrenght.range = defaultLightRange;}
            else { superLampIsOn = false; }
        }
        if (Input.GetButtonDown("Fire1") && inventory.inventoryEnabled == false)
        {
            animator.Rebind();
            animator.Update(0f);
            animator.SetTrigger("lightOn"); //Plays lantern animation
        }

        if (Input.GetButtonUp("Fire1") && inventory.inventoryEnabled == false)
        {
            animator.SetTrigger("lightOff"); //Stops lantern animation
            lightStrenght.intensity = defaultLightStrenght;
            lightStrenght.range = defaultLightRange;
            superLampIsOn = false;
        }
        
    /*    //Mining
        if (Input.GetButtonDown("Fire2"))
        {
            animator.Rebind();
            animator.Update(0f);

            animator.SetTrigger("miningOn"); //Plays mining animation
        }
        
         if (Input.GetButtonUp("Fire2"))
        {
           
            animator.SetTrigger("miningOff"); //stops mining animation
        }*/
  
    }
}
