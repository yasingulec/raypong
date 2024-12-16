using Raylib_cs;
using RayPong.src;

int screenWidth = 1280;
int screenHeight = 800;

Raylib.InitWindow(screenWidth, screenHeight, "RayPong");
Raylib.SetTargetFPS(60);

// initializing the ball object
var ball = new Ball
{
    color = Color.White,
    radius=10f,
    x=screenWidth/2,
    y=screenHeight/2,
    xSpeed=10,
    ySpeed=10,
};

while (!Raylib.WindowShouldClose())
{
    
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);
    ball.Render();
    ball.Update();

    Raylib.EndDrawing();
}

Raylib.CloseWindow();
