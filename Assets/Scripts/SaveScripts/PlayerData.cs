using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int goldAmount;
    public float GasAmount;
    public int MaxGasAmount;
    public float[] position;
    public string slotName;
    public bool[] golds;
    public int RatRepellantAmount;

    public bool RingCollected;
    public bool PlayerHasKey;

    //guides
    public int walkCheck;
    public int shopCheck;

    public PlayerData (Player player)
    {
        goldAmount = player.goldAmount;
        MaxGasAmount = player.MaxGasAmount;
        GasAmount = player.GasAmount;
        position = new float[3];
        slotName = player.slotName;
        golds = player.golds; //golds
        RatRepellantAmount = player.RatRepellantAmount;
        PlayerHasKey = player.PlayerHasKey;
        RingCollected = player.RingCollected;

        //guides
        walkCheck = player.walkCheck;
        shopCheck = player.shopCheck;

        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

      

    }

}
