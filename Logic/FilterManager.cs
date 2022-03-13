﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace image_filtering_app
{
    static class FilterManager
    {
        public static Dictionary<string, Func<Bitmap, Bitmap>> filtersForToolStrip = new Dictionary<string, Func<Bitmap, Bitmap>> {
            { "Functional filters",     null }, // label
            { "Inversion",              (bmp) => bmp.ApplyFilter(InversionFilter) },
            { "Brightness Correction",  (bmp) => bmp.ApplyFilter(BrightnessFilter) },
            { "Contrast Enhancement",   (bmp) => bmp.ApplyFilter(ContrastFilter) },
            { "Gamma Correction",       (bmp) => bmp.ApplyFilter(GammaFilter)},

            { "Convolutional filters",  null }, // label
            { "Box Blur",               (bmp) => bmp.ApplyFilter(KernelFilter, Kernel.BoxBlurKernel) },
            { "Gaussian Blur",          (bmp) => bmp.ApplyFilter(KernelFilter, Kernel.GaussianBlurKernel) },
            { "Sharpen",                (bmp) => bmp.ApplyFilter(KernelFilter, Kernel.SharpenKernel) },
            { "Outline",                (bmp) => bmp.ApplyFilter(KernelFilter, Kernel.OutlineKernel) },
            { "Emboss",                 (bmp) => bmp.ApplyFilter(KernelFilter, Kernel.EmbossKernel) },

            { "Custom filters",  null }, // label
        };

        public static void UpdateFilterMapping(string filter)
        {
            filtersForToolStrip.Add(
                filter,
                (bmp) => bmp.ApplyFilter(KernelFilter, Kernel.customKernels[filter])
            );
        }

        public static Bitmap RecreateFilterStateFromState(Bitmap originalImage, List<string> state)
        {
            foreach (string filter in state)
                originalImage = filtersForToolStrip[filter](originalImage);

            return originalImage;
        }

        // -------------- Functional Filters -------------- //

        static public byte[] InversionFilter(byte[] buffer)
        {
            byte[] result = new byte[buffer.Length];
            int inv = 0;
            for (int i = 0; i < buffer.Length; i++)
            {
                if ((i + 1) % 4 == 0)
                {
                    result[i] = buffer[i];
                    continue;
                }

                inv = FilterValues.inversionValue - buffer[i];
                result[i] = (byte)inv;
            }
            return result;
        }

        static public byte[] BrightnessFilter(byte[] buffer)
        {
            var brightness = FilterValues.brightnessValue;

            byte[] result = new byte[buffer.Length];

            for (int i = 0; i < buffer.Length; i++)
            {
                if ((i + 1) % 4 == 0)
                {
                    result[i] = buffer[i];
                    continue;
                }
                result[i] = (byte)(brightness > 0 ? Math.Min(buffer[i] + brightness, 255) : Math.Max(buffer[i] + brightness, 0));

            }

            return result;
        }
        static public byte[] ContrastFilter(byte[] buffer)
        {
            var correctionFactor = Math.Pow((100.0 + FilterValues.contrastValue) / 100.0, 2);

            byte[] result = new byte[buffer.Length];

            int cnt = 0, value;
            for (int i = 0; i < buffer.Length; i++)
            {
                if ((i + 1) % 4 == 0)
                {
                    result[i] = buffer[i];
                    continue;
                }

                value = (int)(((((buffer[i] / 255.0) - 0.5) * correctionFactor) + 0.5) * 255.0);
                cnt = (value < 0) ? 0 : (value > 255) ? 255 : value;
                result[i] = (byte)cnt;
            }
            return result;
        }

        static public byte[] GammaFilter(byte[] buffer)
        {
            var gamma = FilterValues.gammaValue;

            byte[] result = new byte[buffer.Length];

            for (int i = 0; i < buffer.Length; i++)
            {
                if ((i + 1) % 4 == 0)
                {
                    result[i] = buffer[i];
                    continue;
                }

                double range = (double)buffer[i] / 255;
                double correctionFactor = 1d * Math.Pow(range, gamma);
                result[i] = (byte)(correctionFactor * 255);

            }
            return result;
        }


        // -------------- Convultion Filters -------------- //

        static public byte[] KernelFilter(byte[] buffer, int stride, CustomKernel customKernel)
        {
            double[,] kernel = customKernel.GetKernel();
            byte[] result = new byte[buffer.Length];

            // 1D Bitmap byte data
            for (int i = 0; i < buffer.Length; i++)
            {
                if ((i + 1) % 4 == 0)
                {
                    result[i] = buffer[i];
                    continue;
                }

                double newByte = 0;
                bool ignorePixel = false;

                // Iterating through kernel columns
                int lowerColBound = -kernel.GetLength(0) / 2 - customKernel.anchor.X;
                int upperColBound = kernel.GetLength(0) / 2 - customKernel.anchor.X;
                for (int j = lowerColBound; j <= upperColBound; j++)
                {
                    if ((i + 4 * j < 0) || (i + 4 * j >= buffer.Length) || ignorePixel)
                    {
                        newByte = 0;
                        break;
                    }

                    // Iterating through kernel rows
                    int lowerRowBound = -kernel.GetLength(1) / 2 - customKernel.anchor.Y;
                    int upperRowBound = kernel.GetLength(1) / 2 - customKernel.anchor.Y;
                    for (int k = lowerRowBound; k <= upperRowBound; k++)
                    {
                        if ((i + 4 * j + k * stride < 0) || (i + 4 * j + k * stride >= buffer.Length))
                        {
                            ignorePixel = true;
                            break;
                        }

                        newByte += kernel[
                            j - lowerColBound,
                            k - lowerRowBound]
                            * buffer[i + 4 * j + k * stride]
                            + customKernel.offset;
                    }
                }

                result[i] = (byte)(newByte < 0 ? 0 : newByte > 255 ? 255 : newByte);
            }

            return result;
        }
    }
}