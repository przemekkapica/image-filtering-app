using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace image_filtering_app
{
    public static class Kernel
    {
        public static Dictionary<string, CustomKernel> customKernels = new Dictionary<string, CustomKernel>();

        public static CustomKernel SharpenKernel = new CustomKernel(new double[3, 3] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } }, 1, 0, Point.Empty);
        public static CustomKernel OutlineKernel = new CustomKernel(new double[3, 3] { { -1, -1, -1 }, { -1, 8, -1 }, { -1, -1, -1 } }, 1, 0, Point.Empty);
        public static CustomKernel EmbossKernel = new CustomKernel(new double[3, 3] { { -2, -1, 0 }, { -1, 1, 1 }, { 0, 1, 2 } }, 1, 0, Point.Empty);
        public static CustomKernel BoxBlurKernel = new CustomKernel(new double[3, 3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } }, 9, 0, Point.Empty);
        public static CustomKernel GaussianBlurKernel = new CustomKernel(new double[3, 3] { { 1, 2, 1 }, { 2, 4, 2 }, { 1, 2, 1 } }, 16, 0, Point.Empty);
    }
}
