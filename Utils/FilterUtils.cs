using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilteringApp.Utils
{
    public static class FilterUtils
    {
        public static List<List<double>> GetSortedImageArray(List<List<double>> rgbaArray, string channel)
        {
            switch (channel)
            {
                case "R":
                    rgbaArray.Sort((rgba1, rgba2) => rgba1[0].CompareTo(rgba2[0]));
                    break;
                case "G":
                    rgbaArray.Sort((rgba1, rgba2) => rgba1[1].CompareTo(rgba2[1]));
                    break;
                case "B":
                    rgbaArray.Sort((rgba1, rgba2) => rgba1[2].CompareTo(rgba2[2]));
                    break;
            }

            return rgbaArray;
        }

        public static List<double> GetRgbRanges(List<List<double>> rgbaArray)
        {
            // returns ranges in rgb order
            double rMax = -1, gMax = -1, bMax = -1;
            double rMin = 256, gMin = 256, bMin = 256;

            for (int i = 0; i < rgbaArray.Count; i++)
            {
                double r = rgbaArray[i][0];
                double g = rgbaArray[i][1];
                double b = rgbaArray[i][2];

                rMax = Math.Max(rMax, r);
                gMax = Math.Max(gMax, g);
                bMax = Math.Max(bMax, b);

                rMin = Math.Min(rMin, r);
                gMin = Math.Min(gMin, g);
                bMin = Math.Min(bMin, b);
            }
            double rRange = rMax - rMin;
            double gRange = gMax - gMin;
            double bRange = bMax - gMin;

            List<double> ranges = new List<double>();
            ranges.Add(rRange);
            ranges.Add(gRange);
            ranges.Add(bRange);

            return ranges;
        }

        public static List<double> GetRgbMeanValues(List<List<double>> rgbaArray)
        {
            // returns rgb values in that order
            double rMean = 0, gMean = 0, bMean = 0;
            int length = rgbaArray.Count;

            for (int i = 0; i < length; i++)
            {
                int r = (int)rgbaArray[i][0];
                int g = (int)rgbaArray[i][1];
                int b = (int)rgbaArray[i][2];

                rMean += r;
                gMean += g;
                bMean += b;
            }

            rMean /= length;
            gMean /= length;
            bMean /= length;

            List<double> means = new List<double>();
            means.Add(rMean);
            means.Add(gMean);
            means.Add(bMean);

            return means;
        }

        public static List<List<double>> ConvertBGRAToRGBA(byte[] buffer, int width)
        {
            List<List<double>> rgbaImage = new List<List<double>>();

            int rowIndex = 0, colIndex = 0;

            for (int i = 0; i < buffer.Length; i += 4)
            {
                List<double> rgba = new List<double>();
                rgba.Add((double)buffer[i + 2]);
                rgba.Add((double)buffer[i + 1]);
                rgba.Add((double)buffer[i]);
                rgba.Add((double)buffer[i + 3]);
                rgba.Add(rowIndex);
                rgba.Add(colIndex);

                rgbaImage.Add(rgba);

                colIndex++;
                if (colIndex == width)
                {
                    colIndex = 0;
                    rowIndex++;
                }
            }
            return rgbaImage;
        }

        public static byte[] ConvertRGBAToBGRA(List<double>[,] source, int length, int width, int height)
        {
            byte[] result = new byte[length * 4];

            int k = 0;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    result[k++] = (byte)source[i, j][2];
                    result[k++] = (byte)source[i, j][1];
                    result[k++] = (byte)source[i, j][0];
                    result[k++] = (byte)source[i, j][3];
                }
            }

            return result;
        }

        public static List<List<double>> SplitList(List<List<double>> list, int start, int end)
        {
            List<List<double>> result = new List<List<double>>();
            for (int i = start; i < end; i++)
            {
                result.Add(list[i]);
            }
            return result;
        }
    }
}
