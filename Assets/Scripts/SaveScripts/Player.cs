using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Values that will saved (ignore these)")]
    public int goldAmount;
    public float GasAmount;
    public int MaxGasAmount;
    public string slotName;
    public bool[] golds;
    public int RatRepellantAmount;
    public int OilItemAmount;
    //ring key stuff
    public bool RingCollected;
    public bool PlayerHasKey;

    //guides
    public int walkCheck;
    public int shopCheck;

   [Header("Garbage dependencies (fps player both)")]
    public Inventory inventory;
    public GoldCheck GoldCheck;
    public DoorOpen DoorOpen;
    public ItemPickup ItemPickup;
    public PlayerGuide PlayerGuide;
    public WalkGuide WalkGuide;

    // Update is called once per frame

    public void Start()
    {
       
        slotName = Globals.NewAdventurerName;
        Debug.Log(slotName);
        if (Globals.SMENULOADPRESSED == true && !Globals.loadnewgame)
        {
            LoadPlayer();
            Globals.SMENULOADPRESSED = false;
            Debug.Log("Loaded saved game");
            Debug.Log(slotName);
        }
    }

    public void SavePlayer()
    {
        OilItemAmount = inventory.OilItemAmount;
        goldAmount = inventory.goldQuantity;
        MaxGasAmount = inventory.MaximumFuel;
        RatRepellantAmount = inventory.RatRepellantAmount;
        PlayerHasKey = DoorOpen.PlayerHasKey;
        RingCollected = ItemPickup.RingCollected;

        //guides
        walkCheck = WalkGuide.walkCheck;
        shopCheck = PlayerGuide.shopCheck;
        //
        GasAmount = SuperLamp.fuel;

        GoldCheck.GOLDCHECKER();

        golds = GoldCheck.goldexits;

      //  for (int i = 0; i < golds.Length; i++) Debug.Log(golds[i]);

            SaveSystem.SavePlayer(this,Globals.slot);
      
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer(Globals.slot);
        //guides
        WalkGuide.walkCheck = data.walkCheck;
        PlayerGuide.shopCheck = data.shopCheck;
        //
        inventory.OilItemAmount = 0;
        inventory.RatRepellantAmount = 0;
        inventory.goldQuantity = 0;
        inventory.UpdateInventory("buyCarryableOil", data.OilItemAmount);
        inventory.UpdateInventory("buyRatRepellant", data.RatRepellantAmount);
        inventory.UpdateInventory("gold", data.goldAmount);
        inventory.MaximumFuel = data.MaxGasAmount;
        SuperLamp.fuel = data.GasAmount;
        inventory.UpdateInventory("fuel", Convert.ToInt32(SuperLamp.fuel));
        slotName = data.slotName;
        Vector3 position;
        CharacterController cc = GetComponent<CharacterController>(); 
        //You need to disable and re enable char contrler in order to move player, nice one ...
        cc.enabled = false;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
        cc.enabled = true;
        if (data.PlayerHasKey)
        {
            inventory.UpdateInventory("OldKey", 1);
            DoorOpen.PlayerHasKey = true;
        }
        else if( data.RingCollected && !data.PlayerHasKey)
        {
            inventory.UpdateInventory("WeddingRing", 1);
            ItemPickup.RingCollected = true;
        }
        else if (!data.RingCollected && !data.PlayerHasKey)
        {
            inventory.RingHelpText.SetActive(false);
            inventory.WeddingRingSprite.SetActive(false);
            inventory.OldKeySprite.SetActive(false);
        }

        golds = data.golds;
        GoldCheck.goldexits = golds;
        GoldCheck.GOLDUPDATEPOSSOMETHING();


    }


}
