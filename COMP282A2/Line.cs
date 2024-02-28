using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP282A2
{
    class Line
    {     

        public
            Line(Point point1, Point point2, Color color)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.color = color;
        }
        public Point point1 { get; set; }
        public Point point2 { get; set; }
        public Color color { get; set; }
    
  
        public override string ToString()
        {
            return string.Format("First point: {0}\n Second point: {1}\n Color: {2}", this.point1, this.point2, this.color);
        }

        
    }
}




