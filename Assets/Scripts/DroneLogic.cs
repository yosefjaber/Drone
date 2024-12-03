using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneLogic : MonoBehaviour
{
    public float speed = 10.0f;
    public float plantTime = 2.0f;
    public float droneRefreshRate = 240f;
    public float randomness = 0.1f;
    public GameObject[] trees;
    private Rigidbody rb;
    private Bounce bounce;
    public bool manual = false;
    public controller Controller;
    public int treesPlanted = 0;
    public int treesGrow = 0;
    public float chanceToGrow = 0.6f;
    // Start is called before the first frame update


    void Start()
    {
        Controller = GetComponent<controller>();
        if (!manual)
        {
            float droneRefreshTime = 1 / droneRefreshRate;
            rb = this.GetComponent<Rigidbody>();
            bounce = new Bounce(this.gameObject);
            rb.linearVelocity = new Vector3(speed, 0, speed);
            InvokeRepeating("plantTree", 0, plantTime);
            InvokeRepeating("UpdateDrone", 0, droneRefreshTime);
        }
        else 
        {
            Controller.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    void plantTree()
    {
    treesPlanted++;
        if(Random.Range(0f,1f) > chanceToGrow)
        {
            treesGrow++;
            Instantiate(trees[Random.Range(0, 9)], new Vector3(transform.position.x + Random.Range(-randomness, randomness), 0, transform.position.z + Random.Range(-randomness, randomness)), Quaternion.identity);
            Debug.Log(treesPlanted + " trees planted and " + treesGrow + " trees grew");
        }
    }
    
    void UpdateDrone()
    {
        bounce.bounce();
    }

}
