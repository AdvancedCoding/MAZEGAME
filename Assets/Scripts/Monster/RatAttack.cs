using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAttack : MonoBehaviour
{
    [Header("Max slow is 11, else bugs")]
    public int slowAmount = 2;
    public int slowTimer = 3;
    public PlayerMovement playerMovement;
    private bool timerIsDone = true;
  /*  private int slowamount;// advanced max value using clamping  too complicated xddd
    public int slowAmount
    {
        get { return slowamount; }
        set { slowamount = Mathf.Clamp(value, 0, 50); }
    }*/

 
   
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
