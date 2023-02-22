using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gobang
{
    class Chessboard
    {
        private bool bOver = false;
        private List<Chessman> chess;

        private Chessman.TYPE[,] chessMap;

        private Point[] winChess = new Point[5];

        public int GridCount { set; get; }

        public int GridWidth { set; get; }

        public int OriginX { set; get; }

        public int OriginY { set; get; }

        public Point CursorPoint { set; get; }

        private Rectangle ChessRect { set; get; }

        private int[,] scorMap;

        public bool IsGameOver(out Chessman.TYPE type)
        {
            type = Chessman.TYPE.NONE;
            if (chess.Count < 9)
                return false;

            int count = 1;
            Chessman ch = chess.Last();
            winChess[0] = new Point(ch.X,ch.Y);

            // 横
            for (int i= ch.X-1;i>=0;i--)
            {
                if(chessMap[i,ch.Y] == ch.Type)
                {
                    winChess[count++] = new Point(i, ch.Y);
                }
                else
                {
                    break;
                }
            }

            for (int i = ch.X +1 ; i < GridCount+1; i++)
            {
                if (chessMap[i, ch.Y] == ch.Type)
                {
                    winChess[count++] = new Point(i, ch.Y);
                }
                else
                {
                    break;
                }
            }
            if (count >= 5)
            {
                type = ch.Type;
                bOver = true;
                return true;
            }

            // 竖
            count = 1;
            for (int i = ch.Y - 1; i >= 0; i--)
            {
                if (chessMap[ch.X, i] == ch.Type)
                {
                    winChess[count++] = new Point(ch.X, i);
                }
                else
                {
                    break;
                }
            }

            for (int i = ch.Y + 1; i < GridCount + 1; i++)
            {
                if (chessMap[ch.X, i] == ch.Type)
                {
                    winChess[count++] = new Point(ch.X, i);
                }
                else
                {
                    break;
                }             
                
            }
            if (count >= 5)
            {
                type = ch.Type;
                bOver = true;
                return true;
            }

            // 左斜
            count = 1;
            for (int i = ch.X - 1,j = ch.Y - 1; i>=0 && j>=0;i--,j--)
            {
                if (chessMap[i,j] == ch.Type)
                {
                    winChess[count++] = new Point(i,j);
                }
                else
                {
                    break;
                }
            }
            for (int i = ch.X + 1, j = ch.Y + 1; i < GridCount+1 && j <GridCount+1; i++, j++)
            {
                if (chessMap[i, j] == ch.Type)
                {
                    winChess[count++] = new Point(i, j);
                }
                else
                {
                    break;
                }
            }
            if (count >= 5)
            {
                type = ch.Type;
                bOver = true;
                return true;
            }


            // 右斜
            count = 1;
            for (int i = ch.X + 1, j = ch.Y - 1; i < GridCount+1 && j >= 0; i++, j--)
            {
                if (chessMap[i, j] == ch.Type)
                {
                    winChess[count++] = new Point(i, j);
                }
                else
                {
                    break;
                }
            }
            for (int i = ch.X - 1, j = ch.Y + 1; i >=0 && j < GridCount + 1; i--, j++)
            {
                if (chessMap[i, j] == ch.Type)
                {
                    winChess[count++] = new Point(i, j);
                }
                else
                {
                    break;
                }
            }
            if (count >= 5)
            {
                type = ch.Type;
                bOver = true;
                return true;
            }

            return false;
        }

        public Chessboard() 
        {
            chess = new List<Chessman>();
            
        }
        public void Init()
        {
            chessMap = new Chessman.TYPE[GridCount+1, GridCount+1];
            ChessRect = new Rectangle(OriginX, OriginY, GridCount * GridWidth, GridCount * GridWidth);
            scorMap = new int[GridCount + 1, GridCount + 1];
            Rest();
        }

        public void Rest()
        {
            bOver = false;
            chess.Clear();
            for (int i=0;i<GridCount+1;i++)
            {
                for(int j=0;j<GridCount+1;j++)
                {
                    chessMap[i, j] = Chessman.TYPE.NONE;
                }
            }
        }

        public void AddAiChess()
        {

        }

        // ai 算法 计算得分
        // type : ai 棋子类型
        private void CalSocle(Chessman.TYPE aiType)
        {
            Point[] dirPoints = new Point[4];
            dirPoints[0] = new Point(-1,0);
            dirPoints[1] = new Point(-1,-1);
            dirPoints[2] = new Point(0,-1);
            dirPoints[3] = new Point(1,-1);

            for (int i=0;i<GridCount+1;i++)
            {
                for(int j=0;j<GridCount+1;j++)
                {
                    scorMap[i, j] = 0;

                    if (chessMap[i, j] != Chessman.TYPE.NONE)
                        continue;

                    // 计算8个方向的得分
                    for(int n=0;n<4;n++)
                    {
                        int aiCount = 0, humenCount = 0, emptyCount = 0;
                        // 计算4个点
                        for (int c = 1; c < 5; c++)
                        {
                            int x1 = i + dirPoints[n].X * c;
                            int y1 = j + dirPoints[n].Y * c;

                            if (x1 > GridCount || x1 < 0 || y1 > GridCount || y1 < 0)
                                break;

                            if (chessMap[x1, y1] == aiType)
                            {
                                aiCount++;
                            }
                            else if (chessMap[x1, y1] == Chessman.TYPE.NONE)
                            {
                                emptyCount++;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }

                        for (int c = 1; c < 5; c++)
                        {
                            int x1 = i - dirPoints[n].X * c;
                            int y1 = j - dirPoints[n].Y * c;

                            if (x1 > GridCount || x1 < 0 || y1 > GridCount || y1 < 0)
                                break;

                            if (chessMap[x1, y1] == aiType)
                            {
                                aiCount++;
                            }
                            else if (chessMap[x1, y1] == Chessman.TYPE.NONE)
                            {
                                emptyCount++;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (aiCount == 0)
                        {
                            scorMap[i, j] += 5;
                        }
                        else if (aiCount == 1)
                        {
                            scorMap[i, j] += 10;
                        }
                        else if (aiCount == 2)
                        {
                            if (emptyCount > 1)
                                scorMap[i, j] += 50;
                            else
                                scorMap[i, j] += 25;
                        }
                        else if (aiCount == 3)
                        {
                            if (emptyCount > 1)
                                scorMap[i, j] += 10000;
                            else
                                scorMap[i, j] = 55;
                        }
                        else if (aiCount >= 4)
                        {
                            scorMap[i, j] += 30000;
                        }

                        emptyCount = 0;
                        for (int c = 1; c < 5; c++)
                        {
                            int x1 = i + dirPoints[n].X * c;
                            int y1 = j + dirPoints[n].Y * c;

                            if (x1 > GridCount || x1 < 0 || y1 > GridCount || y1 < 0)
                                break;

                            if (chessMap[x1, y1] == Chessman.TYPE.NONE)
                            {
                                emptyCount++;
                                break;
                            }
                            else if (chessMap[x1, y1] != aiType)
                            {
                                humenCount++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        for (int c = 1; c < 5; c++)
                        {
                            int x1 = i - dirPoints[n].X * c;
                            int y1 = j - dirPoints[n].Y * c;

                            if (x1 > GridCount || x1 < 0 || y1 > GridCount || y1 < 0)
                                break;

                            if (chessMap[x1, y1] == Chessman.TYPE.NONE)
                            {
                                emptyCount++;
                                break;
                            }
                            else if (chessMap[x1, y1] != aiType)
                            {
                                humenCount++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (humenCount == 0)
                        {
                            scorMap[i, j] += 5;
                        }
                        else if (humenCount == 1)
                        {
                            scorMap[i, j] += 10;
                        }
                        else if (humenCount == 2)
                        {
                            if (emptyCount > 1)
                                scorMap[i, j] += 40;
                            else
                                scorMap[i, j] += 30;
                        }
                        else if (humenCount == 3)
                        {
                            if (emptyCount > 1)
                                scorMap[i, j] += 200;
                            else
                                scorMap[i, j] += 60;
                        }
                        else if (humenCount >= 4)
                        {
                            scorMap[i, j] += 20000;
                        }

                    }
                    //for(int x=-1;x<=1;x++)
                    //{
                    //    for(int y=-1;y<=1;y++)
                    //    {
                    //        if (x == 0 && y == 0) continue;

                    //        int aiCount = 0, humenCount = 0, emptyCount = 0;
                            
                    //        // 计算4个点
                    //        for (int c = 1; c < 5; c++)
                    //        {
                    //            int x1 = i + x * c;
                    //            int y1 = j + y * c;

                    //            if (x1 > GridCount || x1 < 0 || y1 > GridCount || y1 < 0)
                    //                break;

                    //            if (chessMap[x1, y1] == aiType)
                    //            {
                    //                aiCount++;
                    //            }
                    //            else if (chessMap[x1, y1] == Chessman.TYPE.NONE)
                    //            {
                    //                emptyCount++;
                    //                break;
                    //            }
                    //            else
                    //            {
                    //                break;
                    //            }
                    //        }

                    //        for (int c = 1; c < 5; c++)
                    //        {
                    //            int x1 = i - x * c;
                    //            int y1 = j - y * c;

                    //            if (x1 > GridCount || x1 < 0 || y1 > GridCount || y1 < 0)
                    //                break;

                    //            if (chessMap[x1, y1] == aiType)
                    //            {
                    //                aiCount++;
                    //            }
                    //            else if (chessMap[x1, y1] == Chessman.TYPE.NONE)
                    //            {
                    //                emptyCount++;
                    //                break;
                    //            }
                    //            else
                    //            {
                    //                break;
                    //            }
                    //        }

                    //        if (aiCount==0)
                    //        {
                    //            scorMap[i, j] = 5;
                    //        }
                    //        else if(aiCount==1)
                    //        {
                    //            scorMap[i, j] = 10;
                    //        }
                    //        else if(aiCount==2)
                    //        {
                    //            if(emptyCount>1)
                    //                scorMap[i, j] = 50;
                    //            else
                    //                scorMap[i, j] = 25;
                    //        }
                    //        else if (aiCount == 3)
                    //        {
                    //            if (emptyCount > 1)
                    //                scorMap[i, j] = 10000;
                    //            else
                    //                scorMap[i, j] = 55;
                    //        }
                    //        else if (aiCount >= 4)
                    //        {
                    //             scorMap[i, j] = 30000;
                    //        }

                    //        emptyCount = 0;
                    //        for (int c = 1; c < 5; c++)
                    //        {
                    //            int x1 = i + x * c;
                    //            int y1 = j + y * c;

                    //            if (x1 > GridCount || x1 < 0 || y1 > GridCount || y1 < 0)
                    //                break;

                    //            if (chessMap[x1, y1] == Chessman.TYPE.NONE)
                    //            {
                    //                emptyCount++;
                    //                break;
                    //            }
                    //            else if (chessMap[x1, y1] != aiType)
                    //            {
                    //                humenCount++;
                    //            }
                    //            else
                    //            {
                    //                break;
                    //            }
                    //        }

                    //        for (int c = 1; c < 5; c++)
                    //        {
                    //            int x1 = i - x * c;
                    //            int y1 = j - y * c;

                    //            if (x1 > GridCount || x1 < 0 || y1 > GridCount || y1 < 0)
                    //                break;

                    //            if (chessMap[x1, y1] == Chessman.TYPE.NONE)
                    //            {
                    //                emptyCount++;
                    //                break;
                    //            }
                    //            else if (chessMap[x1, y1] != aiType)
                    //            {
                    //                humenCount++;
                    //            }
                    //            else
                    //            {
                    //                break;
                    //            }
                    //        }

                    //        if (humenCount == 0)
                    //        {
                    //            scorMap[i, j] += 5;
                    //        }
                    //        else if (humenCount == 1)
                    //        {
                    //            scorMap[i, j] += 10;
                    //        }
                    //        else if (humenCount == 2)
                    //        {
                    //            if (emptyCount > 1)
                    //                scorMap[i, j] += 40;
                    //            else
                    //                scorMap[i, j] += 30;
                    //        }
                    //        else if (humenCount == 3)
                    //        {
                    //            if (emptyCount > 1)
                    //                scorMap[i, j] += 200;
                    //            else
                    //                scorMap[i, j] += 60;
                    //        }
                    //        else if (humenCount >= 4)
                    //        {
                    //            scorMap[i, j] += 20000;
                    //        }

                    //    }
                    //}                    
                   
                }
            }
        }

        private Point Think(Chessman.TYPE aiType)
        {
            int maxScore = 0;
            List<Point> points = new List<Point>();
            CalSocle(aiType);

            for(int i=0;i<GridCount+1;i++)
            {
                for(int j=0;j<GridCount+1;j++)
                {
                    if(scorMap[i,j]>maxScore)
                    {
                        maxScore = scorMap[i, j];
                        points.Clear();
                        points.Add(new Point(i, j));
                    }
                    else if(scorMap[i,j]==maxScore)
                    {
                        points.Add(new Point(i, j));
                    }
                }
            }

            Random rd = new Random();
            return points.ElementAt(rd.Next(0, points.Count));
        }


        public void ClearChesss()
        {
            chess.Clear();
        }

        public bool AddAiChess(Chessman.TYPE aiType)
        {
            Point pt = Think(aiType);

            // 添加新棋子
            Chessman ch = new Chessman(pt, this);
            ch.Type = aiType;
            chess.Add(ch);

            // 设置棋子在棋盘中的位置
            chessMap[pt.X, pt.Y] = aiType;

            return true;
        }

        public bool AddChess(Point pt,Chessman.TYPE type)
        {
            if(!ChessRect.Contains(pt))
            {
                return false;
            }

            Point grid = GetNearestPoint(pt);

            // 去除重复的点
            foreach(var tmp in chess)
            {
                if(tmp.X==grid.X && tmp.Y==grid.Y)
                {
                    return false;
                }
            }

            // 添加新棋子
            Chessman ch = new Chessman(grid,this);
            ch.Type = type;
            chess.Add(ch);

            // 设置棋子在棋盘中的位置
            chessMap[grid.X, grid.Y] = type;

            return true;
        }

        private Point GetNearestPoint(Point pt)
        {
            int x = pt.X - OriginX;
            int y = pt.Y - OriginY;
            int nx, ny;
            if (x < 0 && x > -GridWidth / 2)
            {
                nx = 0;
            }
            else
            {
                nx = x / GridWidth + ((x % GridWidth > GridWidth / 2) ? 1 : 0);
            }

            if (y < 0 && y > -GridWidth / 2)
            {
                ny = 0;
            }
            else
            {
                ny = y / GridWidth + ((y % GridWidth > GridWidth / 2) ? 1 : 0);
            }

            return new Point(nx,ny);            

        }

        public void Draw(Graphics g)
        {
            // 双缓冲 先绘制到图片中
            Bitmap bt = new Bitmap((GridCount+1)*GridWidth+OriginX, (GridCount+1) * GridWidth+OriginY);
            Graphics bg = Graphics.FromImage(bt);
            bg.SmoothingMode = SmoothingMode.HighQuality; //高质量

            Pen pn = new Pen(Color.Gray);
            pn.Width = 1;

            // 清除
            bg.Clear( Color.FromArgb(255,224,224,224));

            // 绘制当前鼠标位置
            DrawCursorCell(bg);


            // 绘制棋盘 横线
            for (int i = 1; i < GridCount; i++)
            {
                int x1 = OriginX, x2 = OriginX + GridCount * GridWidth;
                int y = OriginY + i * GridWidth;

                bg.DrawLine(pn, x1, y, x2, y);
            }

            // 竖线
            for (int i = 1; i < GridCount; i++)
            {
                int y1 = OriginY, y2 = OriginY + GridCount * GridWidth;
                int x = OriginX + i * GridWidth;

                bg.DrawLine(pn, x, y1, x, y2);
            }

            // 边框
            int len = GridWidth * GridCount;
            pn.Width = 2;
            bg.DrawLine(pn, OriginX, OriginY, OriginX+ len, OriginY);
            bg.DrawLine(pn, OriginX, OriginY, OriginX, OriginY+ len);
            bg.DrawLine(pn, OriginX+ len, OriginY, OriginX+ len, OriginY+ len);
            bg.DrawLine(pn, OriginX, OriginY+ len, OriginX+ len, OriginY+ len);

            // 参考点
            int center = GridCount / 2;
            int n = (int)( GridCount/2 / 8.0 * 5.0);
            DrawPoint(bg, OriginX + n * GridWidth, OriginY + n * GridWidth, 5, Color.Gray);
            DrawPoint(bg, OriginX + (GridCount- n) * GridWidth, OriginY + n * GridWidth, 5, Color.Gray);
            DrawPoint(bg, OriginX + 5 * GridWidth, OriginY + (GridCount - n) * GridWidth, 5, Color.Gray);
            DrawPoint(bg, OriginX + (GridCount - n) * GridWidth, OriginY + (GridCount - n) * GridWidth, 5, Color.Gray);
            DrawPoint(bg, OriginX + center * GridWidth, OriginY + center * GridWidth, 5, Color.Gray);

            // 绘制棋子
            foreach(var tmp in chess)
            {
                tmp.Draw(bg);
            }  
            
            // 绘制最后一个棋子的标记
            if(chess.Count>0)
            {
                chess.Last().DrawFlag(bg);
            }

            // 绘制赢棋子
            if(bOver )
            {
                foreach (var tmp in chess)
                {
                    for(int i=0;i<5;i++)
                    {
                        if (tmp.X == winChess[i].X && tmp.Y == winChess[i].Y)
                            tmp.DrawFlag(bg);
                    }                    
                }
            }
            

            // 绘制图片，一次将全部内容绘制出来
            g.DrawImage(bt,0,0);

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

        private void DrawCursorCell(Graphics g)
        {
            if (!ChessRect.Contains(CursorPoint))
            {
                return;
            }            

            Point grid = GetNearestPoint(CursorPoint);

            //检查该位置是否有棋子
            if(chessMap[grid.X,grid.Y] == Chessman.TYPE.BLACK || chessMap[grid.X, grid.Y]==Chessman.TYPE.WHITE)
            {
                return;
            }

            Pen pn = new Pen(Color.Red);

            int width = GridWidth  / 8;
            Point center = new Point(grid.X * GridWidth + OriginX, grid.Y * GridWidth + OriginY);
            Point p1 = new Point(-width * 3, -width * 3);
            Point p2 = new Point(-width, -width * 3);
            Point p3 = new Point(-width * 3, -width);
            p1.Offset(center);
            p2.Offset(center);
            p3.Offset(center);

            g.DrawLine(pn, p1,p2);
            g.DrawLine(pn, p1,p3);

            p1.X = width * 3 + center.X;
            p2.X = width + center.X;
            p3.X = width * 3 + center.X;
            g.DrawLine(pn, p1, p2);
            g.DrawLine(pn, p1, p3);

            p1.Y = width * 3 + center.Y;
            p2.Y = width * 3 + center.Y;
            p3.Y = width  + center.Y;
            g.DrawLine(pn, p1, p2);
            g.DrawLine(pn, p1, p3);

            p1.X = -width * 3 + center.X;
            p2.X = -width + center.X;
            p3.X = -width * 3 + center.X;
            g.DrawLine(pn, p1, p2);
            g.DrawLine(pn, p1, p3);

            pn.Dispose();
        }

    }
}
