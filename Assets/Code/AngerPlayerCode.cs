using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using TMPro;

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
    float fireCD = 0.25f;
    bool cooldown = false;
    AudioSource _audioSource;
    public AudioClip fire;
    public AudioClip bullet;

    // Key
    public AudioClip keyPickUp;

    // Death
    public TextMeshProUGUI textUI;
    bool isAlive = true;
    public AudioClip death;

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
                fireCD = 0.25f;
                cooldown = false;
            }
        }

        if(Input.GetMouseButtonDown(0) && cooldown != true && isAlive) {
            lookMouse();
            _audioSource.PlayOneShot(fire);
            GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(gun.forward * bulletForce);
            cooldown = true;
            _audioSource.PlayOneShot(bullet);
        }

        // Movement
        if(Input.GetMouseButtonDown(1) && isAlive) {
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

    private void OnTriggerEnter(Collider other){
        
        // Pick Up Key
        if(other.CompareTag("Key")){
            AngerPublicVars.hasKey = true;
            _audioSource.PlayOneShot(keyPickUp);
            Destroy(other.gameObject);
        }

        // Death
        if(other.CompareTag("Enemy") && isAlive){
            die();
        }
    }

    void die() {
        _navAgent.destination = transform.position;
        _audioSource.PlayOneShot(death);
        isAlive = false;
        AngerPublicVars.gameRun = false;
        textUI.text = "";
        StopAllCoroutines();
        string message = "Riley was consumed by her anger!";
        StartCoroutine(printText(message));
    }

    IEnumerator printText (string text) {
        foreach (char c in text) {
            textUI.text += c;
            yield return new WaitForSeconds(0.06f);
        }
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("AngerScene");
    }
}
