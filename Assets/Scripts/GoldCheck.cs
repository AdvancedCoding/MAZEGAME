using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCheck : MonoBehaviour
{
  //  public GameObject[] golds;
    public GameObject[] golds;
    public bool[] goldexits;
    // Start is called before the first frame update
    void Start()
    {

/*
        goldexits = new bool[golds.Length + 1];
        for (int i = 0; i < golds.Length; i++)
        {
            if (golds[i] == null)
            {
                goldexits[i] = false;
            }
            else
            {
                goldexits[i] = true;
            }
            Debug.Log(golds[i]);
            Debug.Log(goldexits[i]);
        }
        */
    }
    public void GOLDCHECKER()
    {

        goldexits = new bool[golds.Length + 1];
        for (int i = 0; i < golds.Length; i++)
        {
            if (golds[i] == null)
            {
                goldexits[i] = false;
            }
            else
            {
                goldexits[i] = true;
            }
        //    Debug.Log(golds[i]);
     //       Debug.Log(goldexits[i]);
        }

    }

    public void GOLDUPDATEPOSSOMETHING()
    {
        Debug.Log(goldexits.Length);
        Debug.Log(golds.Length);
        for (int i = 0; i < goldexits.Length-1; i++)
        {
            if (!goldexits[i]) Destroy(golds[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
