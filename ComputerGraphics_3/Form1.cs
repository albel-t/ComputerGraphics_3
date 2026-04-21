using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerGraphics_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Добавляем начальный куб
            sceneObjects.Add(new Cube(1, "Куб 4x4x4", new Vector3(0, 0, 0), 2, Color.White));
            UpdateObjectList();

            lastRenderTime = DateTime.Now;
            Render();
        }

        private void buttonTextureOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog_Texture = new OpenFileDialog();
            openFileDialog_Texture.Title = "Выберите файл";
            openFileDialog_Texture.Filter = "Картинки (*.png)|*.png|Все файлы (*.*)|*.*";
            openFileDialog_Texture.FilterIndex = 1; // Какой фильтр выбран по умолчанию
            openFileDialog_Texture.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog_Texture.Multiselect = false; // Можно ли выбирать несколько файлов
            openFileDialog_Texture.RestoreDirectory = true; // Восстанавливать ли предыдущую директорию

            if (openFileDialog_Texture.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog_Texture.FileName;

                //MessageBox.Show($"Выбран файл: {selectedFilePath}");

            }
        }

        private float cameraAngle = 0;
        private float cameraDistance = 15;
        private int screenWidth = 400;
        private int screenHeight = 400;
        private int renderResolution = 100;

        // Список всех объектов в сцене
        private List<SceneObject> sceneObjects = new List<SceneObject>();
        private int nextObjectId = 1;

        private DateTime lastRenderTime;
        private int frameCount = 0;


        private void AddObject()
        {
            float x, y, z, size;

            if (float.TryParse(textBoxObjX.Text, out x) &&
                float.TryParse(textBoxObjY.Text, out y) &&
                float.TryParse(textBoxObjZ.Text, out z) &&
                float.TryParse(textBoxObjRadius.Text, out size) && size > 0)
            {
                Random rand = new Random();
                Color randomColor = Color.FromArgb(rand.Next(100, 255), rand.Next(100, 255), rand.Next(100, 255));

                SceneObject newObject = null;

                if (comboBoxObjType.SelectedItem.ToString() == "Sphere")
                {
                    newObject = new Sphere(nextObjectId++, $"Сфера {nextObjectId - 1}", new Vector3(x, y, z), size, randomColor);
                }
                else
                {
                    newObject = new Cube(nextObjectId++, $"Куб {nextObjectId - 1}", new Vector3(x, y, z), size, randomColor);
                }

                sceneObjects.Add(newObject);
                UpdateObjectList();
                Render();
            }
            else
            {
                MessageBox.Show("Введите корректные координаты и размер (размер > 0)");
            }
        }

        private void RemoveObject()
        {
            if (listBoxObjects.SelectedItem != null)
            {
                int id = (int)listBoxObjects.SelectedItem;
                var obj = sceneObjects.Find(o => o.Id == id);
                if (obj != null && obj.Name != "Куб 4x4x4")
                {
                    sceneObjects.Remove(obj);
                    UpdateObjectList();
                    Render();
                }
                else if (obj != null && obj.Name == "Куб 4x4x4")
                {
                    MessageBox.Show("Нельзя удалить базовый куб");
                }
            }
        }

        private void UpdateObjectList()
        {
            listBoxObjects.Items.Clear();
            foreach (var obj in sceneObjects)
            {
                listBoxObjects.Items.Add(obj.Id);
            }

            listBoxObjects.Format += (s, e) =>
            {
                int id = (int)e.ListItem;
                var obj = sceneObjects.Find(o => o.Id == id);
                if (obj != null)
                {
                    e.Value = obj.ToString();
                }
            };
            listBoxObjects.Invalidate();
        }

        private void ApplyRenderResolution()
        {
            int newRes;
            if (int.TryParse(textBoxResolution.Text, out newRes) && newRes >= 1 && newRes <= screenWidth)
            {
                renderResolution = newRes;
                Render();
            }
            else
            {
                MessageBox.Show($"Введите число от 1 до {screenWidth}");
            }
        }

        private void Render()
        {
            DateTime startTime = DateTime.Now;

            float cameraX = (float)(Math.Cos(cameraAngle) * cameraDistance);
            float cameraY = (float)(Math.Sin(cameraAngle) * cameraDistance);
            float cameraZ = 8;

            textBoxCameraX.Text = $"X: {cameraX:F2}";
            textBoxCameraY.Text = $"Y: {cameraY:F2}";

            Bitmap bmp = new Bitmap(screenWidth, screenHeight);

            Vector3 cameraPos = new Vector3(cameraX, cameraY, cameraZ);

            int blockSize = Math.Max(1, screenWidth / renderResolution);

            for (int blockY = 0; blockY < screenHeight; blockY += blockSize)
            {
                for (int blockX = 0; blockX < screenWidth; blockX += blockSize)
                {
                    int centerX = blockX + blockSize / 2;
                    int centerY = blockY + blockSize / 2;

                    if (centerX >= screenWidth) centerX = screenWidth - 1;
                    if (centerY >= screenHeight) centerY = screenHeight - 1;

                    Ray ray = GetRayFromScreenCoords(centerX, centerY, cameraPos);

                    float closestT = float.MaxValue;
                    SceneObject hitObject = null;
                    Vector3 hitPoint = new Vector3();

                    foreach (var obj in sceneObjects)
                    {
                        float t;
                        Vector3 point;
                        if (obj.Intersect(ray, out t, out point) && t > 0 && t < closestT)
                        {
                            closestT = t;
                            hitObject = obj;
                            hitPoint = point;
                        }
                    }

                    Color blockColor = hitObject != null ? hitObject.GetColor(hitPoint) : Color.DarkBlue;

                    for (int y = blockY; y < Math.Min(blockY + blockSize, screenHeight); y++)
                    {
                        for (int x = blockX; x < Math.Min(blockX + blockSize, screenWidth); x++)
                        {
                            bmp.SetPixel(x, y, blockColor);
                        }
                    }
                }
            }

            pictureBoxScreen.Image = bmp;

            frameCount++;
            TimeSpan elapsed = DateTime.Now - lastRenderTime;
            if (elapsed.TotalSeconds >= 1)
            {
                labelFPS.Text = $"FPS: {frameCount} | Res: {renderResolution}x{renderResolution} | Objs: {sceneObjects.Count}";
                frameCount = 0;
                lastRenderTime = DateTime.Now;
            }
        }

        private Ray GetRayFromScreenCoords(int x, int y, Vector3 cameraPos)
        {
            Vector3 target = new Vector3(0, 0, 0);
            Vector3 forward = (target - cameraPos).Normalize();
            Vector3 realUp = new Vector3(0, 1, 0);
            Vector3 realRight = Vector3.Cross(realUp, forward).Normalize();
            Vector3 realUpCorrected = Vector3.Cross(forward, realRight).Normalize();

            float fov = 60 * (float)Math.PI / 180;
            float aspect = (float)screenWidth / screenHeight;

            float px = (x / (float)screenWidth) * 2 - 1;
            float py = (y / (float)screenHeight) * 2 - 1;

            float screenXcoord = px * (float)Math.Tan(fov / 2) * aspect;
            float screenYcoord = py * (float)Math.Tan(fov / 2);

            Vector3 rayDirCam = new Vector3(screenXcoord, -screenYcoord, 1).Normalize();
            Vector3 rayDir = (realRight * rayDirCam.X + realUpCorrected * rayDirCam.Y + forward * rayDirCam.Z).Normalize();

            return new Ray(cameraPos, rayDir);
        }
    }

}
