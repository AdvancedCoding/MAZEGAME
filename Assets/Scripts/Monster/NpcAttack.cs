using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class NpcAttack : MonoBehaviour
{
    public string sceneName = "oton-kuutio";
    public bool playerImmortality = false;
    public int PlayerMaxHP = 2; 
    public int PlayerRemainingHP;

    public float timerInsideMonster = 3f;
    public GameObject BloodStain;
   // public AudioClip NpcAttackAudio;
    public AudioSource enemyAttackAudioSource;

    public AudioSource playerAS;
    public AudioClip damagedPlayerAudio;

    public GameObject player;

    private float TimeToEscape;
    private bool NpcHasAttacked;

    public static bool npcIsDead = false;
    public Animator klonkkuAnimator = null; //klonkun animation controller
    public Animator playerShake; //kamera shake
    // public Object resetToScene;
    // Start is called before the first frame update
     private float counter = 0f;
    public GameObject enemy;
    void Start()
    {
        BloodStain.SetActive(false);
        
        PlayerRemainingHP = PlayerMaxHP;
        NpcHasAttacked = false;
        TimeToEscape = 3.0f;
      // PlayerRemainingHP--;
      // damagedPlayer();
    }

    // private void OnCollisionEnter(Collision collision)
    private void OnTriggerEnter(Collider collision)
    {
        //&& collision.GetType() == typeof(CapsuleCollider)
        
            if (collision.tag == "Player" && !npcIsDead )
            {
           // Debug.Log(collision.);
                NpcHasAttacked = true;
                klonkkuAnimator.SetTrigger("punchMonster"); //monster punch animation

                if (PlayerRemainingHP <= PlayerMaxHP && PlayerRemainingHP > 0)
                {
                    PlayerRemainingHP--;
                    BloodStain.SetActive(true);
                    Debug.Log("HP: " + PlayerRemainingHP);
                    playerAS.Play();
                // AudioSource.PlayClipAtPoint(audioSource, enemy.transform.position);
                enemyAttackAudioSource.Play();
                  //  playerShake.SetTrigger("shakeCam"); //tärisevä kamera

                }

                if (PlayerRemainingHP <= 0 && playerImmortality == false)
                {
                    //klonkkuAnimator.SetTrigger("punchMonster");
                    SceneManager.LoadScene(sceneName);
              
                }

            }
        
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "Player" && !npcIsDead)
        {
            counter += Time.deltaTime;
            if (counter>timerInsideMonster) PlayerRemainingHP--; counter = 0f;

            if (PlayerRemainingHP <= 0 && playerImmortality == false)
            {
                Debug.Log("KILLED BY ON TRIGGER STAY");
                //klonkkuAnimator.SetTrigger("punchMonster");
                SceneManager.LoadScene(sceneName);
            }

        }

    }

    // private void OnCollisionExit(Collision collision)
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {         
            Debug.Log("Escaped");
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (PlayerRemainingHP == PlayerMaxHP)
        {
            playerAS.Stop();
        }
        
        if (NpcHasAttacked)
        {
            TimeToEscape -= Time.deltaTime;
           
        }

        if (TimeToEscape > 0f)
        {
            playerImmortality = true; 
        }

        else if (TimeToEscape <= 0f)
        {
            BloodStain.SetActive(false);
           
            NpcHasAttacked = false;
            playerImmortality = false;
         
        }

    }
}
