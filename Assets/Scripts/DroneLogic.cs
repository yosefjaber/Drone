using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneLogic : MonoBehaviour
{
    public float speed = 10.0f;
    public float plantTime = 2.0f;
    private Rigidbody rb;
    private int fdirection = 1;
    private int rdirection = 1;
    public GameObject tree;
    // Start is called before the first frame update
    
    public float cooldownDuration = 0.1f; // Cooldown duration in seconds
    private float lastFunctionCallTimeR = 0f; // Time when the function was last called
    private float lastFunctionCallTimeF = 0f; // Time when the function was last called
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("plantTree", plantTime);
        rb.velocity = (transform.right*rdirection + transform.forward*fdirection) * speed/2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= 80 || transform.position.x <= -80)
        {
            setSpeedr();
            Debug.Log("Direction changed");
        }
        else if(transform.position.z >= 45 || transform.position.z <= -45)
        {
            setSpeedf();
            Debug.Log("Direction changed"); 
        }
        lastFunctionCallTimeR += Time.deltaTime;
        lastFunctionCallTimeF += Time.deltaTime;
    }
    
    void plantTree()
    {
        Instantiate(tree, new Vector3(transform.position.x,0,transform.position.z), Quaternion.identity);
        Invoke("plantTree", plantTime);
    }
    
    void setSpeedr()
    {
        if(lastFunctionCallTimeR < cooldownDuration)
        {
            Debug.Log("Wait");
            return;
        }
        rdirection = rdirection * -1;
        rb.velocity = (transform.right*rdirection + transform.forward*fdirection) * speed/2;
        lastFunctionCallTimeR = 0f;
        Debug.Log("Change Speed");
    }
    
    void setSpeedf()
    {
        if(lastFunctionCallTimeF < cooldownDuration)
        {
            Debug.Log("Wait");
            return;
        }
        fdirection = fdirection * -1;
        rb.velocity = (transform.right*rdirection + transform.forward*fdirection) * speed/2;
        lastFunctionCallTimeF = 0f;
        Debug.Log("Change Speed");
    }
}
