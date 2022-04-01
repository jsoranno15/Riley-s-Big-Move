using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCode : MonoBehaviour
{
    // Movement
    NavMeshAgent _navAgent;
    Camera mainCam;

    // Shooting
    int bulletForce = 500;
    public Transform spawnPoint;
    public Transform gun;
    public GameObject bulletPrefab;

    void Start() {
        _navAgent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
    }

    private void Update() {

        // Shooting
        if(Input.GetMouseButtonDown(0)) {
            lookMouse();
            GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(gun.forward * bulletForce);
        }

        // Movement
        if(Input.GetMouseButtonDown(1)) {
            RaycastHit hit;
            if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200)) {
                _navAgent.destination = hit.point;
            }
        }
    }

    public void FixedUpdate() {
        lookMouse();
    }

    void lookMouse(){
        RaycastHit hit;
            if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition) ,out hit, 200 )){
                Vector3 target = hit.point;
                target.y = spawnPoint.position.y;
                gun.LookAt(target);
            }
    }

    // Key Collecting
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Key")){
            PublicVars.keyNum++;
            Destroy(other.gameObject);
        }
    }
}
