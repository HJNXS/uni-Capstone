using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// AI Controller, controls the current states, actions and decision transitions.
/// </summary>
/// <PrimaryContributor>Hayley Kumpis</PrimaryContributor>
/// <LastEdited>11/09/2018</LastEdited>
public class StateController : MonoBehaviour {

    public State currentState;
    public AIStats AiStats;
    public Transform eyes;
    public State remainState;
    public State previousState;
    public State pauseState;
    [HideInInspector] public List<Transform> lightInfoPos;

    public bool aiActive;
    public Renderer Visual;

    public List<Transform> waypointList;
    public float speed = 0f;
    public float ActualSpeed = 0f;
    public float waitTime = 0f;
    public float waitTimeSearchIdl = 5f;

	public ParticleSystem confusedParticle;

    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public GridAgent gridAgent;
    [HideInInspector] public float stateTimeElapsed;

    [HideInInspector] public event System.Action onStateChange;

    [HideInInspector] public bool pointReached = false;
    [HideInInspector] public bool searchOneTime = true;
    [HideInInspector] public bool toggle = false;
    [HideInInspector] public Animator AIanimator;
    [HideInInspector] public FieldOfView AIfov;

    [HideInInspector] public Transform playerTransform; //reference to the player.
    [HideInInspector] public Coroutine coroutineHolder; //reference to the player.

    public bool isPause; //reference to the player.

    [Header("Event")]
    public GameEvent restartSceneEvent;


    [Header("Sound Event")]
    public GameEvent guardNoticeEvent;

	private void OnEnable()
	{
		PauseManager.onGamePause += delegate () { isPause = true;
			previousState = currentState;
			pauseState.transitions[0].falseState = previousState;
		};
		PauseManager.onGameResume += delegate () { isPause = false; };
		LightDown.onLightOff += addLightOff;
		LightDown.onLightOn += removeLightOn;
	}

	void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        gridAgent = GetComponent<GridAgent>();
        AIanimator = GetComponent<Animator>();
        AIfov = GetComponent<FieldOfView>();
        if (speed == 0f)
            speed = AiStats.moveSpeed;
        if (waitTime == 0f)
            waitTime = AiStats.searchDuration;
		ActualSpeed = speed;

	}
	
	void Update () {
        if (!aiActive)
            return;
        currentState.UpdateState(this);
        
	}

    private void OnDrawGizmos()
    {
        if (currentState != null && eyes != null)
        {
            Gizmos.color = currentState.sceneGizmoCol;
            Gizmos.DrawWireSphere(eyes.position, AiStats.lookSphereCastRadius);
        }
    }


    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
			if (onStateChange != null)
				onStateChange();
            OnExitState();
        }
    }

    /// <summary>
    /// Checks how much time has passed since start of state and compares to duration. 
    /// </summary>
    /// <param name="duration"></param>
    /// <returns></returns>
    /// <remarks> Used in search/alert </remarks>
    public bool CheckIfCountdownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
		//Debug.Log(stateTimeElapsed);
        return (stateTimeElapsed >= duration);
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
        pointReached = false;
    }

	private void addLightOff(Transform t)
	{
		lightInfoPos.Add(t);
	}

	private void removeLightOn(Transform t)
	{
		lightInfoPos.Remove(t);
	}
}
