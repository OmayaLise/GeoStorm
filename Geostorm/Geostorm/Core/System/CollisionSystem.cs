
using System;
using System.Numerics;
using Raylib_cs;

namespace Geostorm
{
    public class CollisionSystem : ISystem
    {
        public override void Update(in GameInputs gameInputs, GameData gameData)
        {
            //Update collision enemies
            foreach (Enemy enemy in gameData.Enemies)
            {
                if (!enemy.isSpawn)
                    continue;
                else
                {
                    float distance = Vector2.Distance(gameData.player.position, enemy.position);
                    if (distance < gameData.player.collision + enemy.collision)
                    {
                        gameData.player.life--;
                        enemy.isDead = true;
                    }

                    foreach (Bullet bullet in gameData.Bullets)
                    {
                        float distanceBullet = Vector2.Distance(bullet.position, enemy.position);
                        if (distanceBullet < bullet.collision + enemy.collision)
                        {
                            bullet.isDead = true;
                            enemy.isDead = true;
                            Raylib.DrawCircleV(enemy.position, 25f, Color.YELLOW);
                            gameData.player.score += enemy.scorePoints;
                        }

                    }
                }
            }

            //Update collision blackhole
            foreach (Blackhole blackhole1 in gameData.Blackholes)
            {
                if (!blackhole1.isSpawn)
                    continue;

                foreach (Entity entity in gameData.Entities)
                {
                    if (entity == blackhole1)
                        continue;

                    float distanceBlackhole = Vector2.Distance(entity.position, blackhole1.position);
                    if (distanceBlackhole > entity.collision + blackhole1.collision)
                        continue;

                    // TODO switch 
                    if (entity is Player)
                    {
                        Player player = entity as Player;
                        player.life--;
                        gameData.player.color = Color.RED;
                        blackhole1.isDead = true;
                    }
                    else if (entity is Enemy)
                    {
                        Enemy enemy = entity as Enemy;

                        if (enemy.isSpawn)
                            entity.isDead = true;
                    }
                    else if (entity is Bullet)
                    {
                        blackhole1.isDead = true;
                        gameData.player.score += blackhole1.scorePoints;
                        Raylib.DrawCircleV(blackhole1.position, 50f, Color.RED);
                    }
                    else if (entity is Blackhole)
                    {
                        Blackhole blackhole2 = entity as Blackhole;
                        if(blackhole2.isSpawn)
                        {
                            blackhole1.explosion = true;
                        }
                    }
                           
                    }
            }

            // Explosion effect
            foreach (Blackhole blackhole in gameData.Blackholes)
            {
                if (blackhole.explosion)
                {
                    blackhole.explosionTimer++;
                    foreach (Entity entity in gameData.Entities)
                    {
                        float distanceExplosion = Vector2.Distance(entity.position, blackhole.position);
                        if (distanceExplosion < 200)
                        {
                            if (entity is Enemy)
                                entity.isDead = true;
                                
                            if (entity is Player)
                            {
                                Player player = entity as Player;
                                player.life--;
                                gameData.player.color = Color.RED;
                            }

                        }
                    }

                    if (blackhole.explosionTimer > 3)
                    {
                        blackhole.isDead = true;
                        blackhole.explosion = false;

                    }
                }
            }

            if (gameData.player.life <= 0)
            {
                gameData.player.isDead = true;
            }
        }
    }
}
