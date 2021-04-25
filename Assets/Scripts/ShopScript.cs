using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    // Start is called before the first frame update
   
    public bool ShopEnabled;
    public GameObject ShopUIObject;
    public GameObject ShopToolTip;
    public bool playerIsInShop = false;

    public AudioClip HernandezShowsHisGratitude;

    public AudioClip[] audioClipsGreet;
    public AudioClip[] audioClipsThanks;
    public AudioClip[] audioClipsChatter;

    public AudioSource Hernandez;

    public ItemPickup Ring;

    public ShopUIButtonsScript shopUIButtonsScript;

    public Inventory inventory;

    public DoorOpen doorOpen;
    
    
    //  public Collider ShopCollider;
    MouseLook ML;
    SuperLamp SL;
    //public AudioClip _ac;
    public GameObject storeObject;

    public void Start()
    {
         ShopToolTip.SetActive(false);
         ShopUIObject.SetActive(false);
         ML = GameObject.Find("Main Camera").GetComponent<MouseLook>();
        SL = GameObject.Find("HITBOXFORLIGHT").GetComponent<SuperLamp>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //show ui tip press e to open store
            ShopToolTip.SetActive(true);
            playerIsInShop = true;
            
            //Hernandez voice lines
            if (Hernandez.isPlaying)
            {
                Hernandez.Stop();
            }

            if (Ring.RingCollected && !doorOpen.PlayerHasKey)
            {

                AudioSource.PlayClipAtPoint(HernandezShowsHisGratitude, Hernandez.transform.position);
                
                inventory.UpdateInventory("OldKey", 1);

                doorOpen.PlayerHasKey = true;
            }

            else
            {
                Hernandez.PlayOneShot(audioClipsGreet[Random.Range(0, audioClipsGreet.Length)]);
                StartCoroutine(HernandezTimer());
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Hernandez.isPlaying) {
                Hernandez.Stop();
            }
            
            Hernandez.PlayOneShot(audioClipsThanks[Random.Range(0, audioClipsThanks.Length)]);
            playerIsInShop = false;
            shopUIButtonsScript.NotEnoughGoldText.SetActive(false);
        }
    }

    IEnumerator HernandezTimer()
    {
        while (playerIsInShop) {
            yield return new WaitForSeconds(8);
                if (!Hernandez.isPlaying)
                {
                    Hernandez.PlayOneShot(audioClipsChatter[Random.Range(0, audioClipsChatter.Length)]);
                }
            yield return new WaitForSeconds(5);
        }
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsInShop)
        {
            ShopEnabled = !ShopEnabled;          
            
        }

        if (ShopEnabled == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined; //cursor locked to screen 
            
            //You need to disable and re enable char contrler in order to move player, nice one ...
            ML.enabled = false;
            SL.enabled = false;
            ShopUIObject.SetActive(true);
            ShopToolTip.SetActive(false);

            inventory.ShopInventory = true; //cant open/close inventory

        }

        if (!ShopEnabled && playerIsInShop)
        {
            if (!ML.enabled) { ML.enabled = true; }
            if (!SL.enabled) { SL.enabled = true; }
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            ShopUIObject.SetActive(false);
            ShopToolTip.SetActive(true);            


        }
        if (!playerIsInShop) {
            if (!ML.enabled) { ML.enabled = true; }
            if (!SL.enabled) { SL.enabled = true; }
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            ShopUIObject.SetActive(false); 
            ShopToolTip.SetActive(false);
            ShopEnabled = false;

            inventory.ShopInventory = false; //inventory works normalluy
          
        }

       //cursor locked to screen 
    }



}
