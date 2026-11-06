using System;
using System.Drawing;
using System.Windows.Forms;

namespace testeVisualização3d
{
    public partial class Form1 : Form
    {
        public Cube cube;

        const int offsetZ = 600;
        const float zoom = 100;
        const float cubeSize = 500;

        private Timer timer = new Timer();
        private bool autoRotation = false;

        private int input_x = 0;
        private int input_y = 0;

        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.KeyPreview = true;

            //to centralize
            float size = cubeSize / 2;

            Vertice[] vertices = new Vertice[8]
            {
                new Vertice(-size, -size, -size), //0 fundo superior esquerdo
                new Vertice( size, -size, -size), //1 fundo superior direito
                new Vertice( size,  size, -size), //2 fundo inferior direito
                new Vertice(-size,  size, -size), //3 fundo inferior esquerdo
                new Vertice(-size, -size,  size), //4 frente superior esquerdo
                new Vertice( size, -size,  size), //5 frente superior direito
                new Vertice( size,  size,  size), //6 frente inferior direito
                new Vertice(-size,  size,  size)  //7 frente inferior esquerdo
            };

            Aresta[] arestas = new Aresta[12]
            {
                //face traseira
                new Aresta(vertices[0], vertices[1]),
                new Aresta(vertices[1], vertices[2]),
                new Aresta(vertices[2], vertices[3]),
                new Aresta(vertices[3], vertices[0]),

                //face frontal
                new Aresta(vertices[4], vertices[5]),
                new Aresta(vertices[5], vertices[6]),
                new Aresta(vertices[6], vertices[7]),
                new Aresta(vertices[7], vertices[4]),

                //conexões frente | fundo
                new Aresta(vertices[0], vertices[4]),
                new Aresta(vertices[1], vertices[5]),
                new Aresta(vertices[2], vertices[6]),
                new Aresta(vertices[3], vertices[7]),
            };

            cube = new Cube(vertices, arestas);

            this.Invalidate();

            timer.Interval = 24;
            timer.Tick += (s, eA) =>
            {

                if (autoRotation) 
                {
                    cube.AngleX++;
                    cube.AngleY++;
                }
                else 
                {
                    if (input_x == -1)
                        cube.AngleY--;
                    else if (input_x == 1)
                        cube.AngleY++;

                    if (input_y == -1)
                        cube.AngleX--;
                    else if (input_y == 1)
                        cube.AngleX++;
                }

                this.Invalidate();
            };

            timer.Start();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Down)
                input_y = 1;

            else if (e.KeyCode == Keys.Up)
                input_y = -1;

            if (e.KeyCode == Keys.Left)
                input_x = -1;
            else if (e.KeyCode == Keys.Right)
                input_x = 1;

            if (e.KeyCode == Keys.Space)
                autoRotation = !autoRotation;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
                input_y = 0;

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                input_x = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (var pen = new Pen(Color.Green, 2))
            {
                PointF[] screenPoints = new PointF[cube.Vertices.Length];

                for (int i = 0; i < cube.Vertices.Length; i++) 
                {
                    float[] rotated = cube.Vertices[i].GetRotatedXY(cube.AngleX, cube.AngleY);

                    float x = rotated[0];
                    float y = rotated[1];
                    float z = rotated[2] + offsetZ;

                    if (z <= 0)
                        z = 0.1f;

                    screenPoints[i] = new PointF(
                        (x/z) * zoom + this.ClientSize.Width / 2,
                        (y/z) * zoom + this.ClientSize.Height / 2
                        );
                }

                foreach(var aresta in cube.Arestas) 
                {
                    int indexA = Array.IndexOf(cube.Vertices, aresta.VerticeA);
                    int indexB = Array.IndexOf(cube.Vertices, aresta.VerticeB);

                    e.Graphics.DrawLine(pen, screenPoints[indexA], screenPoints[indexB]);
                }
            }
        }
    }

    public class Vertice
    {
        public float[] Position;

        public Vertice(float x, float y, float z) 
        {
            Position = new float[3] { x, y, z };
        }
         
        public float[] GetRotatedXY(float angleX, float angleY) 
        {
            float radX = (float)(angleX * Math.PI / 180); 
            float radY = (float)(angleY * Math.PI / 180);

            //y axys
            float x1 = (float)(Position[0] * Math.Cos(radY) - Position[2] * Math.Sin(radY));
            float y1 = Position[1];
            float z1 = (float)(Position[0] * Math.Sin(radY) + Position[2] * Math.Cos(radY));

            //x axys
            float x2 = x1;
            float y2 = (float)(y1 * Math.Cos(radX) - z1 * Math.Sin(radX));
            float z2 = (float)(y1 * Math.Sin(radX) + z1 * Math.Cos(radX));

            return new float[3] { x2, y2, z2 };
        }
    }

    public class Aresta
    {
        public Vertice VerticeA;
        public Vertice VerticeB;

        public Aresta(Vertice a, Vertice b) 
        {
            VerticeA = a;
            VerticeB = b;
        }
    }

    public class Cube
    {
        public Vertice[] Vertices;
        public Aresta[] Arestas;

        public float AngleX = 0;
        public float AngleY = 0;

        public Cube(Vertice[] vertices, Aresta[] arestas)
        {
            Vertices = vertices;
            Arestas = arestas;
        }
    }
}