using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for AI states.
/// </summary>
/// <PrimaryContributor>Hayley Kumpis</PrimaryContributor>
/// <LastEdited>11/09/2018</LastEdited>
[CreateAssetMenu (menuName = "PlugAi/State")]
public class State : ScriptableObject {

    public Transition[] transitions;
    public Action[] actions;
    public Color sceneGizmoCol = Color.gray;
    
	public void UpdateState(StateController controller )
    {
        DoAction(controller);
        CheckTransitions(controller);
    }

    private void DoAction(StateController controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(controller);
        }
    }

    private void CheckTransitions(StateController controller)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            bool decisionSucceeded = transitions[i].decision.Decide(controller);

            if (decisionSucceeded)
            {
                controller.TransitionToState(transitions[i].trueState);
            }
            else
            {
                controller.TransitionToState(transitions[i].falseState);
            }
        }
    }

}
