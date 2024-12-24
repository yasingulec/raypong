using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
namespace RayPong.src
{
    public class Ball
    {
        public int x { get; set; }

        public int y { get; set; }

        public float radius { get; set; }

        public Color color { get; set; }

        public int xSpeed { get; set; }

        public int ySpeed { get; set; }


        public void Render()
        {
            Raylib.DrawCircle(x, y, radius, color);
        }

        public Enums.Player Update(Paddle player1, Paddle player2)
        {
            Render();

            // Move the ball based on its speed (velocity)
            x += xSpeed;
            y += ySpeed;

            // Check for collisions with top and bottom boundaries
            if (y <= 0 || y + radius * 2 >= Raylib.GetScreenHeight())
            {
                ySpeed = -ySpeed;  // Reverse vertical direction on top/bottom collision
            }

            // Check for collisions with player paddles
            if (player1.CheckCollisionWithBall(this))
            {
                // Reverse horizontal direction if the ball hits Player 1's paddle
                xSpeed = -xSpeed;

                // Optional: Add more dynamic behavior like modifying the vertical speed based on where it hits
                float hitPosition = (y + radius) - (player1.y + player1.height / 2);
                ySpeed += (int)(hitPosition * 0.1f);  // Explicit cast to int
            }

            if (player2.CheckCollisionWithBall(this))
            {
                // Reverse horizontal direction if the ball hits Player 2's paddle
                xSpeed = -xSpeed;

                // Optional: Add more dynamic behavior for Player 2's paddle
                float hitPosition = (y + radius) - (player2.y + player2.height / 2);
                ySpeed += (int)(hitPosition * 0.1f);  // Explicit cast to int
            }

            // Check if the ball goes out of bounds on the right side
            if (x + radius * 2 >= Raylib.GetScreenWidth())
            {
                // Player 1 scores a point
                return Enums.Player.P1;
            }

            // Check if the ball goes out of bounds on the left side
            if (x - radius <= 0)
            {
                // Player 2 scores a point
                return Enums.Player.P2;
            }

            // Default return value, no scoring or events
            return Enums.Player.Default;
        }

        // Resets the ball in middle
        public void Reset()
        {
            x = Raylib.GetScreenWidth() / 2;
            y = Raylib.GetScreenHeight() / 2;
        }
    }
}
