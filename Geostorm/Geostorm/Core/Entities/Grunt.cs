using System.Numerics;

namespace Geostorm
{
    public class Grunt : Enemy
    {
        
        public Grunt (Vector2 position)
        {
            this.position = position;
            collision = 20f;
            scorePoints = 50;
            speed = 3f;
            isSpawn = false;
            delaySpawn = 100;
            timer = 0;

        }

        public override void DoUpdate()
        {
           
        }
        public override void Draw(Graphics graphics)
        {
            if (isSpawn)
                graphics.DrawEnemy(position, rotation);
            else
                graphics.DrawSpawnEnemy(position, rotation);

        }    
    }
}
