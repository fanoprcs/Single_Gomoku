using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Gomoku
{
    abstract class Piece : PictureBox
    {
        private static readonly int Piece_Width = 40;
        public Piece(int x, int y)
        {
            this.BackColor = Color.Transparent;
            this.Location = new Point(x- Piece_Width/2, y- Piece_Width/2);
            this.Size = new Size(Piece_Width, Piece_Width);
        }
        
    }
}
