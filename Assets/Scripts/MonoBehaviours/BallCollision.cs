using System;
using Interfaces;
using UnityEngine;

namespace MonoBehaviours
{
    public class BallCollision : MonoBehaviour, IBallCollision
    {
        public event Action OnDamageCollision;
        public event Action OnCoinTrigger;

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.CompareTag("Obstacle"))
            {
                OnDamageCollision?.Invoke();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag("Obstacle"))
            {
                OnDamageCollision?.Invoke();
            }
            else if (other.transform.CompareTag("Coin"))
            {
                OnCoinTrigger?.Invoke();
            }
        }
    }
}