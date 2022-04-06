using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JoyPlayerCode : MonoBehaviour
{
    // Movement
    NavMeshAgent _navAgent;
    Camera mainCam;

    public int bulletForce = 500;
    public Transform spawnPoint;
    public Transform gun;
    public GameObject bulletPrefab;

    public Vector3 startPos;

    private GameObject portal;

    void Start() {
        portal = GameObject.FindGameObjectWithTag("Portal");
        if (portal != null) 
        { 
            portal.SetActive(false);
            Debug.Log("Portal Found and Locked!");
        }
        
        _navAgent = GetComponent<NavMeshAgent>();
        mainCam = Camera.main;
        startPos = transform.position;

        PublicVars.enemyNum = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    private void Update() {

        // Shooting
        if(Input.GetMouseButtonDown(0)&&this.tag=="Player") {
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

        if (PublicVars.enemyNum == PublicVars.enemyDestroyed && portal != null) { portal.SetActive(true); }
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

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Key")){
            PublicVars.keyNum++;
            Destroy(other.gameObject);
        }
    }
}
