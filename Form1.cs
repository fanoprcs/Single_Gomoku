using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku
{
    public partial class Form1 : Form
    {
        private Game game = new Game();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Piece p = game.PlaceAPiece(e.X, e.Y);
            if (p != null)
            {
                this.Controls.Add(p);
                int Victory = game.CheckWinner();
                if (Victory != (int)PieceType.NONE)
                {
                    string str;
                    if (Victory == (int)PieceType.BLACK)
                        str = "黑方";
                    else
                        str = "白方";
                    MessageBox.Show("恭喜" + str + "獲勝");
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(game.CanMousePlace(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
