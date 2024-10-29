using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Framecounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the frame rate as 1 divided by the time taken to render the last frame
        float frameRate = 1.0f / Time.deltaTime;
    
        // Log the frame rate to the console
        Debug.Log("FPS: " + Mathf.RoundToInt(frameRate));
    }

}
