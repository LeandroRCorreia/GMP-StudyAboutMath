using UnityEngine;

public struct RectangleTriangle
{
    public RectangleTriangle(float adjacent, float opposite)
    {
        legAdjacent = adjacent;
        legOpposite = opposite;
        hypotenuse = Mathf.Sqrt(opposite * opposite + adjacent * adjacent);
    }

    public float hypotenuse;
    public float legOpposite;
    public float legAdjacent;

    public float Sine => legOpposite / hypotenuse;

    public float Cossine => legAdjacent / hypotenuse;

    public float Tan => legOpposite / legAdjacent;

    public float AngleDegress => Mathf.Acos(Cossine) * Mathf.Rad2Deg;

    public float AngleRadians => Mathf.Acos(Cossine);

}
