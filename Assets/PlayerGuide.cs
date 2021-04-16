using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuide : MonoBehaviour
{

public GameObject thePlayer;
public GameObject hernandezCam;
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
thePlayer.SetActive(false);
StartCoroutine(FinishCut());
shopCheck=1;

IEnumerator FinishCut(){ //Kameran vaihto takaisin 6s jälkeen
yield return new WaitForSeconds(6);
thePlayer.SetActive(true);
hernandezCam.SetActive(false);
}

}

else{
Debug.Log("shop already seen");
}

}


}
