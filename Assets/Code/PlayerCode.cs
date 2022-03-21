using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCode : MonoBehaviour
{
    NavMeshAgent _navAgent;
    Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        _navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        mainCam = Camera.main;
    }

    private void Update(){
        if(Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition) ,out hit, 200 )){
                _navAgent.destination = hit.point;
            }
        }
    }
}
