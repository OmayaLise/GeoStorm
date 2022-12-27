using System.Numerics;

namespace Geostorm
{
    public class Blackhole : Entity
    {
        public int scorePoints;
        public float pull;
        public int timer;
        public int delaySpawn;
        public bool explosion;
        public int explosionTimer;
        public bool drawCircle;
        public Blackhole(Vector2 position)
        {
            this.position = position;
            collision = 25f;
            scorePoints = 100;
            pull = 0;
            isSpawn = false;
            timer = 0;
            delaySpawn = 150;
            explosion = false;
            explosionTimer = 0;
        }
        public override void Update(in GameInputs gameInputs, GameData gameData)
        {
            timer++;
            if (timer > delaySpawn)
            {
                if (!isSpawn)
                    isSpawn = true;
                foreach (Entity entity in gameData.Entities)
                {
                    if (entity != this && entity.isSpawn)
                    {
                        float distance = Vector2.Distance(entity.position, this.position);
                        if (distance < 150)
                            pull = 1.10f;
                        else if (distance < 100)
                            pull = 1.25f;
                        else if (distance < 50)
                            pull = 1.50f;

                        Vector2 pullDir = (this.position - entity.position);
                            Vector2 pullNorm = Vector2.Normalize(pullDir);
                            entity.position += pullNorm * pull;

                    }
                }

            }
        }
    


        public override void Draw(Graphics graphics)
        {
            if (isSpawn && drawCircle)
            {
                graphics.DrawBlackHole(position, drawCircle);
                drawCircle = false;
            }
            else if (isSpawn && !drawCircle)
            {
                graphics.DrawBlackHole(position, drawCircle);
                drawCircle = true;
            }
            else
                graphics.DrawnSpawnBlackhole(position);

            if (explosion)
                graphics.DrawExplosion(position);
        }
    }
}
