using UnityEngine;

enum PlaneOperations
{
    None, PointFrontOnPlane, ProjectPoint, ProjectVector
}

public class PlaneVisualizer : MonoBehaviour
{
    [SerializeField] private PlaneOperations operationsPlane;

    [Space]

    [Header("Plane")]
    [SerializeField] private Vector3 p1;
    [SerializeField] private Vector3 p2;
    [SerializeField] private Vector3 p3;
    [SerializeField] private Vector3 p;
    
    private const float radiusSpheres = 0.5f;

    private void OnDrawGizmos()
    {
        UpdatePlane();
    }

    private void UpdatePlane()
    {
        MyPlane plane;
        StartPlane(out plane);
        ChoicePlaneOperation(in plane);
        DrawBasisOrigin();
        DrawPlaneVisualizer(in plane);
    }

    private void StartPlane(out MyPlane plane)
    {
        plane = new MyPlane(p1, p2, p3);
        var size = Mathf.Max((p2 - p1).magnitude, (p3 - p1).magnitude);
        var distanceOriginVec = plane.Distance * plane.normal;
        
        GizmosUtils.DrawPlane(plane.normal, plane.point, Vector2.one * size * 2);
        GizmosUtils.DrawVectorAtOrigin(distanceOriginVec, 4);
    }

    private void DrawBasisOrigin()
    {
        var basisLenght = 5;

        Gizmos.color = Color.red;
        GizmosUtils.DrawVectorAtOrigin(Vector3.right * basisLenght);

        Gizmos.color = Color.green;
        GizmosUtils.DrawVectorAtOrigin(Vector3.up * basisLenght);

        Gizmos.color = Color.blue;
        GizmosUtils.DrawVectorAtOrigin(Vector3.forward * basisLenght);

    }

    private void DrawPlaneVisualizer(in MyPlane plane)
    {
        //perpendicular line from origin to plane
        Gizmos.color = Color.white;
        GizmosUtils.DrawVectorAtOrigin(plane.normal * plane.Distance);

        //spheres
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(p1, radiusSpheres);
        Gizmos.DrawSphere(p2, radiusSpheres);
        Gizmos.DrawSphere(p3, radiusSpheres);

        // Normal Vector
        Gizmos.color = Color.magenta;
        GizmosUtils.DrawVector(p1, plane.normal);

    }

    private void ChoicePlaneOperation(in MyPlane plane)
    {
        switch (operationsPlane)
        {
            case PlaneOperations.PointFrontOnPlane:
                UpdateIsInFrontOperation(plane);
                break;

            case PlaneOperations.ProjectPoint:
                UpdateProjectPoint(plane);
                break;

            case PlaneOperations.ProjectVector:
                UpdateProjectVector(plane);
                break;

        }
    }

    private void UpdateIsInFrontOperation(in MyPlane plane)
    {
        var isPointFront = plane.IsInfront(p);
        Gizmos.color = isPointFront ? Color.green : Color.red;
        Gizmos.DrawSphere(p, radiusSpheres);
    }

    private void UpdateProjectPoint(in MyPlane plane)
    {
        var projected = plane.ProjectPoint(p);
        var pointPosition = plane.point + p;

        GizmosUtils.DrawVectorAtOrigin(projected);

        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(p, radiusSpheres);
        
        GizmosUtils.DrawRay(p, projected - p);
    }

    private void UpdateProjectVector(in MyPlane plane)
    {
        var projectVec = plane.ProjectVector(p);

        Gizmos.color = Color.cyan;
        GizmosUtils.DrawVector(plane.point, p);

        Gizmos.color = Color.blue;
        GizmosUtils.DrawVector(plane.point, projectVec);

        Gizmos.color = Color.cyan;
        GizmosUtils.DrawVector(p1 + p, projectVec - p);
    }

}
