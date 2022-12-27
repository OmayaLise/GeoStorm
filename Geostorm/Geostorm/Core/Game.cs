
using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;

namespace Geostorm
{
    class Game
    {
        GameData gameData;
        List<ISystem> allSys = new List<ISystem>();
        Graphics graphics = new Graphics();
        List<Vector2> particles = new List<Vector2>();

        public Game(GameData gameData)
        {
            this.gameData = gameData;
            allSys.Add(new EnemySpawn());
            allSys.Add(new CollisionSystem());
            allSys.Add(new NextLevel());
            this.gameData.player.position = new Vector2(gameData.screenSize.X / 2, gameData.screenSize.Y / 2);
        }

        public void Update (GameInputs gameInputs)
        {
            if(!gameData.player.isDead)
            {
                gameInputs.Update();

                if (!gameInputs.paused)
                {
                    foreach (ISystem system in allSys)
                    {
                        system.Update(gameInputs, gameData);
                    }

                    foreach (Entity entity in gameData.Entities)
                        entity.Update(gameInputs, gameData);
                    gameData.Update();
                }
                else
                    graphics.DrawPause(gameData.screenSize);
     
            }
            Render(graphics);

        }

        public void Render(Graphics graphics)
        {
            if (!gameData.player.isDead)
            {
                gameData.player.Draw(graphics);

                foreach (Entity entity in gameData.Entities)
                    entity.Draw(graphics);
                graphics.DrawInterface(gameData.level, gameData.screenSize);
            }

            else
            {
                Raylib.StopMusicStream(gameData.musicAndSounds.musicLoop);
                Raylib.PlayMusicStream(gameData.musicAndSounds.musicGameOver);
                graphics.DrawGameOver(gameData.player.score, gameData.screenSize);
            }
                
        }
    }
}
