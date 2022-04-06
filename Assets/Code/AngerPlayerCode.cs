using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AngerPlayerCode : MonoBehaviour
{
    // Movement
    NavMeshAgent _navAgent;
    Camera mainCam;
    float speed = 5.0f;

    // Shooting
    public Transform spawnPoint;
    public Transform gun;
    public GameObject bulletPrefab;
    int bulletForce = 500;
    float fireCD = 0.75f;
    bool cooldown = false;
    AudioSource _audioSource;
    public AudioClip fire;
    public AudioClip bullet;

    void Start() { 
        _navAgent = GetComponent<NavMeshAgent>();
        _navAgent.speed = speed;
        mainCam = Camera.main;
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update() {

        // Shooting
        if(cooldown) {
            if(fireCD > 0) {
                fireCD -= Time.deltaTime;
            }
            else {
                fireCD = 1.0f;
                cooldown = false;
            }
        }

        if(Input.GetMouseButtonDown(0) && cooldown != true) {
            lookMouse();
            _audioSource.PlayOneShot(fire);
            GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(gun.forward * bulletForce);
            cooldown = true;
            _audioSource.PlayOneShot(bullet);
        }

        // Movement
        if(Input.GetMouseButtonDown(1)) {
            RaycastHit hit;
            if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200)) {
                _navAgent.destination = hit.point;
            }
            print(_navAgent.speed);
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
