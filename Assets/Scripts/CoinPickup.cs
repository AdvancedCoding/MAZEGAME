using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
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
        Destroy(gameObject);
        //GetComponent<AudioSource>().Play;
    }
}
