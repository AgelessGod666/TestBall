using Holders;
using Models;
using Presenters;
using UnityEngine;
using Utils;
using Views;

namespace MonoBehaviours
{
    public class GameBoot : MonoBehaviour
    {
        [SerializeField] private GameObject coinPrefab;
        [SerializeField] private GameObject healthRemoverPrefab;
        [SerializeField] private Transform road;
        [SerializeField] private Transform objectsStartPosition;
        [SerializeField] private BallCollision ballCollision;
        [SerializeField] private Rigidbody ball;
        [SerializeField] private Input input;
        [SerializeField] private GamePanelHolder gamePanelHolder;
        [SerializeField] private StartPanelHolder startPanelHolderPrefab;

        private void Awake()
        {
            var startPanelHolder = Instantiate(startPanelHolderPrefab, gamePanelHolder.transform);
            var startPanelPresenter = new StartPanelPresenter(startPanelHolder);
            
            var objectRandomizer = new ObjectsRandomizer(coinPrefab, healthRemoverPrefab, road, objectsStartPosition);
            objectRandomizer.InstantiateObjects();

            var ballView = new BallView(ball);
            var ballModel = new BallModel();
            
            var gamePanelView = new GamePanelView(gamePanelHolder);
            var gamePanelModel = new GamePanelModel();
            var gamePanelPresenter = new GamePanelPresenter(gamePanelView, ballModel, startPanelPresenter, ballModel, ballCollision, gamePanelModel);
            
            var ballPresenter = new BallPresenter(ballView, ballModel, input, ballCollision, startPanelPresenter, gamePanelModel);
        }
    }
}