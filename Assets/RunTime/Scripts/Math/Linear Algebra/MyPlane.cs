using UnityEngine;

public struct MyPlane
{

    public Vector3 point;

    public Vector3 normal;

    public float Distance => Vector3.Dot(normal, point);

    public MyPlane(in Vector3 p1, in Vector3 p2, in Vector3 p3)
    {
        this.point = p1;

        this.normal = Vector3.Cross(p2 - p1, p3 - p1).normalized;
    }

    public bool IsInfront(in Vector3 p)
    {
        return Vector3.Dot(p - point, normal) > Distance;
    }

    public Vector3 ProjectPoint(in Vector3 point, out Vector3 projected)
    {   
        projected = ProjectInPlane(point - this.point);
        return this.point + projected;
    }

    public Vector3 ProjectVector(in Vector3 v, out Vector3 pvn)
    {
        pvn = ProjectInPlane(v);
        return v - pvn;
    }

    private Vector3 ProjectInPlane(in Vector3 v)
    {
        return  Vector3.Dot(normal, v) * normal;
    }

}
