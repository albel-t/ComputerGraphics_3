using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics_3
{

    // Базовый абстрактный класс
    public abstract class SceneObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Vector3 Position { get; set; }
        public float Size { get; set; }
        public Color Color { get; set; }

        public SceneObject(int id, string name, Vector3 position, float size, Color color)
        {
            Id = id;
            Name = name;
            Position = position;
            Size = size;
            Color = color;
        }

        public abstract bool Intersect(Ray ray, out float t, out Vector3 hitPoint);
        public abstract Color GetColor(Vector3 hitPoint);

        public override string ToString()
        {
            return $"{Id}: {Name} ({Position.X:F1}, {Position.Y:F1}, {Position.Z:F1}) Size={Size:F1}";
        }
    }

    // Класс Cube
    public class Cube : SceneObject
    {
        public Cube(int id, string name, Vector3 position, float size, Color color)
            : base(id, name, position, size, color) { }

        public override bool Intersect(Ray ray, out float t, out Vector3 hitPoint)
        {
            t = float.MaxValue;
            hitPoint = new Vector3();

            float cubeMinX = Position.X - Size;
            float cubeMaxX = Position.X + Size;
            float cubeMinY = Position.Y - Size;
            float cubeMaxY = Position.Y + Size;
            float cubeMinZ = Position.Z - Size;
            float cubeMaxZ = Position.Z + Size;

            float tmin = (cubeMinX - ray.Origin.X) / ray.Direction.X;
            float tmax = (cubeMaxX - ray.Origin.X) / ray.Direction.X;
            if (tmin > tmax) { float temp = tmin; tmin = tmax; tmax = temp; }

            float tymin = (cubeMinY - ray.Origin.Y) / ray.Direction.Y;
            float tymax = (cubeMaxY - ray.Origin.Y) / ray.Direction.Y;
            if (tymin > tymax) { float temp = tymin; tymin = tymax; tymax = temp; }

            if ((tmin > tymax) || (tymin > tmax)) return false;
            if (tymin > tmin) tmin = tymin;
            if (tymax < tmax) tmax = tymax;

            float tzmin = (cubeMinZ - ray.Origin.Z) / ray.Direction.Z;
            float tzmax = (cubeMaxZ - ray.Origin.Z) / ray.Direction.Z;
            if (tzmin > tzmax) { float temp = tzmin; tzmin = tzmax; tzmax = temp; }

            if ((tmin > tzmax) || (tzmin > tmax)) return false;
            if (tzmin > tmin) tmin = tzmin;
            if (tzmax < tmax) tmax = tzmax;

            t = tmin;
            if (t > 0)
            {
                hitPoint = ray.Origin + ray.Direction * t;
                return true;
            }
            return false;
        }

        public override Color GetColor(Vector3 hitPoint)
        {
            float eps = 0.01f;
            float cubeMinX = Position.X - Size;
            float cubeMaxX = Position.X + Size;
            float cubeMinY = Position.Y - Size;
            float cubeMaxY = Position.Y + Size;
            float cubeMinZ = Position.Z - Size;
            float cubeMaxZ = Position.Z + Size;

            if (Math.Abs(hitPoint.X - cubeMinX) < eps || Math.Abs(hitPoint.X - cubeMaxX) < eps)
                return Color.Red;
            if (Math.Abs(hitPoint.Y - cubeMinY) < eps || Math.Abs(hitPoint.Y - cubeMaxY) < eps)
                return Color.Green;
            if (Math.Abs(hitPoint.Z - cubeMinZ) < eps || Math.Abs(hitPoint.Z - cubeMaxZ) < eps)
                return Color.Blue;

            return Color.White;
        }
    }

    // Класс Sphere
    public class Sphere : SceneObject
    {
        public Sphere(int id, string name, Vector3 position, float radius, Color color)
            : base(id, name, position, radius, color) { }

        public override bool Intersect(Ray ray, out float t, out Vector3 hitPoint)
        {
            t = 0;
            hitPoint = new Vector3();

            Vector3 oc = ray.Origin - Position;
            float a = Vector3.Dot(ray.Direction, ray.Direction);
            float b = 2.0f * Vector3.Dot(oc, ray.Direction);
            float c = Vector3.Dot(oc, oc) - Size * Size;
            float discriminant = b * b - 4 * a * c;

            if (discriminant < 0) return false;

            float sqrtD = (float)Math.Sqrt(discriminant);
            float t1 = (-b - sqrtD) / (2 * a);
            float t2 = (-b + sqrtD) / (2 * a);

            if (t1 > 0 && t1 < t2)
                t = t1;
            else if (t2 > 0)
                t = t2;
            else
                return false;

            hitPoint = ray.Origin + ray.Direction * t;
            return true;
        }

        public override Color GetColor(Vector3 hitPoint)
        {
            // Вычисляем нормаль для затенения
            Vector3 normal = (hitPoint - Position).Normalize();

            // Простое затенение на основе нормали
            float shade = (normal.X + normal.Y + normal.Z) / 3 + 0.5f;
            shade = Math.Max(0.2f, Math.Min(1.0f, shade));

            return Color.FromArgb(
                (int)(Color.R * shade),
                (int)(Color.G * shade),
                (int)(Color.B * shade)
            );
        }
    }

    // Вспомогательные структуры
    public struct Vector3
    {
        public float X, Y, Z;
        public Vector3(float x, float y, float z) { X = x; Y = y; Z = z; }

        public Vector3 Normalize()
        {
            float len = (float)Math.Sqrt(X * X + Y * Y + Z * Z);
            if (len < 0.0001f) return new Vector3(0, 0, 1);
            return new Vector3(X / len, Y / len, Z / len);
        }

        public static float Dot(Vector3 a, Vector3 b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;

        public static Vector3 Cross(Vector3 a, Vector3 b)
        {
            return new Vector3(
                a.Y * b.Z - a.Z * b.Y,
                a.Z * b.X - a.X * b.Z,
                a.X * b.Y - a.Y * b.X
            );
        }

        public static Vector3 operator +(Vector3 a, Vector3 b) => new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Vector3 operator -(Vector3 a, Vector3 b) => new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static Vector3 operator *(Vector3 a, float b) => new Vector3(a.X * b, a.Y * b, a.Z * b);
    }

    public struct Ray
    {
        public Vector3 Origin;
        public Vector3 Direction;
        public Ray(Vector3 origin, Vector3 direction) { Origin = origin; Direction = direction; }
    }
    

}
