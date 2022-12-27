using System.Numerics;
using Raylib_cs;


namespace Geostorm
{
    public class GameInputs
    {
        public Vector2 screenSize;
        public float deltaTime;
        public Vector2 moveAxis;
        public Vector2 shootAxis;
        public bool shoot;
        public bool paused;
        public bool exit;

        public GameInputs (Vector2 screenSize)
        {
            this.screenSize = screenSize;
            deltaTime = 0f;
            moveAxis.X = 0f;
            moveAxis.Y = 0f;
            shoot = false;
            paused = false;
            exit = false;
        }
        public void Update ()
        {
            deltaTime = Raylib.GetFrameTime();

            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
              moveAxis.X ++ ;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
              moveAxis.X --;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
              moveAxis.Y --;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
              moveAxis.Y ++;
            if (Raylib.IsKeyReleased(KeyboardKey.KEY_P))
                paused = !paused;
            if (Raylib.IsKeyReleased(KeyboardKey.KEY_ESCAPE))
                exit = true;

             shootAxis = Raylib.GetMousePosition();

            if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
                shoot = true;
            else
                shoot = false;



        }

        public void ResetMove()
        {
            moveAxis.X = 0;
            moveAxis.Y = 0;

        }
    }
}
