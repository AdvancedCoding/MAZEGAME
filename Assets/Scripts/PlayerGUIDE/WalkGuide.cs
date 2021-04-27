using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkGuide : MonoBehaviour
{

public GameObject thePlayer;
public GameObject guideText;
public GameObject niceText;
public GameObject inventory;
public int walkCheck = 0;

void Start(){
guideText.SetActive(true);
}


void OnTriggerExit(Collider other){

if (walkCheck == 0){
guideText.SetActive(false);
niceText.SetActive(true); //show hernandez text
walkCheck=1;
StartCoroutine(FinishCut());

IEnumerator FinishCut(){ //Kameran vaihto takaisin 6s jälkeen
yield return new WaitForSeconds(5);
niceText.SetActive(false); //hide hernandez text
inventory.SetActive(true);
}

}

else{
Debug.Log("walkguide already seen");
}

}

}
