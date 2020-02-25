using System;
using System.Text;

namespace MatrixTransformations
{
    public class Matrix
    {
        float[,] mat = new float[2, 2];

        public Matrix()
        {
            mat[0, 0] = 1; mat[0, 1] = 0;
            mat[1, 0] = 0; mat[1, 1] = 1;
        }
        public Matrix(float m11, float m12,
                      float m21, float m22)
        {
            mat[0, 0] = m11; mat[0, 1] = m12;
            mat[1, 0] = m21; mat[1, 1] = m22;
        }

        public Matrix(Vector v)
        {
            mat[0, 0] = v.x; mat[0, 1] = 0;
            mat[1, 0] = v.y; mat[1, 1] = 0;
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            return new Matrix(
                m1.mat[0, 0] + m2.mat[0, 0],
                m1.mat[1, 0] + m2.mat[1, 0],
                m1.mat[0, 1] + m2.mat[0, 1],
                m1.mat[1, 1] + m2.mat[1, 1]);
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            return new Matrix(
                            m1.mat[0, 0] - m2.mat[0, 0],
                            m1.mat[1, 0] - m2.mat[1, 0],
                            m1.mat[0, 1] - m2.mat[0, 1],
                            m1.mat[1, 1] - m2.mat[1, 1]);
        }
        public static Matrix operator *(Matrix m1, float f)
        {
            Matrix m = new Matrix();

            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    m.mat[i, j] = m1.mat[i, j] * f;

            return m;
        }

        public static Matrix operator *(float f, Matrix m1)
        {
            return m1 * f;
        }
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            Matrix m = new Matrix();

            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    m.mat[i, j] = 0;

                    for (int k = 0; k < 2; k++)
                    {
                        m.mat[i, j] += m1.mat[i, k] * m2.mat[k, j];
                    }
                }

            return m;
        }

        public static Vector operator *(Matrix m1, Vector v)
        {
            Matrix mv = new Matrix(v);
            mv = m1 * mv;

            return new Vector(mv.mat[0, 0], mv.mat[1, 0]);
        }

        public static Matrix ScaleMatrix(float s)
        {
            return Identity() * s;
        }

        public static Matrix RotateMatrix(float degrees)
        {
            double radians = Math.PI * degrees / 180.0;

            var rotationmatrix = new Matrix();

            rotationmatrix.mat[0, 0] = (float)Math.Cos(radians);
            rotationmatrix.mat[0, 1] = -1 * (float)Math.Sin(radians);
            rotationmatrix.mat[1, 0] = (float)Math.Sin(radians);
            rotationmatrix.mat[1, 1] = (float)Math.Cos(radians);

            return rotationmatrix;
        }

        public static Matrix Identity()
        {
            return new Matrix();
        }

        public override string ToString()
        {
            return "Tostring not implemented"; 
        }
    }
}
