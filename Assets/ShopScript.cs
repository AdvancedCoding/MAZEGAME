using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Inventory Inventory;
    private bool ShopEnabled;
    public GameObject ShopObject;

    public void BuyFuel()
    {
        Inventory.UpdateInventory("fuel", 60);
        Inventory.UpdateInventory("gold", -1);
        Debug.Log("IM A GENIIUS");
    }








    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ShopEnabled = !ShopEnabled;
        }

        if (ShopEnabled == true)
        {

            Cursor.lockState = CursorLockMode.Confined; //cursor locked to screen 
            ShopObject.SetActive(true);
        }

        else
        {
            Cursor.lockState = CursorLockMode.Locked; //cursor locked to screen 
            ShopObject.SetActive(false);

        }
    }



}
