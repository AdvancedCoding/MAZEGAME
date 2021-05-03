using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform _destination;
    private NavMeshAgent _navMeshAgent;

    public Transform[] patrolPoints;
   
    public float defaultAiDetectDistance = 5;
  
    private int nextPP;
    private bool isInPpDest = false;
    public bool isRat = false;
    [HideInInspector]
    public float aiDetectDistance;

    void Start()
    {
      aiDetectDistance = defaultAiDetectDistance;
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (_navMeshAgent == null)
        {
            Debug.LogError("no nav mesh agents");
        }
        else
        {
            nextPP = Random.Range(0, patrolPoints.Length);
            SetPatrol();
            
        }
    }

    private void SetDestination()
    {
        if(_destination != null)
        {
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }
    private void SetPatrol()
    {
        Vector3 targetVector;
        if (patrolPoints == null) return; //exploding the script
        float ppdistance = Vector3.Distance(patrolPoints[nextPP].position, _navMeshAgent.transform.position);
        if (ppdistance <= 1) isInPpDest = true;
      
        
        if (isInPpDest) 
        { 
            nextPP = Random.Range(0, patrolPoints.Length);
           // targetVector = patrolPoints[nextPP].position;
            isInPpDest = false;
        }
     
             targetVector = patrolPoints[nextPP].position;
                _navMeshAgent.SetDestination(targetVector);
       // Debug.Log("Im going to:" + nextPP);
        
    }
    private bool PlayerIsInRange()
    {
        float distance = Vector3.Distance(_destination.transform.position, _navMeshAgent.transform.position);
        if (distance <= aiDetectDistance) { return true; }
        else return false;
        

    }

    private void Update()
    {
        if (!isRat) 
        { 
            if (_navMeshAgent != null && PlayerIsInRange()) { SetDestination(); } //Debug.Log("AI Following player"); 
            else if (_navMeshAgent != null && !PlayerIsInRange()) SetPatrol(); //Debug.Log("AI Patrolling area");
        }
        else if (isRat)
        {
            if (_navMeshAgent != null && PlayerIsInRange() && !UseItem.ratRepellantIsOn) { SetDestination(); } //Debug.Log("AI Following player"); 
            else if (_navMeshAgent != null) SetPatrol(); //Debug.Log("AI Patrolling area");
        }

    }

}
