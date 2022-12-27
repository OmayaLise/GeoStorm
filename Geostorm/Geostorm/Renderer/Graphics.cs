using System.Numerics;
using System;
using Raylib_cs;

namespace Geostorm
{

    public class Graphics
    {        

        public void DrawPlayer(Vector2 position, float rotation, Color color)
        {
            float preScale = 20f;
            Vector2 innerCenter = new Vector2(-0.5f, 0f) * preScale;
            Vector2 outerCenter = new Vector2(-1f, 0f) * preScale;
            Vector2 topInnerWing = new Vector2(-0.2f, -0.55f) * preScale;
            Vector2 topOuterWing = new Vector2(-0.4f, -0.8f) * preScale;
            Vector2 topGun = new Vector2(0.6f, -0.3f) * preScale;
            Vector2 bottomInnerWing = new Vector2(topInnerWing.X, -topInnerWing.Y);
            Vector2 bottomOuterWing = new Vector2(topOuterWing.X, -topOuterWing.Y);
            Vector2 bottomGun = new Vector2(topGun.X, -topGun.Y);

            innerCenter = new Vector2( innerCenter.X * MathF.Cos(rotation) - innerCenter.Y * MathF.Sin(rotation), innerCenter.X * MathF.Sin(rotation) + innerCenter.Y * MathF.Cos(rotation)); 
            outerCenter = new Vector2(outerCenter.X * MathF.Cos(rotation) - outerCenter.Y * MathF.Sin(rotation), outerCenter.X * MathF.Sin(rotation) + outerCenter.Y * MathF.Cos(rotation));
            topInnerWing = new Vector2(topInnerWing.X * MathF.Cos(rotation) - topInnerWing.Y * MathF.Sin(rotation), topInnerWing.X * MathF.Sin(rotation) + topInnerWing.Y * MathF.Cos(rotation)); 
            topOuterWing = new Vector2(topOuterWing.X * MathF.Cos(rotation) - topOuterWing.Y * MathF.Sin(rotation), topOuterWing.X * MathF.Sin(rotation) + topOuterWing.Y * MathF.Cos(rotation)); 
            topGun = new Vector2(topGun.X * MathF.Cos(rotation) - topGun.Y * MathF.Sin(rotation), topGun.X * MathF.Sin(rotation) + topGun.Y * MathF.Cos(rotation));  
            bottomInnerWing = new Vector2(bottomInnerWing.X * MathF.Cos(rotation) - bottomInnerWing.Y * MathF.Sin(rotation), bottomInnerWing.X * MathF.Sin(rotation) + bottomInnerWing.Y * MathF.Cos(rotation));  
            bottomOuterWing = new Vector2(bottomOuterWing.X * MathF.Cos(rotation) - bottomOuterWing.Y * MathF.Sin(rotation), bottomOuterWing.X * MathF.Sin(rotation) + bottomOuterWing.Y * MathF.Cos(rotation));  
            bottomGun = new Vector2(bottomGun.X * MathF.Cos(rotation) - bottomGun.Y * MathF.Sin(rotation), bottomGun.X * MathF.Sin(rotation) + bottomGun.Y * MathF.Cos(rotation));

            Raylib.DrawLineV(innerCenter + position, topInnerWing + position, color);
            Raylib.DrawLineV(topInnerWing + position, topGun + position, color);
            Raylib.DrawLineV(topGun + position, topOuterWing + position,  color);
            Raylib.DrawLineV(topOuterWing + position, outerCenter + position, color);
            Raylib.DrawLineV(outerCenter + position,  bottomOuterWing + position, color);
            Raylib.DrawLineV(bottomOuterWing + position, bottomGun + position,  color);
            Raylib.DrawLineV(bottomGun + position,  bottomInnerWing + position,  color);
            Raylib.DrawLineV(bottomInnerWing + position, innerCenter + position,  color);

        }

        public void DrawUI(int playerLife, int score, int weaponLevel)
        {
            Raylib.DrawText("Life " + playerLife , 25, 25, 40,  Color.GREEN);
            Raylib.DrawText("Score " + score, 25, 75, 40, Color.WHITE);
            Raylib.DrawText("Weapon level " + weaponLevel, 25, 125, 40, Color.YELLOW);

        }

        public void DrawEnemy(Vector2 position, float rotation)
        {
            float preScale = 18.0f;
            Vector2 left = new Vector2(-1f, 0f) * preScale;
            Vector2 top = new Vector2(-0f, -1f) * preScale;
            Vector2 right = new Vector2(1f, 0f) * preScale;
            Vector2 bottom = new Vector2(-0f, 1f) * preScale;

            Raylib.DrawLine((int)left.X + (int)position.X, (int)left.Y + (int)position.Y, (int)top.X + (int)position.X, (int)top.Y + (int)position.Y, Color.BLUE);
            Raylib.DrawLine((int)top.X + (int)position.X, (int)top.Y + (int)position.Y, (int)right.X + (int)position.X, (int)right.Y + (int)position.Y, Color.ORANGE);
            Raylib.DrawLine((int)right.X + (int)position.X, (int)right.Y + (int)position.Y, (int)bottom.X + (int)position.X, (int)bottom.Y + (int)position.Y, Color.ORANGE);
            Raylib.DrawLine((int)bottom.X + (int)position.X, (int)bottom.Y + (int)position.Y, (int)left.X + (int)position.X, (int)left.Y + (int)position.Y, Color.BLUE);

        }

        public void DrawSpawnEnemy(Vector2 position, float rotation)
        {
            float preScale = 18.0f;
            Vector2 left = new Vector2(-1f, 0f) * preScale;
            Vector2 top = new Vector2(-0f, -1f) * preScale;
            Vector2 right = new Vector2(1f, 0f) * preScale;
            Vector2 bottom = new Vector2(-0f, 1f) * preScale;

            Raylib.DrawLine((int)left.X + (int)position.X, (int)left.Y + (int)position.Y, (int)top.X + (int)position.X, (int)top.Y + (int)position.Y, Color.LIGHTGRAY);
            Raylib.DrawLine((int)top.X + (int)position.X, (int)top.Y + (int)position.Y, (int)right.X + (int)position.X, (int)right.Y + (int)position.Y, Color.LIGHTGRAY);
            Raylib.DrawLine((int)right.X + (int)position.X, (int)right.Y + (int)position.Y, (int)bottom.X + (int)position.X, (int)bottom.Y + (int)position.Y, Color.LIGHTGRAY);
            Raylib.DrawLine((int)bottom.X + (int)position.X, (int)bottom.Y + (int)position.Y, (int)left.X + (int)position.X, (int)left.Y + (int)position.Y, Color.LIGHTGRAY);
        }

        public void DrawBullet(Vector2 position, float rotation)
        {
            float preScale = 15.0f;
            Vector2 left = new Vector2(-0.3f, 0f) * preScale;
            Vector2 top = new Vector2(-0.1f, 0.2f) * preScale;
            Vector2 right = new Vector2(0.8f, 0f) * preScale;
            Vector2 bottom = new Vector2(top.X, -top.Y);

            left = new Vector2(left.X * MathF.Cos(rotation) - left.Y * MathF.Sin(rotation), left.X * MathF.Sin(rotation) + left.Y * MathF.Cos(rotation));
            top = new Vector2(top.X * MathF.Cos(rotation) - top.Y * MathF.Sin(rotation), top.X * MathF.Sin(rotation) + top.Y * MathF.Cos(rotation));
            right = new Vector2(right.X * MathF.Cos(rotation) - right.Y * MathF.Sin(rotation), right.X * MathF.Sin(rotation) + right.Y * MathF.Cos(rotation));
            bottom = new Vector2(bottom.X * MathF.Cos(rotation) - bottom.Y * MathF.Sin(rotation), bottom.X * MathF.Sin(rotation) + bottom.Y * MathF.Cos(rotation));

            Raylib.DrawLine((int)left.X + (int)position.X, (int)left.Y + (int)position.Y, (int)top.X + (int)position.X, (int)top.Y + (int)position.Y, Color.YELLOW);
            Raylib.DrawLine((int)top.X + (int)position.X, (int)top.Y + (int)position.Y, (int)right.X + (int)position.X, (int)right.Y + (int)position.Y, Color.YELLOW);
            Raylib.DrawLine((int)right.X + (int)position.X, (int)right.Y + (int)position.Y, (int)bottom.X + (int)position.X, (int)bottom.Y + (int)position.Y, Color.YELLOW);
            Raylib.DrawLine((int)bottom.X + (int)position.X, (int)bottom.Y + (int)position.Y, (int)left.X + (int)position.X, (int)left.Y + (int)position.Y, Color.YELLOW);

        }
        public void DrawInterface(int worldLevel, Vector2 screenSize)
        {
            Raylib.DrawText("Level " + worldLevel, (int)screenSize.X - 300, (int)(screenSize.Y/2 + screenSize.Y / 3), 75, Color.SKYBLUE);
        }

        public void DrawGameOver(int score, Vector2 screenSize)
        {
            Raylib.DrawText("GameOver", (int)screenSize.X / 3 , (int)screenSize.Y / 4 , 100, Color.RED);
            Raylib.DrawText("Score " + score, (int)screenSize.X / 3  , (int)screenSize.Y / 2, 75, Color.WHITE);

        }

        public void DrawBlackHole(Vector2 position, bool drawCircle)
        {
            if (drawCircle)
            {
                Raylib.DrawCircleLines((int)position.X, (int)position.Y, 50f, Color.PURPLE);
                Raylib.DrawCircleLines((int)position.X, (int)position.Y, 30f, Color.PURPLE);
            }
            else
            {
                Raylib.DrawCircleLines((int)position.X, (int)position.Y, 40f, Color.DARKPURPLE);
                Raylib.DrawCircleLines((int)position.X, (int)position.Y, 20f, Color.DARKPURPLE);
            }
        }

        public void DrawnSpawnBlackhole(Vector2 position)
        {
            Raylib.DrawCircleLines((int)position.X, (int)position.Y, 50f, Color.LIGHTGRAY);
        }

        public void DrawExplosion(Vector2 position)
        {
            Raylib.DrawCircleV(position, 200f, Color.RED);
            Raylib.DrawCircleV(position, 100f, Color.RED);
        }

        public void DrawPause(Vector2 screenSize)
        {
            Raylib.DrawText("Pause", (int)screenSize.X / 2, (int)screenSize.Y / 4, 100, Color.RED);
        }
    }
}
