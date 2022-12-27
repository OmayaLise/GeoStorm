using Raylib_cs;
using System.Numerics;
using System;
using System.Reflection;
using System.IO;

namespace Geostorm
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitAudioDevice();
            Raylib.SetTargetFPS(60);

            Vector2 screenSize = new Vector2(Console.LargestWindowWidth, 900);
            Raylib.SetConfigFlags(ConfigFlags.FLAG_MSAA_4X_HINT | ConfigFlags.FLAG_VSYNC_HINT | ConfigFlags.FLAG_WINDOW_RESIZABLE);
            Raylib.InitWindow((int)screenSize.X, (int) screenSize.Y, "Geostorm");

            GameInputs gameInputs = new GameInputs(screenSize);
            GameData gameData = new GameData(screenSize);
            Game game = new Game(gameData); 

            Raylib.PlayMusicStream(gameData.musicAndSounds.musicLoop);

            ImguiController controller = new ImguiController();
            controller.Load((int)screenSize.X, (int)screenSize.Y);

            while (!Raylib.WindowShouldClose())
            {
                if (gameInputs.exit)
                    Raylib.CloseWindow();

                    if (!gameData.player.isDead)
                        Raylib.UpdateMusicStream(gameData.musicAndSounds.musicLoop);
                    else
                        Raylib.UpdateMusicStream(gameData.musicAndSounds.musicGameOver);

                    float dt = Raylib.GetFrameTime();
                    // Feed the input events to our ImGui controller, which passes them through to ImGui.
                    controller.Update(dt);

                    // Draw
                    //----------------------------------------------------------------------------------
                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.BLACK);

                    controller.Draw();

                    game.Update(gameInputs);

                    Raylib.EndDrawing();

            }

            controller.Dispose();
            Raylib.CloseAudioDevice();
            Raylib.CloseWindow();
        }
    }
}


