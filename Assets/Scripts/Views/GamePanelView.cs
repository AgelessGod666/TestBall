using Holders;
using TMPro;

namespace Views
{
    public class GamePanelView
    {
        private readonly TextMeshProUGUI coins;
        private readonly TextMeshProUGUI health;
        
        public GamePanelView(GamePanelHolder gamePanelHolder)
        {
            coins = gamePanelHolder.coins;
            health = gamePanelHolder.health;
        }

        public void ChangeHealth(int health)
        {
            this.health.text = health.ToString();
        }

        public void ChangeCoins(int coins)
        {
            this.coins.text = coins.ToString();
        }
    }
}