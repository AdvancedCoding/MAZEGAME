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
    

    [Header("Garbage dependencies (fps player both)")]
    public Inventory inventory;


    // Update is called once per frame

    public void Start()
    {
        if (Globals.SMENULOADPRESSED == true)
        {
            LoadPlayer();
            Globals.SMENULOADPRESSED = false;
            Debug.Log("Loaded saved game");
        }
    }

    public void SavePlayer()
    {
        goldAmount = inventory.goldQuantity;
        MaxGasAmount = inventory.MaximumFuel;
        //GasAmount = Convert.ToInt32(SuperLamp.fuel);
        GasAmount = SuperLamp.fuel;


        SaveSystem.SavePlayer(this);

    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        inventory.goldQuantity = 0;
        inventory.UpdateInventory("gold", data.goldAmount);
        inventory.MaximumFuel = data.MaxGasAmount;
        SuperLamp.fuel = data.GasAmount;
        inventory.UpdateInventory("fuel", Convert.ToInt32(SuperLamp.fuel));

        Vector3 position;
        CharacterController cc = GetComponent<CharacterController>(); 
        //You need to disable and re enable char contrler in order to move player, nice one ...
        cc.enabled = false;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
        cc.enabled = true;


    }


}
