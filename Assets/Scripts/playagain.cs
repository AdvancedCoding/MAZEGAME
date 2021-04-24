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
   // private GameObject playB;
    private GameObject loadB;

    public GameObject buttonslots;
    public GameObject credBox;
    public GameObject IPfieldObject;
    public InputField inputField;
    public GameObject stNewGameButton;
    public Button butS1;
    public Button butS2;
    public Button butS3;

    private bool credActive = false;
    private bool buttonMenuOpened = false;


    public void PlayAgain()
    {
        gunSfx.PlayOneShot(clickFx);
        Globals.SMENULOADPRESSED = false;
        SceneManager.LoadScene(sceneName);
    }

    public void StartNewAdventure()
    {
        IPfieldObject.SetActive(true);
        stNewGameButton.SetActive(true);
    }
    public void SaveNewAdventurerName()
    {
    Globals.NewAdventurerName = inputField.text;
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
        if (butS1.GetComponentInChildren<Text>().text == "")
        {
            Globals.loadnewgame = true;
            StartNewAdventure();
        }
        else
        { 
            Globals.loadnewgame = false;
            LoadGame(); 
        }    
    }
    public void loadSlot2()
    {
        Globals.slot = "slot2";
        if (butS2.GetComponentInChildren<Text>().text == "") 
        {   
            Globals.loadnewgame = true;
            StartNewAdventure();
        }
        else 
        { 
            Globals.loadnewgame = false;
            LoadGame();
        }
       
    
    }

    public void loadSlot3()
    {
        Globals.slot = "slot3";
        if (butS3.GetComponentInChildren<Text>().text == "") 
        { 
            Globals.loadnewgame = true;
            StartNewAdventure();
        }
        else 
        { 
            Globals.loadnewgame = false;
            LoadGame();
        }
        
    }

    public void delSlot1()
    {
        butS1.GetComponentInChildren<Text>().text = "";
        

    }
    public void delSlot2()
    {
        butS2.GetComponentInChildren<Text>().text = "";
    }
    public void delSlot3()
    {
        butS3.GetComponentInChildren<Text>().text = "";
    }

    public void ShowCredits()
    {
   
      //  playB.SetActive(credActive);
        loadB.SetActive(credActive);
        credBox.SetActive(!credActive);
        credActive = !credActive;
    }

    public void loadSlotsNames()
    {
        PlayerData data1 = SaveSystem.LoadPlayer("slot1");
        PlayerData data2 = SaveSystem.LoadPlayer("slot2");
        PlayerData data3 = SaveSystem.LoadPlayer("slot3");
      

        butS1.GetComponentInChildren<Text>().text = data1.slotName;
        butS2.GetComponentInChildren<Text>().text = data2.slotName;
        butS3.GetComponentInChildren<Text>().text = data3.slotName;

    }

    void Start()
    {
     //   playB = GameObject.Find("ButtonPlay");
        loadB = GameObject.Find("ButtonLoad");
        loadSlotsNames();
       
        
       

        Cursor.lockState = CursorLockMode.Confined;
    }

}
