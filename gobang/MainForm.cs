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
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        bool bStart = false;
        private Manager manager = new Manager();
        int time = 0;
        public MainForm()
        {
            InitializeComponent();

            manager.Init();
        }

        void Draw()
        {
            Graphics g = this.CreateGraphics();
            manager.Board.Draw(g);
            g.Dispose();
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!bStart)
                return;

            manager.SetCorsorPoint(e.Location);
            if(!manager.bOver )
            {      
                if(manager.Go())
                {
                    time = 0;
                    label_count.Text = manager.Board.chessCount.ToString();
                    Draw();

                    if (manager.bOver)
                    {
                        timer.Stop();
                        if (manager.WinType == manager.humenPlayer.Type)
                        {
                            MessageBox.Show("您赢得了比赛，游戏结束!!");
                        }
                        else if (manager.WinType == manager.aiPlayer.Type)
                        {
                            MessageBox.Show("游戏结束,您输了!!");
                        }

                        bStart = false;
                        btn_start.Text = "开始";
                        EnableItems(true);                       

                    }
                }
                
            }
            else
            {
                if(MessageBox.Show(this,"您要开始新的对局么？","提升",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    manager.NewGame();
                    Draw();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(bStart)
            {
                if(MessageBox.Show(this,"您要开始新的游戏么？","提示",MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                bStart = true;
                btn_start.Text = "重新开始";
            }

            
            if (rbt_color_black.Checked)
            {
                manager.humenPlayer.ChessColor = Color.Black;
                manager.aiPlayer.ChessColor = Color.White;
            }
            else
            {
                manager.humenPlayer.ChessColor = Color.White;
                manager.aiPlayer.ChessColor = Color.Black;
            }

            if (rbt_frist.Checked)
            {
                manager.humenPlayer.Type = ChessType.FRIST;
                manager.aiPlayer.Type = ChessType.SECOND;
                manager.Board.FristColor = manager.humenPlayer.ChessColor;
            }
            else
            {
                manager.humenPlayer.Type = ChessType.SECOND;
                manager.aiPlayer.Type = ChessType.FRIST;
                manager.Board.FristColor = manager.aiPlayer.ChessColor;
            }

            label_count.Text = "0";
            manager.NewGame();
            Draw();

            if (manager.aiPlayer.Type==ChessType.FRIST)
            {
                manager.aiPlayer.GoFrist();
            }

            time = 0;
            timer.Start();

            EnableItems(false);
        }

        private void EnableItems(bool en)
        {
            rbt_color_black.Enabled = en;
            rbt_color_white.Enabled = en;
            rbt_frist.Enabled = en;
            rbt_second.Enabled = en;
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Draw();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            manager.Board.bSelectPoint = true;
            manager.Board.SelectPoint = e.Location;
            Draw();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            time++;
            label_time.Text = $"{time / 10.0}秒";
        }
    }
}
