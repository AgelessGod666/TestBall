using System;
using Cysharp.Threading.Tasks.Linq;
using Interfaces;
using Models;
using Views;

namespace Presenters
{
    public class BallPresenter
    {
        private readonly BallView ballView;
        private readonly BallModel ballModel;
        private readonly IInputInterface inputInterface;
        private readonly IBallCollision ballCollision;
        private readonly IGameStart gameStart;
        private readonly GamePanelModel gamePanelModel;
        private float speedAccelerationPerSecond = 0.1f;
        private float maxSpeed;

        public BallPresenter(BallView ballView, BallModel ballModel, IInputInterface inputInterface,
            IBallCollision ballCollision, IGameStart gameStart, GamePanelModel gamePanelModel)
        {
            this.ballView = ballView;
            this.ballModel = ballModel;
            this.inputInterface = inputInterface;
            this.ballCollision = ballCollision;
            this.gameStart = gameStart;
            this.gamePanelModel = gamePanelModel;
            Initialize();
        }

        private void Initialize()
        {
            gameStart.OnGameStarted += ResetGame;
            inputInterface.OnClicked += ballView.ChangeDirection;
            ballCollision.OnDamageCollision += RemoveHealth;
            ballCollision.OnCoinTrigger += ChangeSpeed;
        }

        private void ChangeSpeed()
        {
            maxSpeed = gamePanelModel.Coins >= 100 ? ballModel.Speed *= 4 :
                gamePanelModel.Coins >= 50 ? ballModel.Speed *= 3 :
                gamePanelModel.Coins >= 25 ? ballModel.Speed *= 2 : ballModel.Speed *= 1.5f;
            speedAccelerationPerSecond = (maxSpeed - ballModel.Speed) / 2000;
            IncreaseSpeed();
        }

        private async void IncreaseSpeed()
        {
            var timerAsyncEnumerable = UniTaskAsyncEnumerable
                .Timer(TimeSpan.FromMilliseconds(0), TimeSpan.FromMilliseconds(2000))
                .Select((_, i) => ballModel.Speed += speedAccelerationPerSecond);
            
            await foreach (var millisecond in timerAsyncEnumerable)
            {
                ballView.SetSpeed(ballModel.Speed);
            }
        }
        
        private void ResetGame()
        {
            ballModel.Reset();
            ballView.SetSpeed(ballModel.Speed);
            ballView.StartBall();
        }

        private void RemoveHealth()
        {
            ballModel.Health -= 1;
            if (ballModel.Health <= 0)
            {
                ballView.StopBall();
            }
        }
    }
}