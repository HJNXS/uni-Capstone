using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridGenerator;


/// <summary>
/// Handles the agent movement in the grid world.
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>09/08/18</LastEdited>
[RequireComponent(typeof(PathFinding))]
[RequireComponent(typeof(WayPoint))]
public class GridAgent : MonoBehaviour {

	public GridGenerator.GridGenerator grid;

	private PathFinding pathFinding;

	private Node currentNode;

	public List<Node> nodesToPath;

	private WayPoint wayPointMovement;

	private Coroutine movementCouroutine = null;

	public bool AgentArrived { get; private set; }
	private bool isPause;
    [HideInInspector] public StateController controller;


	private void Start()
	{
		AgentArrived = false;
		isPause = false;
		pathFinding = GetComponent<PathFinding>();
		wayPointMovement = GetComponent<WayPoint>();
        controller = GetComponent<StateController>();
		grid.EntityList.Add(transform);
	}

	/// <summary>
	/// Move the agent to a position by pathfinding through the grid world.
	/// </summary>
	/// <param name="position">The target position the agent needs to move</param>
	public void SetDestination(Vector3 position, float currentSpeed)
	{
		isPause = false;
        nodesToPath = pathFinding.FindPath(grid,transform.position, position);
		grid.FinalPath = nodesToPath;
		if (nodesToPath.Count > 0 && movementCouroutine == null)
		{
			movementCouroutine = StartCoroutine(MoveAgent(transform, nodesToPath, currentSpeed));
		}
	}

    public void StopPathing()
    {
        if (movementCouroutine != null)
        {
			isPause = true;
        }
    }

    public void StopPathingCoroutine()
    {
        if (movementCouroutine != null)
        {
			StopCoroutine(movementCouroutine);
			nodesToPath.Clear();
			wayPointMovement.Reset();
			movementCouroutine = null;
        }
    }

    /// <summary>
    /// stops coroutine and immediately starts another to new pos.
    /// </summary>
    /// <param name="pos">The position of the player/chase target</param>
    [System.Obsolete("not using this method anymore")]
    public void RestartPath(Vector3 pos, float currentSpeed)
    {
        if (movementCouroutine != null)
        {
            StopCoroutine(movementCouroutine);
			nodesToPath.Clear();
            movementCouroutine = null;
            SetDestination(pos, currentSpeed);  //not using this method anymore
        }
    }

    IEnumerator MoveAgent(Transform entity, List<Node> nodes, float currentSpeed)
	{
		if (nodes.Count != 0)
		{
			AgentArrived = wayPointMovement.MoveToNode(transform, nodes, controller.ActualSpeed);
			while (!AgentArrived)
			{
				while (isPause)
				{
					yield return null;
				}
				AgentArrived = wayPointMovement.MoveToNode(transform, nodes, controller.ActualSpeed);
				yield return 0;
			}
			AgentArrived = false;
			movementCouroutine = null;
		}
		else
		{
			AgentArrived = true;
		}
	}
}
