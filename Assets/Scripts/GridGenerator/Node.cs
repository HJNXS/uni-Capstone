using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridGenerator
{
	/// <summary>
	/// Node represent a unit of a grid on which entity moves.
	/// </summary>
	/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
	/// <LastEdited>18/08/18</LastEdited>
	[Serializable]
	public class Node
	{
		#region Node variables
		/// <summary>
		/// The index position inside a grid.
		/// </summary>
		[SerializeField]
		internal int gridX, gridY;
		/// <summary>
		/// Is the node passable?
		/// </summary>
		internal bool isWalkable;
		/// <summary>
		/// Is the node occupied by another entity?
		/// </summary>
		internal bool isOccupied;
		/// <summary>
		/// isWalkable is set byt mask instead of whether an object is found on top.
		/// </summary>
		internal bool setByMask;

		/// <summary>
		/// Node Position
		/// </summary>
		[SerializeField]
		internal Vector3 Position;

		internal float Size;

		/// <summary>
		/// Store the node it previously were (normally the current node) to trace the shortest path.
		/// </summary>
		internal Node Parent;

		internal int gCost;
		internal int hCost;
		internal int FCost { get { return gCost + hCost; } }

		#endregion

		public bool IsWalkable { get { return isWalkable; } set { isWalkable = value; } }

		public Node(bool walkable, bool occupied, bool maskSet, Vector3 pos, int x, int y, float nodeSize)
		{
			isWalkable = walkable;
			isOccupied = occupied;
			setByMask = maskSet;
			Position = pos;
			Size = nodeSize;
			gridX = x;
			gridY = y;
		}
	}
}