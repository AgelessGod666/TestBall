using System;

namespace Interfaces
{
    public interface IBallCollision
    {
        event Action OnDamageCollision;
        event Action OnCoinTrigger;
    }
}