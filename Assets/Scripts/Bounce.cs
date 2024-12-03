using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce
{
    public GameObject drone;
    public float speed = 10.0f;
    public float plantTime = 2.0f;
    public GameObject plane;
    private Rigidbody rb;
    private float lastXChangeTime = 0f;
    private float lastZChangeTime = 0f;
    private float directionChangeCooldown = 0.2f; // Cooldown period in seconds
    
    public Bounce (GameObject drone)
    {
        this.drone = drone;
        rb = drone.GetComponent<Rigidbody>();
    }
    
    void changeDirection(int x, int z)
    {
        Vector3 velocity = rb.linearVelocity;
        velocity.x = x * velocity.x;
        velocity.z = z * velocity.z;
        rb.linearVelocity = velocity;
    }
    
    public void bounce()
    {
        float time = Time.time;
        
        if(drone.transform.position.x >= 80 && drone.transform.position.z >= 45 && (time - lastXChangeTime > directionChangeCooldown) && (time - lastZChangeTime > directionChangeCooldown))
        {
            changeDirection(-1, -1);
            lastXChangeTime = time;
            lastZChangeTime = time;
            Debug.Log("Special Case");
        }
        else if(drone.transform.position.x <= -80 && drone.transform.position.z <= -45 && (time - lastXChangeTime > directionChangeCooldown) && (time - lastZChangeTime > directionChangeCooldown))
        {
            changeDirection(-1, -1);
            lastXChangeTime = time;
            lastZChangeTime = time;
        }
        else if(drone.transform.position.x >= 80 && drone.transform.position.z <= -45 && (time - lastXChangeTime > directionChangeCooldown) && (time - lastZChangeTime > directionChangeCooldown))
        {
            changeDirection(-1, -1);
            lastXChangeTime = time;
            lastZChangeTime = time;
        }
        else if(drone.transform.position.x <= -80 && drone.transform.position.z >= 45 && (time - lastXChangeTime > directionChangeCooldown) && (time - lastZChangeTime > directionChangeCooldown))
        {
            changeDirection(-1, -1);
            lastXChangeTime = time;
            lastZChangeTime = time;
        }
    
        if(drone.transform.position.x >= 80 && (time - lastXChangeTime > directionChangeCooldown))
        {
            changeDirection(-1, 1);
            lastXChangeTime = time;
        }
        else if(drone.transform.position.x <= -80 && (time - lastXChangeTime > directionChangeCooldown))
        {
            changeDirection(-1, 1);
            lastXChangeTime = time;
        }
        else if(drone.transform.position.z >= 45 && (time - lastZChangeTime > directionChangeCooldown))
        {
            changeDirection(1, -1);
            lastZChangeTime = time;
        }
        else if(drone.transform.position.z <= -45 && (time - lastZChangeTime > directionChangeCooldown))
        {
            changeDirection(1, -1);
            lastZChangeTime = time;
        }
    }
}
