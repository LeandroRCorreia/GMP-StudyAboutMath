using UnityEngine;

[System.Serializable]
public struct Matrix2X2
{

    public Matrix2X2(Vector2 column0, Vector2 column1)
    {
        m00 = column0.x;
        m01 = column0.y;

        m10 = column1.x;
        m11 = column1.y;
    }

    //i
    public float m00;
    public float m01;
    //j
    public float m10;
    public float m11;

    public static Matrix2X2 identity => new Matrix2X2(new Vector2(1, 0), new Vector2(0, 1)); 

    public Vector3 GetColumn(int index)
    {
        if(index > 1 || index < 0) return Vector3.zero;

        float[,] matrixArray = new float[2,2] {{m00, m10}, {m01, m11}};

        return new Vector3(matrixArray[0, index], matrixArray[1, index]);
    }

    #region Matrices_Operation

    public static Vector3 operator *(in Matrix2X2 basis, in Vector3 v)
    {
        Vector3 result = v.x * basis.GetColumn(0) + v.y * basis.GetColumn(1);
        return result;
    }

    public static Vector3 operator *(in Vector3 v, in Matrix2X2 basis)
    {
        Vector3 result = v.x * basis.GetColumn(0) + v.y * basis.GetColumn(1);
        return result;
    }

    public static Matrix2X2 operator *(in Matrix2X2 to, in Matrix2X2 from) 
    {
        Vector3 lasti = from.GetColumn(0);
        Vector3 lastj = from.GetColumn(1);

        Vector3 currentI = to.GetColumn(0);
        Vector3 currentJ = to.GetColumn(1);
        
        Vector3 i = lasti.x * currentI + lasti.y * currentJ;
        Vector3 j = lastj.x * currentI + lastj.y * currentJ;

        return new Matrix2X2(i, j);
    }

    #endregion

    public override string ToString()
    {
        return $"{m00} {m10}\n{m01} {m11}";
    }
    
}
