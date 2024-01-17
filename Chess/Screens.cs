using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MonoGame.Extended;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class MenuScreen : Screen
    {
        public override void Begin()
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override Screenum Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
    public class GameScreen : Screen
    {
        bool WhiteTurn = true;
        const int size = 73;
        public ChessPiece SelectedPiece = null;
        public Texture2D ChessBoardTex;
        public static Texture2D ChessPiecesTex;
        public ChessBoard chessBoard;
        public List<Move> PossibleMoves;
        bool drawCheck;
        MouseState prevState;
        bool inCheck = false;
        bool checkMate = false;
        bool pawnPromotion = false;
        ChessPiece promotingPawn;

        public Dictionary<Textures, Rectangle> sprites = new Dictionary<Textures, Rectangle>()
        {
            [Textures.Queen] = new Rectangle(4, 70, 52, 48),
            [Textures.King] = new Rectangle(67, 70, 47, 47),
            [Textures.Rook] = new Rectangle(132, 70, 38, 42),
            [Textures.Knight] = new Rectangle(188, 70, 45, 44),
            [Textures.Bishop] = new Rectangle(247, 70, 46, 46),
            [Textures.Pawn] = new Rectangle(315, 70, 33, 43),
        };

        public static Dictionary<ChessPiece.PieceType, (Textures, Rectangle)> PieceToSprite = new Dictionary<ChessPiece.PieceType, (Textures, Rectangle)>()
        {
            [ChessPiece.PieceType.Pawn] = (Textures.Pawn, new Rectangle(315, 70, 33, 43)),
            [ChessPiece.PieceType.King] = (Textures.King, new Rectangle(67, 70, 47, 47)),
            [ChessPiece.PieceType.Queen] = (Textures.Queen, new Rectangle(4, 70, 52, 48)),
            [ChessPiece.PieceType.Rook] = (Textures.Rook, new Rectangle(132, 70, 38, 42)),
            [ChessPiece.PieceType.Knight] = (Textures.Knight, new Rectangle(188, 70, 45, 44)),
            [ChessPiece.PieceType.Bishop] = (Textures.Bishop, new Rectangle(247, 70, 46, 46)),

        };

        public void Load(string fen)
        {
            int x = 0;
            int y = 0;
            for (int i = 0; i < fen.Length; i++)
            {
                int spaces = 0;

                if (int.TryParse(fen[i].ToString(), out spaces))
                {
                    x += spaces;
                }
                else
                {
                    switch (fen[i])
                    {

                        case '/':

                            y++;
                            x = -1;

                            break;

                        case 'r':

                            chessBoard.Grid[x, y] = new Rook(new Point(x, y), ChessPiece.PieceType.Rook, true);

                            break;
                        case 'n':

                            chessBoard.Grid[x, y] = new Knight(new Point(x, y), ChessPiece.PieceType.Knight, true);

                            break;
                        case 'b':

                            chessBoard.Grid[x, y] = new Bishop(new Point(x, y), ChessPiece.PieceType.Bishop, true);

                            break;
                        case 'q':

                            chessBoard.Grid[x, y] = new Queen(new Point(x, y), ChessPiece.PieceType.Queen, true);

                            break;
                        case 'k':

                            chessBoard.Grid[x, y] = new King(new Point(x, y), ChessPiece.PieceType.King, true);

                            break;

                        case 'p':

                            chessBoard.Grid[x, y] = new Pawn(new Point(x, y), ChessPiece.PieceType.Pawn, true);

                            break;

                        case 'R':

                            chessBoard.Grid[x, y] = new Rook(new Point(x, y), ChessPiece.PieceType.Rook, false);

                            break;

                        case 'N':

                            chessBoard.Grid[x, y] = new Knight(new Point(x, y), ChessPiece.PieceType.Knight, false);

                            break;
                        case 'B':

                            chessBoard.Grid[x, y] = new Bishop(new Point(x, y), ChessPiece.PieceType.Bishop, false);

                            break;
                        case 'Q':

                            chessBoard.Grid[x, y] = new Queen(new Point(x, y), ChessPiece.PieceType.Queen, false);

                            break;
                        case 'K':

                            chessBoard.Grid[x, y] = new King(new Point(x, y), ChessPiece.PieceType.King, false);

                            break;
                        case 'P':

                            chessBoard.Grid[x, y] = new Pawn(new Point(x, y), ChessPiece.PieceType.Pawn, false);

                            break;

                    }
                    x++;
                }


            }
        }


        public override void Begin()
        {
            chessBoard = new ChessBoard(ChessBoardTex, Game1.GameDimensions, Color.White, 0, Vector2.Zero);
            Load("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR");

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            chessBoard.Draw(spriteBatch);

            if (SelectedPiece != null)
            {
                spriteBatch.DrawRectangle(new Rectangle(50 + SelectedPiece.BoardPos.X * size, size * SelectedPiece.BoardPos.Y, 75, 75), Color.Red, 1, 0);
            }
            if (PossibleMoves != null)
            {
                for (int i = 0; i < PossibleMoves.Count; i++)
                {
                    spriteBatch.DrawRectangle(new Rectangle(50 + PossibleMoves[i].Destination.X * size, size * PossibleMoves[i].Destination.Y, 75, 75), Color.Lime, 1, 0);
                }
            }
            if (drawCheck)
            {
                Point KingPos = chessBoard.FindKing(WhiteTurn);

                spriteBatch.DrawRectangle(new Rectangle(50 + KingPos.X * size, size * KingPos.Y, 75, 75), Color.Red, 1, 0);

            }
            if (checkMate)
            {
                Game1.gameFont.DrawString(spriteBatch);
            }
            if (pawnPromotion)
            {
                chessBoard.DrawPromotionPieces(spriteBatch, promotingPawn.IsBlack);
            }

            spriteBatch.End();
        }

        public override Screenum Update(GameTime gameTime)
        {
            MouseState currState = Mouse.GetState();

            inCheck = chessBoard.IsInCheck(WhiteTurn);

            if (inCheck) drawCheck = true;

            if (currState.LeftButton == ButtonState.Pressed && prevState.LeftButton == ButtonState.Released)
            {
                Point pos = new Point((currState.Position.X - 50) / size, currState.Position.Y / size);
                if (pos.X < 8 && pos.Y < 8)
                 {
                    #region

                    if (pawnPromotion)
                    {
                        for (int i = 0; i < chessBoard.PromotionPieces.Count; i++)
                        {
                            if (chessBoard.PromotionPieces[i].Intersects(new Rectangle(currState.Position.X, currState.Position.Y, 5, 5)))
                            {
                                promotingPawn = chessBoard.PawnPromotion((Pawn)promotingPawn, chessBoard.RectangleToPieceType[chessBoard.PromotionPieces[i]]);

                                switch(promotingPawn.Type)
                                {
                                    case ChessPiece.PieceType.Queen:
                                        chessBoard.Grid[promotingPawn.BoardPos.X, promotingPawn.BoardPos.Y] = new Queen(new Point(promotingPawn.BoardPos.X, promotingPawn.BoardPos.Y), promotingPawn.Type, promotingPawn.IsBlack);
                                        break;
                                    case ChessPiece.PieceType.Rook:
                                        chessBoard.Grid[promotingPawn.BoardPos.X, promotingPawn.BoardPos.Y] = new Rook(new Point(promotingPawn.BoardPos.X, promotingPawn.BoardPos.Y), promotingPawn.Type, promotingPawn.IsBlack);
                                        break;
                                    case ChessPiece.PieceType.Knight:
                                        chessBoard.Grid[promotingPawn.BoardPos.X, promotingPawn.BoardPos.Y] = new Knight(new Point(promotingPawn.BoardPos.X, promotingPawn.BoardPos.Y), promotingPawn.Type, promotingPawn.IsBlack);
                                        break;
                                    case ChessPiece.PieceType.Bishop:
                                        chessBoard.Grid[promotingPawn.BoardPos.X, promotingPawn.BoardPos.Y] = new Bishop(new Point(promotingPawn.BoardPos.X, promotingPawn.BoardPos.Y), promotingPawn.Type, promotingPawn.IsBlack);
                                        break;

                                }


                                pawnPromotion = false;
                            }

                        }  
                    }

                    if (PossibleMoves != null && SelectedPiece != null)
                    {
                        if (PossibleMoves.Any(Pos => Pos.Destination == pos))
                        {
                            chessBoard.Grid[SelectedPiece.BoardPos.X, SelectedPiece.BoardPos.Y] = null;
                            SelectedPiece.BoardPos = new Point(pos.X, pos.Y);
                            if (SelectedPiece.GetType() == typeof(Pawn) && SelectedPiece.BoardPos.Y == 0 && !SelectedPiece.IsBlack)
                            {
                                pawnPromotion = true;
                                promotingPawn = (Pawn)SelectedPiece;
                            }
                            if (SelectedPiece.GetType() == typeof(Pawn) && SelectedPiece.BoardPos.Y == 7 && SelectedPiece.IsBlack)
                            { 
                                pawnPromotion = true;
                                promotingPawn = (Pawn)SelectedPiece;
                            }

                            chessBoard.Grid[pos.X, pos.Y] = SelectedPiece;

                            Move currentMove = PossibleMoves.Where(Pos => Pos.Destination == pos).FirstOrDefault();


                            if (currentMove.Property == Move.Type.EnPassant)
                            {
                                if (chessBoard.Grid[pos.X, pos.Y + 1] != null && chessBoard.Grid[pos.X, pos.Y + 1].GetType() == typeof(Pawn) && chessBoard.Grid[pos.X, pos.Y + 1].IsBlack)
                                {
                                    chessBoard.Grid[pos.X, pos.Y + 1] = null;
                                }
                                else if (chessBoard.Grid[pos.X, pos.Y - 1] != null && chessBoard.Grid[pos.X, pos.Y - 1].GetType() == typeof(Pawn) && !chessBoard.Grid[pos.X, pos.Y - 1].IsBlack)
                                {
                                    chessBoard.Grid[pos.X, pos.Y - 1] = null;
                                }
                            }
                            if (currentMove.Property == Move.Type.Castling)
                            {
                                if (currentMove.Destination.X == 6)
                                {

                                    chessBoard.Grid[5, pos.Y] = chessBoard.Grid[7, pos.Y];
                                    chessBoard.Grid[5, pos.Y].BoardPos = new Point(5, pos.Y);

                                    chessBoard.Grid[7, pos.Y] = null;
                            
                                }
                                else if (currentMove.Destination.X == 2)
                                {

                                    chessBoard.Grid[3, pos.Y] = chessBoard.Grid[0, pos.Y];
                                    chessBoard.Grid[3, pos.Y].BoardPos = new Point(3, pos.Y);


                                    chessBoard.Grid[0, pos.Y] = null;
                                }
                            }


                            for (int x = 0; x < chessBoard.Grid.GetLength(0); x++)
                            {
                                for (int y = 0; y < chessBoard.Grid.GetLength(0); y++)
                                {
                                    if (chessBoard.Grid[x, y] != null && chessBoard.Grid[x, y].GetType() == typeof(Pawn) && chessBoard.Grid[x, y].IsBlack == WhiteTurn)
                                    {
                                        var pawn = (Pawn)chessBoard.Grid[x, y];
                                        pawn.PotentiallyEnPassantable = false;
                                    }
                                }
                            }

                            if (chessBoard.Grid[pos.X, pos.Y].GetType() == typeof(Pawn))
                            {
                                var pawn = (Pawn)chessBoard.Grid[pos.X, pos.Y];
                                pawn.HasMoved = true;

                            }
                            if (chessBoard.Grid[pos.X, pos.Y].GetType() == typeof(King))
                            {
                                var king = (King)chessBoard.Grid[pos.X, pos.Y];
                                king.HasMoved = true;

                            }
                            if (chessBoard.Grid[pos.X, pos.Y].GetType() == typeof(Rook))
                            {
                                var rook = (Rook)chessBoard.Grid[pos.X, pos.Y];
                                rook.HasMoved = true;

                            }


                            PossibleMoves = SelectedPiece.Move(chessBoard.Grid);
                          


                            WhiteTurn = !WhiteTurn;

                            PossibleMoves.Clear();
                        }
                        else
                        {
                            SelectedPiece = null;
                            PossibleMoves.Clear();
                        }
                    }

                    if (SelectedPiece != null && SelectedPiece == chessBoard.Grid[pos.X, pos.Y])
                    {
                        SelectedPiece = null;
                        PossibleMoves.Clear();
                    }
                    else
                    {
                        if (pos.X >= 0 && pos.X < chessBoard.Grid.GetLength(0) && pos.Y >= 0 && pos.Y < chessBoard.Grid.GetLength(0))
                        {
                            if (chessBoard.Grid[pos.X, pos.Y] != null && chessBoard.Grid[pos.X, pos.Y].IsBlack == !WhiteTurn)
                            {
                                SelectedPiece = chessBoard.Grid[pos.X, pos.Y];
                                PossibleMoves = new List<Move>();

                                if (SelectedPiece != null)
                                {
                                    var potentialMoves = SelectedPiece.Move(chessBoard.Grid);

                                    for (int i = 0; i < potentialMoves.Count; i++)
                                    {
                                        var tempBoardPos = SelectedPiece.BoardPos;
                                        ChessPiece tempPiece = chessBoard.Grid[potentialMoves[i].Destination.X, potentialMoves[i].Destination.Y];
                                        Point tempGridPos = new Point(potentialMoves[i].Destination.X, potentialMoves[i].Destination.Y);

                                        SelectedPiece.BoardPos = new Point(potentialMoves[i].Destination.X, potentialMoves[i].Destination.Y);
                                        chessBoard.Grid[potentialMoves[i].Destination.X, potentialMoves[i].Destination.Y] = SelectedPiece;

                                        var tempPreviousPos = chessBoard.Grid[pos.X, pos.Y];

                                        chessBoard.Grid[pos.X, pos.Y] = null;

                                        if (!chessBoard.IsInCheck(!SelectedPiece.IsBlack))
                                        {
                                            PossibleMoves.Add(potentialMoves[i]);
                                        }


                                        chessBoard.Grid[pos.X, pos.Y] = tempPreviousPos;

                                        SelectedPiece.BoardPos = tempBoardPos;
                                        chessBoard.Grid[tempGridPos.X, tempGridPos.Y] = tempPiece;

                                        if (chessBoard.IsInCheckMate(!SelectedPiece.IsBlack))
                                        {
                                            checkMate = true;
                                        }

                                    }

                                }


                            }
                        }
                        if (SelectedPiece != null && SelectedPiece.GetType() == typeof(Pawn))
                        {
                            Pawn temp = (Pawn)SelectedPiece;

                            if (SelectedPiece.BoardPos.X - 1 > 0 && chessBoard.Grid[SelectedPiece.BoardPos.X - 1, SelectedPiece.BoardPos.Y] != null && chessBoard.Grid[SelectedPiece.BoardPos.X - 1, SelectedPiece.BoardPos.Y].GetType() == typeof(Pawn) && SelectedPiece.IsBlack != chessBoard.Grid[SelectedPiece.BoardPos.X - 1, SelectedPiece.BoardPos.Y].IsBlack)
                            {
                                temp.EnPassant(chessBoard.Grid, PossibleMoves, (Pawn)chessBoard.Grid[SelectedPiece.BoardPos.X - 1, SelectedPiece.BoardPos.Y]);
                            }
                            if (SelectedPiece.BoardPos.X + 1 < chessBoard.Grid.GetLength(0) && chessBoard.Grid[SelectedPiece.BoardPos.X + 1, SelectedPiece.BoardPos.Y] != null && chessBoard.Grid[SelectedPiece.BoardPos.X + 1, SelectedPiece.BoardPos.Y].GetType() == typeof(Pawn) && SelectedPiece.IsBlack != chessBoard.Grid[SelectedPiece.BoardPos.X + 1, SelectedPiece.BoardPos.Y].IsBlack)
                            {
                                temp.EnPassant(chessBoard.Grid, PossibleMoves, (Pawn)chessBoard.Grid[SelectedPiece.BoardPos.X + 1, SelectedPiece.BoardPos.Y]);
                            }
                        }
                    }


                    #endregion

                }
            }



            if (SelectedPiece != null)
            {
                //PossibleMoves = SelectedPiece.Move(chessBoard.Grid);
            }

            prevState = currState;

            return Screenum.Game;
        }
    }
}
