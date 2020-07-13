using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridGenerator;

/// <summary>
/// PathFinding implements the A* Algorithm for an agent to move through nodes
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>09/08/18</LastEdited>
public class PathFinding : MonoBehaviour {

	/// <summary>
	/// Searches for the path from a starting position and an end position.
	/// </summary>
	/// <param name="startPos"></param>
	/// <param name="targetPos"></param>
	public List<Node> FindPath(GridGenerator.GridGenerator grid, Vector3 startPos, Vector3 targetPos)
	{
		Node StartNode = grid.NodeFromWorldPoint(startPos);
		Node TargetNode = grid.NodeFromWorldPoint(targetPos);

		List<Node> OpenList = new List<Node>();
		HashSet<Node> ClosedList = new HashSet<Node>();

		OpenList.Add(StartNode);

		while(OpenList.Count > 0)
		{
			Node CurrentNode = OpenList[0];
			for (int i = 1; i < OpenList.Count; i++)
			{
				if (OpenList[i].FCost < CurrentNode.FCost || OpenList[i].FCost == CurrentNode.FCost && OpenList[i].hCost < CurrentNode.hCost)
				{
					CurrentNode = OpenList[i];
				}
			}
			OpenList.Remove(CurrentNode);
			ClosedList.Add(CurrentNode);

			if (CurrentNode == TargetNode)
			{
				return GetFinalPath(StartNode, TargetNode);
			}
			
			foreach (Node neighbourNode in grid.GetNeighbouringNodes(CurrentNode))
			{
				if (!neighbourNode.isWalkable || ClosedList.Contains(neighbourNode))
				{
					continue;
				}
				int MoveCost = CurrentNode.gCost + GetManhattenDistance(CurrentNode, neighbourNode);

				if (MoveCost < neighbourNode.gCost || !OpenList.Contains(neighbourNode))
				{
					neighbourNode.gCost = MoveCost;
					neighbourNode.hCost = GetManhattenDistance(neighbourNode, TargetNode);
					neighbourNode.Parent = CurrentNode;

					if(!OpenList.Contains(neighbourNode))
					{
						OpenList.Add(neighbourNode);
					}
				}
			}
		}
		return null;
	}

	/// <summary>
	/// Gets the shortest path from an intial position to a target position
	/// </summary>
	/// <param name="startNode"></param>
	/// <param name="endNode"></param>
	/// <returns></returns>
	public List<Node> GetFinalPath(Node startNode, Node endNode)
	{
		List<Node> FinalPath = new List<Node>();
		Node CurrentNode = endNode;

		while(CurrentNode != startNode)
		{
			FinalPath.Add(CurrentNode);
			CurrentNode = CurrentNode.Parent;
		}

		FinalPath.Reverse();

		//grid.FinalPath = FinalPath;
		return FinalPath;
	}

	private int GetManhattenDistance(Node nodeA, Node nodeB)
	{
		int ix = Mathf.Abs(nodeA.gridX - nodeB.gridX);
		int iy = Mathf.Abs(nodeA.gridY - nodeB.gridY);

		return ix + iy;
	}
}
