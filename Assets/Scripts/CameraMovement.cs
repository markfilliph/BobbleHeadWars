using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject followTarget;
    public float moveSpeed;

    void Start()
    {
        if (followTarget != null)
        {
            transform.position = Vector3.Lerp(transform.position,
                followTarget.transform.position, Time.deltaTime * moveSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
