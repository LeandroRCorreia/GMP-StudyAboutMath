using TMPro;
using Unity.Mathematics;
using UnityEngine;


public static class MathUltils
{






}

public class Lerp : MonoBehaviour
{
    [SerializeField] private Transform point_A;
    [SerializeField] private Transform point_B;

    [SerializeField] private float T;
    [SerializeField] private float radiusSpheres = 0.175f;

    private Vector3 positionA => point_A.position;
    private Vector3 positionB => point_B.position;



    private void OnDrawGizmos()
    {
        
        DrawAndCalculateLerpEquation();
    }

    private void DrawAndCalculateLerpEquation()
    {
        Vector3 vectorAB;
        Vector3 tVectorBetweeenAB;
        CalculateLerpEquation(out vectorAB, out tVectorBetweeenAB);
        DrawLerpEquationDemonstration(vectorAB, tVectorBetweeenAB);
    }

    private void CalculateLerpEquation(out Vector3 vectorAB, out Vector3 tVectorBetweeenAB)
    {
        vectorAB = new Vector3(positionB.x - positionA.x, positionB.y - positionA.y);
        var xT = positionA.x + vectorAB.x * T;
        var yT = positionA.y + vectorAB.y * T;
        tVectorBetweeenAB = new Vector3(xT, yT);
    }

    private void DrawLerpEquationDemonstration(Vector3 vectorAB, Vector3 tVectorBetweeenAB)
    {
        DrawTSphereAndLineBetweenAB(tVectorBetweeenAB);
        DrawInfiniteLineOut(vectorAB.x, vectorAB.y);
        DrawXYLineAndSphere(vectorAB);
    }

    private void DrawTSphereAndLineBetweenAB(Vector3 tVectorBetweeenAB)
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(positionA, positionB);
        Gizmos.color = Color.white;

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(tVectorBetweeenAB, radiusSpheres);
    }

    private void DrawInfiniteLineOut(float x, float y)
    {
        Gizmos.color = Color.white;
        float minimumLenghtLineOut = 5;
        Gizmos.DrawRay(positionB, new Vector3(x, y) * (T + minimumLenghtLineOut));
        Gizmos.DrawRay(positionA, new Vector3(x, y) * -(T + minimumLenghtLineOut));
    }

    private void DrawXYLineAndSphere(Vector3 vectorAB)
    {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(positionA + Vector3.right * vectorAB.x * T, radiusSpheres);
        Gizmos.DrawSphere(positionA + Vector3.up * vectorAB.y * T, radiusSpheres);
        Gizmos.DrawRay(positionA, Vector3.right * vectorAB.x);
        Gizmos.DrawRay(positionA, Vector3.up * vectorAB.y);
    }

}
