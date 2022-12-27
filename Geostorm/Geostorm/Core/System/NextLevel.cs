
namespace Geostorm
{
    public class NextLevel : ISystem
    {
        public override void Update(in GameInputs gameInputs, GameData gameData)
        {
            switch(gameData.player.score)
            {
                case 1000:
                    gameData.level = 2;
                    break;
                case 2500:
                    gameData.level = 3;
                    gameData.player.speed = 3;
                    break;
                case 5000:
                    gameData.level = 4;
                    break;
                case 7500:
                    gameData.level = 5;
                    gameData.player.speed = 4;
                    break;
                default:
                    break;

            }

        }
    }
}
