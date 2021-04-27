using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestGold : MonoBehaviour
{
    public Inventory inventory;
    private bool ChestOpened;
    public GameObject OpenChestText;

    public AudioClip chestOpenAudio;


    private void Start()
    {
        ChestOpened = false;
        OpenChestText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
              
        if (other.CompareTag("Player"))
        {
            if (!ChestOpened)
            {
                OpenChestText.SetActive(true);
            }

            if (Input.GetKey(KeyCode.E) && ChestOpened == false) {

                AudioSource.PlayClipAtPoint(chestOpenAudio, gameObject.transform.position);
                inventory.UpdateInventory("gold", 10);
                ChestOpened = true;
                Debug.Log("chest test 2");
                OpenChestText.SetActive(false);
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
