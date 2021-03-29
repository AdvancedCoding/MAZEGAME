using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

[SerializeField] private AudioClip clip; //sfx
private AudioSource audioSource; //sfx

    public Inventory inventory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup();
        }
    }

    void Pickup()
    {
        inventory.UpdateInventory("gold", 1);
        Debug.Log("picked"); // coin++;
        
        audioSource = GetComponent<AudioSource>(); //play sfx
        audioSource.PlayOneShot(clip);
        
        Destroy(gameObject);
        

    }
}
