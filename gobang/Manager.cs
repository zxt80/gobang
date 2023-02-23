using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gobang
{
    class Manager
    {
        // 玩家先手还是后手
        public ChessType HumenChessType { set; get; } 

        public HumenPlayer humenPlayer;
        public AIPlayer aiPlayer;
        public ChessBoard Board { set; get; }

        // 游戏是否结束
        public bool bOver = false;

        // 获胜方
        public ChessType WinType = ChessType.NONE;

        public void SetCorsorPoint(Point pt)
        {
            humenPlayer.CursorPoint = pt;
        }
        public bool Go() 
        {
            if(humenPlayer.Go() )
            {
                if (humenPlayer.IsWin())
                {
                    bOver = true;
                    WinType = humenPlayer.Type;
                    return true;
                }

                if(aiPlayer.Go())
                {
                    if(aiPlayer.IsWin())
                    {
                        bOver = true;
                        WinType = aiPlayer.Type;
                    }
                    return true;
                }
            }
            return false;
        }

        public void NewGame()
        {
            bOver = false;
            Board.Rest();
        }

        public void Init()
        {
            humenPlayer = new HumenPlayer();
            aiPlayer = new AIPlayer();
            Board = new ChessBoard();
            Board.Size = 17;
            humenPlayer.Board = Board;
            aiPlayer.Board = Board;

            humenPlayer.Type = ChessType.FRIST;
            aiPlayer.Type = ChessType.SECOND;
            humenPlayer.ChessColor = Color.Black;
            aiPlayer.ChessColor = Color.White;
        }
    }
}
