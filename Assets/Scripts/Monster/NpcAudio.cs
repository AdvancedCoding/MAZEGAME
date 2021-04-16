using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAudio : MonoBehaviour
{
 public AudioClip scream;
 public GameObject soundRange;

  void Update(){
     // AudioSource.PlayClipAtPoint(scream, soundRange.transform.position);
  }

    
    
   /* private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //show ui tip press e to open store
            AudioSource.PlayClipAtPoint(scream, soundRange.transform.position);

        }
    }*/
}
