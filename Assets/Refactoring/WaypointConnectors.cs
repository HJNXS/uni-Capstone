using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointConnectors : MonoBehaviour {

    [SerializeField] private List<WaypointConnectors> connectors = new List<WaypointConnectors>();

    public List<WaypointConnectors> Connectors
    {
        get
        {
            return connectors;
        }

        set
        {
            connectors = value;
        }
    }

    private void OnDrawGizmosSelected()
    {
        foreach(WaypointConnectors e in Connectors)
        {
            //Gizmos.
            Gizmos.DrawLine(transform.position, e.transform.position);
        }
    }
}
