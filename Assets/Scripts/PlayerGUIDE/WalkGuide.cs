using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkGuide : MonoBehaviour
{

public GameObject thePlayer;
public GameObject hernandezText;
public GameObject inventory;
public int walkCheck = 0;

/*
void OnTriggerEnter(){
hernandezCam.SetActive(true);
thePlayer.SetActive(false);
}
*/

void OnTriggerExit(Collider other){
if (walkCheck == 0){

inventory.SetActive(true);
hernandezText.SetActive(true); //show hernandez text
walkCheck=1;
StartCoroutine(FinishCut());


IEnumerator FinishCut(){ //Kameran vaihto takaisin 6s jälkeen
yield return new WaitForSeconds(6);
hernandezText.SetActive(false); //hide hernandez text
inventory.SetActive(true);
}

}

else{
Debug.Log("walkguide already seen");
}

}

}
