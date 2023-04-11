using TMPro;
using UnityEngine;

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
        Gizmos.DrawRay(positionA, Vector3.right * (positionB.x - positionA.x));
        equationLine = new EquationLine(positionA, positionB);
    }

}
