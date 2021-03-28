using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playersfx : MonoBehaviour
{

[SerializeField] private AudioClip clip; //oton animation sfx
private AudioSource audioSource; //oton sfx
    // Start is called before the first frame update
    void Start()
    {
     audioSource = GetComponent<AudioSource>(); //oton sfx tweak lamppu
        
    }
    
    private void playerTweakLight()
    {
    audioSource.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
    
 
        
    }
}
