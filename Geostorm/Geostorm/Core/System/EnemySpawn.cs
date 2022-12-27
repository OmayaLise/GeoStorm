using System;
using System.Numerics;


namespace Geostorm
{
    public class EnemySpawn : ISystem
    {
        public int timer;
        public int spawnTime;
        public int timerHole;
        public int spawnTimeHole;
        public override void Update(in GameInputs gameInputs, GameData gameData)
        {
            timer++;
            timerHole++;

            switch(gameData.level)
            {
                case 1:
                    spawnTime = 20;
                    spawnTimeHole = 125;
                    break;
                case 2:
                    spawnTimeHole = 100;
                    break;
                case 3:
                    spawnTime = 10;
                    spawnTimeHole = 75;
                    break;
                case 4:
                    spawnTimeHole = 50;
                    break;
                case 5:
                    spawnTime = 5;
                    spawnTimeHole = 25;
                    break;
                default:
                    break;
            }

            if (timer > spawnTime)
            {    
                Random rand = new Random();
                Grunt grunt = new Grunt(new Vector2(rand.Next((int)gameInputs.screenSize.X), rand.Next((int)gameInputs.screenSize.Y)));
                gameData.AddEnemyDelayed(grunt);
                timer = 0;
            }

            if(timerHole > spawnTimeHole)
            {
                Random rand = new Random();
                Blackhole blackhole = new Blackhole(new Vector2(rand.Next((int)gameInputs.screenSize.X), rand.Next((int)gameInputs.screenSize.Y)));
                gameData.AddBlackHole(blackhole);
                timerHole = 0;
            }
        }
    }
}
