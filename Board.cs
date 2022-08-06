using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Gomoku
{
    
    class Board
    {
        private int init_x = 28;
        private int init_y = 26;
        private int space = 50;
        private int whether = 15;//判斷是否可放置的像素大小
        public int[] xboard = new int[13];
        public int[] yboard = new int[13];
        public int[,] board = new int[13,13];//當作x, y座標, 而非二維陣列
        public Point location;
        public Board()
        {
            location = new Point();
            for(int i = 0; i<13; i++)
            {
                    xboard[i] = init_x + i * space;
                    yboard[i] = init_y + i * space;
            }
        }
        public bool Wheher_Be_Place(int x, int y)
        {
            Point ans = ClosetNode(x, y);
            int x_loc = Pretect((x + space / 2 - init_x) / space);
            int y_loc = Pretect((y + space / 2 - init_y) / space);
            if (board[x_loc, y_loc] != (int)PieceType.NONE || Math.Abs(xboard[x_loc] - x) > whether || Math.Abs(yboard[y_loc] - y) > whether)
                return false;
            location.X = ans.X;
            location.Y = ans.Y;
            return true;
        }

        public bool CanMousePlace(int x, int y)
        {
            int x_loc = Pretect((x + space / 2 - init_x) / space);
            int y_loc = Pretect((y + space / 2 - init_y) / space);
            if (board[x_loc, y_loc] != (int)PieceType.NONE || Math.Abs(xboard[x_loc] - x) > whether || Math.Abs(yboard[y_loc] - y) > whether)
                return false;
            else
                return true;
        }
        private Point ClosetNode(int x, int y)
        {
            int x_loc = Pretect((x + space / 2 - init_x) / space);
            int y_loc = Pretect((y + space / 2 - init_y) / space);
            Point p1 = new Point(xboard[x_loc], yboard[y_loc]);
            return p1;
        }
        private int Pretect(int x)
        {
            if (x > 12)
                x = 12;
            if (x < 0)
                x = 0;
            return x;
        }
        public Point RecordSituation(int x, int y, int type)
        {
            int x_loc = Pretect((x + space / 2 - init_x) / space);
            int y_loc = Pretect((y + space / 2 - init_y) / space);
            if (type == (int)PieceType.BLACK)
                board[x_loc, y_loc] = (int)PieceType.BLACK;
            if(type == (int)PieceType.WHITE)
                board[x_loc, y_loc] = (int)PieceType.WHITE;
            return new Point(x_loc, y_loc);
        }
    }
}

