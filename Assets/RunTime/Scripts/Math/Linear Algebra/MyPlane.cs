using UnityEngine;

public struct MyPlane
{

    public Vector3 point;

    public Vector3 normal;

    public float Distance => Vector3.Dot(normal, point);

    public MyPlane(in Vector3 p1, in Vector3 p2, in Vector3 p3)
    {
        point = p1;
        normal = Vector3.Cross(p2 - p1, p3 - p1).normalized;
    }

    public bool IsInfront(in Vector3 p)
    {
        return Vector3.Dot(p, normal) > Distance;
    }

    public Vector3 ProjectPoint(in Vector3 p)
    {   
        return this.point + ProjectVector(p - point);
    }

    public Vector3 ProjectVector(in Vector3 vec)
    {
        return vec - Vector3.Dot(vec, normal) * normal;
    }

}
