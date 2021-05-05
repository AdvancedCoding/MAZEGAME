using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIButtonsScript : MonoBehaviour
{
    public Inventory Inventory;

    //prices
    public int FuelPrice = 1;
    public int FuelCanisterPrice = 5;
    public int HealItemPrice;
    public int CarryOilItemPrice = 2;

    public int ratItemPrice = 2;

    public GameObject storeObject;
    public GameObject NotEnoughGoldText;

    public AudioClip SmallOilAudio;
    public AudioClip BigOilAudio;
    public AudioClip HealItemAudio;
    public AudioClip CarryOilItemAudio;
    public AudioClip ratItemAudio;


    public AudioClip NotEnoughGoldAudio;

    public bool newLampBought = false;
    public GameObject lampSprite;
    public ShopScript shopScript;

   private void Start()
    {
        NotEnoughGoldText.SetActive(false);
        HealItemPrice = 2;
        CarryOilItemPrice = 2;
    }

    public void BuyFuel()
    {
        if (Inventory.goldQuantity >= FuelPrice)
        {
            Inventory.UpdateInventory("buyFuel", 60);
            Inventory.UpdateInventory("gold", -FuelPrice);
            Debug.Log("ÖLJYY OSTETTU: "+60);        

            AudioSource.PlayClipAtPoint(SmallOilAudio, storeObject.transform.position);
        }
        else
        {
            Debug.Log("EI OO TARPEEKS RAHAA (HIENO TEKSTI TÄHÄN) "); //joku UI juttu tähän joku saa tehdä
            AudioSource.PlayClipAtPoint(NotEnoughGoldAudio, storeObject.transform.position);
            NotEnoughGoldText.SetActive(true);
        }
    }

    public void BuyBigFuelCanister()
    {
        if (Inventory.goldQuantity >= FuelCanisterPrice && !newLampBought)
        {
            Inventory.UpdateInventory("buyCanister", 120);
            Inventory.UpdateInventory("gold", -FuelCanisterPrice);
            Debug.Log("Kanisteri OSTETTU: " + 120);

            AudioSource.PlayClipAtPoint(BigOilAudio, storeObject.transform.position);
            lampSprite.SetActive(false);
            shopScript.betterLampText.SetActive(false);
            newLampBought = true;
        }

        else if (newLampBought)
        {
            Debug.Log("already bought");
        }

        else
        {
            Debug.Log("EI OO TARPEEKS RAHAA (HIENO TEKSTI TÄHÄN) ");
            AudioSource.PlayClipAtPoint(NotEnoughGoldAudio, storeObject.transform.position);
            NotEnoughGoldText.SetActive(true);
        }
    }

    public void BuyHealItem()
    {
        if (Inventory.goldQuantity >= HealItemPrice)
        {
            Inventory.UpdateInventory("buyHeal", 1);
            Inventory.UpdateInventory("gold", -HealItemPrice);
            Debug.Log("Heal price: " + HealItemPrice);
            Debug.Log("Heal OSTETTU");

            AudioSource.PlayClipAtPoint(HealItemAudio, storeObject.transform.position);

        }
        else
        {
            Debug.Log("EI OO TARPEEKS RAHAA (HIENO TEKSTI TÄHÄN) ");
            AudioSource.PlayClipAtPoint(NotEnoughGoldAudio, storeObject.transform.position);
            NotEnoughGoldText.SetActive(true);
        }
    }

    public void BuyCarryableOil()
    {
        if (Inventory.goldQuantity >= CarryOilItemPrice)
        {
            Inventory.UpdateInventory("buyCarryableOil", 1);
            Inventory.UpdateInventory("gold", -CarryOilItemPrice);
            Debug.Log("OIL price: " + CarryOilItemPrice);
            Debug.Log("Carry Fuel OSTETTU");

            AudioSource.PlayClipAtPoint(CarryOilItemAudio, storeObject.transform.position);

        }
        else
        {
            Debug.Log("EI OO TARPEEKS RAHAA (HIENO TEKSTI TÄHÄN) ");
            AudioSource.PlayClipAtPoint(NotEnoughGoldAudio, storeObject.transform.position);
            NotEnoughGoldText.SetActive(true);
        }
    }

    public void BuyRatRepellant()
    {
        if (Inventory.goldQuantity >= ratItemPrice)
        {
            Inventory.UpdateInventory("buyRatRepellant", 1);
            Inventory.UpdateInventory("gold", -ratItemPrice);
            Debug.Log("rat shit price: " + CarryOilItemPrice);
            Debug.Log("rat Fuel OSTETTU");

            AudioSource.PlayClipAtPoint(ratItemAudio, storeObject.transform.position); //rat item audio here

        }
        else
        {
            Debug.Log("EI OO TARPEEKS RAHAA (HIENO TEKSTI TÄHÄN) ");
            AudioSource.PlayClipAtPoint(NotEnoughGoldAudio, storeObject.transform.position);
            NotEnoughGoldText.SetActive(true);
        }
    }



    // Update is called once per frame
    void Update()
    {
       
    }
}
