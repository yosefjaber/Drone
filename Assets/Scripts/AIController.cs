using UnityEngine;

public class AIController : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    public float distanceBetweenTurns;
    public float startingX = -79f;
    public float startingZ = 45f;
    private Vector3 currentTarget;
    private int moves = 0;
    public GameMaker gameMaker;

    void Start()
    {
        distanceBetweenTurns = gameMaker.DistanceBetweenTurns;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = gameMaker.DroneSpeed;
        currentTarget = new Vector3(startingX, 0, startingZ);
        agent.SetDestination(currentTarget);
    }

    void Update()
    {
        if (HasReachedDestination())
        {
            UpdateTarget();
            agent.SetDestination(currentTarget);
        }
    }
    
    public void Reset()
    {
        moves = 0;
        currentTarget = new Vector3(startingX, 0, startingZ);
        agent.SetDestination(currentTarget);
    }

    void UpdateTarget()
    {
        if (transform.position.x >= 79)
        {
            // Stop the drone at x = 79
            currentTarget = new Vector3(-79, 0, transform.position.z);
            // Optionally, you can disable the NavMeshAgent or this script to stop movement completely
            // agent.isStopped = true;
            // this.enabled = false;
        }
        else
        {
            if (moves % 4 == 0)
            {
                currentTarget = new Vector3(transform.position.x, 0, -45);
            }
            else if (moves % 4 == 1)
            {
                // Check if the next x position exceeds 79
                float nextX = transform.position.x + distanceBetweenTurns;
                currentTarget = new Vector3(Mathf.Min(nextX, 80), 0, -45);
            }
            else if (moves % 4 == 2)
            {
                currentTarget = new Vector3(transform.position.x, 0, 45);
            }
            else if (moves % 4 == 3)
            {
                // Check if the next x position exceeds 79
                float nextX = transform.position.x + distanceBetweenTurns;
                currentTarget = new Vector3(Mathf.Min(nextX, 80), 0, 45);
            }
            moves++;
        }
    }


    bool HasReachedDestination()
    {
        return !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance;
    }
}
