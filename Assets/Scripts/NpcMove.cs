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
    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (_navMeshAgent == null)
        {
            Debug.LogError("no nav mesh agents");
        }
        else
        {
            SetDestination();

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
    private void Update()
    {
        //TODO IF navagent != && Player in radius  setplayerdestplayerfollow
        
        if (_navMeshAgent != null) SetDestination();

        // Else SetDestPatrol  random int  1-6   pos  Transform _pos1 ... pos6 yms
    }

}
