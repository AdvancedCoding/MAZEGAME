using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loreBegin : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerGuide playerGuide;
    void Start()
    {
        if (playerGuide.shopCheck == 1) gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
