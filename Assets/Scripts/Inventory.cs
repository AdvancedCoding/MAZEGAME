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

    public GameObject WeddingRingSprite;
    public GameObject RingHelpText;
    public GameObject OldKeySprite;

    public ShopScript shopScript;

    public bool ShopInventory = false;

    public int HealItemAmount = 0;
    public GameObject HealItemAmountText;
    public int OilItemAmount = 0;
    public GameObject OilItemAmountText;

    [Header("Rat shit")]
    public int RatRepellantAmount;
    public GameObject RatRepellantAmountText;

    // public SuperLamp superLamp;
    MouseLook ML;

    private void Start()
    {
       
        WeddingRingSprite.SetActive(false);
        OldKeySprite.SetActive(false);
        ML = GameObject.Find("Main Camera").GetComponent<MouseLook>();
        UpdateInventory("fuel", Convert.ToInt32(SuperLamp.fuel));
        UpdateInventory("buyHeal", 1);
    }

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

            case "buyHeal":
                HealItemAmount += amount;
                HealItemAmountText.GetComponent<Text>().text = HealItemAmount.ToString();
                break;

            case "useHeal":
                HealItemAmount -= amount;
                HealItemAmountText.GetComponent<Text>().text = HealItemAmount.ToString();
                break;

            case "WeddingRing":
                WeddingRingSprite.SetActive(true);
                break;

            case "OldKey":
                RingHelpText.SetActive(false);
                WeddingRingSprite.SetActive(false);
                OldKeySprite.SetActive(true);
                break;

            case "oilItemFill":           
                SuperLamp.fuel += amount;
                if (SuperLamp.fuel > MaximumFuel) SuperLamp.fuel = MaximumFuel;
                fuelBar.SetFuelSlider(Convert.ToInt32(SuperLamp.fuel));
                OilItemAmount--;
                OilItemAmountText.GetComponent<Text>().text = OilItemAmount.ToString();
                break;

            case "buyCarryableOil":
                OilItemAmount += amount;
                OilItemAmountText.GetComponent<Text>().text = OilItemAmount.ToString();
                break;
            case "buyRatRepellant":
                RatRepellantAmount += amount;
                RatRepellantAmountText.GetComponent<Text>().text = OilItemAmount.ToString();
                break;

            case "useRatRepellant":
                RatRepellantAmount -= amount;
                RatRepellantAmountText.GetComponent<Text>().text = OilItemAmount.ToString();
                break;

            default:
                Debug.Log("Ayy_Lmao"); //En tiiä tarviiks tätä defaulttii en jaksa kattoo =)
                break;
                
        }
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Tab) && !ShopInventory)
        {
            inventoryEnabled = true;
           
        }

        else if (!shopScript.playerIsInShop)
        {
            inventoryEnabled = false;
        }

        if (Input.GetKeyUp(KeyCode.Tab) && !ShopInventory)
        {
            inventoryEnabled = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && shopScript.playerIsInShop)
        {
            inventoryEnabled = !inventoryEnabled;
        }

        if (inventoryEnabled == true)
        {
            ML.enabled = false;
            inventory.SetActive(true);
            if (!shopScript.ShopEnabled)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
            //Cursor does not work in update method if use in 2 update methods  ( Store and Inventory (cancels eachother))
            //     

        }

        if (!inventoryEnabled)
        {
            inventory.SetActive(false);
            ML.enabled = true;
            if (!shopScript.ShopEnabled)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
         //   Cursor.visible = false;
          //  Cursor.lockState = CursorLockMode.Locked;
        }

       
    }
}
