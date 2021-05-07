using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goMainMenu : MonoBehaviour
{
    public string sceneName = "Assets/Scenes/MainMenu";
    public AudioSource gunSfx;
    public AudioClip clickFx;


    public void goMainMenuS()
    {
        gunSfx.PlayOneShot(clickFx);
        //Globals.SMENULOADPRESSED = false; ??????
//        SceneManager.LoadScene(sceneName);
	SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex-1);
    }
}
