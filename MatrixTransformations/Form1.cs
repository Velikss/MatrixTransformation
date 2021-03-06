﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MatrixTransformations
{
    public partial class Form1 : Form
    {
        // Axes
        AxisX x_axis;
        AxisY y_axis;

        // Objects
        Square square1, square2, square3;

        // Window dimensions
        const int WIDTH = 800;
        const int HEIGHT = 600;

        public Form1()
        {
            InitializeComponent();

            this.Width = WIDTH;
            this.Height = HEIGHT;
            this.DoubleBuffered = true;

            Vector v1 = new Vector();
            Console.WriteLine(v1);
            Vector v2 = new Vector(1, 2);
            Console.WriteLine(v2);
            Vector v3 = new Vector(2, 6);
            Console.WriteLine(v3);
            Vector v4 = v2 + v3;
            Console.WriteLine(v4); // 3, 8

            Matrix m1 = new Matrix();
            Console.WriteLine(m1); // 1, 0, 0, 1
            Matrix m2 = new Matrix(
                2, 4, 0, 0,
                -1, 3, 0, 0);
            Console.WriteLine(m2);
            Console.WriteLine(m1 + m2); // 3, 4, -1, 4
            Console.WriteLine(m1 - m2); // -1, -4, 1, -2
            Console.WriteLine(m2 * m2); // 0, 20, -5, 5

            Console.WriteLine(m2 * v3); // 28, 16

            // Define axes
            x_axis = new AxisX(200);
            y_axis = new AxisY(200);

            // Create object
            square1 = new Square(Color.Purple, 100);
            square2 = new Square(Color.Green, 50);
            square3 = new Square(Color.Blue, 100);
            
            Matrix scale = Matrix.ScaleMatrix(3.0f);

            for (int i = 0; i < square2.vb.Count; i++)
                square2.vb[i] = scale * square2.vb[i];
            
            Matrix rotated = Matrix.RotateMatrix(20);
            for (int i = 0; i < square3.vb.Count; i++)
                square3.vb[i] = rotated * square3.vb[i];

            
            var transv = new Vector(50, 150);
            var translator = Matrix.TranslationMatrix(transv);
            for (int i = 0; i < square1.vb.Count; i++)
                square1.vb[i] = translator * square1.vb[i];

            Console.WriteLine(square1);
            

        }

        public List<Vector> ViewportTransformation(List<Vector> s)
        {
            for (int i = 0; i < s.Count; i++)
                s[i] = new Vector(s[i].x + WIDTH / 2, s[i].y * -1 + HEIGHT / 2);

            return s;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw axes
            x_axis.Draw(e.Graphics, ViewportTransformation(x_axis.vb));
            y_axis.Draw(e.Graphics, ViewportTransformation(y_axis.vb));

            // Draw square
            square1.Draw(e.Graphics, ViewportTransformation(square1.vb));
            square2.Draw(e.Graphics, ViewportTransformation(square2.vb));
            square3.Draw(e.Graphics, ViewportTransformation(square3.vb));


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
