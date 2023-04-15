using UnityEngine;

public class LineIntersection : MonoBehaviour
{
    [SerializeField] private float playerT;

    [SerializeField] private float playerSpheresRadius = 0.25f;

    [Header("LinePlayerPath")]
    [SerializeField] private Transform startPlayerPath; 
    [SerializeField] private Transform endPlayerPath;

    [Header("LineWall")]
    [SerializeField] private Transform startWall; 
    [SerializeField] private Transform endWall;

    public Vector3 startPlayerPathPosition => startPlayerPath.position;
    public Vector3 endPlayerPathPosition => endPlayerPath.position;

    public Vector3 startWallPosition => startWall.position;
    public Vector3 endWallPosition => endWall.position;

    private void OnDrawGizmos()
    {
        DrawAndCalculateProcess();
    }

    private void DrawAndCalculateProcess()
    {
        Vector3 intersectionPoint, PlayerPositionT;

        if(MathUtils.GetLineIntersectionPoint(startPlayerPathPosition,
        endPlayerPathPosition,
        startWallPosition,
        endWallPosition, 
        out intersectionPoint))
        {
            Color playerColor = Color.green;

            PlayerPositionT = MathUtils.LerpUnclamped(startPlayerPathPosition,
                endPlayerPathPosition, playerT);

            float tIntersectionPoint = MathUtils.InverseLerp(startPlayerPathPosition, endPlayerPathPosition, intersectionPoint);
            if(playerT >= tIntersectionPoint)
            {
                playerT = tIntersectionPoint;
                playerColor = Color.red;
            }

            DrawIntersectionPointAndLines(intersectionPoint);
            Gizmos.color = playerColor;
            Gizmos.DrawSphere(PlayerPositionT, playerSpheresRadius);
        }

    }

    private void DrawIntersectionPointAndLines(Vector3 intersectionPoint)
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(startPlayerPathPosition, endPlayerPathPosition);
        Gizmos.DrawLine(startWallPosition, endWallPosition);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(intersectionPoint, playerSpheresRadius * 0.5f);
    }

}
