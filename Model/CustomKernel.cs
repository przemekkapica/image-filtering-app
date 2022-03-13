using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image_filtering_app
{
    public struct CustomKernel
    {
        public double[,] kernel;
        public int divisor;

        public int offset;
        public Point anchor;

        public CustomKernel(double[,] kernel, int div, int off, Point anch)
        {
            this.kernel = kernel;
            divisor = div;
            offset = off;
            anchor = anch;
        }

        public double[,] GetKernel()
        {
            double[,] kernelCopy = new double[kernel.GetLength(0), kernel.GetLength(1)];
            for (int i = 0; i < kernel.GetLength(0); i++)
                for (int j = 0; j < kernel.GetLength(1); j++)
                    kernelCopy[i, j] = kernel[i, j] / divisor;
            return kernelCopy;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Kernel with following values:\n");
            foreach (int i in kernel)
            {
                sb.Append(i);
                sb.Append(", ");
            }
            sb.Append("\n");
            sb.Append(divisor);
            sb.Append("\n");
            sb.Append(offset);
            sb.Append("\n");
            sb.Append(anchor.ToString());
            return sb.ToString();
        }
    }
}
