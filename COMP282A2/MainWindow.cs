using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace COMP282A2
{
    public partial class MainWindow : Form
    {
        Point point1 = new Point(0, 0);
        Point point2 = new Point(0, 0);
        Color color = Color.Black;
        Line line = new Line(new Point(0, 0), new Point(0, 0), Color.Black);
        List<Line> lines = new List<Line>();
        List<Line> ins_lines = new List<Line>();
        private bool isDrawing = false;
        List<Circle> circles = new List<Circle>();
        int num = 0;


        public MainWindow()
        {
            InitializeComponent();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void draw_line(Line line)// draw line
        {
            Graphics g = pictureBox_LEFT.CreateGraphics();
            Pen pen = new Pen(line.color);
            g.DrawLine(pen, line.point1, line.point2);
            //allLines.Add(line);
        }

        private void draw_circle(Circle circle)// draw circle
        {
            Graphics g = pictureBox_LEFT.CreateGraphics();
            Pen pen = new Pen(circle.color);
            g.DrawEllipse(pen, circle.x-10, circle.y-10, 20, 20);
            //circles.Add(circle);
        }
        private Line rowToLine (DataGridViewRow row)// convert row to line
        {
            Point point1 = new Point(Convert.ToInt32(row.Cells[0].Value), Convert.ToInt32(row.Cells[1].Value));
            Point point2 = new Point(Convert.ToInt32(row.Cells[2].Value), Convert.ToInt32(row.Cells[3].Value));
            Color color = row.Cells[4].Style.BackColor;
            return new Line(point1, point2, color);
        }
        private bool IsPointOnLine(Point point, Line line)// check if point is on line
        {
            double distance = Math.Abs(
                (line.point2.Y - line.point1.Y) * point.X
                - (line.point2.X - line.point1.X) * point.Y
                + line.point2.X * line.point1.Y
                - line.point2.Y * line.point1.X
            ) / Math.Sqrt(
                Math.Pow(line.point2.Y - line.point1.Y, 2)
                + Math.Pow(line.point2.X - line.point1.X, 2)
            );
            bool isPointOnLine = point.X <= Math.Max(line.point1.X, line.point2.X)
                && point.X >= Math.Min(line.point1.X, line.point2.X)
                && point.Y <= Math.Max(line.point1.Y, line.point2.Y)
                && point.Y >= Math.Min(line.point1.Y, line.point2.Y);
            return distance <= float.Epsilon && isPointOnLine;
        }

        private void find_intersection(Line line1,Line line2) // find intersection
        {
            
            float x1 = line1.point1.X;
            float y1 = line1.point1.Y;
            float x2 = line1.point2.X;
            float y2 = line1.point2.Y;
            float x3 = line2.point1.X;
            float y3 = line2.point1.Y;
            float x4 = line2.point2.X;
            float y4 = line2.point2.Y;

            float denom = (y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1);
            if (Math.Abs(denom) < float.Epsilon) // check if lines are parallel
            {
                if (IsPointOnLine(line1.point1, line2)) // check if point1 of line1 on line2
                {
                    if (IsPointOnLine(line1.point2, line2)) // check if point2 of line1 on line2
                    {
                        draw_line(line1); // draw line1 because line1 is on line2
                        ins_lines.Add(line1);
                    }
                    else if (IsPointOnLine(line2.point2, line1)) // check if point2 of line2 on line1
                    {
                        draw_line(new Line(line1.point1, line2.point2, color));// draw line from point1 of line1 to point2 of line2
                        ins_lines.Add(new Line(line1.point1, line2.point2, color));
                    }
                    else if (IsPointOnLine(line2.point1, line1)) // check if point1 of line2 on line1
                    {
                        draw_line(new Line(line1.point1, line2.point1, color));// draw line from point1 of line1 to point1 of line2
                        ins_lines.Add(new Line(line1.point1, line2.point1, color));
                    }
                }
                else if (IsPointOnLine(line2.point1, line1))
                {
                    if (IsPointOnLine(line2.point2, line1))
                    {
                        draw_line(line2);
                        ins_lines.Add(line2);
                    }
                    else if (IsPointOnLine(line1.point2, line2))
                    {
                        draw_line(new Line(line2.point1, line1.point2, color));
                        ins_lines.Add(new Line(line2.point1, line1.point2, color));
                    }
                    else if (IsPointOnLine(line1.point1, line2))
                    {
                        draw_line(new Line(line2.point1, line1.point1, color));
                        ins_lines.Add(new Line(line2.point1, line1.point1, color));
                    }
                }
            }
            else
            {
                float ua = ((x4 - x3) * (y1 - y3) - (y4 - y3) * (x1 - x3)) / denom;
                float ub = ((x2 - x1) * (y1 - y3) - (y2 - y1) * (x1 - x3)) / denom;

                float x = x1 + ua * (x2 - x1);
                float y = y1 + ua * (y2 - y1);

                bool xonline1 = x >= Math.Min(line1.point1.X, line1.point2.X) && x <= Math.Max(line1.point1.X, line1.point2.X);
                bool yonline1 = y >= Math.Min(line1.point1.Y, line1.point2.Y) && y <= Math.Max(line1.point1.Y, line1.point2.Y);
                bool xonline2 = x >= Math.Min(line2.point1.X, line2.point2.X) && x <= Math.Max(line2.point1.X, line2.point2.X);
                bool yonline2 = y >= Math.Min(line2.point1.Y, line2.point2.Y) && y <= Math.Max(line2.point1.Y, line2.point2.Y);


                if (xonline1 && yonline1 && xonline2 && yonline2)// check if intersection is on both lines
                 {

                    draw_circle(new Circle(x,y,color));
                    circles.Add(new Circle(x,y,color));
                }
            }
        }
        private void delete_line(Line line)
        {
            pictureBox_LEFT.Refresh();
            foreach (Line l in lines)
            {
                if (l != line && l != null)
                {
                    draw_line(l);
                }
            }
            foreach (Circle c in circles)
            {
                draw_circle(c);
            }
            foreach (Line l in ins_lines)
            {
                draw_line(l);
            }
        }
        private void button_color_Click(object sender, EventArgs e)
        {
            colorDialog1= new ColorDialog();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            color = colorDialog1.Color;
            button_color.ForeColor = colorDialog1.Color;
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0 && dataGridView1.SelectedCells[0].RowIndex< num)
            {
                try { 
                    int index = dataGridView1.SelectedCells[0].RowIndex;
                    //line = rowToLine(dataGridView1.Rows[index]);
                    dataGridView1.Rows.RemoveAt(index);
                    delete_line(lines[index]);

                    //delete_line(line);
                    lines.RemoveAt(index);
                    num--;
                }
                catch (Exception)
                {
                    MessageBox.Show("No line selected!");
                }
                
            }
            
            else
            {
                MessageBox.Show("No line selected!");
            }
            //Console.WriteLine(num);
        }

        private void button_find_intersection_Click(object sender, EventArgs e)
        {
            pictureBox_LEFT.Refresh();
            circles.Clear();
            ins_lines.Clear();
            foreach (Line l in lines)
            {
                if (l != null)
                {
                    draw_line(l);
                }
            }
            if(lines.Count>1)
            {
                for(int i=0;i<lines.Count-1;i++)
                {
                    for(int j=i+1;j<lines.Count;j++)
                    {
                        if (lines[i] != null && lines[j] != null)
                        find_intersection(lines[i], lines[j]);
                    }
                }
            }
            //else
            //{
            //    MessageBox.Show("Please add at least two lines to find intersection");
            //}
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {     
            List<Line> newlines = new List<Line>();
            newlines=lines;
            //lines.Clear();
            pictureBox_LEFT.Refresh();
            bool b = false;
            foreach(Line l in lines)
            {
                if (l != null)
                {
                    draw_line(l);
                }
            }
            foreach (Circle c in circles)
            {
                draw_circle(c);
            }
            foreach (Line l in ins_lines)
            {
                draw_line(l);
            }
            num = 0;
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                
                int x1, y1, x2, y2;
                bool b1 = int.TryParse(Convert.ToString(row.Cells[0].Value), out x1);
                bool b2 = int.TryParse(Convert.ToString(row.Cells[1].Value), out y1);
                bool b3 = int.TryParse(Convert.ToString(row.Cells[2].Value), out x2);
                bool b4 = int.TryParse(Convert.ToString(row.Cells[3].Value), out y2);
                bool n1 = row.Cells[0].Value == null;
                bool n2 = row.Cells[1].Value == null;
                bool n3 = row.Cells[2].Value == null;
                bool n4 = row.Cells[3].Value == null;
                int index = dataGridView1.Rows.IndexOf(row);
                //Console.WriteLine(index);
                //Console.WriteLine(newlines[index]);
                //Console.WriteLine("index:"+index);
                //lines.Add(null);
                if (num == dataGridView1.RowCount - 2)
                    lines.Add(null);

                if (b1 && b2 && b3 && b4)
                {
                    lines[index] = rowToLine(row);
                    delete_line(lines[index]);
                    draw_line(lines[index]);
                    num++;
                }
                else if (!((b1 || n1) && (b2 || n2) && (b3 || n3) && (b4 || n4)))
                {
                    b = true;
                    //Console.WriteLine("here");
                    //Console.WriteLine(newlines[index].ToString());
                    //if (newlines[index]!=null) draw_line(newlines[index]);

                }
                else if ((b1 && !b2 && !b3 && !b4) ||
                            (!b1 && b2 && !b3 && !b4) ||
                            (!b1 && !b2 && b3 && !b4) ||
                            (!b1 && !b2 && !b3 && b4))
                {
                    if (index==dataGridView1.RowCount-2)
                        row.Cells[4].Style.BackColor = color;
                 num++;
                    
                }
 
                else if (b1 || b2 || b3 || b4)
                {
                    num++;
                }
            }
            if (b) MessageBox.Show("Some of the number fields do not contain interages");

            //Console.WriteLine("num:" + num);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.SelectedCells.Count>0)
            {

                if (dataGridView1.SelectedCells[0].ColumnIndex == 4 && dataGridView1.SelectedCells[0].RowIndex<num)
                {
                    int index = dataGridView1.SelectedCells[0].RowIndex;

                    if (colorDialog1.ShowDialog() == DialogResult.OK)
                        dataGridView1.Rows[index].Cells[4].Style.BackColor = colorDialog1.Color;
                    if (lines[index] != null)
                    {
                        lines[index].color = colorDialog1.Color;
                        delete_line(lines[index]);
                        draw_line(lines[index]);
                    }
                }
                else if (dataGridView1.SelectedCells[0].ColumnIndex == 4 && dataGridView1.SelectedCells[0].RowIndex > lines.Count)
                {
                    MessageBox.Show("Please add the line first");
                }


            }
            
        }
        private void pictureBox_LEFT_mousedown(object sender, MouseEventArgs e)
        {
            point1 = e.Location;
            isDrawing = true;
        }
        private void pictureBox_LEFT_mouseup(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                point2 = e.Location;
                line = new Line(point1, point2, color);
                //if (dataGridView1.Rows.Count - 2>=0)
                //{
                //    DataGridViewRow row = dataGridView1.Rows[dataGridView1.Rows.Count - 2];
                //    int x1, y1, x2, y2;
                //    bool b1 = int.TryParse(Convert.ToString(row.Cells[0].Value), out x1);
                //    bool b2 = int.TryParse(Convert.ToString(row.Cells[1].Value), out y1);
                //    bool b3 = int.TryParse(Convert.ToString(row.Cells[2].Value), out x2);
                //    bool b4 = int.TryParse(Convert.ToString(row.Cells[3].Value), out y2);
                //    if (!(b1 || b2 || b3 || b4))
                //        row.Cells[4].Style.BackColor = color;
                //}

                dataGridView1.Rows.Add(point1.X.ToString(), point1.Y.ToString(), point2.X.ToString(), point2.Y.ToString());
                dataGridView1.Rows[dataGridView1.Rows.Count - 2].Cells[4].Style.BackColor = color;
                lines.Add(null);
                num++;
                lines[num-1]=line;
                draw_line(line);
                isDrawing = false;

                //Console.WriteLine("num:"+num) ;

                List<Line> newlines = new List<Line>();
                newlines = lines;
                //lines.Clear();
                pictureBox_LEFT.Refresh();
                bool b = false;
                foreach (Line l in lines)
                {
                    if (l != null)
                    {
                        draw_line(l);
                    }
                }
                foreach (Circle c in circles)
                {
                    draw_circle(c);
                }
                foreach (Line l in ins_lines)
                {
                    draw_line(l);
                }
                num = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    int x1, y1, x2, y2;
                    bool b1 = int.TryParse(Convert.ToString(row.Cells[0].Value), out x1);
                    bool b2 = int.TryParse(Convert.ToString(row.Cells[1].Value), out y1);
                    bool b3 = int.TryParse(Convert.ToString(row.Cells[2].Value), out x2);
                    bool b4 = int.TryParse(Convert.ToString(row.Cells[3].Value), out y2);
                    bool n1 = row.Cells[0].Value == null;
                    bool n2 = row.Cells[1].Value == null;
                    bool n3 = row.Cells[2].Value == null;
                    bool n4 = row.Cells[3].Value == null;
                    int index = dataGridView1.Rows.IndexOf(row);
                    //Console.WriteLine(index);
                    //Console.WriteLine(newlines[index]);
                    //Console.WriteLine("index:"+index);
                    //lines.Add(null);
                    if (num == dataGridView1.RowCount - 2)
                        lines.Add(null);

                    if (b1 && b2 && b3 && b4)
                    {
                        lines[index] = rowToLine(row);
                        delete_line(lines[index]);
                        draw_line(lines[index]);
                        num++;
                    }
                    else if (!((b1 || n1) && (b2 || n2) && (b3 || n3) && (b4 || n4)))
                    {
                        b = true;
                        //Console.WriteLine("here");
                        //Console.WriteLine(newlines[index].ToString());
                        //if (newlines[index]!=null) draw_line(newlines[index]);

                    }
                    else if ((b1 && !b2 && !b3 && !b4) ||
                                (!b1 && b2 && !b3 && !b4) ||
                                (!b1 && !b2 && b3 && !b4) ||
                                (!b1 && !b2 && !b3 && b4))
                    {
                        if (index == dataGridView1.RowCount - 2)
                            row.Cells[4].Style.BackColor = color;
                        num++;

                    }

                    else if (b1 || b2 || b3 || b4)
                    {
                        num++;
                    }
                }
                if (b) MessageBox.Show("Some of the number fields do not contain interages");

                //Console.WriteLine("num:" + num);
            }
        }
    }
}
