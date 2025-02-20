using InGame;

namespace Utility
{
    public class PlayerController : Singleton<PlayerController>
    {
        private Player mainPlayer;

        public Player MainPlayer => mainPlayer;

        public void SetMainPlayer(Player player)
        {
            mainPlayer = player;
        }
    }
}