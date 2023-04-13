using UnityEngine;

public struct EquationLine
{
    public EquationLine(Vector3 pointA, Vector3 pointB)
    {
        m = (pointB.y - pointA.y) / (pointB.x - pointA.x);
        c = -m * pointA.x + pointA.y;

    }

    public float m;
    public float c;

    public float RadianAngle => Mathf.Atan(m);
    public float DegressAngle => Mathf.Atan(m) * Mathf.Rad2Deg;

}
