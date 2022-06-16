using UnityEngine;

namespace Utils
{
    public class ObjectsRandomizer
    {
        private readonly GameObject coinPrefab;
        private readonly GameObject healthRemoverPrefab;
        private readonly Transform road;
        private readonly Transform objectsStart;
        private Vector3 objectsStartPosition;

        public ObjectsRandomizer(GameObject coinPrefab, GameObject healthRemoverPrefab, Transform road, Transform objectsStart)
        {
            this.coinPrefab = coinPrefab;
            this.healthRemoverPrefab = healthRemoverPrefab;
            this.road = road;
            this.objectsStart = objectsStart;
            Initialize();
        }

        private void Initialize()
        {
            objectsStartPosition = objectsStart.position;
        }

        public void InstantiateObjects()
        {
            var distance = road.localScale.y;
            var objectsCount = distance / 5;
            for (int i = 0; i < objectsCount; i++)
            {
                var obstacle = Object.Instantiate(Random.Range(0, 2) == 0 ? coinPrefab : healthRemoverPrefab);
                var xRandom = Random.Range(0, 3);
                obstacle.transform.position = new Vector3(xRandom switch
                {
                    0 => -2,
                    1 => 0,
                    _ => 2
                }, objectsStartPosition.y + i * 5, -1);
            }
        }
    }
}