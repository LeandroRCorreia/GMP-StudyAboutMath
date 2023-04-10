using UnityEngine;

[ExecuteAlways]
public class FieldOfView : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("Line Parameter")]
    [Range(0, 180)]
    [SerializeField] private float angleDegress = 45f;
    [SerializeField] private float fieldDistance = 5f;    

    private void OnDrawGizmos()
    {
        var isVisible  = IsInsideFieldOfView(transform.position, target.position);
        Gizmos.color = isVisible ? Color.green : Color.red;
        DrawFieldOfView();

    }

    private bool IsInsideFieldOfView(Vector3 origin, Vector3 target)
    {
        if(origin.y > target.y) return false;

        RectangleTriangle triang = new RectangleTriangle(target.y - origin.y, target.x - origin.x);

        if (triang.hypotenuse > fieldDistance) return false;

        return Mathf.Abs(triang.AngleDegress) < angleDegress * 0.5f;
    }

    public void DrawFieldOfView()
    {
        Gizmos.DrawWireSphere(transform.position, fieldDistance);
        float angleRadians = angleDegress * 0.5f * Mathf.Deg2Rad;
        float deltaX = Mathf.Sin(angleRadians);
        float deltaY = Mathf.Cos(angleRadians);

        Vector3 directionPositive = new Vector3(deltaX, deltaY);
        Vector3 directionNegative = new Vector3(-deltaX, deltaY);

        Gizmos.DrawRay(transform.position, directionPositive * fieldDistance);
        Gizmos.DrawRay(transform.position, directionNegative * fieldDistance);

    }

}
