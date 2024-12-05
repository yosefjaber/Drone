using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneLogic : MonoBehaviour
{
    public float plantTime;
    public float droneRefreshRate = 240f;
    public float randomness;
    public GameObject[] trees;
    private Rigidbody rb;
    public bool manual = false;
    public controller Controller;
    public int treesPlanted = 0;
    public int treesGrow = 0;
    public float chanceToGrow;
    public GameMaker gameMaker;
    // Start is called before the first frame update


    void Start()
    {
        randomness = gameMaker.SeedRandomness;
        if (gameMaker == null)
        {
            Debug.LogError("GameMaker reference is not set in DroneLogic.");
            return;
        }
        
        plantTime = 1 / gameMaker.SeedsPerSecond; // Use the instance reference
        chanceToGrow = 1 - gameMaker.SeedFailRate; // Use the instance reference
        
        Controller = GetComponent<controller>();
        if (!manual)
        {
            float droneRefreshTime = 1 / droneRefreshRate;
            rb = this.GetComponent<Rigidbody>();
            InvokeRepeating("plantTree", 0, plantTime);
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
    if (gameMaker.gameOver == false)
    {
        treesPlanted++;
            if(Random.Range(0f,1f) > chanceToGrow)
            {
                treesGrow++;
                Instantiate(trees[Random.Range(0, 9)], new Vector3(transform.position.x + Random.Range(-randomness, randomness), 0, transform.position.z + Random.Range(-randomness, randomness)), Quaternion.identity);
                //Debug.Log(treesPlanted + " trees planted and " + treesGrow + " trees grew");
            }
        }
    }
}
