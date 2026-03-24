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
    }
}
