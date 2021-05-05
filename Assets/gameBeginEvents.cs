using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameBeginEvents : MonoBehaviour
{
    public GameObject loreText;
    
    public void hideLore(){ //called from camera end-game-animation EVENT
                loreText.SetActive(false);
                }
    
}
