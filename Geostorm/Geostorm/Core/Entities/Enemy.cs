using System.Numerics;

namespace Geostorm
{
        public abstract class Enemy : Entity
        {
        public float speed;
        public int scorePoints;
        public int timer;
        public int delaySpawn;
        public sealed override void Update(in GameInputs gameInputs, GameData gameData)
        {
            timer++;
            if (timer > delaySpawn)
            {
                if(!isSpawn)
                    isSpawn = true;
                Vector2 dir = (gameData.player.position - this.position);
                Vector2 dirNorm = Vector2.Normalize(dir);
                position += dirNorm*speed;
            }
        }

        abstract public void DoUpdate();

        public override void Draw(Graphics graphics)
        {
            
        }
    }
}
