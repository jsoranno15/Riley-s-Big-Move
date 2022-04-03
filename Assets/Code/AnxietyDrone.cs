using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class AnxietyDrone : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public float spotDistance = 20;

    private AudioSource guardAudio;
    private Animator animator;

    private float spotCounter = 0;
    private bool playerIn = false;
    private bool isDestroyed = false;

    private int layerMask = 1 << 8;

    void Start()
    {
        //Reset enemyTracker
        PublicVars.enemyDestroyed = 0;

        guardAudio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        animator.Play("Patrol");
        layerMask = ~layerMask;
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
            if (Physics.Raycast(transform.position, dirPlayer, out raycastHit, spotDistance, layerMask))
            {
                Debug.Log("Theres a Ray!");
                Debug.DrawLine(transform.position, raycastHit.point, Color.white);
                if(raycastHit.collider.CompareTag("Player") && !isDestroyed)
                {
                    Debug.Log("This ray is hitting a player!");
                    Debug.Log("Intruder confirmed.");
                    transform.LookAt(target.transform);
                    PublicVars.isSpotted = true;
                    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
                    
                    //Below code is an alternative to Vector3.MoveTowards that allows the drones to move towards the player when they are spotted.
                    //May need further testing for "proper implementation"
                    //GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
                    //GetComponent<NavMeshAgent>().speed = speed * 3;
                    
                    //check to see if the player is close enough to the enemy to kill them AND the player has been confirmed to be spotted
                    if (PublicVars.isSpotted && Vector3.Distance(target.transform.position, transform.position) < 1.5f)
                    {
                        Debug.Log(Vector3.Distance(target.transform.position, transform.position));
                        PublicVars.isSpotted = false;
                        Debug.Log("Target has been eliminated.");
                        StartCoroutine(eliminateTarget());
                    }
                }
                else { Debug.Log(raycastHit.collider.tag); }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            Debug.Log("Player is out of view");
            playerIn = false;
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
                Debug.Log("Num of enemies Destroyed is " + PublicVars.enemyDestroyed + " while number of enemies is " + PublicVars.enemyNum);
                animator.Play("Shutdown");
                StartCoroutine(selfDestruct());
            }
        }
    }
    
    void Update()
    {
        if (!playerIn) 
        { 
            spotCounter = 0; 
            this.transform.GetComponent<NavMeshAgent>().isStopped = false;
        }
        else 
        { 
            spotCounter += Time.deltaTime;
            //this.transform.GetComponent<NavMeshAgent>().isStopped = true; //may remove this depending on taste
        }

        if (spotCounter == 3)
        {
            Debug.Log("Player has escaped, returning to normal patrol!");
            playerIn = false;
            
        }

        if(isDestroyed)
        {
            GetComponentInChildren<Light>().intensity -= 1;
        }
    }

    IEnumerator selfDestruct()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    IEnumerator eliminateTarget()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

