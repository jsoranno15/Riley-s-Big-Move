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
    public GameObject necklacePrefab;
    public Transform neckSpawn;

    private GameObject dog;
    public GameObject dogPrefab;
    public Transform dogSpawn;

    private GameObject ball;
    public GameObject ballPrefab;
    public Transform ballSpawn;

    private GameObject bear;
    public GameObject bearPrefab;
    public Transform bearSpawn;

    private GameObject key;
    public GameObject keyPrefab;
    public Transform keySpawn;

    private GameObject door;
    public GameObject doorPrefab;
    public Transform doorSpawn;


    AudioSource _audioSource;
    public AudioClip collectObjectSound;
    public AudioClip clipboardSound;


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
        _audioSource = GetComponent<AudioSource>();
        mainCam = Camera.main;
        startPos = transform.position;
    }


    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200)) {

                if (hit.transform.name == "Clipboard" && SadPublicVars.objectIndex == 0 && SadPublicVars.clicked == false){
                    if(SadPublicVars.hasNecklace == false){
                        SadPublicVars.clicked = true;
                        Instantiate(necklacePrefab, neckSpawn.position, neckSpawn.rotation);
                        _audioSource.PlayOneShot(clipboardSound);
                        Debug.Log("clip board clicked"); 
                    }
                }
                if (hit.transform.name == "Clipboard" && SadPublicVars.objectIndex == 1 && SadPublicVars.clicked == false){
                    if(SadPublicVars.hasNecklace == true && SadPublicVars.hasDog == false){
                        SadPublicVars.clicked = true;
                        Instantiate(dogPrefab, dogSpawn.position, dogSpawn.rotation);
                        _audioSource.PlayOneShot(clipboardSound);
                        Debug.Log("clip board clicked"); 
                    }
                }
                if (hit.transform.name == "Clipboard" && SadPublicVars.objectIndex == 2 && SadPublicVars.clicked == false){
                    if(SadPublicVars.hasNecklace == true && SadPublicVars.hasDog == true && SadPublicVars.hasBall == false){
                        SadPublicVars.clicked = true;
                        Instantiate(ballPrefab, ballSpawn.position, ballSpawn.rotation);
                        _audioSource.PlayOneShot(clipboardSound);
                        Debug.Log("clip board clicked"); 
                    }
                }
                if (hit.transform.name == "Clipboard" && SadPublicVars.objectIndex == 3 && SadPublicVars.clicked == false){
                    if(SadPublicVars.hasNecklace == true && SadPublicVars.hasDog == true && SadPublicVars.hasBall == true && SadPublicVars.hasBear == false){
                        SadPublicVars.clicked = true;
                        Instantiate(bearPrefab, bearSpawn.position, bearSpawn.rotation);
                        _audioSource.PlayOneShot(clipboardSound);
                        Debug.Log("clip board clicked"); 
                    }
                }
                if (hit.transform.name == "Clipboard" && SadPublicVars.objectIndex == 4 && SadPublicVars.clicked == false){
                    if(SadPublicVars.hasNecklace == true && SadPublicVars.hasDog == true && SadPublicVars.hasBall == true && 
                       SadPublicVars.hasBear == true && SadPublicVars.hasKey == false){
                        SadPublicVars.clicked = true;
                        Instantiate(keyPrefab, keySpawn.position, keySpawn.rotation);
                        _audioSource.PlayOneShot(clipboardSound);
                        Debug.Log("clip board clicked"); 
                    }
                }
                if (hit.transform.tag == "Necklace"){
                    necklace = GameObject.FindGameObjectWithTag("Necklace");
                    SadPublicVars.objectIndex = 1;
                    SadPublicVars.hasNecklace = true;
                    updateVars();
                    Destroy(necklace);
                }
                if (hit.transform.tag == "Dog"){
                    dog = GameObject.FindGameObjectWithTag("Dog");
                    SadPublicVars.objectIndex = 2;
                    SadPublicVars.hasDog = true;
                    updateVars();
                    Destroy(dog);
                }
                if (hit.transform.tag == "Soccer"){
                    ball = GameObject.FindGameObjectWithTag("Soccer");
                    SadPublicVars.objectIndex = 3;
                    SadPublicVars.hasBall = true;
                    updateVars();
                    Destroy(ball);
                }
                if (hit.transform.tag == "Bear"){
                    bear = GameObject.FindGameObjectWithTag("Bear");
                    SadPublicVars.objectIndex = 4;
                    SadPublicVars.hasBear = true;
                    updateVars();
                    Destroy(bear);
                }
                if (hit.transform.tag == "Key"){
                    key = GameObject.FindGameObjectWithTag("Key");
                    SadPublicVars.objectIndex = 5;
                    SadPublicVars.hasKey = true;
                    Instantiate(doorPrefab, doorSpawn.position, doorSpawn.rotation);
                    updateVars();
                    Destroy(key);
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

    void updateVars(){
        SadPublicVars.clicked = false;
        SadPublicVars.itemCount++;
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Clipboard")){
            print("Board!");
        }
    }
}
