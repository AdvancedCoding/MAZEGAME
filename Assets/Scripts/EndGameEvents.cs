using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EndGameEvents : MonoBehaviour
{
	public AudioSource mariaSFX;
	public AudioSource mariaSFX2;

    public GameObject MariaCanvas;
    public Animator totw;
    public VideoPlayer Video;
      public Animator fadeBlack;
      public Animator creditA;
    
                  public void playMaria(){ //called from camera end-game-animation EVENT
                   MariaCanvas.SetActive(true);  
                    Video.Play();
                }
                    public void hideMaria(){ //called from camera end-game-animation EVENT
                   MariaCanvas.SetActive(false);  
                    Video.Stop();

                }
                
                
                 public void sadHernandez(){ //called from camera end-game-animation EVENT
                mariaSFX.Play();
                }
                
                public void sadHernandezMariaSNGLE(){ //called from camera end-game-animation EVENT
                mariaSFX2.Play();
                }
                
                 public void fadeBlack1(){ //called from camera end-game-animation EVENT
                fadeBlack.SetTrigger("fadeBlack");
                }
                
                public void showCredits(){ //called from camera end-game-animation EVENT
                creditA.SetTrigger("show");
                }
                
                 public void showTotw(){ //called from camera end-game-animation EVENT
               // totw.SetTrigger("show");
                }


    
}
