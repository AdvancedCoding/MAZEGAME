using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject GetKeyText;
  
    public bool PlayerHasKey;

    public GameObject door;
    public GameObject OpenedDoor;

    public Inventory inventory;

    public AudioSource OpenedDoorAS;
    public AudioClip doorAudio;

    private bool doorOpened;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHasKey = false;
        GetKeyText.SetActive(false);
      
        OpenedDoor.SetActive(false);
        doorOpened = false;
    }

    private void OnTriggerEnter(Collider other)
    {

       if (other.tag == "Player" && PlayerHasKey && !doorOpened)
       {

            Destroy(door);
            OpenedDoor.SetActive(true);
            OpenedDoorAS.PlayOneShot(doorAudio); //Door open audio here
            doorOpened = true;

        }

        if (other.tag == "Player" && !PlayerHasKey)
        {
            GetKeyText.SetActive(true);
        
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {         
            GetKeyText.SetActive(false);
        }
    }

 
}
