using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldWInGuide : MonoBehaviour
{
public GameObject thePlayer;
public GameObject guideText;
public int walkCheck = 0;


void OnTriggerExit(Collider other){

if (walkCheck == 0){
guideText.SetActive(true);
walkCheck=1;
StartCoroutine(FinishCut());

IEnumerator FinishCut(){ 
yield return new WaitForSeconds(5);
guideText.SetActive(false); 
}

}

else{
Debug.Log("winguide already seen");
}

}

}
