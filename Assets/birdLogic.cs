using UnityEngine;

public class birdLogic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Destroy", 17f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Destroy()
    {
        Destroy(gameObject);
    }
}
