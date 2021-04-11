using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndTrigger : MonoBehaviour
{

public int maxGold = 3;
public Inventory inventory;
public GameObject cutsceneCam;
public GameObject cutsceneCam2;
public GameObject PlayerCam;

public AudioSource music;
public AudioSource bgrmusic;



void OnTriggerEnter (){ //kun osut kuutioon tarkistaa onko kultaa tarpeeksi

if (inventory.goldQuantity >= maxGold){
Debug.Log("you won");
cutsceneCam.SetActive(true);
PlayerCam.SetActive(false);
bgrmusic.Stop();
music.Play();
StartCoroutine(FinishCut());

IEnumerator FinishCut(){ //Kameran vaihto 5s jälkeen
yield return new WaitForSeconds(15);
cutsceneCam2.SetActive(true);
cutsceneCam.SetActive(false);
}

}

else{
Debug.Log("get more gold");
}




}

}
