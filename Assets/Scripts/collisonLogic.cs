using UnityEngine;

public class collisonLogic : MonoBehaviour
{
    public GameObject explosion;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(this.gameObject);
        Debug.Log("Collison Detected");
    }
}
