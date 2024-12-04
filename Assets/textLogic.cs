using UnityEngine;
using TMPro;

public class textLogic : MonoBehaviour
{
    public TextMeshProUGUI text;
    public DroneLogic dl; 
    public collisonLogic cl;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Trees Grew: " + dl.treesGrow + "\n" + "Trees Planted: " + dl.treesPlanted + "\n" + "Birds Hit: " + cl.birdsHit;
    }
}
