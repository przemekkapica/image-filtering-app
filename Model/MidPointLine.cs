using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image_filtering_app
{

    public struct Line
    {
        public Point Start;
        public Point End;

        public Line(Point s, Point e)
        {
            End = e;
            Start = s;
        }

        public override string ToString()
        {
            return $"{Start.ToString()} && {End.ToString()}";
        }
    }

    [Serializable]
    class MidPointLine : Shape
    {
        public Point? startPoint = null;
        public Point? endPoint = null;
        public int thickness;
        public Color backColor;

        public MidPointLine(Color color, int thicc, Color backColor) : base(color)
        {
            thickness = thicc - 1;
            shapeType = DrawingShape.LINE;
            supportsAA = true;
            this.backColor = backColor;
        }

        public MidPointLine(Color color, int thicc) : base(color)
        {
            thickness = thicc - 1;
            shapeType = DrawingShape.LINE;
            supportsAA = true;
        }

        public MidPointLine(Color color, int thicc, Point start, Point end, Color backColor) : base(color)
        {
            thickness = thicc - 1;
            shapeType = DrawingShape.LINE;
            startPoint = start;
            endPoint = end;
            this.backColor = backColor;
            supportsAA = true;
        }

        public MidPointLine(Color color, int thicc, Point start, Point end) : base(color)
        {
            thickness = thicc - 1;
            shapeType = DrawingShape.LINE;
            startPoint = start;
            endPoint = end;
            supportsAA = true;
        }


        public override string ToString()
        {
            return "Line";
        }

        public override int AddPoint(Point point)
        {
            if (startPoint == null)
                startPoint = point;
            else if (endPoint == null)
            {
                endPoint = point;
                return 1;
            }
            return 0;
        }

        public override List<ColorPoint> GetPixels(params object[] param)
        {
            Line line = new Line(startPoint.Value, endPoint.Value);

            return SymmetricMidPointAlgorithm(line.Start, line.End);
        }

        public override List<ColorPoint> GetPixelsAA(Bitmap bmp)
        {
            Line line = new Line(startPoint.Value, endPoint.Value);

            return GuptaSproullAlgorithm(bmp, line.Start, line.End);
        }

        List<ColorPoint> SymmetricMidPointAlgorithm(Point start, Point end)
        // https://stackoverflow.com/questions/11678693/all-cases-covered-bresenhams-line-algorithm
        {
            List<ColorPoint> points = new List<ColorPoint>();

            int x1 = start.X, y1 = start.Y;
            int x2 = end.X, y2 = end.Y;

            int dx = x2 - x1;
            int dy = y2 - y1;
            int d = 2 * dy - dx;
            int dE = 2 * dy;
            int dNE = 2 * (dy - dx);
            int xf = x1, yf = y1;
            int xb = x2, yb = y2;
            points.Add( new ColorPoint(shapeColor, new Point(xf, yf)));
            points.Add(new ColorPoint(shapeColor, new Point(xb, yb)));
            while (xf < xb)
            {
                ++xf; --xb;
                if (d < 0)
                    d += dE;
                else
                {
                    d += dNE;
                    ++yf;
                    --yb;
                }
                points.Add(new ColorPoint(shapeColor, new Point(xf, yf)));
                points.Add(new ColorPoint(shapeColor, new Point(xb, yb)));
            }

            return points;
        }

        List<ColorPoint> GuptaSproullAlgorithm(Bitmap bmp, Point start, Point end)
        // http://elynxsdk.free.fr/ext-docs/Rasterization/Antialiasing/Gupta%20sproull%20antialiased%20lines.htm
        // https://jamesarich.weebly.com/uploads/1/4/0/3/14035069/480xprojectreport.pdf
        {
            var points = new List<ColorPoint>();

            int x1 = start.X, y1 = start.Y;
            int x2 = end.X, y2 = end.Y;

            int dx = x2 - x1;
            int dy = y2 - y1;

            int du, dv, u, x, y, ix, iy;

            // By switching to (u,v), we combine all eight octant
            int adx = dx < 0 ? -dx : dx;
            int ady = dy < 0 ? -dy : dy;
            x = x1;
            y = y1;
            if (adx > ady)
            {
                du = adx;
                dv = ady;
                u = x2;
                ix = dx < 0 ? -1 : 1;
                iy = dy < 0 ? -1 : 1;
            }
            else
            {
                du = ady;
                dv = adx;
                u = y2;
                ix = dx < 0 ? -1 : 1;
                iy = dy < 0 ? -1 : 1;
            }

            int uEnd = u + du;
            int d = (2 * dv) - du; // Initial value as in Bresenham's
            int incrS = 2 * dv; // Δd for straight increments
            int incrD = 2 * (dv - du); // Δd for diagonal increments
            int twovdu = 0; // Numerator of distance
            double invD = 1.0 / (2.0 * Math.Sqrt(du * du + dv * dv)); // Precomputed inverse denominator
            double invD2du = 2.0 * (du * invD); // Precomputed constant

            if (adx > ady)
            {
                do
                {
                    points.Add(newColorPixel(bmp, x, y, twovdu * invD));
                    points.Add(newColorPixel(bmp, x, y + iy, invD2du - twovdu * invD));
                    points.Add(newColorPixel(bmp, x, y - iy, invD2du + twovdu * invD));


                    if (d < 0)
                    {
                        // Choose straight
                        twovdu = d + du;
                        d += incrS;

                    }
                    else
                    {
                        // Choose diagonal
                        twovdu = d - du;
                        d += incrD;
                        y += iy;
                    }
                    u++;
                    x += ix;
                } while (u < uEnd);
            }
            else
            {
                do
                {
                    points.Add(newColorPixel(bmp, x, y, twovdu * invD));
                    points.Add(newColorPixel(bmp, x, y + iy, invD2du - twovdu * invD));
                    points.Add(newColorPixel(bmp, x, y - iy, invD2du + twovdu * invD));

                    if (d < 0)
                    {
                        // Choose straight
                        twovdu = d + du;
                        d += incrS;
                    }
                    else
                    {
                        // Choose diagonal
                        twovdu = d - du;
                        d += incrD;
                        x += ix;
                    }
                    u++;
                    y += iy;
                } while (u < uEnd);
            }

            return points;
        }

        ColorPoint newColorPixel(Bitmap bmp, int x, int y, double dist)
        {
            double value = 1 - Math.Pow((dist * 2 / 3), 2);

            Color old = bmp.GetPixelFast(x, y);
            Color col = ColorInterpolator.InterpolateBetween(old, shapeColor, value);

            return new ColorPoint(col, new Point(x, y));
        }

        public override void MovePoints(Point displacement)
        {
            startPoint = startPoint.Value + (Size)displacement;
            endPoint = endPoint.Value + (Size)displacement;
        }

        public override string howToDraw()
        {
            return "Click start and end points";
        }
    }
}
