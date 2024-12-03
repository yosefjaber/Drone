using UnityEngine;

public class spawnBirds : MonoBehaviour
{

    public GameObject bird; 
    public float ChanceToSpawnEverySecond = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("randomSpawnBird", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void spawnBirdLeft()
    {
        GameObject Bird = Instantiate(bird, new Vector3(-85, 15, Random.Range(-45f,45f)), Quaternion.identity);
        Bird.GetComponent<Rigidbody>().linearVelocity = new Vector3(10, 0, 0);
    }
    
    void spawnBirdRight()
    {
        GameObject Bird = Instantiate(bird, new Vector3(85, 15, Random.Range(-45f,45f)), Quaternion.identity);
        Bird.GetComponent<Rigidbody>().linearVelocity = new Vector3(-10, 0, 0);
    }
    
    void randomSpawnBird()
    {
        if(Random.Range(0f,1f) < ChanceToSpawnEverySecond)
        {
            if(Random.Range(0f,1f) > 0.5f)
            {
                spawnBirdLeft();
            }
            else
            {
                spawnBirdRight();
            }
        }
    }
}
