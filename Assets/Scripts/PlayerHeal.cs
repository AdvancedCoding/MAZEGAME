using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeal : MonoBehaviour
{
    public Inventory inventory;
    public NpcAttack npcAttack;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && inventory.HealItemAmount >= 1)
        {
            if (npcAttack.PlayerRemainingHP < npcAttack.PlayerMaxHP)
            {
                npcAttack.PlayerRemainingHP += 1;
                inventory.UpdateInventory("useHeal", 1);
                Debug.Log("Health: " + npcAttack.PlayerRemainingHP.ToString());
                npcAttack.BloodStain.SetActive(false);
            }

            else
            {
                Debug.Log("Health already full.");
                Debug.Log("Health: " + npcAttack.PlayerRemainingHP.ToString());
            }
        }

    }
}
