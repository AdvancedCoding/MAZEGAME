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

    public GameObject buttonslots;
    public GameObject credBox;

    private bool credActive = false;
    private bool buttonMenuOpened = false;

    private string slotName1;
    private string slotName2;
    private string slotName3;

    public void PlayAgain()
    {
        gunSfx.PlayOneShot(clickFx);
        Globals.SMENULOADPRESSED = false;
        SceneManager.LoadScene(sceneName);
    }

    public void openSlotMenu()
    {
        
        buttonMenuOpened = !buttonMenuOpened;
        buttonslots.SetActive(buttonMenuOpened);
    }

    private void LoadGame()
    {
        gunSfx.PlayOneShot(clickFx);
        Globals.SMENULOADPRESSED = true;
        SceneManager.LoadScene(sceneName);

    }
    public void loadSlot1()
    {
        Globals.slot = "slot1";
        LoadGame();
    }
    public void loadSlot2()
    {
        Globals.slot = "slot2";
        LoadGame();
    }

    public void loadSlot3()
    {
        Globals.slot = "slot3";
        LoadGame();
    }


    public void ShowCredits()
    {
   
        playB.SetActive(credActive);
        loadB.SetActive(credActive);
        credBox.SetActive(!credActive);
        credActive = !credActive;
    }

    public void loadSlotsNames()
    {
        PlayerData data1 = SaveSystem.LoadPlayer("slot1");
        PlayerData data2 = SaveSystem.LoadPlayer("slot2");
        PlayerData data3 = SaveSystem.LoadPlayer("slot3");

        slotName1 = data1.slotName;
        slotName2 = data2.slotName;
        slotName3 = data3.slotName;

    }

    void Start()
    {
        playB = GameObject.Find("ButtonPlay");
        loadB = GameObject.Find("ButtonLoad");

       

        Cursor.lockState = CursorLockMode.Confined;
    }

}
