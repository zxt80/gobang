using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gobang
{
    enum ChessType
    {
        NONE,
        FRIST,      // 先手棋子
        SECOND      // 后手棋子
    }

    class BasePlayer
    {
        // 棋盘
        public ChessBoard Board { set; get; }

        // 先手后手
        public ChessType Type { set; get; }

        // 棋子颜色
        public Color ChessColor { set; get; }
        public virtual bool Go()
        {
            return true;
        }

        public bool IsWin()
        {
            return Board.IsGameOver() == Type;
        }
    }
}
