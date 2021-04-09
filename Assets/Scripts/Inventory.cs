using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    //invetory scripti
    public bool inventoryEnabled;
    public GameObject inventory;
    public GameObject goldCountText;
    public int goldQuantity = 0;
    public GameObject fuelAmountText;
    public FuelBarScript fuelBar;
    public int MaximumFuel = 60;
    // public SuperLamp superLamp;
  


    public void UpdateInventory(string itemName, int amount)
    {
        switch (itemName)
        {
            case "gold":
                goldQuantity += amount;
                goldCountText.GetComponent<Text>().text = goldQuantity.ToString();
                break;
  
                // USED TO UPDATE FUELBAR WHEN FUEL IS USED
            case "fuel":
                fuelAmountText.GetComponent<Text>().text = "Fuel amount: " + amount;
                fuelBar.SetFuelSlider(amount); 
                break;

                //REFUEL FUEL
            case "buyFuel":
                fuelAmountText.GetComponent<Text>().text = "Fuel amount: " + amount;
                SuperLamp.fuel += amount;
                if (SuperLamp.fuel > MaximumFuel) SuperLamp.fuel = MaximumFuel;
                fuelBar.SetFuelSlider(Convert.ToInt32(SuperLamp.fuel));
                break;

                //BUY BIGGER CAN OF FUEL
            case "buyCanister":
                fuelAmountText.GetComponent<Text>().text = "Fuel amount: " + amount;
                MaximumFuel = amount;
                SuperLamp.fuel = amount;
                fuelBar.SetMaxFuelSlider(amount); //This fills the slider fully aswell as setting the max amount
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
            inventoryEnabled = !inventoryEnabled;
        }

        if (inventoryEnabled == true)
        {
            inventory.SetActive(true);

            //Cursor does not work in update method if use in 2 update methods  ( Store and Inventory (cancels eachother))
       //     Cursor.visible = true;
      //      Cursor.lockState = CursorLockMode.None;
        
        }

       if (!inventoryEnabled)
        {
            inventory.SetActive(false);
         //   Cursor.visible = false;
          //  Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
