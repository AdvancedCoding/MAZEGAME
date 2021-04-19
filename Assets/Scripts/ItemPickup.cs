using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Inventory inventory;

    public AudioClip RingBing;

    public bool RingCollected;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            inventory.UpdateInventory("WeddingRing", 1);
            RingCollected = true;
            AudioSource.PlayClipAtPoint(RingBing, gameObject.transform.position);

            Destroy(gameObject);

            Debug.Log("Ring test");
        }

    }

}
