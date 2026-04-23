using ComputerGraphics_3;

public class Plane
{
    public Vector3 Normal { get; private set; }
    public float Distance { get; private set; }

    public Plane(Vector3 a, Vector3 b, Vector3 c)
    {
        Vector3 ab = b - a;
        Vector3 ac = c - a;
        Normal = Vector3.Cross(ab, ac).Normalize();
        Distance = -Vector3.Dot(Normal, a);
    }

    public float GetDistanceToPoint(Vector3 point)
    {
        return Vector3.Dot(Normal, point) + Distance;
    }
}