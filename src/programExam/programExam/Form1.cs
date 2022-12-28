using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace programExam
{
    public partial class Form1 : Form
    {
        string filePath;
        string fileName;
        double x;
        double y;
        public Form1()
        {
            InitializeComponent();
            XValueBox.Visible = false;
            YValueBox.Visible = false;
            GetAnswerButton.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "HTML Document (*.html)|*.html";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;
            filePath = openFileDialog.FileName;
            fileName = openFileDialog.SafeFileName;
            webBrowser1.Navigate(filePath);
            XValueBox.Visible = true;
            YValueBox.Visible = true;
            GetAnswerButton.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            this.Size = new Size(982, 580);
        }

        private void GetAnswerButton_Click(object sender, EventArgs e)
        {
            if (fileName == "indexFirst.html")
            {
                if (!double.TryParse(XValueBox.Text, out x))
                {
                    MessageBox.Show("В поле ввода координаты X введены неверные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!double.TryParse(YValueBox.Text, out y))
                {
                    MessageBox.Show("В поле ввода координаты Y введены неверные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (y < 2 * x * x && x > -1 && y > 1 && x < 0)
                {
                    MessageBox.Show("Точка находится внутри заштрихованной области!");
                    toolStripStatusLabel1.Text = "Точка находится внутри заштрихованной области!";
                }
                else if (y > 2 * x * x || x < -1 || y < 1 || x > 0)
                {
                    MessageBox.Show("Точка находится вне заштрихованной области!");
                    toolStripStatusLabel1.Text = "Точка находится на границе заштрихованной области!";
                }
                else
                {
                    MessageBox.Show("Точка находится на границе заштрихованной области!");
                    toolStripStatusLabel1.Text = "Точка находится на границе заштрихованной области!";
                }
            }
            else if (fileName == "indexSecond.html")
            {
                if (!double.TryParse(XValueBox.Text, out x))
                {
                    MessageBox.Show("В поле ввода координаты X введены неверные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!double.TryParse(YValueBox.Text, out y))
                {
                    MessageBox.Show("В поле ввода координаты Y введены неверные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (x * x + y * y < 36 && (x < 0 && y < 0 || (x > 0 && y < 0) || (x < 0 && y > 0)))
                {
                    MessageBox.Show("Точка находится внутри заштрихованной области!");
                    toolStripStatusLabel1.Text = "Точка находится внутри заштрихованной области!";
                }
                else if (x * x + y * y > 36 || x > 0 && y > 0)
                {
                    MessageBox.Show("Точка находится вне заштрихованной области");
                    toolStripStatusLabel1.Text = "Точка находится вне заштрихованной области!";
                }
                else
                {
                    MessageBox.Show("Точка находится на границе заштрихованной области");
                    toolStripStatusLabel1.Text = "Точка находится на границе заштрихованной области!";
                }
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор: Заплаткин Юрий Александрович\nГруппа: ПКсп-120\nВариант: 12");
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
