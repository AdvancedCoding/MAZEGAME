using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EndGameEvents : MonoBehaviour
{
    public GameObject MariaCanvas;
    public VideoPlayer Video;
    
                  public void playMaria(){ //called from camera end-game-animation EVENT
                
                   MariaCanvas.SetActive(true);  
                    Video.Play();

                }
                    public void hideMaria(){ //called from camera end-game-animation EVENT
                
                   MariaCanvas.SetActive(false);  
                    Video.Stop();

                }
    
}
