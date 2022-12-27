using System.Numerics;

namespace Geostorm
{
    public  abstract class Entity
    {
        public Vector2 position;
        public float rotation;
        public bool isDead = false;
        public float collision;
        public bool isSpawn;

        public abstract void Update(in GameInputs gameInputs, GameData gameData); // ADD GAME EVENT
        public abstract void Draw(Graphics graphics);

    }
}
