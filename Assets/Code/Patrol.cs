using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public List<Transform> locations;

    private NavMeshAgent patrol;
    private int currDestination;

    void Start()
    {
        patrol = this.transform.GetComponent<NavMeshAgent>();
        //this.transform.GetComponent<Animator>().Play("Patrol");
        patrol.destination = locations[0].position;
        currDestination = 1;
    }

    void Update()
    {
        if (patrol.remainingDistance <= 2)
        {
            patrol.destination = locations[currDestination].position;
            currDestination += 1;
            if (currDestination == 3) { currDestination = 0; }
        }
    }
}
