using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridGenerator;

/// <summary>
/// WayPoint handles the movement of an entity between a list of nodes.
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>09/08/18</LastEdited>
public class WayPoint : MonoBehaviour {

	private int index;
	public List<Node> lastNodes = new List<Node>();
	public List<Node> allwaypoints = new List<Node>();

	/// <summary>
	/// Move the entity a node at a time until it reaches the destination.
	/// </summary>
	/// <param name="entity">The object which position need to be changed</param>
	/// <param name="waypoints">List of nodes to traval</param>
	/// <param name="speed"></param>
	public bool MoveToNode(Transform entity, List<Node> waypoints, float speed)
	{
		if (waypoints.Count > 0) 
		{
			if (index < waypoints.Count)
			{
				//allwaypoints = waypoints;
				//if (index != 0)
				//{
				//	if (lastNodes != null)
				//	{
				//		foreach (Node node in lastNodes)
				//		{
				//			node.isOccupied = false;
				//		}
				//	}
				//	waypoints[index - 1].isOccupied = false;
				//	waypoints[index].isOccupied = true;
				//}
				//else
				//{
				//	waypoints[index].isOccupied = true;
				//}
				var gapDistance = index == (waypoints.Count - 1) ? 0.07f : 0.5f; // if more nodes move faster
				if (Vector3.Distance(entity.position, waypoints[index].Position) > gapDistance)
				{
					entity.position = Vector3.Lerp(entity.position, waypoints[index].Position, Time.deltaTime * speed);
					Turn(entity, waypoints);
				}
				else
				{
					if (index >= waypoints.Count - 1)
					{
						index = 0;
						//lastNodes.Add(waypoints[waypoints.Count - 1]);
						return true;
					}
					else
					{
						index++;
					}
				}
			} else
			{
				index = 0;
			}
		}
		return false;
	}

	public bool MoveToNode(Transform entity, Node waypoint, float speed, float distance = 0.1f)
	{
		if (Vector3.Distance(entity.transform.position, waypoint.Position) > distance)
		{
			entity.position = Vector3.Lerp(entity.position, waypoint.Position, Time.deltaTime * speed);
			Turn(entity, waypoint);
		}
		else
		{
			return true;
		}
		return false;
	}

	private void Turn(Transform entity, List<Node> waypoints)
	{
		Vector3 newVec = new Vector3(waypoints[index].Position.x, entity.position.y, waypoints[index].Position.z);
		entity.LookAt(newVec);
	}

	public void Turn(Transform entity, Node waypoint)
	{
		Vector3 newVec = new Vector3(waypoint.Position.x, entity.position.y, waypoint.Position.z);
		entity.LookAt(newVec);
	}

	public void Reset()
	{
		foreach (Node node in allwaypoints)
		{
			node.isOccupied = false;
		}
		index = 0;
		lastNodes.Clear();
		allwaypoints.Clear();
	}

}
