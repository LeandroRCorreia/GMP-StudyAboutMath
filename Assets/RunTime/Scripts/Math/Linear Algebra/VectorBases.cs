using UnityEngine;
using TMPro;

public class VectorBases : MonoBehaviour
{

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI infoText;

    [Header("Basis")]
    [SerializeField] private Vector2 i;
    [SerializeField] private Vector2 j;

    [SerializeField] private float x;

    [SerializeField] private float y;

    private void OnDrawGizmos() 
    {
        DrawAxis();

        Vector2 w = i * x + j * y;

        Gizmos.color = Color.yellow;
        GizmosUtils.DrawVectorAtOrigin(w);
        bool Ld = AreLinearDependent(i, j);
        infoText.text = $"v = ({w.x}, {w.y})\ni = ({i.x}, {i.y})\nj = ({j.x}, {j.y})\nLD = {Ld}";
    }

    private void DrawAxis()
    {
        float axisLenght = 4f;

        Gizmos.color = Color.red;
        GizmosUtils.DrawVectorAtOrigin(Vector3.right * axisLenght);

        Gizmos.color = Color.green;
        GizmosUtils.DrawVectorAtOrigin(Vector3.up * axisLenght);

    }

    private bool AreLinearDependent(Vector2 a, Vector2 b)
    {
        float determinant = a.x * b.y - a.y * b.x;
        return Mathf.Approximately(determinant, 0);
    }

}
