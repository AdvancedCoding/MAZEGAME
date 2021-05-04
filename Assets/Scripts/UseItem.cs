using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
{

   public Inventory inventory;
   public NpcAttack npcAttack;

   public AudioClip drinking;
    public AudioClip CarryOilFill;

    [Header ("Rat stuff")]
    public float ratTimer = 30f; //rats avoid you for x amount of time
    public static bool ratRepellantIsOn = false; // used for npcmove

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

    public void RatRepellantUse()
    {
        if (inventory.RatRepellantAmount>0)
        {
            inventory.UpdateInventory("useRatRepellant", 1);
            // AudioSource.PlayClipAtPoint(CarryOilFill, inventory.transform.position); //Oil Audio Here
            StartCoroutine(ratRepellantTimer());
        }
    }

    IEnumerator ratRepellantTimer()
    {
        ratRepellantIsOn = true;
        yield return new WaitForSecondsRealtime(ratTimer);
        ratRepellantIsOn = false;
    }


    }
