using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIButtonsScript : MonoBehaviour
{
    public Inventory Inventory;
    public int FuelPrice = 1;
    public int FuelCanisterPrice = 5;
    
    
    public void BuyFuel()
    {
        if (Inventory.goldQuantity >= FuelPrice)
        {
            Inventory.UpdateInventory("buyFuel", 60);
            Inventory.UpdateInventory("gold", -FuelPrice);
            Debug.Log("ÖLJYY OSTETTU: "+60);
        }
        else
        {
            Debug.Log("EI OO TARPEEKS RAHAA (HIENO TEKSTI TÄHÄN) "); //joku UI juttu tähän joku saa tehdä
        }
    }

    public void BuyBigFuelCanister()
    {
        if (Inventory.goldQuantity >= FuelCanisterPrice)
        {
            Inventory.UpdateInventory("buyCanister", 120);
            Inventory.UpdateInventory("gold", -FuelCanisterPrice);
            Debug.Log("Kanisteri OSTETTU: " + 120);
        }
        else
        {
            Debug.Log("EI OO TARPEEKS RAHAA (HIENO TEKSTI TÄHÄN) "); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
