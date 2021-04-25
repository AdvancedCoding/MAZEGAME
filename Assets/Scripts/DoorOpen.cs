using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject GetKeyText;
    public GameObject OpenDoorText;

    public bool PlayerHasKey;

    public Inventory inventory;


    // Start is called before the first frame update
    void Start()
    {
        PlayerHasKey = false;
        GetKeyText.SetActive(false);
        OpenDoorText.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && PlayerHasKey)
        {
            //OpenDoorText.SetActive(true);
            //AudioSource.PlayClipAtPoint(RingBing, gameObject.transform.position); //Door open audio here
            Destroy(gameObject);
        }

        else if (other.CompareTag("Player") && !PlayerHasKey)
        {
            GetKeyText.SetActive(true);
            Debug.Log("door test");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenDoorText.SetActive(false);
            GetKeyText.SetActive(false);
        }
    }
}
