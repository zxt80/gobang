using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gobang
{
    class Chessman
    {
        public int X { set; get; }
        public int Y { set; get; }
        public TYPE Type { set; get; }

        public int Radius { set; get; }

        public Point DrawPoint{ set; get; }

        public Chessman(Point pt,Chessboard board) {
            X = pt.X;
            Y = pt.Y;
            Radius = board.GridWidth / 2 - 4;
            DrawPoint = new Point(board.OriginX + X * board.GridWidth,board.OriginY+board.GridWidth*Y);
        }

        public enum TYPE
        {
            NONE,
            WHITE,
            BLACK
        }

        public void Draw(Graphics g)
        {
            DrawChess(g, DrawPoint.X, DrawPoint.Y, Radius, Type== TYPE.WHITE ? Color.White:Color.Black);
        }

        public void DrawFlag(Graphics g)
        {
            Pen pn = new Pen(Color.Red);
            pn.Width = 2;

            Point p1 = new Point(DrawPoint.X - Radius / 2, DrawPoint.Y);
            Point p2 = new Point(DrawPoint.X + Radius / 2, DrawPoint.Y);

            Point p3 = new Point(DrawPoint.X, DrawPoint.Y - Radius / 2);
            Point p4 = new Point(DrawPoint.X, DrawPoint.Y + Radius / 2);
            g.DrawLine(pn, p1, p2);
            g.DrawLine(pn, p3, p4);
            pn.Dispose();

        }

        private void DrawChess(Graphics g, int x, int y, int r, Color c)
        {
            SolidBrush redBrush = new SolidBrush(c);
            Rectangle rect = new Rectangle(x - r, y - r, r * 2, r * 2);
            g.FillEllipse(redBrush, rect);
            redBrush.Dispose();
        }
    }
}
