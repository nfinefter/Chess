using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public sealed class Knight : ChessPiece
    {
        public Knight(Point pos, PieceType pieceType, bool isBlack) : base(pos, pieceType, isBlack)
        {

        }

        public override List<Move> Move(ChessPiece[,] Grid)
        {
            List<Move> PossibleMoves = new List<Move>();
            PossibleMoves.Clear();
            if (BoardPos.Y + 2 < Grid.GetLength(0) && BoardPos.X + 1 < Grid.GetLength(0))
            {
                if ((Grid[BoardPos.X + 1, BoardPos.Y + 2] != null && IsBlack != Grid[BoardPos.X + 1, BoardPos.Y + 2].IsBlack) || Grid[BoardPos.X + 1, BoardPos.Y + 2] == null)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X + 1, BoardPos.Y + 2)));
                }
            }
            if (BoardPos.Y + 2 < Grid.GetLength(0) && BoardPos.X - 1 >= 0)
            {
                if ((Grid[BoardPos.X - 1, BoardPos.Y + 2] != null && IsBlack != Grid[BoardPos.X - 1, BoardPos.Y + 2].IsBlack) || Grid[BoardPos.X - 1, BoardPos.Y + 2] == null)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X - 1, BoardPos.Y + 2)));
                }
            }

            if (BoardPos.Y - 2 >= 0 && BoardPos.X + 1 < Grid.GetLength(0))
            {
                if ((Grid[BoardPos.X + 1, BoardPos.Y - 2] != null && IsBlack != Grid[BoardPos.X + 1, BoardPos.Y - 2].IsBlack) || Grid[BoardPos.X + 1, BoardPos.Y - 2] == null)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X + 1, BoardPos.Y - 2)));
                }

            }
            if (BoardPos.Y - 2 >= 0 && BoardPos.X - 1 >= 0)
            {
                if ((Grid[BoardPos.X - 1, BoardPos.Y - 2] != null && IsBlack != Grid[BoardPos.X - 1, BoardPos.Y - 2].IsBlack) || Grid[BoardPos.X - 1, BoardPos.Y - 2] == null)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X - 1, BoardPos.Y - 2)));
                }
            }

            if (BoardPos.Y + 1 < Grid.GetLength(0) && BoardPos.X + 2 < Grid.GetLength(0))
            {
                if ((Grid[BoardPos.X + 2, BoardPos.Y + 1] != null && IsBlack != Grid[BoardPos.X + 2, BoardPos.Y + 1].IsBlack) || Grid[BoardPos.X + 2, BoardPos.Y + 1] == null)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X + 2, BoardPos.Y + 1)));
                }
            }
            if (BoardPos.Y + 1 < Grid.GetLength(0) && BoardPos.X - 2 >= 0)
            {
                if ((Grid[BoardPos.X - 2, BoardPos.Y + 1] != null && IsBlack != Grid[BoardPos.X - 2, BoardPos.Y + 1].IsBlack) || Grid[BoardPos.X - 2, BoardPos.Y + 1] == null)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X - 2, BoardPos.Y + 1)));
                }
            }

            if (BoardPos.Y - 1 >= 0 && BoardPos.X + 2 < Grid.GetLength(0))
            {
                if ((Grid[BoardPos.X + 2, BoardPos.Y - 1] != null && IsBlack != Grid[BoardPos.X + 2, BoardPos.Y - 1].IsBlack) || Grid[BoardPos.X + 2, BoardPos.Y - 1] == null)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X + 2, BoardPos.Y - 1)));
                }
            }
            if (BoardPos.Y - 1 >= 0 && BoardPos.X - 2 >= 0)
            {
                if ((Grid[BoardPos.X - 2, BoardPos.Y - 1] != null && IsBlack != Grid[BoardPos.X - 2, BoardPos.Y - 1].IsBlack) || Grid[BoardPos.X - 2, BoardPos.Y - 1] == null)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X - 2, BoardPos.Y - 1)));
                }
            }



            return PossibleMoves;
        }
    }
    public sealed class Rook : ChessPiece
    {
        public bool HasMoved = false;
        public Rook(Point pos, PieceType pieceType, bool isBlack) : base(pos, pieceType, isBlack)
        {
        }

        public override List<Move> Move(ChessPiece[,] Grid)
        {
            List<Move> PossibleMoves = new List<Move>();
            PossibleMoves.Clear();
            for (int i = 1; i < Grid.GetLength(0); i++)
            {

                if (BoardPos.Y + i < Grid.GetLength(0))
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X, BoardPos.Y + i)));

                    if (Grid[BoardPos.X, BoardPos.Y + i] != null)
                    {
                        if (Grid[BoardPos.X, BoardPos.Y + i].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Chess.Move(new Point(BoardPos.X, BoardPos.Y + i)));
                        }
                        break;
                    }

                }

            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {

                if (BoardPos.X + i < Grid.GetLength(0))
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X + i, BoardPos.Y)));

                    if (Grid[BoardPos.X + i, BoardPos.Y] != null)
                    {
                        if (Grid[BoardPos.X + i, BoardPos.Y].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Chess.Move(new Point(BoardPos.X + i, BoardPos.Y)));
                        }
                        break;
                    }

                }

            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {

                if (BoardPos.Y - i >= 0)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X, BoardPos.Y - i)));

                    if (Grid[BoardPos.X, BoardPos.Y - i] != null)
                    {
                        if (Grid[BoardPos.X, BoardPos.Y - i].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Chess.Move(new Point(BoardPos.X, BoardPos.Y - i)));
                        }
                        break;
                    }

                }

            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {

                if (BoardPos.X - i >= 0)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X - i, BoardPos.Y)));

                    if (Grid[BoardPos.X - i, BoardPos.Y] != null)
                    {
                        if (Grid[BoardPos.X - i, BoardPos.Y].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Chess.Move(new Point(BoardPos.X - i, BoardPos.Y)));
                        }
                        break;
                    }

                }

            }


            return PossibleMoves;
        }
    }
    public sealed class King : ChessPiece
    {
        public bool HasMoved = false;
        public King(Point pos, PieceType pieceType, bool isBlack) : base(pos, pieceType, isBlack)
        {

        }
        private bool IsKingSideClear(ChessPiece[,] Grid)
        {
            if (HasMoved) return false;
            if (Grid[BoardPos.X + 1, BoardPos.Y] == null && Grid[BoardPos.X + 2, BoardPos.Y] == null)
            {
                return true;
            }
            return false;
        }

        private bool IsQueenSideClear(ChessPiece[,] Grid)
        {
            if (HasMoved) return false;
            if (Grid[BoardPos.X - 1, BoardPos.Y] == null && Grid[BoardPos.X - 2, BoardPos.Y] == null && Grid[BoardPos.X - 3, BoardPos.Y] == null)
            {
                return true;
            }
            return false;
        }

        private bool CanCastleKingSide(ChessPiece[,] Grid)
        {
            //Check for if rook moved
            if (Grid[7, BoardPos.Y] != null && Grid[7, BoardPos.Y].GetType() == typeof(Rook))
            {
                Rook temp = new Rook(Grid[7, BoardPos.Y].BoardPos, PieceType.Rook, Grid[7, BoardPos.Y].IsBlack);
                if (temp.HasMoved)
                {
                    return false;
                }
            }


            return IsKingSideClear(Grid); 
        }

        private bool CanCastleQueenSide(ChessPiece[,] Grid)
        {
            //Check for if rook moved
            if (Grid[0, BoardPos.Y] != null && Grid[0, BoardPos.Y].GetType() == typeof(Rook))
            {
                Rook temp = new Rook(Grid[0, BoardPos.Y].BoardPos, PieceType.Rook, Grid[0, BoardPos.Y].IsBlack);
                if (temp.HasMoved)
                {
                    return false;
                }
            }
            return IsQueenSideClear(Grid);
        }

        public override List<Move> Move(ChessPiece[,] Grid)
        {
            List<Move> PossibleMoves = new List<Move>();
            PossibleMoves.Clear();

            if (CanCastleKingSide(Grid))
            {
                PossibleMoves.Add(new Chess.Move(new Point(6, BoardPos.Y), Chess.Move.Type.Castling));
            }
            if (CanCastleQueenSide(Grid))
            {
                PossibleMoves.Add(new Chess.Move(new Point(2, BoardPos.Y), Chess.Move.Type.Castling));
            }

            if (BoardPos.Y + 1 < Grid.GetLength(0) && BoardPos.X + 1 < Grid.GetLength(0))
            {
                if ((Grid[BoardPos.X + 1, BoardPos.Y + 1] != null && IsBlack != Grid[BoardPos.X + 1, BoardPos.Y + 1].IsBlack) || Grid[BoardPos.X + 1, BoardPos.Y + 1] == null)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X + 1, BoardPos.Y + 1)));
                }
            }
            if (BoardPos.Y - 1 >= 0 && BoardPos.X - 1 >= 0)
            {
                if ((Grid[BoardPos.X - 1, BoardPos.Y - 1] != null && IsBlack != Grid[BoardPos.X - 1, BoardPos.Y - 1].IsBlack) || Grid[BoardPos.X - 1, BoardPos.Y - 1] == null)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X - 1, BoardPos.Y - 1)));
                }
            }
            if (BoardPos.Y + 1 < Grid.GetLength(0) && BoardPos.X - 1 >= 0)
            {
                if ((Grid[BoardPos.X - 1, BoardPos.Y + 1] != null && IsBlack != Grid[BoardPos.X - 1, BoardPos.Y + 1].IsBlack) || Grid[BoardPos.X - 1, BoardPos.Y + 1] == null)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X - 1, BoardPos.Y + 1)));
                }

            }
            if (BoardPos.Y - 1 >= 0 && BoardPos.X + 1 < Grid.GetLength(0))
            {
                if ((Grid[BoardPos.X + 1, BoardPos.Y - 1] != null && IsBlack != Grid[BoardPos.X + 1, BoardPos.Y - 1].IsBlack) || Grid[BoardPos.X + 1, BoardPos.Y - 1] == null)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X + 1, BoardPos.Y - 1)));
                }
            }
            if (BoardPos.Y + 1 < Grid.GetLength(0))
            {
                if ((Grid[BoardPos.X, BoardPos.Y + 1] != null && IsBlack != Grid[BoardPos.X, BoardPos.Y + 1].IsBlack) || Grid[BoardPos.X, BoardPos.Y + 1] == null)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X, BoardPos.Y + 1)));
                }
            }
            if (BoardPos.Y - 1 >= 0)
            {
                if ((Grid[BoardPos.X, BoardPos.Y - 1] != null && IsBlack != Grid[BoardPos.X, BoardPos.Y - 1].IsBlack) || Grid[BoardPos.X, BoardPos.Y - 1] == null)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X, BoardPos.Y - 1)));
                }
            }
            if (BoardPos.X - 1 >= 0)
            {
                if ((Grid[BoardPos.X - 1, BoardPos.Y] != null && IsBlack != Grid[BoardPos.X - 1, BoardPos.Y].IsBlack) || Grid[BoardPos.X - 1, BoardPos.Y] == null)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X - 1, BoardPos.Y)));
                }
            }
            if (BoardPos.X + 1 < Grid.GetLength(0))
            {
                if ((Grid[BoardPos.X + 1, BoardPos.Y] != null && IsBlack != Grid[BoardPos.X + 1, BoardPos.Y].IsBlack) || Grid[BoardPos.X + 1, BoardPos.Y] == null)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X + 1, BoardPos.Y)));
                }
            }

            return PossibleMoves;
        }
    }
    public sealed class Queen : ChessPiece
    {

        public Queen(Point pos, PieceType pieceType, bool isBlack) : base(pos, pieceType, isBlack)
        {
        }

        public override List<Move> Move(ChessPiece[,] Grid)
        {
            List<Move> PossibleMoves = new List<Move>();
            PossibleMoves.Clear();
            for (int i = 1; i < Grid.GetLength(0); i++)
            {

                if (BoardPos.Y + i < Grid.GetLength(0))
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X, BoardPos.Y + i)));

                    if (Grid[BoardPos.X, BoardPos.Y + i] != null)
                    {
                        if (Grid[BoardPos.X, BoardPos.Y + i].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Chess.Move(new Point(BoardPos.X, BoardPos.Y + i)));
                        }
                        break;
                    }

                }

            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {

                if (BoardPos.X + i < Grid.GetLength(0))
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X + i, BoardPos.Y)));

                    if (Grid[BoardPos.X + i, BoardPos.Y] != null)
                    {
                        if (Grid[BoardPos.X + i, BoardPos.Y].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Chess.Move(new Point(BoardPos.X + i, BoardPos.Y)));
                        }
                        break;
                    }

                }

            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {

                if (BoardPos.Y - i >= 0)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X, BoardPos.Y - i)));

                    if (Grid[BoardPos.X, BoardPos.Y - i] != null)
                    {
                        if (Grid[BoardPos.X, BoardPos.Y - i].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Chess.Move(new Point(BoardPos.X, BoardPos.Y - i)));
                        }
                        break;
                    }

                }

            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {

                if (BoardPos.X - i >= 0)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X - i, BoardPos.Y)));

                    if (Grid[BoardPos.X - i, BoardPos.Y] != null)
                    {
                        if (Grid[BoardPos.X - i, BoardPos.Y].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Chess.Move(new Point(BoardPos.X - i, BoardPos.Y)));
                        }
                        break;
                    }

                }

            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {

                if (BoardPos.Y + i < Grid.GetLength(0) && BoardPos.X + i < Grid.GetLength(0))
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X + i, BoardPos.Y + i)));

                    if (Grid[BoardPos.X + i, BoardPos.Y + i] != null)
                    {
                        if (Grid[BoardPos.X + i, BoardPos.Y + i].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Chess.Move(new Point(BoardPos.X + i, BoardPos.Y + i)));
                        }
                        break;
                    }

                }

            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {
                if (BoardPos.Y - i >= 0 && BoardPos.X + i < Grid.GetLength(0))
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X + i, BoardPos.Y - i)));

                    if (Grid[BoardPos.X + i, BoardPos.Y - i] != null)
                    {
                        if (Grid[BoardPos.X + i, BoardPos.Y - i].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Chess.Move(new Point(BoardPos.X + i, BoardPos.Y - i)));
                        }
                        break;
                    }
                }
            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {
                if (BoardPos.Y + i < Grid.GetLength(0) && BoardPos.X - i >= 0)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X - i, BoardPos.Y + i)));

                    if (Grid[BoardPos.X - i, BoardPos.Y + i] != null)
                    {
                        if (Grid[BoardPos.X - i, BoardPos.Y + i].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Chess.Move(new Point(BoardPos.X - i, BoardPos.Y + i)));
                        }
                        break;
                    }
                }
            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {
                if (BoardPos.Y - i >= 0 && BoardPos.X - i >= 0)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X - i, BoardPos.Y - i)));

                    if (Grid[BoardPos.X - i, BoardPos.Y - i] != null)
                    {
                        if (Grid[BoardPos.X - i, BoardPos.Y - i].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Chess.Move(new Point(BoardPos.X - i, BoardPos.Y - i)));
                        }
                        break;
                    }
                }
            }

            return PossibleMoves;
        }
    }
    public sealed class Bishop : ChessPiece
    {
        public Bishop(Point pos, PieceType pieceType, bool isBlack) : base(pos, pieceType, isBlack)
        {
        }

        public override List<Move> Move(ChessPiece[,] Grid)
        {
            List<Move> PossibleMoves = new List<Move>();
            PossibleMoves.Clear();
            for (int i = 1; i < Grid.GetLength(0); i++)
            {

                if (BoardPos.Y + i < Grid.GetLength(0) && BoardPos.X + i < Grid.GetLength(0))
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X + i, BoardPos.Y + i)));

                    if (Grid[BoardPos.X + i, BoardPos.Y + i] != null)
                    {
                        if (Grid[BoardPos.X + i, BoardPos.Y + i].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Chess.Move(new Point(BoardPos.X + i, BoardPos.Y + i)));
                        }
                        break;
                    }

                }

            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {
                if (BoardPos.Y - i >= 0 && BoardPos.X + i < Grid.GetLength(0))
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X + i, BoardPos.Y - i)));

                    if (Grid[BoardPos.X + i, BoardPos.Y - i] != null)
                    {
                        if (Grid[BoardPos.X + i, BoardPos.Y - i].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Chess.Move(new Point(BoardPos.X + i, BoardPos.Y - i)));
                        }
                        break;
                    }
                }
            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {
                if (BoardPos.Y + i < Grid.GetLength(0) && BoardPos.X - i >= 0)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X - i, BoardPos.Y + i)));

                    if (Grid[BoardPos.X - i, BoardPos.Y + i] != null)
                    {
                        if (Grid[BoardPos.X - i, BoardPos.Y + i].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Chess.Move(new Point(BoardPos.X - i, BoardPos.Y + i)));
                        }
                        break;
                    }
                }
            }
            for (int i = 1; i < Grid.GetLength(0); i++)
            {
                if (BoardPos.Y - i >= 0 && BoardPos.X - i >= 0)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X - i, BoardPos.Y - i)));

                    if (Grid[BoardPos.X - i, BoardPos.Y - i] != null)
                    {
                        if (Grid[BoardPos.X - i, BoardPos.Y - i].IsBlack == IsBlack)
                        {
                            PossibleMoves.Remove(new Chess.Move(new Point(BoardPos.X - i, BoardPos.Y - i)));
                        }
                        break;
                    }
                }
            }


            return PossibleMoves;
        }
    }
    public sealed class Pawn : ChessPiece
    {
        public bool HasMoved = false;
        public bool PotentiallyEnPassantable = false;
        public bool UnEnPassantable => !PotentiallyEnPassantable; //Nikita approved, don't touch;
        public Pawn(Point pos, PieceType pieceType, bool isBlack) : base(pos, pieceType, isBlack)
        {
        }


        public override List<Move> Move(ChessPiece[,] Grid)
        {
            List<Move> PossibleMoves = new List<Move>();

            PossibleMoves.Clear();
            if (!HasMoved)
            { 
                if (BoardPos.Y + 2 < Grid.GetLength(0) && Grid[BoardPos.X, BoardPos.Y + 1] == null && Grid[BoardPos.X, BoardPos.Y + 2] == null && IsBlack)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X, BoardPos.Y + 2), Chess.Move.Type.EnPassant));
                    PotentiallyEnPassantable = true;
                }
                if (BoardPos.Y - 2 >= 0 && Grid[BoardPos.X, BoardPos.Y - 1] == null && Grid[BoardPos.X, BoardPos.Y - 2] == null && !IsBlack)
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X, BoardPos.Y - 2), Chess.Move.Type.EnPassant));
                    PotentiallyEnPassantable = true;
                }
            }

            if (BoardPos.Y + 1 < Grid.GetLength(0) && Grid[BoardPos.X, BoardPos.Y + 1] == null && IsBlack)
            {
                PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X, BoardPos.Y + 1)));
            }
            if (BoardPos.Y - 1 >= 0 && Grid[BoardPos.X, BoardPos.Y - 1] == null && !IsBlack)
            {
                PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X, BoardPos.Y - 1)));
            }

            if (BoardPos.X - 1 >= 0 && BoardPos.Y - 1 >= 0 && Grid[BoardPos.X - 1, BoardPos.Y - 1] != null && !IsBlack && Grid[BoardPos.X - 1, BoardPos.Y - 1].IsBlack != IsBlack)
            {
                PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X - 1, BoardPos.Y - 1)));
            }
            if (BoardPos.X + 1 < Grid.GetLength(0) && BoardPos.Y - 1 >= 0 && Grid[BoardPos.X + 1, BoardPos.Y - 1] != null && !IsBlack && Grid[BoardPos.X + 1, BoardPos.Y - 1].IsBlack != IsBlack)
            {
                PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X + 1, BoardPos.Y - 1)));
            }

            if (BoardPos.X - 1 >= 0 && BoardPos.Y + 1 < Grid.GetLength(0) && Grid[BoardPos.X - 1, BoardPos.Y + 1] != null && IsBlack && Grid[BoardPos.X - 1, BoardPos.Y + 1].IsBlack != IsBlack)
            {
                PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X - 1, BoardPos.Y + 1)));
            }
            if (BoardPos.X + 1 < Grid.GetLength(0) && BoardPos.Y + 1 < Grid.GetLength(0) && Grid[BoardPos.X + 1, BoardPos.Y + 1] != null && IsBlack && Grid[BoardPos.X + 1, BoardPos.Y + 1].IsBlack != IsBlack)
            {
                PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X + 1, BoardPos.Y + 1)));
            }


            //if (BoardPos.X + 1 < Grid.GetLength(0) && Grid[BoardPos.X + 1, BoardPos.Y] != null && Grid[BoardPos.X + 1, BoardPos.Y].IsBlack != IsBlack && !IsBlack && Grid[BoardPos.X + 1, BoardPos.Y].Type == PieceType.Pawn && ((Pawn)Grid[BoardPos.X + 1, BoardPos.Y]).PotentiallyEnPassantable)
            //{
            //    PossibleMoves.Add(new Point(BoardPos.X + 1, BoardPos.Y - 1));
            //    Grid[BoardPos.X + 1, BoardPos.Y] = null;
            //}
            //if (BoardPos.X - 1 >= 0 && Grid[BoardPos.X - 1, BoardPos.Y] != null && Grid[BoardPos.X - 1, BoardPos.Y].IsBlack != IsBlack && !IsBlack && Grid[BoardPos.X - 1, BoardPos.Y].Type == PieceType.Pawn && ((Pawn)Grid[BoardPos.X - 1, BoardPos.Y]).PotentiallyEnPassantable)
            //{
            //    PossibleMoves.Add(new Point(BoardPos.X - 1, BoardPos.Y - 1));
            //    Grid[BoardPos.X - 1, BoardPos.Y] = null;
            //}
            //if (BoardPos.X + 1 < Grid.GetLength(0) && Grid[BoardPos.X + 1, BoardPos.Y] != null && Grid[BoardPos.X + 1, BoardPos.Y].IsBlack != IsBlack && IsBlack && Grid[BoardPos.X + 1, BoardPos.Y].Type == PieceType.Pawn && ((Pawn)Grid[BoardPos.X + 1, BoardPos.Y]).PotentiallyEnPassantable)
            //{
            //    PossibleMoves.Add(new Point(BoardPos.X + 1, BoardPos.Y + 1));
            //    Grid[BoardPos.X + 1, BoardPos.Y] = null;
            //}
            //if (BoardPos.X - 1 >= 0 && Grid[BoardPos.X - 1, BoardPos.Y] != null && Grid[BoardPos.X - 1, BoardPos.Y].IsBlack != IsBlack && IsBlack && Grid[BoardPos.X - 1, BoardPos.Y].Type == PieceType.Pawn && ((Pawn)Grid[BoardPos.X - 1, BoardPos.Y]).PotentiallyEnPassantable)
            //{
            //    PossibleMoves.Add(new Point(BoardPos.X - 1, BoardPos.Y + 1));
            //    Grid[BoardPos.X - 1, BoardPos.Y] = null;
            //}

            return PossibleMoves;
        }

        public void EnPassant(ChessPiece[,] Grid, List<Move> PossibleMoves, Pawn pawn)
        {

            if (pawn.PotentiallyEnPassantable)
            {
                if (BoardPos.X - 1 >= 0 && BoardPos.Y - 1 >= 0 && Grid[BoardPos.X - 1, BoardPos.Y] != null && !IsBlack && Grid[BoardPos.X - 1, BoardPos.Y].IsBlack != IsBlack && Grid[BoardPos.X - 1, BoardPos.Y].GetType() == typeof(Pawn))
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X - 1, BoardPos.Y - 1), Chess.Move.Type.EnPassant));
                }
                if (BoardPos.X + 1 < Grid.GetLength(0) && BoardPos.Y - 1 >= 0 && Grid[BoardPos.X + 1, BoardPos.Y] != null && !IsBlack && Grid[BoardPos.X + 1, BoardPos.Y].IsBlack != IsBlack && Grid[BoardPos.X + 1, BoardPos.Y].GetType() == typeof(Pawn))
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X + 1, BoardPos.Y - 1), Chess.Move.Type.EnPassant));
                }
                if (BoardPos.X - 1 >= 0 && BoardPos.Y + 1 < Grid.GetLength(0) && Grid[BoardPos.X - 1, BoardPos.Y] != null && IsBlack && Grid[BoardPos.X - 1, BoardPos.Y].IsBlack != IsBlack && Grid[BoardPos.X - 1, BoardPos.Y].GetType() == typeof(Pawn))
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X - 1, BoardPos.Y + 1), Chess.Move.Type.EnPassant));
                }
                if (BoardPos.X + 1 < Grid.GetLength(0) && BoardPos.Y + 1 < Grid.GetLength(0) && Grid[BoardPos.X + 1, BoardPos.Y] != null && IsBlack && Grid[BoardPos.X + 1, BoardPos.Y].IsBlack != IsBlack && Grid[BoardPos.X + 1, BoardPos.Y].GetType() == typeof(Pawn))
                {
                    PossibleMoves.Add(new Chess.Move(new Point(BoardPos.X + 1, BoardPos.Y + 1), Chess.Move.Type.EnPassant));
                }
            }
        }
    }
}