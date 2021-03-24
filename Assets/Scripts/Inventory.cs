using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    //invetory scripti
    public bool invetoryEnabled;
    public GameObject inventory;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            invetoryEnabled = !invetoryEnabled;
        }

        if (invetoryEnabled == true)
        {
            inventory.SetActive(true);

        }

        else
        {
            inventory.SetActive(false);
        }
    }
}
