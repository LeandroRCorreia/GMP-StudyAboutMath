using UnityEngine;

public class IntersectionCircle : MonoBehaviour
{

    [Header("Circle")]
    [SerializeField] private Transform circleTransform;
    [SerializeField] private float circleRadius;

    [Header("Line")]
    [SerializeField] private Transform startLine;
    [SerializeField] private Transform endLine;
    [SerializeField] private float sphereIntersectionRadius = 0.125f;
    private Vector3 circlePosition => circleTransform.position;
    private Vector3 startLinePosition => startLine.position;
    private Vector3 endLinePosition => endLine.position;

    private void OnDrawGizmos() 
    {
        MathUtils.FindLineEquation(startLinePosition, endLinePosition, out float mLine, out float cLine);
        float constantK = cLine - circlePosition.y;
        float a = mLine * mLine + 1;
        float b = 2 * mLine * constantK - 2 * circlePosition.x;
        float c = constantK * constantK - circleRadius * circleRadius + circlePosition.x * circlePosition.x;

        QuadraticEquation q = new QuadraticEquation(a, b, c);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(startLinePosition, endLinePosition);
        Gizmos.DrawWireSphere(circlePosition, circleRadius);
        InterpretDeltaThenDraw(q, mLine, cLine);

    }

    private void InterpretDeltaThenDraw(QuadraticEquation q, float mLine, float cLine)
    {
        Gizmos.color = q.Delta != 0 ? Color.green : Color.red;

        var y1 = MathUtils.FindY(q.X1, mLine, cLine);           
        Vector3 v1 = new Vector3(q.X1, y1);

        bool IsPoint1Valid = MathUtils.IsPointIfiniteLine(startLinePosition, endLinePosition, v1);

        if(IsPoint1Valid)
            Gizmos.DrawSphere(v1, sphereIntersectionRadius);

        if(q.Delta > 0)
        {

            var y2 = MathUtils.FindY(q.X2, mLine, cLine);    
            Vector3 v2 = new Vector3(q.X2, y2);
            bool IsPoint2Valid = MathUtils.IsPointIfiniteLine(startLinePosition, endLinePosition, v2);
            if(IsPoint2Valid)
                Gizmos.DrawSphere(v2, sphereIntersectionRadius);
            
        }
    }

}
