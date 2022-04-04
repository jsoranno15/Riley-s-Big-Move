using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SadPlayerCode : MonoBehaviour
{
    // Movement
    NavMeshAgent _navAgent;
    Camera mainCam;

    // public int bulletForce = 500;
    // public Transform spawnPoint;
    // public Transform gun;
    // public GameObject bulletPrefab;



    public Vector3 startPos;
    public GameObject clipboard;
    private GameObject portal;
    private GameObject necklace;

    void Start() {
        portal = GameObject.FindGameObjectWithTag("Portal");
        clipboard = GameObject.FindGameObjectWithTag("Clipboard");
        necklace = GameObject.FindGameObjectWithTag("Necklace");
        if (portal != null) 
        { 
            portal.SetActive(false);
            Debug.Log("Portal Found and Locked!");
        }

        _navAgent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
        startPos = transform.position;

        // PublicVars.enemyNum = GameObject.FindGameObjectsWithTag("Enemy").Length;
        // Debug.Log("Number of enemies is equal to " + PublicVars.enemyNum);
    }


    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200)) {
                if (hit.transform.name == "Clipboard"){
                    SadPublicVars.clicked = true;
                    Debug.Log("clip board clicked");
                }
                if (hit.transform.name == "necklace"){
                    SadPublicVars.hasNecklace = true;
                    SadPublicVars.itemCount++;
                    Destroy(necklace);
                }
            }
            // lookMouse();
            // GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, transform.rotation);
            // newBullet.GetComponent<Rigidbody>().AddForce(gun.forward * bulletForce);
        }



        // Movement
        if(Input.GetMouseButtonDown(1)) {
            RaycastHit hit;
            if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200)) {
                _navAgent.destination = hit.point;
            }
        }

        //if (PublicVars.enemyNum == PublicVars.enemyDestroyed && portal != null) { portal.SetActive(true); }
    }

    // public void FixedUpdate() {
    //     //lookMouse();
    // }

    // void lookMouse(){
    //     RaycastHit hit;
    //         if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition) ,out hit, 200 )){
    //             Vector3 target = hit.point;
    //             target.y = spawnPoint.position.y;
    //             gun.LookAt(target);
    //         }
    // }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Clipboard")){
            print("Board!");
        }
    }
}
