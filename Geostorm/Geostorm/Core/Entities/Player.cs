using System.Numerics;
using System;
using Raylib_cs;
using System.Timers;

namespace Geostorm
{
    public class Player : Entity
    {
        // clean Draw

        public int life;
        public int score;
        public float speed;
        public Color color;
        public Weapon weapon;
        public bool isHurt;
        public Player ()
        {
            collision = 15f;
            life = 10;
            score = 0;
            speed = 2f;
            weapon = new Weapon();
            isSpawn = true;
            color = Color.GREEN;
        }
        public override void Update(in GameInputs gameInputs, GameData gameData)
        {

            gameData.player.position+= gameInputs.moveAxis *speed;

            if (gameInputs.moveAxis != new Vector2())
            {
                Vector2 rotateV = Vector2.Normalize(gameInputs.moveAxis);
                rotation = MathF.Atan2(rotateV.Y, rotateV.X);
            }

            gameInputs.moveAxis = new Vector2(0, 0);

            if (position.X <= 0)
                position.X = 0f;

            if (position.Y <= 0)
                position.Y = 0f;

            if (position.X >= gameInputs.screenSize.X)
                position.X = gameInputs.screenSize.X;

            if (position.Y >= gameInputs.screenSize.Y)
                position.Y = gameInputs.screenSize.Y;

            weapon.Update(gameInputs, gameData);

        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawPlayer(position, rotation, this.color);
            graphics.DrawUI(life, score, weapon.level);
        }

    }
}
