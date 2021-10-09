using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticles : MonoBehaviour
{
    // Start is called before the first frame update
    private ParticleSystem deathParticles; // chapter 8 - page 229
    private bool didStart = false; // chapter 8 - page 229


    void Start() // chapter 8 - page 230
    {
        deathParticles = GetComponent<ParticleSystem>();

    }
    public void Activate() // chapter 8 - page 230
    {
        didStart = true;
        deathParticles.Play();
    }
    public void SetDeathFloor(GameObject deathFloor)
    {
        if (deathParticles == null)
        {
            deathParticles = GetComponent<ParticleSystem>();
        }
        deathParticles.collision.SetPlane(0, deathFloor.transform);
    }

    // Update is called once per frame
    void Update() // chapter 8 - page 230
    {
        if (didStart && deathParticles.isStopped)
        {
            Destroy(gameObject);
        }
    }
}
