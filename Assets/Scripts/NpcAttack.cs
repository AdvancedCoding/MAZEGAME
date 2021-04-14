using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NpcAttack : MonoBehaviour
{
    public string sceneName = "oton-kuutio";
    public bool playerImmortality = false;
    public int PlayerHP = 2; 
    private int PlayerRemainingHP;

    public GameObject BloodStain;
    public AudioClip NpcAttackAudio; 

    // public Object resetToScene;
    // Start is called before the first frame update

    void Start()
    {
        BloodStain.SetActive(false);
        PlayerRemainingHP = PlayerHP;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.tag == "Player")
        {
         
            if (PlayerRemainingHP == PlayerHP)
            {
                PlayerRemainingHP--;
                BloodStain.SetActive(true);          
                Debug.Log("HP: " + PlayerRemainingHP);
                AudioSource.PlayClipAtPoint(NpcAttackAudio, gameObject.transform.position);
           
            }

            else if (PlayerRemainingHP < PlayerHP)
            {
                SceneManager.LoadScene(sceneName);
            }

        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            BloodStain.SetActive(false);
            Debug.Log("Escaped");
        }
    }


    // Update is called once per frame
    void Update()
    {
       
    }
}
