using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

[SerializeField] private AudioClip clip; //sfx
private AudioSource audioSource; //sfx

    public Inventory inventory;
    public float timeToBreakGold = 30f; // 3 Sec
    private float counter = 0f;

      private void OnTriggerEnter(Collider other) //old code
      {
          if (other.CompareTag("Player"))
          {
            //SHOW   UI HINT  ( PRESS MOUSE 2 TO MINE)
            // Pickup();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetButton("Fire2"))
        {
            counter += Time.deltaTime;
            if ( counter > timeToBreakGold)
            {
                counter = 0;
                Pickup();
                //HIDE UI ( PRESS MOUSE 2 TO MINE)
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //HIDE UI ( PRESS MOUSE 2 TO MINE)
        }
    }


    void Pickup()
    {
        inventory.UpdateInventory("gold", 1);
        Debug.Log("picked"); // coin++;

        // audioSource = GetComponent<AudioSource>(); //play sfx
        // audioSource.PlayOneShot(clip);

        AudioSource.PlayClipAtPoint(clip, gameObject.transform.position);

        Destroy(gameObject);
        

    }
}
