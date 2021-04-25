using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestGold : MonoBehaviour
{
    public Inventory inventory;
    private bool ChestOpened;
    public GameObject OpenChestText;


    private void Start()
    {
        ChestOpened = false;
        OpenChestText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        
        
        if (other.CompareTag("Player"))
        {
            OpenChestText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E) && ChestOpened == false) {
               
                inventory.UpdateInventory("gold", 10);
                ChestOpened = true;
                Debug.Log("chest test 2");
                OpenChestText.SetActive(false);
                //AudioSource.PlayClipAtPoint(RingBing, gameObject.transform.position);
            }

            Debug.Log("chest test");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenChestText.SetActive(false);
        }
    }

}
