using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndTrigger : MonoBehaviour
{

    public int maxGold = 3;
    public Inventory inventory;
    public GameObject cutsceneCam;
    public GameObject PlayerCam;


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
