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
            Debug.Log("�LJYY OSTETTU: "+60);
        }
        else
        {
            Debug.Log("EI OO TARPEEKS RAHAA (HIENO TEKSTI T�H�N) "); //joku UI juttu t�h�n joku saa tehd�
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
            Debug.Log("EI OO TARPEEKS RAHAA (HIENO TEKSTI T�H�N) "); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
