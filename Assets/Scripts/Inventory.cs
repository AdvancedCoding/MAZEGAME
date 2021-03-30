using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    //invetory scripti
    public bool invetoryEnabled;
    public GameObject inventory;
    public GameObject goldCountText;
    public int goldQuantity = 0;
    public int fuelAmount = 60;
    public GameObject fuelAmountText;
    public FuelBarScript fuelBar;

   

    public void UpdateInventory(string itemName, int amount)
    {
        switch (itemName)
        {
            case "gold":
                goldQuantity += amount;
                goldCountText.GetComponent<Text>().text = goldQuantity.ToString();
                break;
         


            case "fuel":
                fuelAmountText.GetComponent<Text>().text = "Fuel amount: " + amount;
                fuelBar.SetFuelSlider(amount);
               
                break;

            default:
                Debug.Log("Ayy_Lmao"); //En tiiä tarviiks tätä defaulttii en jaksa kattoo =)
                break;

        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            invetoryEnabled = !invetoryEnabled;
        }

        if (invetoryEnabled == true)
        {
            inventory.SetActive(true);

        }

        else
        {
            inventory.SetActive(false);
        }
    }
}
