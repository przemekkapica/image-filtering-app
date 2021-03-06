using ImageFilteringApp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image_filtering_app
{

    [Serializable]
    class SymmetricMidPointLine : Shape
    {
        public Point? startPoint = null;
        public Point? endPoint = null;
        public int thickness;
        public Color backColor;

        Clipping clipper = null;

        public SymmetricMidPointLine(Color color, int thicc, Color backColor) : base(color)
        {
            thickness = thicc;
            shapeType = DrawingShape.LINE;
            supportsAA = true;
            this.backColor = backColor;
        }

        public SymmetricMidPointLine(Color color, int thicc) : base(color)
        {
            thickness = thicc;
            shapeType = DrawingShape.LINE;
            supportsAA = true;
        }

        public SymmetricMidPointLine(Color color, int thicc, Point start, Point end, Color backColor) : base(color)
        {
            thickness = thicc;
            shapeType = DrawingShape.LINE;
            startPoint = start;
            endPoint = end;
            this.backColor = backColor;
            supportsAA = true;
        }

        public SymmetricMidPointLine(Color color, int thicc, Point start, Point end) : base(color)
        {
            thickness = thicc;
            shapeType = DrawingShape.LINE;
            startPoint = start;
            endPoint = end;
            supportsAA = true;
        }

        public SymmetricMidPointLine(Color color, int thicc, Point start, Point end, Clipping clip) : base(color)
        {
            thickness = thicc;
            shapeType = DrawingShape.LINE;
            startPoint = start;
            endPoint = end;
            clipper = clip;
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

            return XiaolinWuAlgorithm(line.Start, line.End);
        }

        List<ColorPoint> SymmetricMidPointAlgorithm(Point start, Point end)
        {
            List<ColorPoint> points = new List<ColorPoint>();

            int slope = 0;
            if ((end.X - start.X) == 0)
            {
                slope = 10000000;
            }
            else
            {
                slope = Math.Abs((end.Y - start.Y) / (end.X - start.X));
            }

            int x = start.X;
            int x2 = end.X;
            int y = start.Y;
            int y2 = end.Y;

            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;

            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;

            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);

            if (longest <= shortest)
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }

            int numerator = longest >> 1;

            // slope > 1 means we are in the 2nd, 3rd, 6th, or 7th octant: flip the axes
            if (slope > 1)
            {
                if (start.Y > end.Y)
                {
                    (start, end) = (end, start);
                }

                int dx = end.X - start.X;
                int dy = end.Y - start.Y;
                Point delta = new Point(dx, dy);

                int dE = 2 * delta.X;
                int dNE = 2 * (delta.X - delta.Y);
                int dSE = 2 * (delta.X + delta.Y);
                Point f = start;
                Point b = end;

                // 3rd or 6th octant:
                if (start.X < end.X)
                {
                    Point fNE = new Point(1, 0);
                    var bNE = new Point(-fNE.X, -fNE.Y);

                    int d = 2 * delta.X - delta.Y;

                    do
                    {
                        fillDueGivenThickness(points, w, h, f, b);

                        f = new Point(f.X + 0, f.Y + 1);
                        b = new Point(b.X + 0, b.Y - 1);
                        if (d < 0)
                        {
                            d += dE;
                        }
                        else
                        {
                            d += dNE;
                            f = new Point(f.X + fNE.X, f.Y + fNE.Y);
                            b = new Point(b.X + bNE.X, b.Y + bNE.Y);
                        }
                    } while (f.Y <= b.Y);
                }
                else
                {
                    var fSE = new Point(-1, 0);
                    var bSE = new Point(-fSE.X, -fSE.Y);

                    int d = 2 * delta.X + delta.Y;

                    do
                    {
                        fillDueGivenThickness(points, w, h, f, b);

                        f = new Point(f.X + 0, f.Y + 1);
                        b = new Point(b.X + 0, b.Y - 1);
                        if (d < 0)
                        {
                            d += dSE;
                            f = new Point(f.X + fSE.X, f.Y + fSE.Y);
                            b = new Point(b.X + bSE.X, b.Y + bSE.Y);

                        }
                        else
                        {
                            d += dE;
                        }
                    } while (f.Y <= b.Y);
                }
            }
            else
            {
                if (start.X > end.X)
                {
                    (start, end) = (end, start);
                }
                int dx = end.X - start.X;
                int dy = end.Y - start.Y;
                Point delta = new Point(dx, dy);

                //const delta = end.sub(start);
                int dE = 2 * delta.Y;
                int dNE = 2 * (delta.Y - delta.X);
                int dSE = 2 * (delta.Y + delta.X);
                Point f = start;
                Point b = end;

                // 1st or 5th octant:
                if (start.Y < end.Y)
                {
                    var fNE = new Point(0, 1);
                    var bNE = new Point(-fNE.X, -fNE.Y);

                    int d = 2 * delta.Y - delta.X;

                    do
                    {
                        fillDueGivenThickness(points, w, h, f, b);

                        f = new Point(f.X + 1, f.Y + 0);
                        b = new Point(b.X + -1, b.Y + 0);

                        if (d < 0)
                        {
                            d += dE;
                        }
                        else
                        {
                            d += dNE;
                            f = new Point(f.X + fNE.X, f.Y + fNE.Y);
                            b = new Point(b.X + bNE.X, b.Y + bNE.Y);
                        }
                    } while (f.X <= b.X);
                }
                else
                {
                    var fSE = new Point(0, -1);
                    var bSE = new Point(-fSE.X, -fSE.Y);


                    int d = 2 * delta.Y + delta.X;

                    do
                    {
                        fillDueGivenThickness(points, w, h, f, b);

                        f = new Point(f.X + 1, f.Y + 0);
                        b = new Point(b.X + -1, b.Y + 0);

                        if (d < 0)
                        {
                            d += dSE;
                            f = new Point(f.X + fSE.X, f.Y + fSE.Y);
                            b = new Point(b.X + bSE.X, b.Y + bSE.Y);
                        }
                        else
                        {
                            d += dE;
                        }
                    } while (f.X <= b.X);
                }

                numerator += shortest;
                if (numerator >= longest)
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }

            return points;
        }

        private void fillDueGivenThickness(List<ColorPoint> points, int w, int h, Point f, Point b)
        {
            if (Math.Abs(h) > Math.Abs(w))
            {
                for (int j = 1; j < thickness; j++)
                {
                    points.Add(new ColorPoint(shapeColor, new Point(f.X - j, f.Y)));
                    points.Add(new ColorPoint(shapeColor, new Point(b.X - j, b.Y)));
                }
            }
            else if (Math.Abs(w) > Math.Abs(h))
            {
                for (int j = 1; j < thickness; j++)
                {
                    points.Add(new ColorPoint(shapeColor, new Point(f.X, f.Y - j)));
                    points.Add(new ColorPoint(shapeColor, new Point(b.X, b.Y - j)));
                }
            }
        }

        List<ColorPoint> XiaolinWuAlgorithm(Point start, Point end)
        {
            List<ColorPoint> points = new List<ColorPoint>();

            bool direction = Math.Abs(end.Y - start.Y) > Math.Abs(end.X - start.X);
            if (direction)//replace x and y
            {
                Point tmp = new Point(start.X, start.Y);
                Point tmp2 = new Point(end.X, end.Y);
                start = new Point(tmp.Y, tmp.X);
                end = new Point(tmp2.Y, tmp2.X);
            }
            if (start.X > end.X)//replace points
            {
                Point tmp = new Point(start.X, start.Y);
                Point tmp2 = new Point(end.X, end.Y);
                start = new Point(tmp2.X, tmp2.Y);
                end = new Point(tmp.X, tmp.Y);
            }
            double dx = end.X - start.X;
            double dy = end.Y - start.Y;
            double gradient = (double)((double)(dy) / (double)(dx));
            //first point
            int endX = round(start.X);
            double endY = start.Y + gradient * (endX - start.X);
            double gapX = rfPart(start.X + 0.5);
            int pxlX_1 = endX;
            int pxlY_1 = iPart(endY);
            if (direction)
            {
                Point a = new Point(pxlY_1, pxlX_1);
                ColorPoint b = new ColorPoint(shapeColor, new Point(pxlY_1, pxlX_1));
                points.Add(b);
                b = new ColorPoint(shapeColor, new Point(pxlY_1 + 1, pxlX_1));
                points.Add(b);
            }
            else
            {
                Point a = new Point(pxlX_1, pxlY_1);
                ColorPoint b = new ColorPoint(shapeColor, new Point(pxlX_1, pxlY_1));
                points.Add(b);
                b = new ColorPoint(shapeColor, new Point(pxlX_1, pxlY_1 + 1));
                points.Add(b);
            }
            double intery = endY + gradient;

            //second point
            endX = round(end.X);
            endY = end.Y + gradient * (endX - end.X);
            gapX = fPart(end.X + 0.5);
            int pxlX_2 = endX;
            int pxlY_2 = iPart(endY);
            if (direction)
            {
                Point a = new Point(pxlY_2, pxlX_2);
                ColorPoint b = new ColorPoint(shapeColor, new Point(pxlY_2, pxlX_2));
                points.Add(b);
                b = new ColorPoint(shapeColor, new Point(pxlY_2 + 1, pxlX_2));
                points.Add(b);
            }
            else
            {
                Point a = new Point(pxlX_2, pxlY_2);
                ColorPoint b = new ColorPoint(shapeColor, new Point(pxlX_2, pxlY_2));
                points.Add(b);
                b = new ColorPoint(shapeColor, new Point(pxlX_2, pxlY_2 + 1));
                points.Add(b);
            }

            //loop from all points
            for (double x = (pxlX_1 + 1); x <= (pxlX_2 - 1); x++)
            {
                if (direction)
                {
                    Point a = new Point(iPart(intery), (int)x);
                    ColorPoint b = new ColorPoint(shapeColor, new Point(iPart(intery), (int)x));
                    points.Add(b);
                    b = new ColorPoint(shapeColor, new Point(iPart(intery) + 1, (int)x));
                    points.Add(b);
                }
                else
                {
                    Point a = new Point((int)x, iPart(intery));
                    ColorPoint b = new ColorPoint(shapeColor, new Point((int)x, iPart(intery)));
                    points.Add(b);
                    b = new ColorPoint(shapeColor, new Point((int)x, iPart(intery) + 1));
                    points.Add(b);
                }
                intery += gradient;
            }

            return points;
        }

        // helper methods
        int iPart(double d)
        {
            return (int)d;
        }

        int round(double d)
        {
            return (int)(d + 0.50000);
        }

        double fPart(double d)
        {
            return (double)(d - (int)(d));
        }

        double rfPart(double d)
        {
            return (double)(1.00000 - (double)(d - (int)(d)));
        }

        public override void MovePoints(Point displacement)
        {
            startPoint = startPoint.Value + (Size)displacement;
            endPoint = endPoint.Value + (Size)displacement;
        }

        public override string howToDraw()
        {
            return "Point for the start and end of a line. Uses symmetric midpoint line algorithm.";
        }
    }
}
