using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minecartMove : MonoBehaviour
{
    public GameObject cutsceneCam;
    public GameObject PlayerCam;
    public AudioSource cartSFX;

    public GameObject cinematiBars;
    public GameObject inventoryUI;

    public GameObject ThePlayer;
    //public CharacterController cc = GetComponent<CharacterController>(); 
    public CharacterController cc;


    //You need to disable and re enable char contrler in order to move player, nice one ...



    void OnTriggerEnter()
    { //kun osut kuutioon tarkistaa onko kultaa tarpeeksi

        cutsceneCam.SetActive(true);

        inventoryUI.SetActive(false);
        cinematiBars.SetActive(true); //cinematic bars
        PlayerCam.SetActive(false);

        cc.enabled = false;
        ThePlayer.transform.position = new Vector3(49, -3, -45);
        cc.enabled = true;

        cartSFX.Play();

        StartCoroutine(FinishCut());


        IEnumerator FinishCut()
        { //Kameran vaihto 5s jälkeen
            yield return new WaitForSeconds(10);

            PlayerCam.SetActive(true);
            cinematiBars.SetActive(false); //cinematic bars
            inventoryUI.SetActive(true);
            cutsceneCam.SetActive(false);
            cartSFX.Stop();
        }

    }
}
