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
  //  public Collider ShopCollider;

 
    public void Start()
    {
         ShopToolTip.SetActive(false);
         ShopUIObject.SetActive(false);
    }





    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //show ui tip press e to open store
            ShopToolTip.SetActive(true);
            playerIsInShop = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            playerIsInShop = false;
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && playerIsInShop)
        {
            ShopEnabled = !ShopEnabled;
        }

        if (ShopEnabled == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined; //cursor locked to screen 
            ShopUIObject.SetActive(true);
            ShopToolTip.SetActive(false);
        }

        if (!ShopEnabled && playerIsInShop)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            ShopUIObject.SetActive(false);
            ShopToolTip.SetActive(true);
        }
        if (!playerIsInShop) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            ShopUIObject.SetActive(false); 
            ShopToolTip.SetActive(false);
            ShopEnabled = false;
        }

       //cursor locked to screen 
     

    }



}
