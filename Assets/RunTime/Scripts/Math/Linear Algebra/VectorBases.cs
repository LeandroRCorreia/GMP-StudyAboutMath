using UnityEngine;
using TMPro;

public class VectorBases : MonoBehaviour
{

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI infoText;

    [SerializeField] private Vector2 v;

    [SerializeField] private Matrix2X2[] matricesComposition;

    private void OnDrawGizmos()
    {
        UpdateMatrixBasisVisualizer();
    }

    private void UpdateMatrixBasisVisualizer()
    {
        Matrix2X2 basisTransformed;
        Vector3 vTransformed;
        GetMatrixAndVectorTransformed(out basisTransformed, out vTransformed);
        UpdateDrawsAndTextInfo(basisTransformed, vTransformed);
    }

    private void GetMatrixAndVectorTransformed(out Matrix2X2 basisTransformed, out Vector3 vTransformed)
    {
        Matrix2X2 initialMatrix = Matrix2X2.identity;
        basisTransformed = UpdateCompositionOfMatricesTransformation(in initialMatrix, in matricesComposition);
        vTransformed = basisTransformed * v;
    }

    private Matrix2X2 UpdateCompositionOfMatricesTransformation(in Matrix2X2 initialBasis, in Matrix2X2[] matricesT)
    {
        Matrix2X2 result = initialBasis;

        foreach(Matrix2X2 matrix in matricesT)
        {
            result = matrix * result;
        }

        return result;
    }

    private void UpdateDrawsAndTextInfo(Matrix2X2 basisTransformed, Vector3 vTransformed)
    {
        Gizmos.color = Color.yellow;
        GizmosUtils.DrawVectorAtOrigin(vTransformed);
        DrawBasis(in basisTransformed);
        UpdateTextInfo(in basisTransformed, in vTransformed);
    }

    private void DrawBasis(in Matrix2X2 basis2x2)
    {
        Gizmos.color = Color.red;
        GizmosUtils.DrawVectorAtOrigin(basis2x2.GetColumn(0));

        Gizmos.color = Color.green;
        GizmosUtils.DrawVectorAtOrigin(basis2x2.GetColumn(1));
    }

    private void UpdateTextInfo(in Matrix2X2 transformedBasis, in Vector3 vTransformed)
    {
        string vectorBasesConcatened = $"v = ({vTransformed.x}, {vTransformed.y})\n";
        infoText.text = vectorBasesConcatened + transformedBasis;
    }

}
