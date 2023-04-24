using UnityEngine;

[ExecuteAlways]
public class FieldOfViewTopDown : MonoBehaviour
{

    [Range(0, 180)] [SerializeField] private float angle;
    [SerializeField] private float radius;

    [SerializeField] private Transform target;

    private void OnDrawGizmos()
    {   
        DrawFOV();
    }

    private void DrawFOV()
    {
        Gizmos.color = CanSeeTarget(target) ? Color.green : Color.red;

        var leftDir = Quaternion.Euler(0, angle * 0.5f, 0) * transform.forward;
        var rightDir = Quaternion.Euler(0, -angle * 0.5f, 0) * transform.forward;

        Gizmos.DrawWireSphere(transform.position, radius);

        Gizmos.DrawRay(transform.position, leftDir.normalized * radius);
        Gizmos.DrawRay(transform.position, rightDir.normalized * radius);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward);
    }

    private bool CanSeeTarget(Transform target)
    {

        if(target == null) return false;

        var toTarget = (target.position - transform.position);
        if(toTarget.sqrMagnitude > radius * radius) return false;

        float dot = MathUtils.Dot(toTarget, transform.forward);
        if(dot < 0) return false;       

        var cosHalfAngleToTarget = dot / (toTarget.magnitude * transform.forward.magnitude);
        var halfAngleToTarget = Mathf.Acos(cosHalfAngleToTarget) * Mathf.Rad2Deg;

        Debug.Log(halfAngleToTarget);
        Debug.Log(angle * 0.5f);
        return halfAngleToTarget <= (angle * 0.5f);
    }

}
