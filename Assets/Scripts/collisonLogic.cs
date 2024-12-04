using UnityEngine;

public class collisonLogic : MonoBehaviour
{
    public int birdsHit = 0;
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
        birdsHit++;
    }
}
