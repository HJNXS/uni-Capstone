using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

/// <summary>
/// Chase the player action
/// </summary>
/// <PrimaryContributor>Hayley Kumpis</PrimaryContributor>
/// <LastEdited>07/09/2018</LastEdited>
[CreateAssetMenu(menuName = "PlugAi/Actions/Chase")]
public class ChaseAction : Action
{
	private bool isAbleToCatch = false;

	public override void Act(StateController controller)
	{
		Chase(controller);
	}

	private void Chase(StateController controller)
	{
		//chase works a little better now. 
		//still to fix:
		//The actual coroutine doesnt update the final position if the player pos in FOV.
		//currently paths to the last known point, and if it can still see the player, creates a new path.
		//But it actually stops moving which is the issue.

		controller.ActualSpeed = controller.AiStats.chaseSpeed;
		Vector3 destPos = controller.chaseTarget.position;
		var catchDist = controller.AiStats.catchDistance;

		FieldOfView FOV = controller.AIfov;
		FOV.FindVisibleTargets();

		//Debug.Log("Agent arrived: " + controller.gridAgent.AgentArrived.ToString());
		//Debug.Log("destPos : " + destPos.ToString());


		controller.transform.rotation = GetLookRotation(controller, controller.playerTransform.position);

		if (Vector3.Distance(controller.playerTransform.position, controller.transform.position) < catchDist && !isAbleToCatch)
		{
			Vibrate();
			controller.coroutineHolder = controller.StartCoroutine(Catch(controller));
		}
		else if (Vector3.Distance(controller.playerTransform.position, controller.transform.position) < catchDist && isAbleToCatch)
		{
			catchPlayer(controller);
		}
		else
		{
			isAbleToCatch = false;
			controller.AiStats.chaseSpeed = controller.AiStats.resetChaseSpeed;
			if (controller.coroutineHolder != null)
			{
				controller.StopCoroutine(controller.coroutineHolder);
				controller.coroutineHolder = null;
			}
			if (FOV.visibleTargets.Count != 0)
			{
				destPos = controller.playerTransform.position;
				controller.gridAgent.StopPathingCoroutine();
				controller.gridAgent.SetDestination(destPos, controller.AiStats.chaseSpeed);
			}
			//controller.gridAgent.SetDestination(destPos, controller.AiStats.chaseSpeed);
		}

		/*
            if (controller.transform.position != controller.chaseTarget.position)
        {
            controller.transform.rotation = GetLookRotation(controller, destPos);
            if (Vector3.Distance(controller.playerTransform.position, controller.transform.position) > catchDist)
            {
                destPos = controller.chaseTarget.position;
                controller.gridAgent.SetDestination(destPos);
            }
            else
            {
                controller.gridAgent.StopPathing();
                controller.restartSceneEvent.Invoke();
            }
    
            //controller.transform.position = Vector3.MoveTowards(controller.transform.position, destPos, 0.1f);
            
        }
        */
	}

	IEnumerator Catch(StateController controller)
	{
		yield return new WaitForSeconds(controller.AiStats.catchTime);
		controller.AiStats.chaseSpeed += controller.AiStats.addOnchaseSpeed;
		isAbleToCatch = true;
	}

	private void catchPlayer(StateController controller)
	{
		controller.AiStats.chaseSpeed = controller.AiStats.resetChaseSpeed;
		controller.playerTransform.GetComponent<PlayerController>().moveSettings.allowedMovement = false;
		if (controller.playerTransform.GetComponent<PlayerController>().movementCoroutine != null)
			controller.playerTransform.GetComponent<PlayerController>().StopCoroutine(controller.playerTransform.GetComponent<PlayerController>().movementCoroutine);
		ReInput.players.GetPlayer(0).StopVibration();
		controller.gridAgent.StopPathing();
		controller.restartSceneEvent.Invoke();
	}

	private void Vibrate()
	{
		ReInput.players.GetPlayer(0).SetVibration(0, 0.2f);
	}
}
