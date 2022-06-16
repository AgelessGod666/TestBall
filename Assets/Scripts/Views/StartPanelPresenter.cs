using System;
using Holders;

namespace Views
{
    public interface IGameStart
    {
        event Action OnGameStarted;
    }
    
    public class StartPanelPresenter : IGameStart
    {
        public event Action OnGameStarted;
        private readonly StartPanelHolder startPanelHolder;

        public StartPanelPresenter(StartPanelHolder startPanelHolder)
        {
            this.startPanelHolder = startPanelHolder;
            Initialize();
        }

        private void Initialize()
        {
            startPanelHolder.start.onClick.AddListener(RestartGame);
        }

        private void RestartGame()
        {
            OnGameStarted?.Invoke();
            Hide();
        }
        
        public void Show()
        {
            startPanelHolder.gameObject.SetActive(true);
        }

        private void Hide()
        {
            startPanelHolder.gameObject.SetActive(false);
        }
    }
}