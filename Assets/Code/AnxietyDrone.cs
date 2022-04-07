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

    private Transform enemyTransform;
    private AudioSource guardAudio;
    private Animator animator;
    private float escapeCounter = 0;
    private float spotCounter = 0;
    private bool playerIn = false;

    public TextMeshProUGUI tracker;

    void Start()
    {
        guardAudio = GetComponent<AudioSource>();
        enemyTransform = transform;
        animator = GetComponent<Animator>();
        animator.Play("Patrol");

        //tracker = GameObject.FindGameObjectWithTag("tracker").GetComponent<Text>();
        tracker.text = PublicVars.enemyDestroyed.ToString() + " / " + PublicVars.enemyNum.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            Debug.Log("Possible Intruder encountered.");
            playerIn = true;
            spotCounter = 0;
            this.transform.GetComponent<NavMeshAgent>().isStopped = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (playerIn == true)
        {
            spotCounter += Time.deltaTime;
            PublicVars.isSpotted = true;
            Debug.Log("Intruder confirmed.");
            enemyTransform.LookAt(target.transform);
            enemyTransform.position = Vector3.MoveTowards(enemyTransform.position, target.transform.position, speed * Time.deltaTime);

            if (PublicVars.isSpotted)
            {
                PublicVars.isSpotted = false;
                Debug.Log("Target has been eliminated.");
                StartCoroutine(eliminateTarget());
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            Debug.Log("Player is out of view");
            playerIn = false;
            escapeCounter = 0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            Debug.Log("Intruder Eliminated.");
            SceneManager.LoadScene(2);
        }
        else if (collision.transform.CompareTag("Bullet"))
        {
            PublicVars.enemyDestroyed += 1;
            tracker.text = PublicVars.enemyDestroyed.ToString() + " / " + PublicVars.enemyNum;

            animator.Play("Shutdown");
            StartCoroutine(selfDestruct());
        }
    }
    
    void Update()
    {
        if (!playerIn) { escapeCounter += Time.deltaTime; }
        if (playerIn) { spotCounter += Time.deltaTime; }

        if (escapeCounter == 3)
        {
            Debug.Log("Player has escaped, returning to normal patrol!");
            this.transform.GetComponent<NavMeshAgent>().isStopped = false;
            
        }
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

