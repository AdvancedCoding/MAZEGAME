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

    public PlayerData (Player player)
    {
        goldAmount = player.goldAmount;
        MaxGasAmount = player.MaxGasAmount;
        GasAmount = player.GasAmount;
        position = new float[3];

        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

      

    }

}
