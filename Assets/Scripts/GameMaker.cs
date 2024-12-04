using UnityEngine;
using UnityEngine.UI;

public class GameMaker : MonoBehaviour
{
    public GameObject Floor;
    public GameObject Projection;
    public GameObject NavMesh;
    public GameObject House;
    public GameObject ModMenu;
    public GameObject Text;

    public float DroneSpeed;
    public float SeedsPerSecond;
    public float SeedFailRate;
    public float TimeOfSim;
    public int NumberOfSims;
    public float BirdsPerSecond;
    public float DistanceBetweenTurns;

    public Slider DroneSpeedSlider;
    public Slider SeedsPerSecondSlider;
    public Slider SeedFailRateSlider;
    public Slider TimeOfSimSlider;
    public Slider NumberOfSimsSlider;
    public Slider BirdsPerSecondSlider;
    public Slider DistanceBetweenTurnsSlider;
    
    public AIController aiController;
    public float startTime;
    public float timeElapsed;
    public float timeRemaining;
    public int simNumber;

    void Start()
    {
        // Deactivate certain objects initially
        Floor.SetActive(false);
        Projection.SetActive(false);
        NavMesh.SetActive(false);
        House.SetActive(false);
        Text.SetActive(false);
    }
    
    void Update()
    {
        // Update the elapsed time
        timeElapsed = Time.time - startTime;
        
        // Calculate time elapsed in the current simulation
        float currentSimElapsed = timeElapsed % TimeOfSim;
        
        // Calculate time remaining in the current simulation
        timeRemaining = TimeOfSim - currentSimElapsed;
        
        // Update the sim number
        simNumber = Mathf.FloorToInt(timeElapsed / TimeOfSim) + 1;
    }

    public void StartGame()
    {
        // Activate game objects
        Floor.SetActive(true);
        Projection.SetActive(true);
        NavMesh.SetActive(true);
        House.SetActive(true);
        Text.SetActive(true);

        // Get values from sliders
        DroneSpeed = DroneSpeedSlider.value;
        SeedsPerSecond = SeedsPerSecondSlider.value;
        SeedFailRate = 1 - (SeedFailRateSlider.value);
        TimeOfSim = TimeOfSimSlider.value;
        NumberOfSims = Mathf.RoundToInt(NumberOfSimsSlider.value); // Convert to integer
        BirdsPerSecond = BirdsPerSecondSlider.value;
        DistanceBetweenTurns = DistanceBetweenTurnsSlider.value;

        // Log the values
        Debug.Log($"Drone Speed: {DroneSpeed}");
        Debug.Log($"Seeds Per Second: {SeedsPerSecond}");
        Debug.Log($"Seed Fail Rate: {SeedFailRate}");
        Debug.Log($"Time Of Sim: {TimeOfSim}");
        Debug.Log($"Number Of Sims: {NumberOfSims}");
        Debug.Log($"Birds Per Second: {BirdsPerSecond}");
        Debug.Log($"Distance Between Turns: {DistanceBetweenTurns}");
        Debug.Log("Game Started");
        
        InvokeRepeating("EndGame", TimeOfSim, TimeOfSim);
        startTime = Time.time;
        ModMenu.SetActive(false);
    }
    
    public void EndGame()
    {
        aiController.Reset();
    }
}
