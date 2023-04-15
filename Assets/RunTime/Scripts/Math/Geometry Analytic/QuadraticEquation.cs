using UnityEngine;

struct QuadraticEquation
{

    public QuadraticEquation(float a, float b, float c)
    {
        this.a = a;
        this.b = b;
        this.c = c;

    }

    public float a;
    public float b;
    public float c;
    public float Delta => b * b -4 * a * c;

    public float X1 => (-b + Mathf.Sqrt(Delta)) / (2 * a);
    public float X2 => (-b - Mathf.Sqrt(Delta)) / (2 * a);

}
