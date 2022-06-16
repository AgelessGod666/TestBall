using Interfaces;
using Models;
using Views;

namespace Presenters
{
    public class GamePanelPresenter
    {
        private readonly GamePanelView gamePanelView;
        private readonly IHealthTracker healthTracker;
        private readonly StartPanelPresenter startPanelPresenter;
        private readonly IBallModel ballModel;
        private readonly IBallCollision ballCollision;
        private readonly GamePanelModel gamePanelModel;

        public GamePanelPresenter(GamePanelView gamePanelView, IHealthTracker healthTracker, StartPanelPresenter startPanelPresenter, IBallModel ballModel,
            IBallCollision ballCollision, GamePanelModel gamePanelModel)
        {
            this.gamePanelView = gamePanelView;
            this.healthTracker = healthTracker;
            this.startPanelPresenter = startPanelPresenter;
            this.ballModel = ballModel;
            this.ballCollision = ballCollision;
            this.gamePanelModel = gamePanelModel;
            Initialize();
        }
        
        private void Initialize()
        {
            healthTracker.OnHealthRemoved += SolveHealth;
            ballModel.OnReset += Reset;
            ballCollision.OnCoinTrigger += AddCoins;
        }

        private void SolveHealth(int health)
        {
            gamePanelView.ChangeHealth(health);
            if (health <= 0)
            {
                startPanelPresenter.Show();
            }
        }

        private void AddCoins()
        {
            gamePanelModel.Coins += 10;
            gamePanelView.ChangeCoins(gamePanelModel.Coins);
        }

        private void Reset()
        {
            gamePanelModel.Reset();
            gamePanelView.ChangeHealth(ballModel.Health);
            gamePanelView.ChangeCoins(gamePanelModel.Coins);
        }
    }
}