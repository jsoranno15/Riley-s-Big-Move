using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnxietyPlayerCode : MonoBehaviour
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
    private AudioSource gunAudio;

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
        gunAudio = GetComponent<AudioSource>();

        PublicVars.enemyNum = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log("Number of enemies is equal to " + PublicVars.enemyNum);
    }

    private void Update() {

        // Shooting
        if(Input.GetMouseButtonDown(0)) {
            lookMouse();
            GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(gun.forward * bulletForce);
            gunAudio.Play();
        }

        // Movement
        if(Input.GetMouseButtonDown(1)) {
            RaycastHit hit;
            if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200)) {
                _navAgent.destination = hit.point;
            }
        }

        if (PublicVars.enemyNum == PublicVars.enemyDestroyed && portal != null && !PublicVars.turnedOn) 
        { 
            portal.SetActive(true);
            PublicVars.turnedOn = true;
            mainCam.GetComponent<AudioSource>().Stop();
            portal.GetComponent<AudioSource>().Play();
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

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Key")){
            PublicVars.keyNum++;
            Destroy(other.gameObject);
        }
    }
}
