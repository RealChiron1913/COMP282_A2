using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP282A2
{
    class Circle
    {
        public Circle(float x, float y,Color color)
        {
            this.x = x; this.y = y; this.color = color;
        }
        public float x { get; set; }
        public float y { get; set; }
        public Color color { get; set; }
    }
}
