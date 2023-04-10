using TMPro;
using UnityEngine;

struct EquationLine
{
    public EquationLine(Vector3 pointA, Vector3 pointB)
    {
        m = (pointB.y - pointA.y) / (pointB.x - pointA.x);
        c = m * (pointA.x + pointA.y);

    }

    public float m;
    public float c;

    public float RadianAngle => Mathf.Atan(m);
    public float DegressAngle => Mathf.Atan(m) * Mathf.Rad2Deg;

}

[ExecuteAlways]
public class LineEquation : MonoBehaviour
{

    [SerializeField] private Transform point_A;
    [SerializeField] private Transform point_B;

    [SerializeField] private TextMeshProUGUI equationLineText;


    private Vector3 positionA => point_A.position;
    private Vector3 positionB => point_B.position;

    private EquationLine equationLine;

    private void Update() 
    {
        equationLineText.text = $"y = {equationLine.m}x + {equationLine.c} (angle => {equationLine.DegressAngle} ) ";
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(positionA, positionB);
        Gizmos.DrawLine(positionA, positionB.x * Vector3.right);
        equationLine = new EquationLine(positionA, positionB);

    }

}
