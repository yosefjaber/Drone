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
        Debug.Log("Hello World");
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W pressed");
            direction += mainCamera.transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S pressed");
            direction -= mainCamera.transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D pressed");
            direction += mainCamera.transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A pressed");
            direction -= mainCamera.transform.right;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Up Arrow pressed");
            direction += new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("Down Arrow pressed");
            direction -= new Vector3(0, 1, 0);
        }

        if (direction != Vector3.zero)
        {
            rb.velocity = direction.normalized * speed;
            Debug.Log("Velocity set to: " + rb.velocity);
        }
        else
        {
            rb.velocity = Vector3.zero;
            Debug.Log("No keys pressed, velocity set to zero");
        }
    }
}
