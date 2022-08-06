using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Gomoku
{
    class Game
    {
        private int NextPieceType = (int)PieceType.BLACK;//1表示黑棋
        private Board B1 = new Board();
        private Point Check;
        public bool Whether_Be_Place(int x, int y)
        {
            return B1.Wheher_Be_Place(x,y);
        }
        public Piece PlaceAPiece(int x, int y)
        {
            if (B1.Wheher_Be_Place(x, y) == true)
            {
                Piece K;
                if (NextPieceType == (int)PieceType.BLACK)
                {
                    Check = B1.RecordSituation(x, y, NextPieceType);
                    K = new BlackPiece(B1.location.X, B1.location.Y);
                    NextPieceType = 2;
                }
                else
                {
                    Check = B1.RecordSituation(x, y, NextPieceType);
                    K = new WhitePiece(B1.location.X, B1.location.Y);
                    NextPieceType = 1;
                }
                
                return K;
            }
            return null;
        }
        public bool CanMousePlace(int x, int y)
        {
            return B1.CanMousePlace(x, y);
        }
        public int CheckWinner()
        {
            int Type = B1.board[Check.X, Check.Y];
            if(North(Check.X, Check.Y, 1)+ South(Check.X, Check.Y, 1) - 1 ==5)
                return Type;
            if(East(Check.X, Check.Y, 1) + West(Check.X, Check.Y, 1) - 1 == 5)
                return Type;
            if (EastNorth(Check.X, Check.Y, 1) + WestSouth(Check.X, Check.Y, 1) - 1 == 5)
                return Type;
            if (EastSouth(Check.X, Check.Y, 1) + WestNorth(Check.X, Check.Y, 1) - 1 == 5)
                return Type;
            
            return (int)PieceType.NONE;
        }
        private int West(int i, int j, int value)//判斷8種方向的線 直線0, 橫線1, 東北西南2, 西北東南3
        {
            if(i - 1 >= 0 && B1.board[i - 1, j] == B1.board[i,j]  )
            {
                value = West(i - 1, j, value+1);
            }
            return value;
        }
        private int East(int i, int j, int value)//判斷8種方向的線 直線0, 橫線1, 東北西南2, 西北東南3
        {
            if (i + 1 <= 12 && B1.board[i + 1, j] == B1.board[i, j])
            {
                value = East(i + 1, j, value + 1);
            }
            return value;
        }
        private int North(int i, int j, int value)//判斷8種方向的線 直線0, 橫線1, 東北西南2, 西北東南3
        {
            if (j - 1 >= 0 && B1.board[i, j -  1] == B1.board[i, j])
            {
                value = North(i, j - 1, value + 1);
            }
            return value;
        }
        private int South(int i, int j, int value)//判斷8種方向的線 直線0, 橫線1, 東北西南2, 西北東南3
        {
            if (j + 1 <= 12 && B1.board[i, j + 1] == B1.board[i, j])
            {
                value = South(i, j + 1, value + 1);
            }
            return value;
        }
        private int WestNorth(int i, int j, int value)//判斷8種方向的線 直線0, 橫線1, 東北西南2, 西北東南3
        {
            if (i - 1 >= 0 && j - 1 >= 0 && B1.board[i - 1, j - 1] == B1.board[i, j])
            {
                value = WestNorth(i - 1, j - 1, value + 1);
            }
            return value;
        }
        private int EastNorth(int i, int j, int value)//判斷8種方向的線 直線0, 橫線1, 東北西南2, 西北東南3
        {
            if (j - 1 >= 0 && i + 1 <= 12 && B1.board[i + 1, j - 1] == B1.board[i, j])
            {
                value = EastNorth(i + 1, j - 1, value + 1);
            }
            return value;
        }
        private int WestSouth(int i, int j, int value)//判斷8種方向的線 直線0, 橫線1, 東北西南2, 西北東南3
        {
            if (i - 1 >= 0 && j + 1 <= 12 && B1.board[i - 1, j + 1] == B1.board[i, j])
            {
                value = WestSouth(i - 1, j + 1, value + 1);
            }
            return value;
        }
        private int EastSouth(int i, int j, int value)//判斷8種方向的線 直線0, 橫線1, 東北西南2, 西北東南3
        {
            if (i + 1 <= 12 && j + 1 <= 12 && B1.board[i + 1, j + 1] == B1.board[i, j])
            {
                value = EastSouth(i + 1, j + 1, value + 1);
            }
            return value;
        }
    }
}
