using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneLogic : MonoBehaviour
{
    public float speed = 10.0f;
    public float plantTime = 2.0f;
    public float droneRefreshRate = 240f;
    public float randomness = 0.1f;
    public GameObject tree;
    private Rigidbody rb;
    private Bounce bounce;
    // Start is called before the first frame update

    
    void Start()
    {
        float droneRefreshTime = 1 / droneRefreshRate;
        rb = this.GetComponent<Rigidbody>();
        bounce = new Bounce(this.gameObject);
        rb.velocity = new Vector3(speed, 0, speed);
        InvokeRepeating("plantTree", 0, plantTime);
        InvokeRepeating("UpdateDrone", 0, droneRefreshTime);
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    void plantTree()
    {
    Instantiate(tree, 
        new Vector3(transform.position.x + Random.Range(-2f, 2f), 0, transform.position.z + Random.Range(-2f, 2f)), Quaternion.identity);
    }
    
    void UpdateDrone()
    {
        bounce.bounce();
    }

}
