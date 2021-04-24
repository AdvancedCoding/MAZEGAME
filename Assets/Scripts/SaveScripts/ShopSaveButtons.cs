using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSaveButtons : MonoBehaviour
{
    // Start is called before the first frame update
   
    public Player player;
    private bool saveMenuActive = false;
    public GameObject saveSlots;
    public GameObject loadSlots;


    public void saveCurrentSlot()
    {
        player.SavePlayer();
    } //this function is literally and player player  depency is the only thing in this script that is currently being used :D

    public void saveSlot1()
    {
        Globals.slot = "slot1";
        player.SavePlayer();
    }
    public void saveSlot2()
    {
        Globals.slot = "slot2";
        player.SavePlayer();
    }
    public void saveSlot3()
    {

        Globals.slot = "slot3";
        player.SavePlayer();
    }


    public void loadSlot1()
    {
        Globals.slot = "slot1";
        player.LoadPlayer();
       
    }
    public void loadSlot2()
    {
        Globals.slot = "slot2";
        player.LoadPlayer();

    }

    public void loadSlot3()
    {
        Globals.slot = "slot3";
        player.LoadPlayer();
    }

 public void openSaveMenus()
    {
        loadSlots.SetActive(!saveMenuActive);
        saveSlots.SetActive(!saveMenuActive);
        saveMenuActive = !saveMenuActive;
    }
}
