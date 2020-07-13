using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridGenerator {
	/// <summary>
	/// GridGenerator generate a list of node objects from the land gameobject called a grid.
	/// It is used to help to populate a list of node instead manually creating a grid.
	/// </summary>
	/// <remarks>
	/// Only used to generate a grid prefab that will be used by other scripts.
	/// Allow to adjust the height of node manually and prefab the gameobject.
	/// </remarks>
	/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
	/// <LastEdited>24/08/18</LastEdited>
	public class GridGenerator : MonoBehaviour
	{
		#region Editor variables

		public GameObject destroyGridObjs;

		[SerializeField]
		private GameObject tile;
		[SerializeField]
		private LayerMask unwalkableMask;

		[SerializeField]
		private Transform player;

		[SerializeField]
		[Range(0,1f)]
		public float heightAboveGround;
		#endregion

		public static GridGenerator instance;
		public List<Node> FinalPath;
		public List<Transform> EntityList;

		private Node[,] grid;

		float nodeDiameter = 0.0f;
		public Vector2 gridWorldSize;
		int gridSizeX, gridSizeY;

		Vector2 lastIndex;

		#region Calculate length of map
		[Header("Calculate map nodes")]
		public Transform firstNode;
		public Transform lastNodeH;
		public Transform lastNodeV;

		public List<Transform> gridList;
		#endregion

		/// <summary>
		/// Calculate the width and length from 3 Transform (firstNode, lastNodeH, lastNodeV)
		/// </summary>
		private void CalculateGridWorld()
		{
			if (gridWorldSize == Vector2.zero)
				gridWorldSize = new Vector2(Mathf.Abs(lastNodeH.position.z - firstNode.position.z), Mathf.Abs(lastNodeV.position.x - firstNode.position.x));

		}

		/// <summary>
		/// Setup the grid world to be used for entities movement
		/// </summary>
		private void Start()
		{
			CalculateGridWorld();
			nodeDiameter = tile.GetComponent<Renderer>().bounds.size.x;
			gridSizeX = Mathf.RoundToInt( gridWorldSize.x / nodeDiameter) + 1;
			gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter) + 1;
			grid = new Node[gridSizeX, gridSizeY];
			createGridManually();
		}


		/// <summary>
		/// Cleaning the occupied nodes
		/// </summary>
		private void Update()
		{
			foreach (Node node in grid)
			{
				node.isOccupied = false;
				foreach (Transform t in EntityList)
				{
					if (node == NodeFromWorldPoint(t.position))
					{
						//NodeFromWorldPoint(t.position + t.forward * 1f).isOccupied = true;
						node.isOccupied = true;
					}
				}
			}
		}

		/// <summary>
		/// Create a grid programmatically from the width and length
		/// of the grid world.
		/// </summary>
		[System.Obsolete("This method is no longer in use. Getting nodes from placed objects")]
		private void CreateGrid()
		{
			grid = new Node[gridSizeX, gridSizeY];
			Vector3 worldBottomLeft = lastNodeV.position;//landChuck.transform.position - Vector3.right * gridWorldSize.x/2 - Vector3.forward * gridWorldSize.y/2;

			for (int x = 0; x < gridSizeX; x++)
			{
				for (int y = 0; y < gridSizeY; y++)
				{
					Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeDiameter) + Vector3.forward * (y * nodeDiameter + nodeDiameter) + Vector3.up * heightAboveGround;
					bool walkable = !(Physics.CheckSphere(worldPoint, nodeDiameter, unwalkableMask));
					
					//grid[x, y] = new Node(walkable, worldPoint, x, y, nodeDiameter);
					//var newTile = Instantiate(tile, worldPoint,tile.transform.rotation, transform);
					//newTile.transform.parent = ParentGrid.transform;
				}
			}
		}

		/// <summary>
		/// Fill out a 2d grid array with a list of nodes from objects manually
		/// placed inside the levels.
		/// </summary>
		public void createGridManually()
		{
			foreach(Transform t in gridList)
			{
				var index = indexFromPoint(t.position);
				Vector3 tileMid = new Vector3(t.position.x + nodeDiameter / 2, t.position.y, t.position.z / 2);
				bool walkable = Physics.CheckSphere(t.position, (nodeDiameter-0.2f)/2, unwalkableMask,QueryTriggerInteraction.Ignore) ? false : true;
				bool setByMask = !((1 << t.gameObject.layer & unwalkableMask) != 0);
				if (grid[(int)index.x, (int)index.y] == null)
					grid[(int)index.x, (int)index.y] = new Node(walkable & setByMask, false, !setByMask, t.position, (int)index.x, (int)index.y, nodeDiameter);
			}
			Destroy(destroyGridObjs);
		}
		
		/// <summary>
		/// Recreate the grid of notes to set new unwalkable tiles.
		/// </summary>
		public void rebakeGrid()
		{
			foreach(Node node in grid)
			{
				bool walkable = Physics.CheckSphere(node.Position, (nodeDiameter - 0.2f) / 2, unwalkableMask, QueryTriggerInteraction.Ignore);
				if (!node.setByMask)
					node.IsWalkable = !walkable;
			}
		}

		/// <summary>
		/// Get the index of a tile from a position.
		/// </summary>
		/// <param name="worldPosition"></param>
		/// <returns>Index in grid</returns>
		public Vector2 indexFromPoint(Vector3 worldPosition)
		{
			int x, y;

			float percentX = ((worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x);
			float percentY = ((worldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y);
			percentX = Mathf.Clamp01(percentX);
			percentY = Mathf.Clamp01(percentY);

			x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
			y = Mathf.RoundToInt((gridSizeY - 1) * percentY);

			int checky = y;

			if (lastIndex != null)
			{
				if (grid[x, y] != null && ++checky < gridSizeY)
				{
					y++;
				}
			}
		
			lastIndex = new Vector2(x, y);


			return new Vector2(x, y);
		}

		/// <summary>
		/// Get a Node object from a world position.
		/// </summary>
		/// <param name="worldPosition"></param>
		/// <remarks>Use by entity to navigation into the grid world</remarks>
		/// <returns>Node object</returns>
		public Node NodeFromWorldPoint(Vector3 worldPosition)
		{
			int x, y;

			float percentX = ((worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x);
			float percentY = ((worldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y);
			percentX = Mathf.Clamp01(percentX);
			percentY = Mathf.Clamp01(percentY);

			x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
			y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
			return grid[x, y];
		}

		/// <summary>
		/// Get Node object from x and y index.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>Node object</returns>
		public Node NodeFromIndex(int x, int y)
		{
			if (x <= gridSizeX && y <= gridSizeY && x >= 0 && y >= 0)
				return grid[x, y];
			return null;
		}

		/// <summary>
		/// Use by aStar Algorithm, to find nodes adjacent to a node 
		/// from certain direction.
		/// </summary>
		/// <remarks>
		/// Direction Handle are North, South, East, West without any
		/// diagonal movement
		/// </remarks>
		/// <param name="node"></param>
		/// <returns>Return a list of adjacent nodes based on Node argument passed</returns>
		public List<Node> GetNeighbouringNodes(Node node)
		{
			List<Node> NeighbouringNodes = new List<Node>();
			int xCheck, yCheck;

			//Right Side Check
			xCheck = node.gridX + 1;
			yCheck = node.gridY;
			if (xCheck >= 0 && xCheck < gridSizeX)
			{
				if (yCheck >=0 && yCheck < gridSizeY)
				{
					NeighbouringNodes.Add(grid[xCheck, yCheck]);
				}
			}


			//Left Side Check
			xCheck = node.gridX - 1;
			yCheck = node.gridY;
			if (xCheck >= 0 && xCheck < gridSizeX)
			{
				if (yCheck >=0 && yCheck < gridSizeY)
				{
					NeighbouringNodes.Add(grid[xCheck, yCheck]);
				}
			}

			//Top Side Check
			xCheck = node.gridX;
			yCheck = node.gridY + 1;
			if (xCheck >= 0 && xCheck < gridSizeX)
			{
				if (yCheck >=0 && yCheck < gridSizeY)
				{
					NeighbouringNodes.Add(grid[xCheck, yCheck]);
				}
			}


			//Bottom Side Check
			xCheck = node.gridX;
			yCheck = node.gridY - 1;
			if (xCheck >= 0 && xCheck < gridSizeX)
			{
				if (yCheck >=0 && yCheck < gridSizeY)
				{
					NeighbouringNodes.Add(grid[xCheck, yCheck]);
				}
			}

			return NeighbouringNodes;
		}

		private void OnDrawGizmos()
		{
			if (grid != null)
			{
				Node playerNode = NodeFromWorldPoint(player.position);
				foreach (Node n in grid)
				{
					Gizmos.color = (n.isWalkable) ? Color.white : Color.red;
					if (playerNode == n)
					{
						Gizmos.color = Color.cyan;
					}
					if (n.isOccupied == true)
						Gizmos.color = Color.black;
					if (FinalPath != null)
					{
						if (FinalPath.Contains(n))
						{
							Gizmos.color = Color.yellow;
						}
					}

					if (player.GetComponent<PlayerController>().nodesToMove != null)
					{
						if (player.GetComponent<PlayerController>().nodesToMove.Contains(n))
						{
							Gizmos.color = Color.green;
						}
					}
					Gizmos.DrawCube(n.Position, Vector3.one * (nodeDiameter - .1f));
				}
			}
		}

	}
}