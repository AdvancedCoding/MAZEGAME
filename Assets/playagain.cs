using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playagain : MonoBehaviour
{

public string sceneName = "Assets/oton-kuutio";
public AudioSource gunSfx;
public AudioClip clickFx;

public void PlayAgain()
{
gunSfx.PlayOneShot (clickFx);
    SceneManager.LoadScene(sceneName);
}

void Start() {
Cursor.lockState = CursorLockMode.Confined;
}

}
