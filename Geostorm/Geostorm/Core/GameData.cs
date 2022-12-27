using System.Collections.Generic;
using System.Numerics;
using Raylib_cs;

namespace Geostorm
{
    public class GameData
        {
        public Player player = new Player ();
        List<Entity> entities = new List<Entity>();
        List<Enemy> enemies = new List<Enemy>();
        List<Bullet> bullets = new List<Bullet>();
        List<Blackhole> blackHoles = new List<Blackhole>();
        public int level;
        public Vector2 screenSize;


        // Accessors (Cannot add/remove from list)
        public IEnumerable<Entity> Entities { get { return entities; } }
        public IEnumerable<Enemy> Enemies { get { return enemies; } }
        public IEnumerable<Bullet> Bullets { get { return bullets; } }
        public IEnumerable<Blackhole> Blackholes { get { return blackHoles; } }

        List<Enemy> addedEnemies = new List<Enemy>();
        List<Bullet> addedBullets = new List<Bullet>();
        List<Blackhole> addedBlackhole = new List<Blackhole>();

        public Sounds musicAndSounds = new Sounds();
        public GameData(Vector2 screenSize)
        {
            level = 1;
            entities.Add(player);
            this.screenSize = screenSize;
        }
        public void AddEnemyDelayed(Enemy enemy)
        {
            switch (level)
            {
                case 1 :
                {
                    if (enemies.Count < 25)
                    addedEnemies.Add(enemy);
                        break;
                }
                case 2:
                {
                    if (enemies.Count < 50)
                        addedEnemies.Add(enemy);
                    break;
                }
                case 3:
                {
                    if (enemies.Count < 100)
                        addedEnemies.Add(enemy);
                    break;
                }
                case 4:
                {
                    if (enemies.Count < 150)
                        addedEnemies.Add(enemy);
                    break;
                }
                default:
                {
                    if (enemies.Count < 200)
                        addedEnemies.Add(enemy);
                    break;

                }

            }

        }

        public void AddBullet(Bullet bullet)
        {
            addedBullets.Add(bullet);
            Raylib.PlaySound(musicAndSounds.shootSound);
        }

        public void AddBlackHole(Blackhole blackHole)
        { 
            addedBlackhole.Add(blackHole);
        }
        public void Update()
        {
            Synchronize();
        }

        public void Synchronize()
        {
            // Add new entities
            entities.AddRange(addedEnemies);
            enemies.AddRange(addedEnemies);
            entities.AddRange(addedBullets);
            bullets.AddRange(addedBullets);
            entities.AddRange(addedBlackhole);
            blackHoles.AddRange(addedBlackhole);

            // Clear transient lists
            addedEnemies.Clear();
            addedBullets.Clear();
            addedBlackhole.Clear();

            entities.RemoveAll(entity => entity.isDead);
            enemies.RemoveAll(entity => entity.isDead);
            bullets.RemoveAll(entity => entity.isDead);
            blackHoles.RemoveAll(entity => entity.isDead);
        }

    }
}
