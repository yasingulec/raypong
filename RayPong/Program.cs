using Raylib_cs;
using RayPong.src;
using static RayPong.src.Enums;

int screenWidth = 1280;
int screenHeight = 800;
int p1Score = 0;
int p2Score = 0;

Raylib.InitWindow(screenWidth, screenHeight, "RayPong");
Raylib.SetTargetFPS(60);

// initializing the ball object
var ball = new Ball
{
    color = Color.White,
    radius = 10f,
    x = screenWidth / 2,
    y = screenHeight / 2,
    xSpeed = 10,
    ySpeed = 10,
};

var p1 = new Paddle
{
    x = 10,
    y = screenHeight / 2 - 60,
    width = 20,
    height = 120,
    color = Color.White,
    ySpeed = 10,
    PlayerType = Enums.Player.P1,
    score = 0
};

var p2 = new Paddle
{
    x = screenWidth - 30,
    y = screenHeight / 2 - 60,
    width = 20,
    height = 120,
    color = Color.White,
    ySpeed = 10,
    PlayerType = Enums.Player.P2,
    score = 0
};

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);

    // rendering paddles
    p1.Render();
    p2.Render();

    p1.Update();
    p2.Update();

    var status = ball.Update(p1,p2);


    if (status == Enums.Player.P1)
    {
        p1.score += 10;

        ball.Reset();

        if (p1.score == 100)
        {
            Raylib.ClearBackground(Color.Black);

            Raylib.DrawText("P1 Wins!!!", screenWidth / 2, screenHeight / 2, 100, Color.White);

            ball.xSpeed = 0;
            ball.ySpeed = 0;
        }
    }

    if (status == Enums.Player.P2)
    {
        p2.score += 10;

        ball.Reset();

        if (p2.score == 100)
        {
            Raylib.ClearBackground(Color.Black);

            Raylib.DrawText("P2 Wins!!!", screenWidth / 2, screenHeight / 2, 100, Color.White);

            ball.xSpeed = 0;
            ball.ySpeed = 0;
        }
    }

    Raylib.DrawText(p1.score.ToString(), 50, 10, 50, Color.White);

    Raylib.DrawText(p2.score.ToString(), screenWidth - 100, 10, 50, Color.White);


    Raylib.EndDrawing();
}

Raylib.CloseWindow();
