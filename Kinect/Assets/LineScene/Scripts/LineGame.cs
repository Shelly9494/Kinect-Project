using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LineGame : MonoBehaviour {

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCol;

    List <Vector2> points;
    


    public void UpdateLine(Vector2 point)
    {
        if(points == null)
        {
            points = new List<Vector2>();
            SetPoints(point);
            return;
        }

        if (Vector2.Distance(points.Last(), point) > 0.1f)
        {
            SetPoints(point);
        }
    }

    void SetPoints(Vector2 point)
    {
        points.Add(point);

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);

        if(points.Count > 1)
        {
            edgeCol.points = points.ToArray();
        }
    }
}
