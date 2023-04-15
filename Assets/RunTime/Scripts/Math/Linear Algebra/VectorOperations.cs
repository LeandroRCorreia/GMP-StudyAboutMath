using System;
using TMPro;
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

enum VectorVisualizer
{
    None,
    Add,
    ScaleBy,
    Normalized
}

public class VectorOperations : MonoBehaviour
{
    [SerializeField] private VectorVisualizer visualizerMode;

    [SerializeField] private MyVector3 v;
    [SerializeField] private MyVector3 w;

    [SerializeField] private float ScaleBy;

    [SerializeField] TextMeshProUGUI infoText;

    private void OnDrawGizmos()
    {
        DrawVisualizerAxisXYZ();
        ExecuteOperation();

    }

    private void ExecuteOperation()
    {
        switch (visualizerMode)
        {
            case VectorVisualizer.None:
                NoneOperation();
                break;
            case VectorVisualizer.Add:
                AddOperation();
                break;
            case VectorVisualizer.ScaleBy:
                ScaleOperation();
                break;
            case VectorVisualizer.Normalized:
                Normalized();
                break;
        }
    }

    private static void DrawVisualizerAxisXYZ()
    {
        float axisLenght = 4;
        Gizmos.color = Color.red;
        GizmosUtils.DrawVectorAtOrigin(new Vector3(axisLenght, 0, 0));
        Gizmos.color = Color.green;
        GizmosUtils.DrawVectorAtOrigin(new Vector3(0, axisLenght, 0));
        Gizmos.color = Color.blue;
        GizmosUtils.DrawVectorAtOrigin(new Vector3(0, 0, axisLenght));
    }

    private void NoneOperation()
    {
        MyVector3 vxAxisPoint = new MyVector3(v.x, 0, 0);

        Gizmos.color = Color.red;
        GizmosUtils.DrawRay(Vector3.right * v.x, Vector3.forward * v.z, 2);

        Gizmos.color = Color.green;
        GizmosUtils.DrawRay(Vector3.forward * v.z + Vector3.right * v.x, Vector3.up * v.y, 2);

        Gizmos.color = Color.blue;
        GizmosUtils.DrawRay(Vector3.forward * v.z, Vector3.right * v.x, 2);

        Gizmos.color = Color.yellow;
        GizmosUtils.DrawVectorAtOrigin(v);

        infoText.text = $"Magnitude:\n {v.Magnitude}";
    }

    private void AddOperation()
    {
        MyVector3 vw = v + w;

        Gizmos.color = Color.cyan;
        GizmosUtils.DrawVectorAtOrigin(v);

        Gizmos.color = Color.gray;
        GizmosUtils.DrawRay(v, w);

        Gizmos.color = Color.yellow;
        GizmosUtils.DrawVectorAtOrigin(vw);
        infoText.text = $"Result:\n [{vw.x}, {vw.y}, {vw.z}]";

    }

    private void ScaleOperation()
    {
        MyVector3 scaledVector = v * ScaleBy;

        Gizmos.color = Color.yellow;
        GizmosUtils.DrawVectorAtOrigin(v);

        Gizmos.color = Color.cyan;
        GizmosUtils.DrawVectorAtOrigin(scaledVector);

        infoText.text = $"Magnitude:\n {scaledVector.Magnitude}";
    }

    private void Normalized()
    {
        MyVector3 normalizedVector = v.Normalized;

        Gizmos.color = Color.yellow;
        GizmosUtils.DrawVectorAtOrigin(v);

        Gizmos.color = Color.cyan;
        GizmosUtils.DrawVectorAtOrigin(normalizedVector);

        infoText.text = $"Normalized Magnitude:\n {normalizedVector.Magnitude}";
    }

}
