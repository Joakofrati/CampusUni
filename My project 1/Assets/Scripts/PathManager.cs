using UnityEngine;
using UnityEngine.AI;

public class PathManager : MonoBehaviour
{
    public GameObject agent; // Reference to the player/agent
    public float reachThreshold = 1.0f; // Distance threshold to consider the target as reached
    private Transform currentTarget; // Current target position

    private LineRenderer lineRenderer;
    private NavMeshPath path;
    private GoTo goToScript; // Reference to the GoTo script

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            Debug.LogError("PathManager: No LineRenderer component found.");
        }
        path = new NavMeshPath();
    }

    void Update()
    {
        if (currentTarget != null)
        {
            float distanceToTarget = Vector3.Distance(agent.transform.position, currentTarget.position);
            if (distanceToTarget < reachThreshold)
            {
                ClearPath();
                currentTarget = null; // Clear the current target once reached
                Debug.Log("PathManager: Reached the target, path cleared.");
            }
        }
    }

    public void SetTarget(Transform target, GoTo goTo)
    {
        currentTarget = target;
        goToScript = goTo;
        DrawPathToTarget(currentTarget.position);
    }

    void DrawPathToTarget(Vector3 targetPosition)
    {
        if (agent == null)
        {
            Debug.LogError("PathManager: No NavMeshAgent assigned.");
            return;
        }

        if (NavMesh.CalculatePath(agent.transform.position, targetPosition, NavMesh.AllAreas, path))
        {
            lineRenderer.positionCount = path.corners.Length;
            lineRenderer.SetPositions(path.corners);
            goToScript.DisplayMessage(true);
        }
        else
        {
            Debug.LogError("PathManager: No path to target, path calculation failed");
            ClearPath();
            goToScript.DisplayMessage(false);
        }
    }

    public void ClearPath()
    {
        lineRenderer.positionCount = 0;
    }
}
