using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    // Start is called before the first frame update
   
    private bool ShopEnabled;
    public GameObject ShopUIObject;
    public GameObject ShopToolTip;
    public bool playerIsInShop = false;

    public ShopUIButtonsScript shopUIButtonsScript;
    
    //  public Collider ShopCollider;
    MouseLook ML;
    SuperLamp SL;
    public AudioClip _ac;
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
            AudioSource.PlayClipAtPoint(_ac, storeObject.transform.position);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {          
            playerIsInShop = false;
            shopUIButtonsScript.NotEnoughGoldText.SetActive(false);
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
        }

       //cursor locked to screen 
    }



}
