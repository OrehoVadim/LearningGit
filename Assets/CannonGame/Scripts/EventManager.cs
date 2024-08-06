using UnityEngine;

namespace CannonGame.Scripts
{
    public class EventManager
    {
        public delegate void EnemyReachedDestructionPoint(int damage);
        public static event EnemyReachedDestructionPoint OnEnemyReachedDestructionPoint;

        public delegate void EnemyDestroyed(GameObject destroyedEnemy);
        public static event EnemyDestroyed OnEnemyDestroyed;
        
        public static void TriggerEnemyReachedDestructionPoint(int damage)
        {
            OnEnemyReachedDestructionPoint?.Invoke(damage);
        }

        public static void TriggerEnemyDestroyed(GameObject destroyedEnemy)
        {
            OnEnemyDestroyed?.Invoke(destroyedEnemy);
        }
    }
}
