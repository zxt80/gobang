using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gobang
{
    class ChessBoard
    {
        // 棋盘距离窗口的边界
        public int Margin { set; get; }

        // 棋盘尺寸 13，15，17 等奇数
        private int size;
        public int GrideSize { set; get; }
        private int chessRadius;
        private Color gridColor;
        private Color backGroundColor;

        // 先手棋子颜色
        public Color FristColor { set; get; }

        // 棋盘中的棋子
        public ChessType[,] ChessMap { set; get; }

        // 最后一次落子位置
        private Point LastChessPoint = new Point(-1, -1);


        // 棋子数量
        public int chessCount = 0;

        // 获胜棋子位置
        List<Point> winPoint;

        // 当前选择点的位置
        public Point SelectPoint { set; get; }

        // 是否在棋盘中选择了点
        public bool bSelectPoint { set; get; }
        public int Size
        {
            set
            {
                if(value%2!=0)
                {
                    size = value;
                    ChessMap = new ChessType[size, size];
                }
            }
            get 
            {
                return size;
            } 
        }

        public ChessBoard()
        {
            Init();
        }

        private void Init()
        {
            Margin = 30;
            GrideSize = 40;
            chessRadius = 15;
            gridColor = Color.Gray;
            backGroundColor = Color.FromArgb(255, 224, 224, 224);

            FristColor = Color.Black;

            winPoint = new List<Point>();
            bSelectPoint = false;
        }

        public void Rest()
        {
            winPoint.Clear();
            LastChessPoint.X = -1;
            LastChessPoint.Y = -1;
            bSelectPoint = false;
            chessCount = 0;

            for(int i=0;i<size;i++)
            {
                for(int j=0;j<size;j++)
                {
                    ChessMap[i, j] = ChessType.NONE;
                }
            }

        }

        // 落子 
        // pt:棋子在棋盘中的位置
        public bool DownChess(Point pt,ChessType type)
        {
            if (pt.X < 0 || pt.Y < 0 || pt.X >= size || pt.Y >= size)
                return false;
            if(ChessMap[pt.X,pt.Y] == ChessType.NONE)
            {
                ChessMap[pt.X, pt.Y] = type;
                chessCount++;

                LastChessPoint = pt;
                return true;
            }
            return false;
        }

        // 比赛是否获胜
        public ChessType IsGameOver()
        {
            if (chessCount < 9)
                return ChessType.NONE;

            winPoint.Add(LastChessPoint);

            ChessType type = chessCount % 2 == 0 ? ChessType.SECOND : ChessType.FRIST;

            // 横
            for (int i = LastChessPoint.X - 1; i >= 0; i--)
            {
                if (ChessMap[i, LastChessPoint.Y] == type)
                {
                    winPoint.Add(new Point(i, LastChessPoint.Y));
                }
                else
                {
                    break;
                }
            }

            for (int i = LastChessPoint.X + 1; i < size; i++)
            {
                if (ChessMap[i, LastChessPoint.Y] == type)
                {
                    winPoint.Add(new Point(i, LastChessPoint.Y));
                }
                else
                {
                    break;
                }
            }
            if (winPoint.Count >= 5)
            {
                return type;
            }
            else
            {
                winPoint.Clear();
                winPoint.Add(LastChessPoint);
            }
            

            // 竖            
            for (int i = LastChessPoint.Y - 1; i >= 0; i--)
            {
                if (ChessMap[LastChessPoint.X, i] == type)
                {
                    winPoint.Add( new Point(LastChessPoint.X, i));
                }
                else
                {
                    break;
                }
            }

            for (int i = LastChessPoint.Y + 1; i < size; i++)
            {
                if (ChessMap[LastChessPoint.X, i] == type)
                {
                    winPoint.Add(new Point(LastChessPoint.X, i));
                }
                else
                {
                    break;
                }

            }
            if (winPoint.Count >= 5)
            {
                return type;
            }
            else
            {
                winPoint.Clear();
                winPoint.Add(LastChessPoint);
            }

            // 左斜
            for (int i = LastChessPoint.X - 1, j = LastChessPoint.Y - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (ChessMap[i, j] == type)
                {
                    winPoint.Add(new Point(i, j));
                }
                else
                {
                    break;
                }
            }
            for (int i = LastChessPoint.X + 1, j = LastChessPoint.Y + 1; i < size && j < size; i++, j++)
            {
                if (ChessMap[i, j] == type)
                {
                    winPoint.Add(new Point(i, j));
                }
                else
                {
                    break;
                }
            }
            if (winPoint.Count >= 5)
            {
                return type;
            }
            else
            {
                winPoint.Clear();
                winPoint.Add(LastChessPoint);
            }


            // 右斜
            for (int i = LastChessPoint.X + 1, j = LastChessPoint.Y - 1; i < size && j >= 0; i++, j--)
            {
                if (ChessMap[i, j] == type)
                {
                    winPoint.Add(new Point(i, j));
                }
                else
                {
                    break;
                }
            }
            for (int i = LastChessPoint.X - 1, j = LastChessPoint.Y + 1; i >= 0 && j < size; i--, j++)
            {
                if (ChessMap[i, j] == type)
                {
                    winPoint.Add(new Point(i, j));
                }
                else
                {
                    break;
                }
            }
            if (winPoint.Count >= 5)
            {
                return type;
            }
            else
            {
                winPoint.Clear();
            }

            return ChessType.NONE;
        }

        public void Draw(Graphics g)
        {
            int boardLen = (size - 1) * GrideSize;
            Color second = FristColor == Color.White ? Color.Black : Color.White;

            // 双缓冲 先绘制到图片中
            Bitmap bt = new Bitmap(Margin * 2+ boardLen, Margin * 2+ boardLen);
            Graphics bg = Graphics.FromImage(bt);
            bg.SmoothingMode = SmoothingMode.HighQuality; //高质量

            Pen pn = new Pen(gridColor);

            // 清除
            bg.Clear(backGroundColor);

            // 绘制棋盘
            for (int i = 0; i < size; i++)
            {
                if (i == 0 || i == size-1)
                    pn.Width = 2;
                else
                    pn.Width = 1;

                int x1 = Margin, x2 = Margin + boardLen;
                int y = Margin + i * GrideSize;

                bg.DrawLine(pn, x1, y, x2, y);
                bg.DrawLine(pn, y, x1, y, x2);
            }

            // 参考点
            int center = size / 2;
            int n = (int)((size-1) / 2 / 8.0 * 5.0);
            DrawPoint(bg, Margin + n * GrideSize, Margin + n * GrideSize, 5, Color.Gray);
            DrawPoint(bg, Margin + (size - 1 - n) * GrideSize, Margin + n * GrideSize, 5, Color.Gray);
            DrawPoint(bg, Margin + 5 * GrideSize, Margin + (size - 1 - n) * GrideSize, 5, Color.Gray);
            DrawPoint(bg, Margin + (size - 1 - n) * GrideSize, Margin + (size - 1 - n) * GrideSize, 5, Color.Gray);
            DrawPoint(bg, Margin + center * GrideSize, Margin + center * GrideSize, 5, Color.Gray);

            // 画棋子
            for(int i=0;i<size;i++)
            {
                for(int j=0;j<size;j++)
                {
                    int x = Margin + GrideSize * i;
                    int y = Margin + GrideSize * j;
                    if(ChessMap[i,j]==ChessType.FRIST)
                    {
                        DrawPoint(bg, x, y, chessRadius, FristColor);
                    }
                    else if(ChessMap[i, j] == ChessType.SECOND)
                    {
                        DrawPoint(bg, x, y, chessRadius, second);
                    }
                }
            }

            // 最后一次落棋的标记
            if(chessCount>0)
            {
                DrawCross(bg,LastChessPoint);
            }

            // 绘制赢棋标记
            foreach(Point pt in winPoint)
            {
                DrawCross(bg,pt);
            }

            // 绘制当前鼠标在棋盘中的位置
            if(bSelectPoint)
            {
                Point cursor = SelectPoint;
                if(ScreenPoint2Board(ref cursor))
                {
                    DrawCursorCell(bg, cursor);
                }
            }

            // 将图片绘制到内存中去
            g.DrawImage(bt, 0, 0);

            pn.Dispose();
            bg.Dispose();
            bt.Dispose();
        }

        private void DrawPoint(Graphics g, int x, int y, int r, Color c)
        {
            SolidBrush redBrush = new SolidBrush(c);
            Rectangle rect = new Rectangle(x - r, y - r, r * 2, r * 2);
            g.FillEllipse(redBrush, rect);
            redBrush.Dispose();

        }

        private void DrawCross(Graphics g, Point pt)
        {
            Pen pn = new Pen(Color.Red);
            int x = pt.X * GrideSize + Margin;
            int y = pt.Y * GrideSize + Margin;

            int crossLen = chessRadius / 3 * 2;
            g.DrawLine(pn, x - crossLen, y, x + crossLen, y);
            g.DrawLine(pn, x, y - crossLen, x, y + crossLen);

            pn.Dispose();
        }

        private void DrawCursorCell(Graphics g, Point boardPoint)
        {
            //检查该位置是否有棋子
            if (ChessMap[boardPoint.X, boardPoint.Y] != ChessType.NONE)
            {
                return;
            }

            Pen pn = new Pen(Color.Red);

            int width = GrideSize / 8;
            Point center = new Point(boardPoint.X * GrideSize + Margin, boardPoint.Y * GrideSize + Margin);
            Point p1 = new Point(-width * 3, -width * 3);
            Point p2 = new Point(-width, -width * 3);
            Point p3 = new Point(-width * 3, -width);
            p1.Offset(center);
            p2.Offset(center);
            p3.Offset(center);

            g.DrawLine(pn, p1, p2);
            g.DrawLine(pn, p1, p3);

            p1.X = width * 3 + center.X;
            p2.X = width + center.X;
            p3.X = width * 3 + center.X;
            g.DrawLine(pn, p1, p2);
            g.DrawLine(pn, p1, p3);

            p1.Y = width * 3 + center.Y;
            p2.Y = width * 3 + center.Y;
            p3.Y = width + center.Y;
            g.DrawLine(pn, p1, p2);
            g.DrawLine(pn, p1, p3);

            p1.X = -width * 3 + center.X;
            p2.X = -width + center.X;
            p3.X = -width * 3 + center.X;
            g.DrawLine(pn, p1, p2);
            g.DrawLine(pn, p1, p3);

            pn.Dispose();
        }

        public bool ScreenPoint2Board(ref Point pt)
        {
            int x = pt.X - Margin;
            int y = pt.Y - Margin;
            int nx, ny;
            if (x < 0 && x > -GrideSize / 2)
            {
                nx = 0;
            }
            else
            {
                nx = x / GrideSize + ((x % GrideSize > GrideSize / 2) ? 1 : 0);
            }

            if (y < 0 && y > -GrideSize / 2)
            {
                ny = 0;
            }
            else
            {
                ny = y / GrideSize + ((y % GrideSize > GrideSize / 2) ? 1 : 0);
            }

            if(nx<0|| nx >=size||ny<0 ||ny>= size)
            {
                return false;
            }
            else
            {
                pt.X = nx;
                pt.Y = ny;
                return true;
            }
        }

    }
}
