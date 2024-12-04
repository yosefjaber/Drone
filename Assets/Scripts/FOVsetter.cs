using UnityEngine;

public class FOVsetter : MonoBehaviour
{
    public Camera camera;
    public GameMaker gameMaker;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
    }
    
    public void setFOV()
    {
        camera.fieldOfView = gameMaker.CameraFOV;
    }
}
