using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuide : MonoBehaviour
{

public GameObject thePlayer;
public GameObject hernandezCam;
public GameObject hernandezText;
public GameObject inventory;
public GameObject cinematicBars;
public int shopCheck = 0;

/*
void OnTriggerEnter(){
hernandezCam.SetActive(true);
thePlayer.SetActive(false);
}
*/


void OnTriggerEnter (Collider other){	//kun pelaaja kollidee ekan kerran näyttää mistä löytyy hernandezin kauppa

if (shopCheck == 0){
hernandezCam.SetActive(true);
cinematicBars.SetActive(true);
thePlayer.SetActive(false);
inventory.SetActive(false);
hernandezText.SetActive(true); //show hernandez text
StartCoroutine(FinishCut());
shopCheck=1;

IEnumerator FinishCut(){ //Kameran vaihto takaisin 6s jälkeen
yield return new WaitForSeconds(6);
thePlayer.SetActive(true);
hernandezText.SetActive(false); //hide hernandez text
cinematicBars.SetActive(false);
hernandezCam.SetActive(false);
inventory.SetActive(true);
}

}

else{
Debug.Log("shop already seen");
}

}


}
