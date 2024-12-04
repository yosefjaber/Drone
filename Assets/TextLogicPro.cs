using UnityEngine;
using TMPro;

public class TextLogicPro : MonoBehaviour
{
    public TextMeshProUGUI text;
    public DroneLogic dl;
    public collisonLogic cl;
    public GameMaker gameMaker;
    private float timeElapsed = 0.001f; // Initializing to avoid division by zero

    void Start()
    {
        // Initialization logic if needed
    }

    void Update()
    {
        // Update elapsed time
        timeElapsed = gameMaker.timeElapsed;

        // Debug the elapsed time
        Debug.Log($"Elapsed Time: {timeElapsed}");

        // Update the text UI
        text.text = 
            "Trees Grew per second: " + (dl.treesGrow / timeElapsed).ToString("F2") + "\n" +
            "Trees Planted per second: " + (dl.treesPlanted / timeElapsed).ToString("F2") + "\n" +
            "Birds Hit per second: " + (cl.birdsHit / timeElapsed).ToString("F2") + "\n" +
            "Time Remaining for Sim: " + (gameMaker.timeRemaining).ToString("F2") + "\n" +
            "Sim Number: " + gameMaker.simNumber;
    }
}
