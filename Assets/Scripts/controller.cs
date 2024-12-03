using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{

    public GameObject drone; 
    public float speed = 10.0f;
    private Rigidbody rb;
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        rb = drone.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            Vector3 forwards = new Vector3(0, 0, mainCamera.transform.forward.normalized.z);
            direction += forwards;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 forwards = new Vector3(0, 0, mainCamera.transform.forward.normalized.z);
            direction -= forwards;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += mainCamera.transform.right.normalized;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction -= mainCamera.transform.right.normalized;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction += new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction -= new Vector3(0, 1, 0);
        }
        

        if (direction != Vector3.zero)
        {
            rb.linearVelocity = direction.normalized * speed;
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }
    }
}
