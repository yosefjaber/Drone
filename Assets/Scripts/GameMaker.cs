using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaker : MonoBehaviour
{
    public GameObject Floor;
    public GameObject Projection;
    public GameObject NavMesh;
    public GameObject House;
    public GameObject ModMenu;
    public GameObject Text;
    public GameObject EndScreen;

    public float DroneSpeed;
    public float SeedsPerSecond;
    public float SeedFailRate;
    public float TimeOfSim;
    public float StartingX;
    public float StartingZ;
    public int NumberOfSims;
    public float BirdsPerSecond;
    public float DistanceBetweenTurns;
    public float BirdSpeed;
    public float CameraFOV;

    public Slider DroneSpeedSlider;
    public Slider SeedsPerSecondSlider;
    public Slider SeedFailRateSlider;
    public Slider TimeOfSimSlider;
    public Slider StartingXSlider;
    public Slider StartingZSlider;
    public Slider NumberOfSimsSlider;
    public Slider BirdsPerSecondSlider;
    public Slider DistanceBetweenTurnsSlider;
    public Slider BirdSpeedSlider;
    public Slider CameraFOVSlider;
    
    public AIController aiController;
    public FOVsetter fovSetter;
    public float startTime;
    public float timeElapsed = 0;
    public float timeRemaining;
    public int simNumber;
    public bool gameOver = true;

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
        if (!gameOver)
        {
            // Update the elapsed time
            timeElapsed = Time.time - startTime;
            
            // Calculate time elapsed in the current simulation
            float currentSimElapsed = timeElapsed % TimeOfSim;
            
            // Calculate time remaining in the current simulation
            timeRemaining = TimeOfSim - currentSimElapsed;
        }
        
        // Update the sim number
        simNumber = Mathf.FloorToInt(timeElapsed / TimeOfSim) + 1;
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Quit the application
            Application.Quit();
        }
        
        if (EndScreen.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            RestartSimulation();
        }
        
        if (simNumber == NumberOfSims + 1)
        {
            EndGame();
            Debug.Log(simNumber);
            Debug.Log(NumberOfSims);
        }
    }

    public void StartGame()
    {
        gameOver = false;
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
        StartingX = StartingXSlider.value;
        StartingZ = StartingZSlider.value;
        NumberOfSims = Mathf.RoundToInt(NumberOfSimsSlider.value); // Convert to integer
        BirdsPerSecond = BirdsPerSecondSlider.value;
        DistanceBetweenTurns = DistanceBetweenTurnsSlider.value;
        BirdSpeed = BirdSpeedSlider.value;
        CameraFOV = CameraFOVSlider.value;
        
        fovSetter.setFOV();
        aiController.startingX = StartingX;
        aiController.startingZ = StartingZ;
        
        InvokeRepeating("EndSim", TimeOfSim, TimeOfSim);
        startTime = Time.time;
        Debug.Log("Game started MOD MENU CLOSE");
        ModMenu.SetActive(false);
    }
    
    void EndSim()
    {
        //aiController.Reset();
    }
    
    void EndGame()
    {
        gameOver = true;
        EndScreen.SetActive(true);
        // Deactivate game objects
        Floor.SetActive(false);
        Projection.SetActive(false);
        NavMesh.SetActive(false);
        House.SetActive(false);
        DestroyAllInstantiatedObjects();
    }
    
    void RestartSimulation()
    {
        // Reload the active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void DestroyAllInstantiatedObjects()
    {
        // Destroy all instantiated objects
        GameObject[] instantiatedObjects = GameObject.FindGameObjectsWithTag("Created");
        foreach (GameObject obj in instantiatedObjects)
        {
            Destroy(obj);
        }
    }
}
