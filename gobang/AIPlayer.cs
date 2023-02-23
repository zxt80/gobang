using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gobang
{
    class AIPlayer:BasePlayer
    {
        private int[,] scorMap;

        public override bool Go()
        {
            return Board.DownChess(Think(), Type);
        }

        // 第一步
        public void GoFrist()
        {
            Point center = new Point(Board.Size/2,Board.Size/2);
            Board.DownChess(center, Type);
        }

        private Point Think()
        {
            int maxScore = 0;
            List<Point> points = new List<Point>();
            scorMap = new int[Board.Size, Board.Size];
            CalSocle();

            for (int i = 0; i < Board.Size; i++)
            {
                for (int j = 0; j < Board.Size; j++)
                {
                    if (scorMap[i, j] > maxScore)
                    {
                        maxScore = scorMap[i, j];
                        points.Clear();
                        points.Add(new Point(i, j));
                    }
                    else if (scorMap[i, j] == maxScore)
                    {
                        points.Add(new Point(i, j));
                    }
                }
            }

            Random rd = new Random();
            return points.ElementAt(rd.Next(0, points.Count));
            
        }
        private void CalSocle()
        {
            Point[] dirPoints = new Point[4];
            dirPoints[0] = new Point(-1, 0);
            dirPoints[1] = new Point(-1, -1);
            dirPoints[2] = new Point(0, -1);
            dirPoints[3] = new Point(1, -1);

            for (int i = 0; i < Board.Size; i++)
            {
                for (int j = 0; j < Board.Size; j++)
                {
                    scorMap[i, j] = 0;

                    if (Board.ChessMap[i, j] != ChessType.NONE)
                        continue;

                    // 计算8个方向的得分
                    for (int n = 0; n < 4; n++)
                    {
                        int aiCount = 0, humenCount = 0, emptyCount = 0;
                        // 计算4个点
                        for (int c = 1; c < 5; c++)
                        {
                            int x1 = i + dirPoints[n].X * c;
                            int y1 = j + dirPoints[n].Y * c;

                            if (x1 > Board.Size-1 || x1 < 0 || y1 > Board.Size - 1 || y1 < 0)
                                break;

                            if (Board.ChessMap[x1, y1] == Type)
                            {
                                aiCount++;
                            }
                            else if (Board.ChessMap[x1, y1] == ChessType.NONE)
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

                            if (x1 > Board.Size - 1 || x1 < 0 || y1 > Board.Size - 1 || y1 < 0)
                                break;

                            if (Board.ChessMap[x1, y1] == Type)
                            {
                                aiCount++;
                            }
                            else if (Board.ChessMap[x1, y1] == ChessType.NONE)
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

                            if (x1 > Board.Size - 1 || x1 < 0 || y1 > Board.Size - 1 || y1 < 0)
                                break;

                            if (Board.ChessMap[x1, y1] == ChessType.NONE)
                            {
                                emptyCount++;
                                break;
                            }
                            else if (Board.ChessMap[x1, y1] != Type)
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

                            if (x1 > Board.Size-1 || x1 < 0 || y1 > Board.Size - 1 || y1 < 0)
                                break;

                            if (Board.ChessMap[x1, y1] == ChessType.NONE)
                            {
                                emptyCount++;
                                break;
                            }
                            else if (Board.ChessMap[x1, y1] != Type)
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
    }
}
