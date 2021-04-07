using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIButtonsScript : MonoBehaviour
{
    public Inventory Inventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void BuyFuel()
    {
        Inventory.UpdateInventory("buyFuel", 60);
        Inventory.UpdateInventory("gold", -1);
        Debug.Log("IM A GENIIUS");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
