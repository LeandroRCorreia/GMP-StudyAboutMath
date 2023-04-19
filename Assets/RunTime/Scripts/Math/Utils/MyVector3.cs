using System;
using UnityEngine;

[Serializable]
public struct MyVector3
{

    public MyVector3(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;

    }

    public float x;
    public float y;
    public float z;

    public float Magnitude => Mathf.Sqrt(x*x + y*y + z*z);

    public MyVector3 Normalized => this * (1 / Magnitude);
    
    #region Operator_Overloading

    public static MyVector3 operator +(MyVector3 a, MyVector3 b) => new MyVector3(a.x + b.x, a.y + b.y, a.z + b.z);

    public static MyVector3 operator *(MyVector3 a, float scale) =>
    new MyVector3(a.x * scale, a.y * scale, a.z * scale);

    public static MyVector3 operator *(float scale, MyVector3 a) =>
    new MyVector3(a.x * scale, a.y * scale, a.z * scale);

    public static implicit operator Vector3(MyVector3 a) => new Vector3(a.x, a.y, a.z);

    #endregion

}
