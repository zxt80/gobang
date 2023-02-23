using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gobang
{
    class HumenPlayer: BasePlayer
    {
        // 鼠标位置
        public Point CursorPoint { set; get; }
        public override bool Go()
        {
            Point pt = CursorPoint;
            if(Board.ScreenPoint2Board(ref pt))
            {
                return Board.DownChess(pt, Type);
            }

            return false;
        }

    }
}
