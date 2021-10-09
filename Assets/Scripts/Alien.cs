using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events; //chapter 8 - page 211

public class Alien : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    private NavMeshAgent agent;
    public float navigationUpdate;
    private float navigationTime = 0;
    public UnityEvent OnDestroy;
    public Rigidbody head;
    public bool isAlive = true;
    private DeathParticles deathParticles; // chapter 8 - page 230

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navigationTime += Time.deltaTime;
        if (navigationTime > navigationUpdate)
        {
            agent.destination = target.position;
            navigationTime = 0;
        }
        if (target != null)
        {
            agent.destination = target.position;
        }

        //if (isAlive) ***AFTER COMMENTING THIS OUT THE ALIENS WERE ALIVE SINCE THE START OF THE GAME
        //{
        //    Die();
        //    SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDeath);
        //}

    }
    void OnTriggerEnter(Collider other)
    {
         if (isAlive)
        {
            Die();
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDeath);
        }
    }
    public DeathParticles GetDeathParticles()
    {
        if (deathParticles == null)
        {
            deathParticles = GetComponentInChildren<DeathParticles>();
        }
        return deathParticles;
    }

    public void Die()
    {
        isAlive = false; // chapter 8
        head.GetComponent<Animator>().enabled = false; // chapter 8
        head.isKinematic = false; // chapter 8
        head.useGravity = true; // chapter 8
        head.GetComponent<SphereCollider>().enabled = true; // chapter 8
        head.gameObject.transform.parent = null; // chapter 8
        head.velocity = new Vector3(0, 26.0f, 3.0f); // chapter 8
        OnDestroy.Invoke(); // chapter 8
        OnDestroy.RemoveAllListeners(); // chapter 8
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDeath); // chapter 8
        head.GetComponent<SelfDestruct>().Initiate(); // chapter 8 - page 225
        if (deathParticles) // chapter 8 - page 231
        {
            deathParticles.transform.parent = null;
            deathParticles.Activate();
        }
        Destroy(gameObject);
    }
}
