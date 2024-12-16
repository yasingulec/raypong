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

            if (y + radius >= Raylib.GetRenderHeight() ||y - radius <=0)
            {
                ySpeed *= -1;
            }

            if (x + radius >= Raylib.GetRenderWidth() || x - radius <= 0)
            {
                xSpeed *= -1;
            }
        }

        public void Update()
        {
            x += xSpeed;
            y += ySpeed;
        }
    }
}
