using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playersfx : MonoBehaviour
{

[SerializeField] private AudioClip lanternTweak; //oton animation sfx
[SerializeField] private AudioClip pickaxeHit; //oton animation sfx
private AudioSource audioSource; //oton sfx


    void Start()
    {
     audioSource = GetComponent<AudioSource>(); //oton sfx tweak lamppu
        
    }
    
    private void lightOnSFX() //(tweak) animaatiossa oleva event kutsuu tätä
    {
    audioSource.PlayOneShot(lanternTweak);
    }
    
    private void pickHitSFX() //(tweak) animaatiossa oleva event kutsuu tätä
    {
    audioSource.PlayOneShot(pickaxeHit);
    }

    void Update()
    {
    
 
        
    }
}
