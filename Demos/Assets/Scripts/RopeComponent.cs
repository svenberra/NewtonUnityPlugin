using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeComponent : MonoBehaviour
{

    public int Segments = 10;
    public float SegmentSize = 0.3f;
    private List<GameObject> gameObjects = new List<GameObject>();
    private NewtonWorld world;
    private LineRenderer lineRenderer;

    void Awake()
    {
        world = FindObjectOfType(typeof(NewtonWorld)) as NewtonWorld;

        for (var i = 0; i < Segments; i++)
        {
            var go = new GameObject("Segment" + i.ToString());
            go.transform.localPosition = new Vector3(i * SegmentSize, 0, 0);
            var rb = go.AddComponent<NewtonBody>();
            rb.m_world = world;
            rb.m_mass = 1.0f;
            var col = go.AddComponent<NewtonSphereCollider>();
            col.m_radius = SegmentSize / 2.0f;
            var joint = go.AddComponent<NewtonBallAndSocket>();
            joint.m_posit = new Vector3(-(SegmentSize / 2.0f), 0, 0);
            if (i > 0)
            {
                joint.m_otherBody = gameObjects[i - 1].GetComponent<NewtonBody>();
            }

            go.transform.SetParent(transform, false);
            gameObjects.Add(go);
        }

        lineRenderer = transform.gameObject.AddComponent<LineRenderer>();
        lineRenderer.numPositions = Segments;
        lineRenderer.widthMultiplier = SegmentSize;
    }

    void Start()
    {

    }

    void Update()
    {
        var points = new Vector3[Segments];

        for (int i = 0; i < Segments; i++)
        {
            points[i] = gameObjects[i].transform.position;
        }

        lineRenderer.SetPositions(points);
    }
}
