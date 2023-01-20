using System.Drawing;
using System.Drawing.Text;
using System.Reflection;
using System.Security.Policy;
using System.Threading;

namespace GeneratorFigurki
{
    public partial class Form1 : Form
    {
        private static readonly Random random = new Random();
        private bool isSquareGenerated;
        private bool isTriangleGenerated;
        private bool isCircleGenerated;
        Thread squareThread;
        Thread triangleThread;
        Thread circleThread;
        Graphics g;
        int panelY;
        int panelX;
        int panelYDiff;
        int panelXDiff;
        public Form1()
        {
            InitializeComponent();
        }

        private void GetValues()
        {
            g = CreateGraphics();
            panelY = random.Next(0, Height);
            panelX = random.Next(0, Width);
            panelYDiff = Height - panelY;
            panelXDiff = Width - panelX;
        }

        private void squareBtn_Click(object sender, EventArgs e)
        {
            squareThread = new Thread(SquareThread);
            isSquareGenerated = true;
            squareThread.Start();
        }
        private void SquareThread()
        {
            while (isSquareGenerated)
            {
                GenerateSquare();
                Thread.Sleep(100);
            }
        }
    }
}