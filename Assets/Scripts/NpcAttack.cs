using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class NpcAttack : MonoBehaviour
{
    public string sceneName = "oton-kuutio";
    public bool playerImmortality = false;
    public int PlayerHP = 2; 
    private int PlayerRemainingHP;

    public GameObject BloodStain;
    public AudioClip NpcAttackAudio;

    private float TimeToEscape;
    private bool NpcHasAttacked;

    public static bool npcIsDead = false;
    // public Object resetToScene;
    // Start is called before the first frame update

    void Start()
    {
        BloodStain.SetActive(false);
        
        PlayerRemainingHP = PlayerHP;
        NpcHasAttacked = false;
        TimeToEscape = 3.0f;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.tag == "Player" && !npcIsDead)
        {
            NpcHasAttacked = true;

            if (PlayerRemainingHP == PlayerHP)
            {
                PlayerRemainingHP--;
                BloodStain.SetActive(true);
                Debug.Log("HP: " + PlayerRemainingHP);
                AudioSource.PlayClipAtPoint(NpcAttackAudio, gameObject.transform.position);
                
            }

            else if (PlayerRemainingHP < PlayerHP && playerImmortality == false)
            {
                SceneManager.LoadScene(sceneName);
            }

        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {         
            Debug.Log("Escaped");
        }
    }

    // Update is called once per frame
    void Update()
    {
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
