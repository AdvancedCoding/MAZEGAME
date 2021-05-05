using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

[SerializeField] private AudioClip clip; //sfx
private AudioSource audioSource; //sfx
public Animator animator; //for mining animation

    public Inventory inventory;
    public float timeToBreakGold = 3f; // 3 Sec
    private float counter = 0f;
    public GameObject MineText;

    public GameObject player;
    public GameObject particleprefab;

    public void Start()
    {
      
        MineText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) //old code
      {
          if (other.CompareTag("Player"))
          {
            MineText.SetActive(true);
            //SHOW   UI HINT  ( PRESS MOUSE 2 TO MINE)
            // Pickup();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetButton("Fire2") && Vector3.Angle(player.transform.forward, transform.position - player.transform.position) < 45)
        {
            animator.SetTrigger("miningOn"); //stops mining animation
            
            MineText.SetActive(false);
            counter += Time.deltaTime;


            if ( counter > timeToBreakGold)
            {
            
            //animator.SetTrigger("miningOff");
            animator.Rebind();
            animator.Update(0f);
              
                counter = 0;
                Pickup();

               
                //HIDE UI ( PRESS MOUSE 2 TO MINE)
            }
            
        }
          else if (other.CompareTag("Player")){	//if player does not hold long enough to get gold -> show gold ui
          
            MineText.SetActive(true);
            counter = 0;
           
            animator.Rebind();
            animator.Update(0f);

            }
    }
    private void OnTriggerExit(Collider other) //player leaves the gold
    {
        
        if (other.CompareTag("Player"))
        {
            MineText.SetActive(false);
            
           // animator.SetTrigger("miningOff");
            animator.Rebind();
            animator.Update(0f);
        }
    }


    void Pickup()
    {
     
        inventory.UpdateInventory("gold", 1);
        Debug.Log("picked"); // coin++;

        AudioSource.PlayClipAtPoint(clip, gameObject.transform.position);
        Instantiate(particleprefab, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);

        

    }
}
