using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ForestOfChaosLib.Extensions;
using UnityEngine;
using GridGenerator;
using Rewired;

/// <summary>
/// PlayerController class controls the player velocity using the rigidbody.
/// Handles the player's gravity.
/// </summary>
/// <PrimaryContributor>Dinys Monvoisin</PrimaryContributor>
/// <LastEdited>18/08/18</LastEdited>
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(WayPoint))]
public class PlayerController : MonoBehaviour {

	#region Input Details
	public int playerId = 0;
	private IInputManager input;
	#endregion

	[System.Serializable]
	public class MoveSettings
	{
		public float speed = 6;
		public float movementPerTile = 0.1f;
		public int maxNodesToMove = 6;
		public float rotationSpeed = 4f;
		public float distToGrounded = 0.1f;
		public LayerMask ground;
		public bool allowedMovement = true;
	}

	[System.Serializable]
	public class PhysSettings
	{
		public float downAccel = 0.75f;
	}

	#region Editor Class Initialisation
	public MoveSettings moveSettings = new MoveSettings();
	public PhysSettings phycSettings = new PhysSettings();
	#endregion

	#region Camera and angle details
	Transform camTransform;
	Quaternion targetRotation;
	Quaternion playerToRotation;
	#endregion

	#region Movement
	Rigidbody rBody;
	float horizontalInput, verticalInput, jumpInput;
	Vector3 velocity = Vector3.zero;
	#endregion

	#region Grid Player Movement
	public GridGenerator.GridGenerator gridGenerator; //TODO: may be need to make Grid manager to a singleton
	[SerializeField]
	private Node startingNode;
	[SerializeField]
	private Node currentNode;
	private bool agentArrived = true;

	[HideInInspector]
	public Coroutine movementCoroutine;

	public List<Node> nodesToMove = new List<Node>();
	private int selectedIndex = 0;
	private WayPoint waypointMovement;
	private const int NodesCountNeededBeforeMovementStarts = 1; // need a proper name // JORDAN changed from intialNodeNum
	#endregion

	#region Check if Opposite variables

	enum Direction { Horizontal, Vertical, Reset };

	Direction currentDirection;
	Direction prevDirection;

	#endregion

	private Animator playerAnimator;

	#region Unity Monobehaviour methods
	private void OnEnable()
	{
		PauseManager.onGamePause += delegate () { moveSettings.allowedMovement = false; };
		PauseManager.onGamePause += delegate () { moveSettings.allowedMovement = true; };
	}

	private void Start()
	{
		ReInput.players.GetPlayer(0).StopVibration();
        camTransform = Camera.main.transform;
		input = InputManager.instance;
		playerAnimator = GetComponent<Animator>();
		rBody = GetComponent<Rigidbody>();
		waypointMovement = GetComponent<WayPoint>();
		horizontalInput = verticalInput = jumpInput = 0;
	}

	private void Update()
	{

		GetInput();
		MoveToNode(moveSettings.allowedMovement);
	}

	private void FixedUpdate()
	{
		Jump(moveSettings.allowedMovement);
	}
	#endregion

	#region Input methods
	void GetInput()
	{
		horizontalInput = input.GetAxisRaw(playerId, InputAction.MoveHorizontal);
		verticalInput = input.GetAxisRaw(playerId, InputAction.MoveVertical);

		SetLinearAxis();
	}
	
	/// <summary>
	/// Set only one moving axis at a time. Horizontally or vertically.
	/// </summary>
	private void SetLinearAxis()
	{
		prevDirection = currentDirection;

		if(Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput))
		{
			currentDirection = Direction.Horizontal;
			verticalInput    = 0f;
		}
		else if(Mathf.Abs(verticalInput) > Mathf.Abs(horizontalInput))
		{
			currentDirection = Direction.Vertical;
			horizontalInput  = 0f;
		}
		else
		{
			currentDirection = Direction.Reset;
			ResetAxis();
		}
	}

	private void ResetAxis()
	{
		horizontalInput = 0f;
		verticalInput = 0f;
	}
	#endregion

	[System.Obsolete("The free movement is not used anymore")]
	void Move()
	{
		//Handle only walk
		velocity = (verticalInput * camTransform.forward )+ (horizontalInput * camTransform.right);
		velocity.y = 0;
	}

	#region GridMovement Methods

	/// <summary>
	/// Handles the movement from node to node inside the grid world
	/// </summary>
	/// <param name="ableToMove"></param>
	void MoveToNode(bool ableToMove)
	{
		if (ableToMove)
		{
			if(nodesToMove.IsNullOrEmpty())
			{
				currentNode = startingNode = gridGenerator.NodeFromWorldPoint(transform.position);
			}
			else
				currentNode = nodesToMove[nodesToMove.Count - 1];

			//Get the index of the currentNode (the tail of the moving nodes)
			Vector2 newStartingNodeIndex = new Vector2(currentNode.gridX, currentNode.gridY);

			// Set a new nodes from the axis move and depeding on the camera movement
			newStartingNodeIndex = new Vector2(newStartingNodeIndex.x + getMoveDirection(true),
				newStartingNodeIndex.y + getMoveDirection(false));

			var node = gridGenerator.NodeFromIndex((int)newStartingNodeIndex.x, (int)newStartingNodeIndex.y); 

			//Check whether new node and add it moving node.
			if ( node != null)
			{
				if (!nodesToMove.Contains(node) && node.isWalkable && !node.isOccupied && nodesToMove.Count < moveSettings.maxNodesToMove && node != startingNode)
					nodesToMove.Add(node);
			}

			if (!node.isWalkable && node.isOccupied && Mathf.Abs(horizontalInput) > 0 || Mathf.Abs(verticalInput) > 0)
				waypointMovement.Turn(transform, node); 

			if (nodesToMove != null && selectedIndex < nodesToMove.Count) // selected tile == 1 when playerNode is in the list
			{
				if (nodesToMove[selectedIndex].isWalkable)
				{
					if(movementCoroutine == null)
					{
						movementCoroutine = StartCoroutine(MoveUntilReach());
					}
				}
			}
		}
	}

	/// <summary>
	/// Move the player through the list of selected nodes.
	/// </summary>
	IEnumerator MoveUntilReach()
	{
		var time = 0f;
		while(nodesToMove.Count != selectedIndex && nodesToMove.Count > selectedIndex)
		{
			if (prevDirection == currentDirection)
			{
				var distance = selectedIndex == (nodesToMove.Count - 1) ? 0.07f : 0.5f; // if more nodes move faster

				time += Time.deltaTime * moveSettings.speed;
				//time = time.Clamp();

				if (Vector3.Distance(transform.position, nodesToMove[selectedIndex].Position) > distance)
				{
					//Debug.Log("PlayerPos - " + transform.position + " and nodePos - " + nodesToMove[selectedIndex].Position + " and Distance between - " + Vector3.Distance(transform.position, nodesToMove[selectedIndex].Position));
					playerAnimator.SetBool("Movement", true);
					transform.position = Vector3.Lerp(transform.position, nodesToMove[selectedIndex].Position, time);
					waypointMovement.Turn(transform, nodesToMove[selectedIndex]);
				}
				else
				{
					selectedIndex++;
					time = 0;
				}

				if (time >= 1)
				{
					selectedIndex++;
					time = 0;
				}
			} else
			{
				break;
			}
			//Debug.Log("SelectedIndex = " + selectedIndex);
			yield return null;
		}

		var distance2 = 0.07f;
		while (selectedIndex < nodesToMove.Count && Vector3.Distance(transform.position, nodesToMove[selectedIndex].Position) > distance2)
		{
			playerAnimator.SetBool("Movement", true);
			time += Time.deltaTime * moveSettings.speed;
			time = time.Clamp();
			transform.position = Vector3.Lerp(transform.position, nodesToMove[selectedIndex].Position, time);
			waypointMovement.Turn(transform, nodesToMove[selectedIndex]);
			yield return null;
		}

		playerAnimator.SetBool("Movement", false);
		selectedIndex = 0;
		nodesToMove.Clear();
		movementCoroutine = null;
	}

	/// <summary>
	/// Get the direction which need to be substracted to the index of gridX and gridY.
	/// </summary>
	/// <param name="isIndexX"></param>
	/// <returns>X or Y movement in the grid World</returns>
	int getMoveDirection(bool isIndexX)
	{
		Vector3 rotation = camTransform.transform.rotation.eulerAngles;

		if ((rotation.y > 315 && rotation.y < 360) || (rotation.y > 0 && rotation.y < 45))
		{
			return roundSamllestValueToWhole((!isIndexX) ? 1 * verticalInput : 1 * horizontalInput);
		}

		if (rotation.y > 135 && rotation.y < 225)
		{
			return roundSamllestValueToWhole((!isIndexX) ? -1 * verticalInput : -1 * horizontalInput);
		}

		if ((rotation.y > 45 && rotation.y < 135))
		{
			return roundSamllestValueToWhole((isIndexX) ? 1 * verticalInput : -1 * horizontalInput);
		}

		if (rotation.y > 225 && rotation.y < 315)
		{
			return roundSamllestValueToWhole((isIndexX) ? -1 * verticalInput : 1 * horizontalInput);
		}

		throw new System.InvalidOperationException("Cannot assign a value from the camera angle");
	}
	#endregion

	int roundSamllestValueToWhole(float input)
	{
		//Debug.Log("input" + input);
		//Debug.Log("Output- " + ((Mathf.Abs(input) > 0) ? (int)(1 * Mathf.Sign(input)) : 0));
		return (Mathf.Abs(input) > 0) ? (int)(1 * Mathf.Sign(input)): 0;
	}


	#region Gravity methods
	void Jump(bool ableToMove)
	{
		if (jumpInput > 0 && Grounded() && ableToMove)
		{
			//jump
		}
		else if (jumpInput == 0 && Grounded())
		{
			//zero velocity
			velocity.y = 0;
		}
		else
		{
			//gravity
			//velocity.y -= phycSettings.downAccel;
			rBody.AddForce(new Vector3(0f, -phycSettings.downAccel, 0f), ForceMode.Acceleration);
		}
	}
	
	bool Grounded()
	{
		return Physics.Raycast(transform.position, Vector3.down, moveSettings.distToGrounded, moveSettings.ground);
	}
	#endregion
}
