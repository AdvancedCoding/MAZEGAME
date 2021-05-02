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
    public int CarryOilItemPrice = 1;

    public GameObject storeObject;
    public GameObject NotEnoughGoldText;

    public AudioClip SmallOilAudio;
    public AudioClip BigOilAudio;
    public AudioClip HealItemAudio;
    public AudioClip CarryOilItemAudio;

    public AudioClip NotEnoughGoldAudio;

   private void Start()
    {
        NotEnoughGoldText.SetActive(false);
        HealItemPrice = 2;
    }

    public void BuyFuel()
    {
        if (Inventory.goldQuantity >= FuelPrice)
        {
            Inventory.UpdateInventory("buyFuel", 60);
            Inventory.UpdateInventory("gold", -FuelPrice);
            Debug.Log("�LJYY OSTETTU: "+60);        

            AudioSource.PlayClipAtPoint(SmallOilAudio, storeObject.transform.position);
        }
        else
        {
            Debug.Log("EI OO TARPEEKS RAHAA (HIENO TEKSTI T�H�N) "); //joku UI juttu t�h�n joku saa tehd�
            AudioSource.PlayClipAtPoint(NotEnoughGoldAudio, storeObject.transform.position);
            NotEnoughGoldText.SetActive(true);
        }
    }

    public void BuyBigFuelCanister()
    {
        if (Inventory.goldQuantity >= FuelCanisterPrice)
        {
            Inventory.UpdateInventory("buyCanister", 120);
            Inventory.UpdateInventory("gold", -FuelCanisterPrice);
            Debug.Log("Kanisteri OSTETTU: " + 120);

            AudioSource.PlayClipAtPoint(BigOilAudio, storeObject.transform.position);
        }
        else
        {
            Debug.Log("EI OO TARPEEKS RAHAA (HIENO TEKSTI T�H�N) ");
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
            Debug.Log("EI OO TARPEEKS RAHAA (HIENO TEKSTI T�H�N) ");
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
            Debug.Log("Heal price: " + CarryOilItemPrice);
            Debug.Log("Carry Fuel OSTETTU");

            AudioSource.PlayClipAtPoint(CarryOilItemAudio, storeObject.transform.position);

        }
        else
        {
            Debug.Log("EI OO TARPEEKS RAHAA (HIENO TEKSTI T�H�N) ");
            AudioSource.PlayClipAtPoint(NotEnoughGoldAudio, storeObject.transform.position);
            NotEnoughGoldText.SetActive(true);
        }
    } 

        // Update is called once per frame
        void Update()
    {
       
    }
}
