using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageFilteringApp.Model
{
    public class Line
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
}
