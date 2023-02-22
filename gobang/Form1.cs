using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace gobang
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        Chessboard board = new Chessboard();
        bool bStart = false;
        int times = 0;
        Chessman.TYPE fristType;
        bool bAiMode = false;
        SoundPlayer sound = new SoundPlayer(Properties.Resources.ResourceManager.GetStream("chess_move_on_alabaster"));

        public Form1()
        {
            InitializeComponent();
            
            board.GridCount = 16;
            board.GridWidth = 40;
            board.OriginX = 30;
            board.OriginY = 30;
            board.Init();
            fristType = Chessman.TYPE.BLACK;

        }

        void Draw()
        {
            Graphics g = this.CreateGraphics();
            board.Draw(g);
            g.Dispose();
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(!bStart)
               return;
            Chessman.TYPE aiType;
            if(e.Button==MouseButtons.Left)
            {
                Chessman.TYPE type;
                if((fristType == Chessman.TYPE.BLACK && times % 2 == 0) ||
                    (fristType == Chessman.TYPE.WHITE && times % 2 == 1))
                {
                    type = Chessman.TYPE.BLACK;
                    aiType = Chessman.TYPE.WHITE;
                }
                else
                {
                    type = Chessman.TYPE.WHITE;
                    aiType = Chessman.TYPE.BLACK;
                }

                if (board.AddChess(e.Location, type))
                {
                    // 播放声音
                    sound.Play();

                    times++;
                    Draw();

                    // 判断输赢
                    Chessman.TYPE t;
                    if(board.IsGameOver(out t))
                    {
                        bStart = false;
                        
                        if (t == Chessman.TYPE.BLACK)
                            MessageBox.Show(this,"黑棋赢了！！");
                        if (t == Chessman.TYPE.WHITE)
                            MessageBox.Show(this, "白棋赢了！！");

                        btn_start.Text = "开始";

                        EnableItems(true);
                        return;
                    }

                    board.AddAiChess(aiType);
                    times++;
                    Draw();

                    // 判断输赢
                    if (board.IsGameOver(out t))
                    {
                        bStart = false;

                        if (t == Chessman.TYPE.BLACK)
                            MessageBox.Show(this, "黑棋赢了！！");
                        if (t == Chessman.TYPE.WHITE)
                            MessageBox.Show(this, "白棋赢了！！");

                        btn_start.Text = "开始";

                        EnableItems(true);
                        return;
                    }
                }
            }
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            if(bStart)
            {
                //从新开始
                if(MessageBox.Show(this,"确定要重新开始游戏么？","提升",MessageBoxButtons.YesNo)==DialogResult.No)
                {
                    return;
                }
                bStart = false;
                times = 0;
                btn_start.Text = "开始";
                EnableItems(true);

            }
            else
            {
                bStart = true;
                times = 0;
                btn_start.Text = "重新开始";

                EnableItems(false);
            }
            board.Rest();
            Draw();
            
        }

        private void EnableItems(bool en)
        {
            rbt_color_black.Enabled = en;
            rbt_color_white.Enabled = en;
            rbt_frist.Enabled = en;
            rbt_second.Enabled = en;

            checkBox_ai.Enabled = en;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Draw();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Draw();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            board.CursorPoint = e.Location;
            Draw();
        }

        private void rbt_color_black_Click(object sender, EventArgs e)
        {
            fristType = Chessman.TYPE.BLACK;
        }

        private void rbt_color_white_Click(object sender, EventArgs e)
        {
            fristType = Chessman.TYPE.WHITE;
        }

        private void checkBox_ai_Click(object sender, EventArgs e)
        {
            bAiMode = checkBox_ai.Checked;

            rbt_frist.Enabled = bAiMode;
            rbt_second.Enabled = bAiMode;
        }
    }
}
