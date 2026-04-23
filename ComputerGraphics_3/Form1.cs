using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerGraphics_3
{
    public partial class Form1 : Form
    {

        private float cameraAngle = 0;


        private double cameraAngleX = 0;
        private double cameraAngleY = 0;
        private double cameraDistance = 15;
        private int screenWidth;
        private int screenHeight;
        private int renderResolution = 100;

        private bool isDragging = false;
        private int lastMouseX = 0;
        private int lastMouseY = 0;

        private List<SceneObject> sceneObjects = new List<SceneObject>();
        private int nextObjectId = 1;
        private SceneObject activeObject = null;

        private DateTime lastRenderTime;
        private int frameCount = 0;

        public Form1()
        {
            InitializeComponent();


            screenWidth = pictureBoxScreen.Width;
            screenHeight = pictureBoxScreen.Height;

            InputOutputTextbox mouseConsole = new InputOutputTextbox();
            mouseConsole.Connect(richTextBoxMouseLogs);

            MouseCapture mouseInput = new MouseCapture();
            mouseInput.debug = true;
            mouseInput.ConnectEvents(this);
            mouseInput.ConnectStream(mouseConsole);
            mouseInput.ConnectCheckBox(RKMCheckBox, MKMCheckBox, LKMCheckBox);
            mouseInput.ConnectLabel(x_coord_out, y_coord_out);
            //InitializeUI();
            InitializeMouseCapture();
            comboBoxFigures.SelectedIndexChanged += ComboBoxFigures_SelectedIndexChanged;
            buttonRebuildWindow.Click += (s, e) => { ApplyRenderResolution(); };
            buttonEdit.Click += (s, e) => { EditActiveObject(); };
            buttonAdd.Click += (s, e) => { AddNewObject(); };


            sceneObjects.Add(new Cube(1, "Cube1", new Vector3(-2, -2, -2), 2, Color.Red));
            sceneObjects.Add(new Sphere(2, "Sphere1", new Vector3(2, 2, 2), 1.5f, Color.Blue));
            nextObjectId = 3;

            UpdateObjectsList();
            UpdateActiveObjectDisplay();

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
        private void InitializeMouseCapture()
        {
            pictureBoxScreen.MouseDown += PictureBox_MouseDown;
            pictureBoxScreen.MouseUp += PictureBox_MouseUp;
            pictureBoxScreen.MouseMove += PictureBox_MouseMove;
            pictureBoxScreen.MouseWheel += PictureBox_MouseWheel;
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastMouseX = e.X;
                lastMouseY = e.Y;
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int deltaX = e.X - lastMouseX;
                int deltaY = e.Y - lastMouseY;

                cameraAngleX += deltaX * 0.01;
                cameraAngleY += deltaY * 0.01;

                cameraAngleY = Math.Max(-Math.PI / 2.1, Math.Min(Math.PI / 2.1, cameraAngleY));

                lastMouseX = e.X;
                lastMouseY = e.Y;

                UpdateCameraPosition();
                Render();
            }
        }
        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            // Изменяем расстояние камеры в зависимости от направления прокрутки
            float zoomSpeed = 0.5f;
            cameraDistance -= e.Delta * zoomSpeed / 120; // e.Delta: +120 (вверх), -120 (вниз)

            // Ограничиваем расстояние, чтобы камера не улетела слишком далеко или не приблизилась слишком близко
            cameraDistance = Math.Max(3, Math.Min(50, cameraDistance));
            textBoxCameraDistance.Text = cameraDistance.ToString();
            UpdateCameraPosition();
            Render();
        }

        private void UpdateCameraPosition()
        {
            float cameraX = (float)(Math.Cos(cameraAngleY) * Math.Cos(cameraAngleX) * cameraDistance);
            float cameraY = (float)(Math.Cos(cameraAngleY) * Math.Sin(cameraAngleX) * cameraDistance);
            float cameraZ = (float)(Math.Sin(cameraAngleY) * cameraDistance);
            //float cameraD = float.Parse(textBoxCameraDistance.Text);

            textBoxCameraX.Text = $"{cameraX:F2}";
            textBoxCameraY.Text = $"{cameraY:F2}";
            textBoxCameraZ.Text = $"{cameraZ:F2}";

            if (textBoxCameraDistance != null)
            {
                textBoxCameraDistance.Text = $"{cameraDistance:F1}";
            }
        }

        private void AddNewObject()
        {
            Random rand = new Random();
            Color randomColor = Color.FromArgb(rand.Next(100, 255), rand.Next(100, 255), rand.Next(100, 255));

            Sphere newSphere = new Sphere(nextObjectId++, $"NewObject{nextObjectId - 1}", new Vector3(0, 0, 0), 1, randomColor);
            sceneObjects.Add(newSphere);
            activeObject = newSphere;

            UpdateObjectsList();
            UpdateActiveObjectDisplay();
            Render();
        }

        private void EditActiveObject()
        {
            if (activeObject == null) return;

            string text = richTextBoxFigurePropertyOut.Text;

            Match nameMatch = Regex.Match(text, @"Name:(\S+)");
            if (nameMatch.Success)
            {
                activeObject.Name = nameMatch.Groups[1].Value;
            }

            Match sizeMatch = Regex.Match(text, @"Size[^:]*:\s*([\d.-]+)");
            if (sizeMatch.Success)
            {
                float newSize = float.Parse(sizeMatch.Groups[1].Value, System.Globalization.CultureInfo.InvariantCulture);
                activeObject.Size = Math.Max(0.1f, newSize);
            }

            Match xMatch = Regex.Match(text, @"Location\.x:([\d.-]+)");
            Match yMatch = Regex.Match(text, @"Location\.y:([\d.-]+)");
            Match zMatch = Regex.Match(text, @"Location\.z:([\d.-]+)");

            if (xMatch.Success && yMatch.Success && zMatch.Success)
            {
                float newX = float.Parse(xMatch.Groups[1].Value, System.Globalization.CultureInfo.InvariantCulture);
                float newY = float.Parse(yMatch.Groups[1].Value, System.Globalization.CultureInfo.InvariantCulture);
                float newZ = float.Parse(zMatch.Groups[1].Value, System.Globalization.CultureInfo.InvariantCulture);
                activeObject.Position = new Vector3(newX, newY, newZ);
            }

            UpdateObjectsList();
            UpdateActiveObjectDisplay();
            Render();
        }

        private void UpdateObjectsList()
        {
            comboBoxFigures.Items.Clear();
            foreach (var obj in sceneObjects)
            {
                comboBoxFigures.Items.Add(obj);
            }
            comboBoxFigures.Items.Add("NEW");

            if (activeObject != null)
            {
                int index = sceneObjects.FindIndex(o => o.Id == activeObject.Id);
                if (index >= 0)
                    comboBoxFigures.SelectedIndex = index;
                else
                    comboBoxFigures.SelectedIndex = comboBoxFigures.Items.Count - 1;
            }
            else
            {
                comboBoxFigures.SelectedIndex = comboBoxFigures.Items.Count - 1;
            }
        }

        private void ComboBoxFigures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFigures.SelectedItem == null) return;

            if (comboBoxFigures.SelectedItem.ToString() == "NEW")
            {
                AddNewObject();
            }
            else
            {
                activeObject = comboBoxFigures.SelectedItem as SceneObject;
                UpdateActiveObjectDisplay();
            }
        }

        private void UpdateActiveObjectDisplay()
        {
            if (activeObject == null)
            {
                richTextBoxFigurePropertyOut.Text = "";
                return;
            }

            string type = activeObject is Cube ? "Cube" : "Sphere";

            richTextBoxFigurePropertyOut.Text =
                $"Name:{activeObject.Name}\r\n" +
                $"Type:{type}\r\n" +
                $"Size:{activeObject.Size:F2}\r\n" +
                $"Location\r\n" +
                $"{{\r\n" +
                $"    Location.x:{activeObject.Position.X:F2}\r\n" +
                $"    Location.y:{activeObject.Position.Y:F2}\r\n" +
                $"    Location.z:{activeObject.Position.Z:F2}\r\n" +
                $"}}";
        }

        private void ApplyRenderResolution()
        {
            cameraDistance = float.Parse(textBoxCameraDistance.Text);

            float cameraX = float.Parse(textBoxCameraX.Text);
            float cameraY = float.Parse(textBoxCameraY.Text);
            float cameraZ = float.Parse(textBoxCameraZ.Text);
            float radius = (float)Math.Sqrt(cameraX * cameraX + cameraY * cameraY + cameraZ * cameraZ);

            cameraAngleX = (float)Math.Atan2(cameraY, cameraX); 
            cameraAngleY = (float)Math.Asin(cameraZ / radius); 

            int newRes;
            if (int.TryParse(textBoxChuncksCountInput.Text, out newRes) && newRes >= 1 && newRes <= screenWidth)
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

            UpdateCameraPosition();

            Bitmap bmp = new Bitmap(screenWidth, screenHeight);



            float cameraX = float.Parse(textBoxCameraX.Text);
            float cameraY = float.Parse(textBoxCameraY.Text);
            float cameraZ = float.Parse(textBoxCameraZ.Text); ;
            Vector3 cameraPos = new Vector3(cameraX, cameraY, cameraZ);

            Vector3 cameraForward = (new Vector3(0, 0, 0) - cameraPos).Normalize();

            var visibleObjects = new List<SceneObject>();
            float maxDistance = 50f; 
            float cosFov = (float)Math.Cos(60 * Math.PI / 180); 

            foreach (var obj in sceneObjects)
            {
                Vector3 toObject = obj.Position - cameraPos;
                float distance = toObject.Length(); 

                if (distance > maxDistance) continue;

                Vector3 directionToObject = toObject.Normalize();
                float dot = Vector3.Dot(cameraForward, directionToObject);

                if (dot < cosFov) continue;

                visibleObjects.Add(obj);
            }

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

                    foreach (var obj in visibleObjects)
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
                labelFPS.Text = $"FPS: {frameCount} | Chunks: {renderResolution} | Objs: {sceneObjects.Count} | Visible: {visibleObjects.Count}";
                frameCount = 0;
                lastRenderTime = DateTime.Now;
            }
        }
        private Ray GetRayFromScreenCoords(int x, int y, Vector3 cameraPos)
        {
            Vector3 target = new Vector3(0, 0, 0);
            Vector3 forward = (target - cameraPos).Normalize();
            Vector3 realUp = new Vector3(0, 0, 1);
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
    public class InputOutputTextbox : InputOutputStream
    {
        RichTextBox console;
        string InputOutputStream.ReadLine()
        {
            if (console.Lines.Length == 0)
                return string.Empty;

            return console.Lines[console.Lines.Length - 1];
        }
        void InputOutputStream.WriteLine(string line)
        {
            console.AppendText(line + Environment.NewLine);
            console.ScrollToCaret();
        }
        public void Connect(RichTextBox consoleTextBox)
        {
            console = consoleTextBox;
            console.BackColor = Color.Black;
            console.ForeColor = Color.LimeGreen;
            console.Font = new Font("Consolas", 10);
            console.ScrollBars = RichTextBoxScrollBars.Vertical;
        }
    }
}
