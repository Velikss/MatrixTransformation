using System;
using System.Text;

namespace MatrixTransformations
{
    public class Matrix
    {
        float[,] mat;
        int size;

        public Matrix(int size= 4)
        {
            this.mat = new float[size, size];
            this.size = size;
        }

        public Matrix(float m11, float m12, float m13, float m14,
                      float m21, float m22, float m23, float m24,
                      float m31 = 0, float m32 = 0, float m33 = 0, float m34 = 0,
                      float m41 = 0, float m42 = 0, float m43 = 0, float m44 = 0) : this(4)
        {
            mat[0, 0] = m11; mat[0, 1] = m12; mat[0, 2] = m13; mat[0, 3] = m14;
            mat[1, 0] = m21; mat[1, 1] = m22; mat[1, 2] = m23; mat[1, 3] = m24;
            mat[2, 0] = m31; mat[2, 1] = m32; mat[2, 2] = m33; mat[2, 3] = m34;
            mat[3, 0] = m41; mat[3, 1] = m42; mat[3, 2] = m43; mat[3, 3] = m44;
        }

        public Matrix(Vector v) : this(4)
        {
            mat[0, 0] = v.x; mat[0, 1] = 0; mat[0, 2] = 0; mat[0, 3] = 0;
            mat[1, 0] = v.y; mat[1, 1] = 0; mat[1, 2] = 0; mat[1, 3] = 0;
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.size != m2.size) 
                throw new NotSupportedException("Matrixes not compatible");

            Matrix n = new Matrix(m1.size);
            for (int i = 0; i < n.size; i++)
                for (int j = 0; j < n.size; j++)
                    n.mat[i, j] = m1.mat[i, j] + m2.mat[i, j];
            return n;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1.size != m2.size)
                throw new NotSupportedException("Matrixes not compatible");

            Matrix n = new Matrix(m1.size);
            for (int i = 0; i < n.size; i++)
                for (int j = 0; j < n.size; j++)
                    n.mat[i, j] = m1.mat[i, j] - m2.mat[i, j];
            return n; 
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

        public static Matrix TranslationMatrix(Vector v)
        {
            var translator = Identity();
            translator.mat[0, 2] = v.x;
            translator.mat[1, 2] = v.y;
            translator.mat[2, 2] = v.w;
            translator.mat[3, 2] = v.z;
            return translator;
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
