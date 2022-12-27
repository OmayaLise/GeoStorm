using System;
using System.Numerics;

namespace Geostorm
{
   public class Weapon
    {
        public int level;
        public int frequency;
        public int timer;
        public float speed;
        public float rotation;
        public Weapon ()
        {
            level = 1;
            frequency = 25;
            timer = 0;
            rotation = 0;
            speed = 10f;
        }
        public void Update(in GameInputs gameInputs, GameData gameData) 
        {
            timer++;
            
            if (timer> frequency && gameInputs.shoot)
            {
                // TODO switch for level
                if (gameData.player.score > 500 &&  gameData.player.score < 1000 )
                { 
                        level = 2;
                        frequency = 20;

                    
                }

                if (gameData.player.score > 1000 && gameData.player.score < 2000)
                {
                    level = 3;
                    frequency = 15;

                }

                if (gameData.player.score > 2000)
                {
                    level = 4;
                    frequency = 10;
                }

                Vector2 dir = (gameInputs.shootAxis - gameData.player.position);
                dir = Vector2.Normalize(dir);
                if (gameInputs.shootAxis != new Vector2())
                {
                    rotation = MathF.Atan2(dir.Y, dir.X);
                }
                
                Bullet bullet = new Bullet(gameData.player.position, rotation, dir*speed);
                gameData.AddBullet(bullet);
                timer = 0;
            }

        }
    }
}
