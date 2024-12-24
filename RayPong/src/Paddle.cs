using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayPong.src
{
    public class Paddle
    {
        public int x { get; set; }

        public int y { get; set; }

        public int width { get; set; }

        public int height { get; set; }

        public Color color { get; set; }

        public int ySpeed { get; set; }

        public int score { get; set; }

        public Enums.Player PlayerType { get; set; }

        public void Render()
        {
            Raylib.DrawRectangle(x, y, width, height, color);
        }

        public void Update()
        {
            if (PlayerType == Enums.Player.P1)
            {
                if (Raylib.IsKeyDown(KeyboardKey.W))
                {
                    y -= ySpeed;
                }

                if (Raylib.IsKeyDown(KeyboardKey.S))
                {
                    y += ySpeed;
                }
            }

            if (PlayerType == Enums.Player.P2)
            {
                if (Raylib.IsKeyDown(KeyboardKey.Up))
                {
                    y -= ySpeed;
                }

                if (Raylib.IsKeyDown(KeyboardKey.Down))
                {
                    y += ySpeed;
                }
            }

            if (y <= 0)
            {
                y = 0;
            }

            if (y + height > Raylib.GetScreenHeight())
            {
                y = Raylib.GetScreenHeight() - height;
            }
        }

        public void CheckStatus(Ball ball)
        {

        }

        public bool CheckCollisionWithBall(Ball ball)
        {
            // Check if the ball's horizontal position is within the paddle's range
            bool collisionX = ball.x + ball.radius >= x && ball.x <= x + width;

            // Check if the ball's vertical position is within the paddle's range
            bool collisionY = ball.y + ball.radius >= y && ball.y <= y + height;

            return collisionX && collisionY;
        }

    }
}
