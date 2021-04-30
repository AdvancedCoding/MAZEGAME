using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAttack : MonoBehaviour
{
    PlayerMovement playerMovement;
    public int slowAmount = 2;
    public int slowTimer = 3;

    private bool timerIsDone = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player" && timerIsDone)
        {
            playerMovement.speed -= slowAmount;
            timerIsDone = false;
            StartCoroutine(timerDetectDistance());
        }
    }
    IEnumerator timerDetectDistance()
    {
        yield return new WaitForSecondsRealtime(slowTimer);
        playerMovement.speed += slowAmount;
        timerIsDone = true;
    }
}
