using UnityEngine;
using System.Collections.Generic;

public class DrawLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float minDistance = 0.05f; // Minimum distance between points for smoothness
    private List<Vector3> points = new List<Vector3>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Start drawing on left mouse click
        {
            StartDrawing();
        }
        if (Input.GetMouseButton(0)) // Continue drawing while holding
        {
            UpdateDrawing();
        }
        if (Input.GetMouseButtonUp(0)) // Stop drawing on release
        {
            EndDrawing();
        }
    }

    void StartDrawing()
    {
        points.Clear();
        lineRenderer.positionCount = 0;
    }

    void UpdateDrawing()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // Keep it on the same plane

        if (points.Count == 0 || Vector3.Distance(points[points.Count - 1], mousePos) > minDistance)
        {
            points.Add(mousePos);
            lineRenderer.positionCount = points.Count;
            lineRenderer.SetPositions(points.ToArray());
        }
    }

    void EndDrawing()
    {
        // Optionally process the drawing after the user lifts the mouse
    }
}
