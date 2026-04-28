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
        public abstract List<Vector3> GetWorldVertices();

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
        public override List<Vector3> GetWorldVertices()
        {
            List<Vector3> vertices = new List<Vector3>();
            float fullSize = Size; // Используем полный размер, а не половину

            // 8 вершин куба от -Size/2 до Size/2
            for (int i = -1; i <= 1; i += 2)
            {
                for (int j = -1; j <= 1; j += 2)
                {
                    for (int k = -1; k <= 1; k += 2)
                    {
                        // Умножаем на Size/2, чтобы получить вершины от -Size/2 до Size/2
                        Vector3 localVertex = new Vector3(i * fullSize, j * fullSize, k * fullSize);
                        Vector3 worldVertex = localVertex + Position;
                        vertices.Add(worldVertex);
                    }
                }
            }

            return vertices;
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
        private Vector3[] faceCenters; // Центры граней для более точного определения

        public Pyramid(int id, string name, Vector3 position, float size, Color[] colors)
            : base(id, name, position, size, colors)
        {
            float sqrt3 = (float)Math.Sqrt(3.0);
            float sqrt6 = (float)Math.Sqrt(6.0);

            vertices = new Vector3[]
            {
            new Vector3(0, 0, size),                                    // 0: верхняя
            new Vector3(0, size * sqrt6 / 3, -size * sqrt6 / 6),              // 1: нижняя передняя
            new Vector3(-size * sqrt3 / 3, -size * sqrt6 / 6, -size * sqrt6 / 6), // 2: нижняя левая
            new Vector3(size * sqrt3 / 3, -size * sqrt6 / 6, -size * sqrt6 / 6)   // 3: нижняя правая
            };

            // Определяем грани
            faces = new int[][]
            {
            new int[] { 0, 1, 2 }, // грань 0: передняя левая
            new int[] { 0, 2, 3 }, // грань 1: задняя
            new int[] { 0, 3, 1 }, // грань 2: передняя правая
            new int[] { 1, 2, 3 }  // грань 3: основание
            };

            // Вычисляем нормали и центры граней
            faceNormals = new Vector3[faces.Length];
            faceCenters = new Vector3[faces.Length];

            for (int i = 0; i < faces.Length; i++)
            {
                Vector3 v0 = vertices[faces[i][0]];
                Vector3 v1 = vertices[faces[i][1]];
                Vector3 v2 = vertices[faces[i][2]];

                // Нормаль грани
                Vector3 edge1 = v1 - v0;
                Vector3 edge2 = v2 - v0;
                Vector3 normal = Vector3.Cross(edge1, edge2).Normalize();

                // Направляем нормаль наружу
                Vector3 center = (v0 + v1 + v2) / 3;
                if (Vector3.Dot(normal, center) < 0)
                    normal = normal * -1;

                faceNormals[i] = normal;
                faceCenters[i] = center;
            }
        }

        public override List<Vector2> GetProjectedVertices(Vector3 cameraPos, float cameraAngle, int screenWidth, int screenHeight)
        {
            var worldVertices = new List<Vector3>();
            foreach (var vertex in vertices)
            {
                worldVertices.Add(vertex + Position);
            }
            return ProjectVertices(worldVertices, cameraPos, cameraAngle, screenWidth, screenHeight);
        }
        public override List<Vector3> GetWorldVertices()
        {
            List<Vector3> vertices = new List<Vector3>();
            float halfSize = Size / 2;
            float height = Size;

            // Основание (4 вершины)
            vertices.Add(new Vector3(-halfSize, -halfSize, 0) + Position);
            vertices.Add(new Vector3(halfSize, -halfSize, 0) + Position);
            vertices.Add(new Vector3(halfSize, halfSize, 0) + Position);
            vertices.Add(new Vector3(-halfSize, halfSize, 0) + Position);

            // Вершина
            vertices.Add(new Vector3(0, 0, height) + Position);

            return vertices;
        }
        public override bool Intersect(Ray ray, out float t, out Vector3 hitPoint)
        {
            t = float.MaxValue;
            hitPoint = new Vector3();
            bool hit = false;
            float closestT = float.MaxValue;
            Vector3 closestPoint = new Vector3();
            int hitFaceIndex = -1;

            Ray localRay = new Ray(ray.Origin - Position, ray.Direction);

            for (int i = 0; i < faces.Length; i++)
            {
                Vector3 v0 = vertices[faces[i][0]];
                Vector3 v1 = vertices[faces[i][1]];
                Vector3 v2 = vertices[faces[i][2]];

                // Решение системы уравнений для пересечения с треугольником
                Vector3 edge1 = v1 - v0;
                Vector3 edge2 = v2 - v0;
                Vector3 h = Vector3.Cross(localRay.Direction, edge2);
                float a = Vector3.Dot(edge1, h);

                if (Math.Abs(a) < 0.0001f) continue;

                float f = 1.0f / a;
                Vector3 s = localRay.Origin - v0;
                float u = f * Vector3.Dot(s, h);

                if (u < 0.0f || u > 1.0f) continue;

                Vector3 q = Vector3.Cross(s, edge1);
                float v = f * Vector3.Dot(localRay.Direction, q);

                if (v < 0.0f || u + v > 1.0f) continue;

                float t_triangle = f * Vector3.Dot(edge2, q);

                if (t_triangle > 0.0001f && t_triangle < closestT)
                {
                    closestT = t_triangle;
                    closestPoint = localRay.Origin + localRay.Direction * t_triangle;
                    hitFaceIndex = i;
                    hit = true;
                }
            }

            if (hit)
            {
                t = closestT;
                hitPoint = closestPoint + Position;
                lastHitFace = hitFaceIndex;
            }

            return hit;
        }

        private int lastHitFace = -1;

        public override Color GetColor(Vector3 hitPoint, bool ColorIs = true)
        {
            if (!ColorIs) return Color.Gray;
            return Colors[lastHitFace];
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
        public override List<Vector3> GetWorldVertices()
        {
            // Для сферы возвращаем точки bounding box
            List<Vector3> vertices = new List<Vector3>();
            float r = Size;

            // 8 точек bounding box сферы
            for (int i = -1; i <= 1; i += 2)
            {
                for (int j = -1; j <= 1; j += 2)
                {
                    for (int k = -1; k <= 1; k += 2)
                    {
                        vertices.Add(new Vector3(i * r, j * r, k * r) + Position);
                    }
                }
            }

            return vertices;
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
        public static Vector3 operator /(Vector3 a, float b) => new Vector3(a.X / b, a.Y / b, a.Z / b);
    }

    public struct Ray
    {
        public Vector3 Origin;
        public Vector3 Direction;
        public Ray(Vector3 origin, Vector3 direction) { Origin = origin; Direction = direction; }
    }
    public struct Vector2
    {
        public float X, Y;
        public Vector2(float x, float y) { X = x; Y = y; }
    }


}
