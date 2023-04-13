using UnityEngine;

public static class MathUtils
{

    public static bool GetLineIntersectionPoint(Vector3 s1, Vector3 e1, Vector3 s2, Vector3 e2, out Vector3 intersectT)
    {
        MathUtils.FindLineEquation(s1, e1, out float mPlayerPath, out float cPlayerPath);
        MathUtils.FindLineEquation(s2, e2, out float mWall, out float cWall);

        if(Mathf.Approximately(mPlayerPath, mWall))
        {
            intersectT = Vector3.zero;
            return false;
        }

        float intersectX = MathUtils.FindLineIntersectionX(mPlayerPath, mWall, cPlayerPath, cWall);
        float intersectY = MathUtils.FindY(intersectX, mPlayerPath, cPlayerPath);
        intersectT = new Vector3(intersectX, intersectY);
        return true;
    }


    public static float Distance(float adjacent,float opposite)
    {
        return Mathf.Sqrt(opposite * opposite + adjacent * adjacent);
    }
    //1D
    public static float LerpUnclamped(float a, float b, float T)
    {
        return (b - a) * T;
    }

    //2D
    public static Vector3 LerpUnclamped(Vector3 a, Vector3 b, float T)
    { 
        float xT = a.x + (b.x - a.x) * T;
        float yT = a.y + (b.y - a.y) * T;

        return new Vector3(xT, yT); 
    }

    public static void FindLineEquation(Vector3 a, Vector3 b, out float m, out float c)
    {
        m = (b.y - a.y) / (b.x - a.x);
        c = -m * a.x + a.y;
    }

    public static float FindLineIntersectionX(float m1, float m2, float c1, float c2)
    {
        return (c2 - c1) / (m1 - m2);        
    }

    public static float FindY(float x, float m, float c)
    {
        return m * x + c;
    }

    public static float InverseLerp(Vector3 a, Vector3 b, Vector3 point)
    {
        return (point.x - a.x) / (b.x - a.x);
    }

}
