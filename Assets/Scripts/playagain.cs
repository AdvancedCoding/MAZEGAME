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

    [Header("Main menu garbage (credits ignore these)")]
    private GameObject playB;
    private GameObject loadB;
    public GameObject credBox;
    private bool credActive = false;

    public void PlayAgain()
    {
        gunSfx.PlayOneShot(clickFx);
        Globals.SMENULOADPRESSED = false;
        SceneManager.LoadScene(sceneName);
    }

    public void LoadGame()
    {
        gunSfx.PlayOneShot(clickFx);
        Globals.SMENULOADPRESSED = true;
        SceneManager.LoadScene(sceneName);

    }
    public void ShowCredits()
    {
   
        playB.SetActive(credActive);
        loadB.SetActive(credActive);
        credBox.SetActive(!credActive);
        credActive = !credActive;
    }

    void Start()
    {
        playB = GameObject.Find("ButtonPlay");
        loadB = GameObject.Find("ButtonLoad");

        Cursor.lockState = CursorLockMode.Confined;
    }

}
