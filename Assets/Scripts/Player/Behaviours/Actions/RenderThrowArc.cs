using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HardlightAnvil.RunWithIt.Actions
{
    [RequireComponent(typeof(LineRenderer))]
    public class RenderThrowArc : MonoBehaviour
    {
        public LineRenderer lr;

        public float velocity;
        public float angle;
        public int resolution;

        float grav;
        float radTheta;

        void Awake()
        {
            //lr = GetComponent<LineRenderer>();
            grav = Mathf.Abs(Physics.gravity.magnitude);
        }

        // Use this for initialization
        void Start()
        {
            RenderArc();
        }

        public void RenderArc()
        {
            lr.positionCount = resolution + 1;
            lr.SetPositions(ArcArray());
        }

        private Vector3[] ArcArray()
        {
            Vector3[] pointArray = new Vector3[resolution+1];

            radTheta = Mathf.Deg2Rad * angle;
            float maxDist = (velocity * velocity * Mathf.Sin(2 * radTheta)) / grav;

            for(int i = 0; i <= resolution; i++)
            {
                float inc = (float)i / (float)resolution;
                pointArray[i] = CalcArcPoint(inc, maxDist);
            }

            return pointArray;
        }

        //Calc x & y for each vertex
        private Vector3 CalcArcPoint(float inc, float maxDist)
        {
            float x,y;
            x = inc * maxDist;
            y = x * Mathf.Tan(radTheta) - ((grav * x * x) / (2 * Mathf.Pow((velocity * Mathf.Cos(radTheta)),2)));


            return new Vector3(x, y);
        }
    }

}