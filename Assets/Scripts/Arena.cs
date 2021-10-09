using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player; // chapter 8 page 233
    public Transform elevator; // chapter 8 page 233
    private Animator arenaAnimator; // chapter 8 page 233
    private SphereCollider sphereCollider; // chapter 8 page 233

    void Start()
    {
        arenaAnimator = GetComponent<Animator>(); // chapter 8 page 234
        sphereCollider = GetComponent<SphereCollider>(); // chapter 8 page 234
    }
    void OnTriggerEnter(Collider other)
    {
        Camera.main.transform.parent.gameObject. // chapter 8 page 234
            GetComponent<CameraMovement>().enabled = false; // chapter 8 page 234
        player.transform.parent = elevator.transform; // chapter 8 page 234
        player.GetComponent<PlayerController>().enabled = false; // chapter 8 page 234
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.elevatorArrived); // chapter 8 page 234
        arenaAnimator.SetBool("OnElevator", true); // chapter 8 page 234
    }

    public void ActivatePlatform()
    {
        sphereCollider.enabled = true; // chapter 8 page 237
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
