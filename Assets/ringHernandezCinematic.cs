using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ringHernandezCinematic : MonoBehaviour
{

public ItemPickup Ring;
public GameObject cutsceneCam;
public GameObject PlayerCam;

//public AudioSource music;
//public AudioSource bgrmusic;

public GameObject inventoryUI;
public GameObject speech;
public GameObject cinematiBars;
private int seen = 0;



void OnTriggerEnter (){ //kun osut kuutioon tarkistaa onko kultaa tarpeeksi

if (Ring.RingCollected == true && seen == 0){
cutsceneCam.SetActive(true);
speech.SetActive(true);
inventoryUI.SetActive(false);
cinematiBars.SetActive(true); //cinematic bars
PlayerCam.SetActive(false);
//bgrmusic.Stop();
//music.Play();
StartCoroutine(FinishCut());


IEnumerator FinishCut(){ //Kameran vaihto 5s jälkeen
yield return new WaitForSeconds(4);

PlayerCam.SetActive(true);
cinematiBars.SetActive(false); //cinematic bars
inventoryUI.SetActive(true);

cutsceneCam.SetActive(false);
speech.SetActive(false);
//ringFound = 1;
seen = 1;
}

}

else{
Debug.Log("get the ring/hernandez already saw ring");
}




}

}
