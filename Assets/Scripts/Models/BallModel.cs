using System;

namespace Models
{
    public interface IBallModel
    {
        event Action OnReset;
        int Health { get; }
    }
    
    public interface IHealthTracker
    {
        event Action<int> OnHealthRemoved;
    }
    
    public class BallModel : IHealthTracker, IBallModel
    {
        public event Action<int> OnHealthRemoved;
        public event Action OnReset;
        private int health = 3;
        public float Speed = 2;
        
        public int Health
        {
            get => health;
            set
            {
                health = value;
                OnHealthRemoved?.Invoke(health);
            }
        }

        public void Reset()
        {
            health = 3;
            Speed = 2;
            OnReset?.Invoke();
        }
    }
}