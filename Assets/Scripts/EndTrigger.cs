using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndTrigger : MonoBehaviour
{

    public int maxGold = 3;
    public Inventory inventory;
    public GameObject cutsceneCam;
    public GameObject PlayerCam;

	public ItemPickup Ring;
    public AudioSource ringAudio;
    public AudioSource playerAudio;
    public AudioSource Fernando;

    public AudioSource music;
    //public AudioSource bgrmusic;

    public GameObject inventoryUI;
    public GameObject title;
    public GameObject cinematiBars;



    void OnTriggerEnter(Collider other)
    { //kun osut kuutioon tarkistaa onko kultaa tarpeeksi
        if (other.CompareTag("Player"))
        {

            if (inventory.goldQuantity >= maxGold)
            {
                cutsceneCam.SetActive(true);
                inventoryUI.SetActive(false);
                cinematiBars.SetActive(true); //cinematic bars

                PlayerCam.SetActive(false);

		        if (Ring.RingCollected == false )
       	        {
       		          ringAudio.Stop(); //if ring is not collected it is making noise in the end scene --> mute
       	        }
               
                playerAudio.Stop();  //if player is damaged when finishing game, breathing sound is active --> mute
                Fernando.Stop(); //FERNANDO CALLATE POR FAVOOR

                //bgrmusic.Stop();
                music.Play();
                StartCoroutine(FinishCut());
                

                IEnumerator FinishCut() //SHOW TITLE
                {
                    yield return new WaitForSeconds(1);
                    title.SetActive(true);  //TOTW title
                    
                }


                

            }

            else
            {
                Debug.Log("get more gold");
            }

        }


    }

}
