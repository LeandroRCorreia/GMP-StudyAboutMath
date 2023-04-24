using UnityEngine;

public enum Handness
{
    Left, Right
}

public class OrtogonalSystem : MonoBehaviour
{
    [SerializeField] private Vector3 v;
    [SerializeField] private Vector3 w;
    [SerializeField] private Handness handness;

    [SerializeField] private bool forceOrthogonalSystem;

    private void OnDrawGizmos()
    {
        UpdateOrthogonalSystem();
    }

    private void UpdateOrthogonalSystem()
    {
        var currentN = Handness.Left == handness ? MathUtils.Cross(v, w) : MathUtils.Cross(w, v);

        if (forceOrthogonalSystem)
        {

            DrawOrthogonalVectors(currentN);
            return;
        }

        DrawVectors(currentN);
    }

    private void DrawOrthogonalVectors(Vector3 currentN)
    {
        var k = currentN;
        var i = MathUtils.Cross(w, k);
        var j = MathUtils.Cross(k, i);

        Gizmos.color = Color.red;
        GizmosUtils.DrawVectorAtOrigin(i.normalized);

        Gizmos.color = Color.green;
        GizmosUtils.DrawVectorAtOrigin(j.normalized);

        Gizmos.color = Color.cyan;
        GizmosUtils.DrawVectorAtOrigin(k.normalized);



        Gizmos.color = Color.red;
        GizmosUtils.DrawVectorAtOrigin(i.normalized);

        Gizmos.color = Color.green;
        GizmosUtils.DrawVectorAtOrigin(j.normalized);

    }

    private void DrawVectors(Vector3 currentN)
    {
        Gizmos.color = Color.cyan;
        GizmosUtils.DrawVectorAtOrigin(currentN);

        Gizmos.color = Color.red;
        GizmosUtils.DrawVectorAtOrigin(v);

        Gizmos.color = Color.green;
        GizmosUtils.DrawVectorAtOrigin(w);
    }

}
