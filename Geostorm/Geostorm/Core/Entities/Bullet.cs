using System.Numerics;

namespace Geostorm
{
    public class Bullet : Entity
    {
        public Vector2 direction;
        public Bullet(Vector2 position, float rotation, Vector2 direction)
        {
            this.position = position;
            this.rotation = rotation;
            collision = 10f;
            this.direction = direction;
        }
        public override void Update(in GameInputs gameInputs, GameData gameData)
        {
            position += direction;
            if (position.X > gameInputs.screenSize.X || position.Y > gameInputs.screenSize.Y || position.X<0 || position.Y <0)
                isDead = true;
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawBullet(position, rotation);
        }
    }
}
