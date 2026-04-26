using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ComputerGraphics_3
{
    public abstract class SceneObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Vector3 Position { get; set; }
        public float Size { get; set; }
        public Color[] Colors { get; set; }

        public SceneObject(int id, string name, Vector3 position, float size, Color[] colors)
        {
            Id = id;
            Name = name;
            Position = position;
            Size = size;
            Colors = colors;
        }

        public abstract bool Intersect(Ray ray, out float t, out Vector3 hitPoint);
        public abstract Color GetColor(Vector3 hitPoint, bool ColorIs = true);

        public override string ToString()
        {
            return $"{Id}: {Name} ({Position.X:F1}, {Position.Y:F1}, {Position.Z:F1}) Size={Size:F1}";
        }
        public virtual List<Vector2> GetProjectedVertices(Vector3 cameraPos, float cameraAngle, int screenWidth, int screenHeight)
        {
            return new List<Vector2>();
        }

        public Color StrToColor(string color)
        {


            color = Regex.Replace(color, @"Color\.\S\:", "");

            switch (color)
            {
                case "Red":
                    return Color.Red;
                case "White":
                    return Color.White;
                case "Gray":
                    return Color.Gray;
                case "Green":
                    return Color.Green;
                case "Blue":
                    return Color.Blue;
                case "Black":
                    return Color.Black;
                case "Yellow":
                    return Color.Yellow;
                case "Pink":
                    return Color.Pink;
                default:
                    return Color.LightGray;
            }
        }
        public string ColorToStr(Color color)
        {
            if (color == Color.Red)
                return "Red";
            if (color == Color.White)
                return "White";
            if (color == Color.Gray)
                return "Gray";
            if (color == Color.Green)
                return "Green";
            if (color == Color.Blue)
                return "Blue";
            if (color == Color.Black)
                return "Black";
            if (color == Color.Yellow)
                return "Yellow";
            if (color == Color.Pink)
                return "Pink";
            return "LightGray";
        }

        protected List<Vector2> ProjectVertices(List<Vector3> vertices, Vector3 cameraPos, float cameraAngle, int screenWidth, int screenHeight)
        {
            var projected = new List<Vector2>();
            float fovRad = cameraAngle * (float)Math.PI / 180;
            float aspect = (float)screenWidth / screenHeight;

            // Направление камеры к центру сцены (0,0,0)
            Vector3 forward = (new Vector3(0, 0, 0) - cameraPos).Normalize();
            Vector3 up = new Vector3(0, 0, 1);
            Vector3 right = Vector3.Cross(up, forward).Normalize();
            Vector3 correctedUp = Vector3.Cross(forward, right).Normalize();

            foreach (var vertex in vertices)
            {
                Vector3 toVertex = vertex - cameraPos;
                float distance = toVertex.Length();

                // Проверяем, находится ли вершина перед камерой
                if (Vector3.Dot(toVertex, forward) <= 0.1f) continue;

                // Проецируем в координаты камеры
                float x = Vector3.Dot(toVertex, right);
                float y = Vector3.Dot(toVertex, correctedUp);
                float z = Vector3.Dot(toVertex, forward);

                if (z <= 0.1f) continue;

                // Перспективное деление
                float screenX = (x / z) / (float)Math.Tan(fovRad / 2) / aspect;
                float screenY = (y / z) / (float)Math.Tan(fovRad / 2);

                // Преобразуем в пиксельные координаты
                int pixelX = (int)((screenX + 1) * screenWidth / 2);
                int pixelY = (int)((1 - screenY) * screenHeight / 2);

                projected.Add(new Vector2(pixelX, pixelY));
            }

            return projected;
        }
    }

    public class Cube : SceneObject
    {

        public Cube(int id, string name, Vector3 position, float size, Color[] colors)
            : base(id, name, position, size, colors)
        {

        }
        public override List<Vector2> GetProjectedVertices(Vector3 cameraPos, float cameraAngle, int screenWidth, int screenHeight)
        {
            var vertices = new List<Vector3>
            {
                new Vector3(Position.X - Size, Position.Y - Size, Position.Z - Size),
                new Vector3(Position.X + Size, Position.Y - Size, Position.Z - Size),
                new Vector3(Position.X + Size, Position.Y + Size, Position.Z - Size),
                new Vector3(Position.X - Size, Position.Y + Size, Position.Z - Size),
                new Vector3(Position.X - Size, Position.Y - Size, Position.Z + Size),
                new Vector3(Position.X + Size, Position.Y - Size, Position.Z + Size),
                new Vector3(Position.X + Size, Position.Y + Size, Position.Z + Size),
                new Vector3(Position.X - Size, Position.Y + Size, Position.Z + Size)
            };

            return ProjectVertices(vertices, cameraPos, cameraAngle, screenWidth, screenHeight);
        }

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

        public override Color GetColor(Vector3 hitPoint, bool ColorIs = true)
        {
            float eps = 0.01f;
            float cubeMinX = Position.X - Size;
            float cubeMaxX = Position.X + Size;
            float cubeMinY = Position.Y - Size;
            float cubeMaxY = Position.Y + Size;
            float cubeMinZ = Position.Z - Size;
            float cubeMaxZ = Position.Z + Size;

            if (Math.Abs(hitPoint.X - cubeMinX) < eps || Math.Abs(hitPoint.X - cubeMaxX) < eps)
                return ColorIs ? Colors[0] : Color.Gray;
            if (Math.Abs(hitPoint.Y - cubeMinY) < eps || Math.Abs(hitPoint.Y - cubeMaxY) < eps)
                return ColorIs ? Colors[1] : Color.Gray;
            if (Math.Abs(hitPoint.Z - cubeMinZ) < eps || Math.Abs(hitPoint.Z - cubeMaxZ) < eps)
                return ColorIs ? Colors[2] : Color.Gray;

            return Color.White;
        }
    }
    public class Pyramid : SceneObject
    {
        private Vector3[] vertices;
        private int[][] faces;
        private Vector3[] faceNormals;

        public Pyramid(int id, string name, Vector3 position, float size, Color[] colors)
            : base(id, name, position, size, colors)
        {
            // Инициализируем вершины относительно центра
            // Пирамида с квадратным основанием (как египетские пирамиды)
            float halfSize = size;
            float height = size * 1.5f;

            vertices = new Vector3[]
            {
            // Основание (квадрат)
            new Vector3(-halfSize, -halfSize, -halfSize),  // 0: передняя левая
            new Vector3( halfSize, -halfSize, -halfSize),  // 1: передняя правая
            new Vector3( halfSize, -halfSize,  halfSize),  // 2: задняя правая
            new Vector3(-halfSize, -halfSize,  halfSize),  // 3: задняя левая
            // Вершина
            new Vector3(0, height, 0)                       // 4: вершина
            };

            // Определяем грани (4 треугольные грани + основание из 2 треугольников)
            faces = new int[][]
            {
            new int[] { 0, 1, 4 }, // передняя грань
            new int[] { 1, 2, 4 }, // правая грань
            new int[] { 2, 3, 4 }, // задняя грань
            new int[] { 3, 0, 4 }, // левая грань
            new int[] { 0, 2, 1 }, // основание треугольник 1
            new int[] { 0, 3, 2 }  // основание треугольник 2
            };

            // Вычисляем нормали для каждой грани
            faceNormals = new Vector3[faces.Length];
            for (int i = 0; i < faces.Length; i++)
            {
                Vector3 v0 = vertices[faces[i][0]];
                Vector3 v1 = vertices[faces[i][1]];
                Vector3 v2 = vertices[faces[i][2]];

                Vector3 edge1 = v1 - v0;
                Vector3 edge2 = v2 - v0;
                faceNormals[i] = Vector3.Cross(edge1, edge2).Normalize();
            }
        }
        public override List<Vector2> GetProjectedVertices(Vector3 cameraPos, float cameraAngle, int screenWidth, int screenHeight)
        {
            // Получаем все вершины пирамиды в мировых координатах
            var worldVertices = new List<Vector3>();
            foreach (var vertex in vertices)  // vertices - это поле класса
            {
                worldVertices.Add(vertex + Position);
            }
            return ProjectVertices(worldVertices, cameraPos, cameraAngle, screenWidth, screenHeight);
        }

        public override bool Intersect(Ray ray, out float t, out Vector3 hitPoint)
        {
            t = float.MaxValue;
            hitPoint = new Vector3();
            bool hit = false;

            // Смещаем луч в локальные координаты пирамиды
            Ray localRay = new Ray(ray.Origin - Position, ray.Direction);

            // Проверяем пересечение со всеми гранями
            for (int i = 0; i < faces.Length; i++)
            {
                Vector3 v0 = vertices[faces[i][0]];
                Vector3 v1 = vertices[faces[i][1]];
                Vector3 v2 = vertices[faces[i][2]];

                // Алгоритм Möller–Trumbore для пересечения луча с треугольником
                Vector3 edge1 = v1 - v0;
                Vector3 edge2 = v2 - v0;
                Vector3 h = Vector3.Cross(localRay.Direction, edge2);
                float a = Vector3.Dot(edge1, h);

                if (Math.Abs(a) < 0.0001f) continue; // Луч параллелен грани

                float f = 1.0f / a;
                Vector3 s = localRay.Origin - v0;
                float u = f * Vector3.Dot(s, h);

                if (u < 0.0f || u > 1.0f) continue;

                Vector3 q = Vector3.Cross(s, edge1);
                float v = f * Vector3.Dot(localRay.Direction, q);

                if (v < 0.0f || u + v > 1.0f) continue;

                float t_triangle = f * Vector3.Dot(edge2, q);

                if (t_triangle > 0.0001f && t_triangle < t)
                {
                    t = t_triangle;
                    hitPoint = localRay.Origin + localRay.Direction * t;
                    hit = true;
                }
            }

            if (hit)
            {
                hitPoint = hitPoint + Position; // Возвращаем в мировые координаты
            }

            return hit;
        }

        public override Color GetColor(Vector3 hitPoint, bool ColorIs = true)
        {
            // Переводим точку в локальные координаты
            Vector3 localPoint = hitPoint - Position;

            // Определяем, какая грань была пересечена
            for (int i = 0; i < faces.Length; i++)
            {
                Vector3 v0 = vertices[faces[i][0]];
                Vector3 v1 = vertices[faces[i][1]];
                Vector3 v2 = vertices[faces[i][2]];

                // Проверяем, лежит ли точка на грани (с небольшой погрешностью)
                if (IsPointOnTriangle(localPoint, v0, v1, v2))
                {
                    // Для боковых граней (0-3) используем разные цвета
                    if (ColorIs && i < Colors.Length)
                    {
                        return Colors[i % Colors.Length];
                    }
                    // Для основания используем отдельный цвет
                    else if (i >= 4)
                    {
                        return ColorIs ? Colors[Colors.Length > 4 ? 4 : 3] : Color.Gray;
                    }
                    else
                    {
                        return ColorIs ? Colors[i % Colors.Length] : Color.Gray;
                    }
                }
            }

            return Color.White;
        }

        private bool IsPointOnTriangle(Vector3 p, Vector3 a, Vector3 b, Vector3 c)
        {
            float eps = 0.001f;

            // Вычисляем барицентрические координаты
            Vector3 v0 = c - a;
            Vector3 v1 = b - a;
            Vector3 v2 = p - a;

            float dot00 = Vector3.Dot(v0, v0);
            float dot01 = Vector3.Dot(v0, v1);
            float dot02 = Vector3.Dot(v0, v2);
            float dot11 = Vector3.Dot(v1, v1);
            float dot12 = Vector3.Dot(v1, v2);

            float invDenom = 1.0f / (dot00 * dot11 - dot01 * dot01);
            float u = (dot11 * dot02 - dot01 * dot12) * invDenom;
            float v = (dot00 * dot12 - dot01 * dot02) * invDenom;

            return (u >= -eps) && (v >= -eps) && (u + v <= 1.0f + eps);
        }
    }
    public class Sphere : SceneObject
    {
        public Sphere(int id, string name, Vector3 position, float radius, Color[] colors)
            : base(id, name, position, radius, colors) { }
        public override List<Vector2> GetProjectedVertices(Vector3 cameraPos, float cameraAngle, int screenWidth, int screenHeight)
        {
            var vertices = new List<Vector3>();
            int detail = 8;

            for (int i = 0; i <= detail; i++)
            {
                float lat = (float)(Math.PI * i / detail - Math.PI / 2);
                for (int j = 0; j <= detail; j++)
                {
                    float lon = (float)(2 * Math.PI * j / detail);
                    float x = (float)(Position.X + Size * Math.Cos(lat) * Math.Cos(lon));
                    float y = (float)(Position.Y + Size * Math.Sin(lat));
                    float z = (float)(Position.Z + Size * Math.Cos(lat) * Math.Sin(lon));
                    vertices.Add(new Vector3(x, y, z));
                }
            }

            return ProjectVertices(vertices, cameraPos, cameraAngle, screenWidth, screenHeight);
        }

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

        public override Color GetColor(Vector3 hitPoint, bool ColorIs = true)
        {
            Vector3 normal = (hitPoint - Position).Normalize();

            float shade = (normal.X + normal.Y + normal.Z) / 3 + 0.5f;
            shade = Math.Max(0.2f, Math.Min(1.0f, shade));

            return Color.FromArgb(
                (int)(Colors[0].R * shade),
                (int)(Colors[0].G * shade),
                (int)(Colors[0].B * shade)
            );
        }
    }

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
        public float Length()
        {
            return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
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
    public struct Vector2
    {
        public int X, Y;
        public Vector2(int x, int y) { X = x; Y = y; }
    }


}
