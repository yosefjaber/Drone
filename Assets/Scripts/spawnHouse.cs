using UnityEngine;

public class spawnHouse : MonoBehaviour
{
    public GameObject house;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(house, new Vector3(Random.Range(-30,30), 0, Random.Range(-20,20)), Quaternion.Euler(0, Random.Range(0,360), 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
