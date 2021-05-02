using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{

   public Inventory inventory;
   public NpcAttack npcAttack;

   public AudioClip drinking;
    public AudioClip CarryOilFill;

   public void HealItemUse()
    {
        if (inventory.HealItemAmount > 0 && npcAttack.PlayerRemainingHP < npcAttack.PlayerMaxHP)
        {
            inventory.UpdateInventory("useHeal", 1);
            npcAttack.PlayerRemainingHP++;
            Debug.Log("Healed, HP is: " + npcAttack.PlayerRemainingHP);
            AudioSource.PlayClipAtPoint(drinking, inventory.transform.position);
        }

        else if (inventory.HealItemAmount <= 0)
        {
            Debug.Log("Not enough heal items.");
        }

        else if (npcAttack.PlayerRemainingHP == npcAttack.PlayerMaxHP)
        {
            Debug.Log("Health already full");
        }
    }

    public void OilItemUse()
    {
        if (inventory.OilItemAmount > 0 && SuperLamp.fuel < inventory.MaximumFuel)
        {
            inventory.UpdateInventory("oilItemFill", 15);
            AudioSource.PlayClipAtPoint(CarryOilFill, inventory.transform.position); //Oil Audio Here
        }
    }



}
