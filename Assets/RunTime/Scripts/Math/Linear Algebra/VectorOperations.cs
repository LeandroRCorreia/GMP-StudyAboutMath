using TMPro;
using UnityEngine;

enum VectorVisualizer
{
    None, Add, ScaleBy, Normalized
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
