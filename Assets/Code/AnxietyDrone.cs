using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using TMPro;

public class AnxietyDrone : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public float spotDistance;

    private AudioSource guardAudio;
    public List<AudioClip> sounds; //0 is move, 1 is attacking, and 2 is dying

    private Animator animator;
    
    private float spotCounter = 0;
    private bool playerIn = false;
    private bool isDestroyed = false;

    private int layermask = 1 << 8;

    public TextMeshProUGUI tracker;

    void Start()
    {
        guardAudio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        animator.Play("Patrol");

        layermask = ~layermask;

        tracker.text = PublicVars.enemyDestroyed.ToString() + " / " + PublicVars.enemyNum.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            Debug.Log("Possible Intruder encountered.");
            playerIn = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (playerIn == true)
        {
            Debug.Log("Player in sight!");
            Debug.Log(Vector3.Distance(target.transform.position, transform.position) + "from " + name);
            Vector3 dirPlayer = (target.transform.position - transform.position).normalized;
            RaycastHit raycastHit;
            if (Physics.Raycast(transform.position, dirPlayer, out raycastHit, spotDistance, layermask))
            {
                Debug.Log("This ray is hitting a player");
                Debug.DrawLine(transform.position, raycastHit.point, Color.white);
                if(raycastHit.collider.CompareTag("Player") && !isDestroyed)
                {
                    guardAudio.clip = sounds[1];
                    guardAudio.Play();

                    Debug.Log("This ray is hitting a player!");
                    Debug.Log("Intruder confirmed.");
                    transform.LookAt(target.transform);
                    PublicVars.isSpotted = true;
                    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

                    //check to see if the player is close enough to the enemy to kill them AND the player has been confirmed to be spotted
                    if (PublicVars.isSpotted && Vector3.Distance(target.transform.position, transform.position) < 1.5f)
                    {
                        Debug.Log(Vector3.Distance(target.transform.position.normalized, transform.position));
                        PublicVars.isSpotted = false;
                        Debug.Log("Target has been eliminated");
                        StartCoroutine(eliminateTarget());
                    }
                }
            }
            else { Debug.Log(raycastHit.collider.tag); }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            Debug.Log("Player is out of view");
            playerIn = false;
            
            guardAudio.clip = sounds[0];
            guardAudio.Play();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            if (!isDestroyed)
            {
                isDestroyed = true;
                PublicVars.enemyDestroyed += 1;
                tracker.text = PublicVars.enemyDestroyed.ToString() + " / " + PublicVars.enemyNum;

                animator.Play("Shutdown");
                guardAudio.clip = sounds[2];
                guardAudio.Play();

                StartCoroutine(selfDestruct());
            }
            else { Debug.Log("Its already dead."); }
        }
    }
    
    void Update()
    {
        if (!playerIn) 
        {
            spotCounter = 0;
            transform.GetComponent<NavMeshAgent>().isStopped = false;
        }
        else
        {
            spotCounter += Time.deltaTime;
        }

        if (spotCounter == 3)
        {
            Debug.Log("Player has escaped, returning to normal patrol!");
            playerIn = false;
        }

        if(isDestroyed) { GetComponentInChildren<Light>().intensity -= 1; }
    }

    IEnumerator selfDestruct()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    IEnumerator eliminateTarget()
    {
        yield return new WaitForSeconds(2);
        PublicVars.enemyDestroyed = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

