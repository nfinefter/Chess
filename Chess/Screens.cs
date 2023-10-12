﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MonoGame.Extended;

using System;
using System.Collections.Generic;
using System.Linq;
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

        public Texture2D ChessBoardTex;
        public static Texture2D ChessPiecesTex;
        public ChessBoard chessBoard;

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

            spriteBatch.DrawRectangle(new Rectangle(50, 0, 75, 75), Color.Red, 1, 0);


            spriteBatch.End();
        }

        public override Screenum Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                Point pos = new Point(mouseState.Position.X / 75, mouseState.Position.Y / 75);
            }
            

            return Screenum.Game;
        }
    }
}
